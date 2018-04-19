using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WComm;
using SS2.Model;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace SS2
{
    public class PULLOrders
    {
        int failedRecord = 0;
        string errorNotes = "";

        private List<TShipMethod> ShipMethods = new List<TShipMethod>();
        private List<TProgram_Product> Products = new List<TProgram_Product>();
        private List<TState> States = new List<TState>();
        private List<TCountry> Countrys = new List<TCountry>();
        private List<TType> Types = new List<TType>();

        public ReturnValue Run()
        {
            ReturnValue _result = new ReturnValue();

            #region get ship method list

            TShipMethod _tShipMethod = new TShipMethod();
            _result = _tShipMethod.getShipMethodList();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "getShipMethodList failed. \r\n " + _result.ErrMessage;

                Common.Log("getShipMethodList---ER \r\n" + _result.ErrMessage);

                return _result;
            }
            ShipMethods = _result.ObjectList.ConvertAll(t => t as TShipMethod);

            #endregion

            #region get product list

            TProgram_Product _tProgram_Product = new TProgram_Product();
            _result = _tProgram_Product.getProgramProductList();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "getProgramProductList failed. \r\n " + _result.ErrMessage;

                Common.Log("getProgramProductList---ER \r\n" + _result.ErrMessage);

                return _result;
            }
            Products = _result.ObjectList.ConvertAll(t => t as TProgram_Product);


            #endregion

            #region get country list

            TCountry _tCountry = new TCountry();
            _result = _tCountry.getCountryList();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "getCountryList failed. \r\n " + _result.ErrMessage;

                Common.Log("getCountryList---ER \r\n" + _result.ErrMessage);

                return _result;
            }
            Countrys = _result.ObjectList.ConvertAll(t => t as TCountry);


            #endregion

            #region get state list

            TState _tState = new TState();
            _result = _tState.getStateList();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "getStateList failed. \r\n " + _result.ErrMessage;

                Common.Log("getStateList---ER \r\n" + _result.ErrMessage);

                return _result;
            }
            States = _result.ObjectList.ConvertAll(t => t as TState);


            #endregion

            #region get type list

            TType _tType = new TType();
            _result = _tType.geTTypeList();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "geTTypeList failed. \r\n " + _result.ErrMessage;

                Common.Log("geTTypeList---ER \r\n" + _result.ErrMessage);

                return _result;
            }
            Types = _result.ObjectList.ConvertAll(t => t as TType);


            #endregion

            #region PULLOrders

            _result = SS2.ShipStationAPI.PULLOrders();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "PULLOrders failed. \r\n " + _result.ErrMessage;

                Common.Log("PULLOrders---ER \r\n" + _result.ErrMessage);

                return _result;
            }

            List<ShipStationResponseOrder> orderList = _result.ObjectValue as List<ShipStationResponseOrder>;

            #endregion

            foreach (ShipStationResponseOrder order in orderList)
            {

                #region check program ID

                if (string.IsNullOrWhiteSpace(order.advancedOptions.customField1) == true)
                {
                    continue;
                }

                var programId = order.advancedOptions.customField1;

                Common.Log("ProgramID:" + programId + "  Order : " + order.orderId + "---Start");

                List<string> Programs = ConfigurationSettings.AppSettings["ProgramList"].Split(',').ToList();

                if (Programs.Exists(p => p.Equals(programId)) == false)
                {
                    _result.ErrMessage = "Program ID:" + programId + "  is valid";

                    errorNotes = errorNotes + order.orderId + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("ProgramID:" + programId + "  Order : " + order.orderId + "---ER \r\n" + _result.ErrMessage);

                    continue;
                }

                #endregion

                #region check order existed

                TShipStationOrders shipStationOrders = new TShipStationOrders();
                _result = shipStationOrders.getOrderBySOrderId(order.orderId);
                if (_result.Success == false)
                {
                    errorNotes = errorNotes + order.orderId + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("ProgramID:" + programId + "  Order : " + order.orderId + "---ER \r\n" + _result.ErrMessage);

                    continue;
                }
                shipStationOrders = _result.Object as TShipStationOrders;

                if (shipStationOrders.ID != 0)
                {
                    continue;
                }

                #endregion

                #region create ZStore Order

                _result = createZOrder(order);
                if (_result.Success == false)
                {
                    errorNotes = errorNotes + order.orderId + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("ProgramID:" + programId + "  Order : " + order.orderId + "---ER \r\n" + _result.ErrMessage);

                    continue;
                }

                TOrder _tOrder = _result.Object as TOrder;

                #endregion

                #region save Order

                _result = saveZOrder(_tOrder, order);
                if (_result.Success == false)
                {
                    errorNotes = errorNotes + order.orderId + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("ProgramID:" + programId + "  Order : " + order.orderId + "---ER \r\n" + _result.ErrMessage);

                    continue;
                }

                #endregion

                Common.Log("ProgramID:" + programId + "  Order : " + order.orderId + "---OK");
            }


            Common.SentAlterEmail(failedRecord, errorNotes);

            _result.Success = true;

            return _result;
        }

        private ReturnValue createZOrder(ShipStationResponseOrder order)
        {
            ReturnValue _result = new ReturnValue();

            int _sourceId = int.Parse(ConfigurationSettings.AppSettings["SourceId"]);
            int programID = int.Parse(order.advancedOptions.customField1);


            TOrder _tOrder = new TOrder();

            #region get OrderTypeId

            if (string.IsNullOrWhiteSpace(order.advancedOptions.customField3) == true)
            {
                _result.ErrMessage = string.Format("OrderType({0}) is empty. ", order.advancedOptions.customField3);
                _result.Success = false;
                return _result;
            }

            var itemType = Types.Find(s => s.Code.Equals(order.advancedOptions.customField3, StringComparison.OrdinalIgnoreCase));
            if (itemType == null)
            {
                if (Common.AutoCreateProduct == true)
                {
                    TType _tType = new TType();
                    _tType.Code = order.advancedOptions.customField3;
                    _tType.ContentStatusId = 1;
                    _tType.Description = order.advancedOptions.customField3;
                    _tType.GroupBy = "ORDER";
                    _tType.CreatedOn = System.DateTime.Now;
                    _result = _tType.Save();

                    _tType.TypeId = _result.IdentityId;
                    itemType = _tType;

                    Types.Add(_tType);
                }
                else
                {
                    _result.ErrMessage = string.Format("OrderType({0}) can not be found. ", order.advancedOptions.customField3);
                    _result.Success = false;
                    return _result;
                }
            }

            _tOrder.OrderTypeId = itemType.TypeId;

            #endregion

            #region get ShipMethod

            if (string.IsNullOrWhiteSpace(order.advancedOptions.customField2) == true)
            {
                _result.ErrMessage = string.Format("ShipMethod({0}) is empty. ", order.advancedOptions.customField2);
                _result.Success = false;
                return _result;
            }

            var method = ShipMethods.Find(s => s.Code.Equals(order.advancedOptions.customField2, StringComparison.OrdinalIgnoreCase));
            if (method == null)
            {
                _result.ErrMessage = string.Format("ShipMethod({0}) can not be found. ", order.advancedOptions.customField2);
                _result.Success = false;
                return _result;
            }

            int shipMethodId = method.ShipMethodId;

            #endregion

            #region Address

            if (order.shipTo.phone != null)
            {
                order.shipTo.phone = order.shipTo.phone.Replace("+", "");
                if (order.shipTo.phone.Length > 13)
                {
                    order.shipTo.phone = "0000000000";
                }
            }
            if (string.IsNullOrWhiteSpace(order.shipTo.state) && order.shipTo.country != "US" && order.shipTo.country != "CA")
            {
                order.shipTo.state = "XX";
            }

            var address = new TAddress();

            var country = Countrys.Find(c => c.ISO2.Equals(order.shipTo.country, StringComparison.OrdinalIgnoreCase));
            if (country == null)
            {
                _result.ErrMessage = string.Format("Country({0}) can not be found. ", order.shipTo.country);
                _result.Success = false;
                return _result;
            }
            address.CountryId = country.CountryId;

            var state = States.Find(c => c.Code.Equals(order.shipTo.state, StringComparison.OrdinalIgnoreCase));
            if (state == null && order.shipTo.country != "US" && order.shipTo.country != "CA")
            {
                order.shipTo.state = "XX";
                state = States.Find(c => c.Code.Equals(order.shipTo.state, StringComparison.OrdinalIgnoreCase));
            }

            if (state == null)
            {
                _result.ErrMessage = string.Format("State({0}) can not be found. ", order.shipTo.state);
                _result.Success = false;
                return _result;
            }
            address.StateId = state.StateId;



            address.Address1 = order.shipTo.street1;
            address.Address2 = order.shipTo.street2;
            address.Address3 = order.shipTo.street3;
            if (address.Address1 == null) address.Address1 = "";
            if (address.Address2 == null) address.Address2 = "";
            if (address.Address3 == null) address.Address3 = "";

            if (address.Address1.Length > 35 || address.Address2.Length > 35 || address.Address3.Length > 35)
            {
                var temp = address.Address1 + " " + address.Address2 + " " + address.Address3;
                address.Address1 = temp.Substring(0, 35);
                temp = temp.Substring(35);
                if (temp.Length > 35)
                {
                    address.Address2 = temp.Substring(0, 35);
                    temp = temp.Substring(35);
                }
                else
                {
                    address.Address2 = temp;
                    temp = "";
                }
                if (temp.Length > 35)
                {
                    address.Address3 = temp.Substring(0, 35);
                }
                else
                {
                    address.Address3 = temp;
                }
            }

            address.City = order.shipTo.city;
            address.PostalCode = order.shipTo.postalCode;
            address.UpdatedOn = DateTime.Now;
            address.ProgramId = programID;

            _tOrder.Address = address;


            #endregion

            #region Customer

            var customer = new TCustomer();
            customer.SourceId = _sourceId;
            customer.ProgramId = programID;
            customer.FirstName = order.shipTo.fname;
            customer.LastName = order.shipTo.lname;
            customer.Email = order.customerEmail;
            customer.Company = order.shipTo.company;
            customer.CreatedOn = System.DateTime.Now;

            if (programID == 463)
            {
                customer.AltCustNum = "ONL" + order.orderNumber.ToString();
            }

            _tOrder.Customer = customer;

            #endregion

            #region Item Line

            #region   skip the SKU when importing if the SKU=’’ and fulfillmentsku=null and name like ‘coupon%’

            var query = order.items.Where(u =>
            (!string.IsNullOrEmpty(u.sku) || !string.IsNullOrEmpty(u.fulfillmentSku) || !u.name.ToLower().StartsWith("coupon"))
            );

            order.items = query.ToList<ShipStationResponseItem>();

            foreach (ShipStationResponseItem sitem in order.items)
            {
                if (sitem.sku == "" && string.IsNullOrEmpty(sitem.fulfillmentSku) && sitem.name.ToLower().IndexOf("coupon") == 0)
                {
                    order.items.Remove(sitem);
                }
            }

            #endregion


            var lineNum = 1;

            foreach (var lineItem in order.items)
            {
                var sku = string.IsNullOrEmpty(lineItem.fulfillmentSku) ? lineItem.sku : lineItem.fulfillmentSku;
                if (string.IsNullOrWhiteSpace(sku) == true)
                {
                    _result.ErrMessage = string.Format("SKU({0}) is empty.", sku);
                    _result.Success = false;
                    return _result;
                }



                var productItem = Products.Find(s => s.PartNumber != null && s.PartNumber.Equals(sku, StringComparison.OrdinalIgnoreCase) && s.ProgramId == programID);
                if (productItem == null)
                {
                    if (Common.AutoCreateProduct == true)
                    {
                        TProduct _tProduct = new TProduct();
                        _tProduct.PartNumber = sku;
                        _tProduct.Name = lineItem.name;
                        _tProduct.ProgramID = programID;

                        _result = _tProduct.Save();
                        _tProduct.ProductId = _result.IdentityId;

                        TProgram_Product _tProgram_Product = new TProgram_Product();
                        _tProgram_Product.PartNumber = sku;
                        _tProgram_Product.Name = sku;
                        _tProgram_Product.ProgramId = programID;
                        _tProgram_Product.ContentStatusId = 1;
                        _tProgram_Product.ProductId = _tProduct.ProductId;

                        _result = _tProgram_Product.Save();

                        _tProgram_Product.ProgramProductId = _result.IdentityId;
                        productItem = _tProgram_Product;

                        Products.Add(_tProgram_Product);
                    }
                    else
                    {
                        _result.ErrMessage = string.Format("SKU({0}) can not be found. ", sku);
                        _result.Success = false;
                        return _result;
                    }
                }

                TOrder_Line_Item _tOrder_Line_Item = new TOrder_Line_Item();
                _tOrder_Line_Item.ProgramProductId = productItem.ProgramProductId;
                _tOrder_Line_Item.PartNumber = productItem.PartNumber;
                _tOrder_Line_Item.ProductName = lineItem.name;
                _tOrder_Line_Item.Quantity = lineItem.quantity;
                _tOrder_Line_Item.Price = Convert.ToDouble(lineItem.unitPrice);
                _tOrder_Line_Item.ActualPrice = _tOrder_Line_Item.Quantity * _tOrder_Line_Item.Price;
                _tOrder_Line_Item.OrderLineItemDate = lineItem.createDate;

                _tOrder_Line_Item.ShipToCustomerId = _tOrder.CustomerId;
                _tOrder_Line_Item.ShipToAddressId = _tOrder.CustomerAddressId;
                _tOrder_Line_Item.ShipMethodId = shipMethodId;
                _tOrder_Line_Item.LineNum = lineNum;
                lineNum++;

                _tOrder.OrderLines.Add(_tOrder_Line_Item);
            }



            #endregion

            #region Order level

            _tOrder.AltOrderNum = order.orderNumber.ToString();
            _tOrder.OrderDate = order.orderDate;
            _tOrder.TotalOrderAmount = Convert.ToDouble(order.orderTotal);
            _tOrder.TotalTax = Convert.ToDouble(order.taxAmount);
            _tOrder.TotalShipping = Convert.ToDouble(order.shippingAmount);
            _tOrder.TotalProductAmount = Convert.ToDouble(order.orderTotal - order.taxAmount - order.shippingAmount);
            _tOrder.ProgramId = programID;
            _tOrder.SourceId = _sourceId;
            _tOrder.StatusCode = "AS";

            #endregion

            _result.Object = _tOrder;

            return _result;
        }

        private ReturnValue saveZOrder(TOrder zOrder, ShipStationResponseOrder sOrder)
        {
            ReturnValue _result = new ReturnValue();

            Transaction _tran = new Transaction();

            #region get Order ID

            int programID = int.Parse(sOrder.advancedOptions.customField1);

            var oID = new TOrderID_Generator();
            _result = oID.getOrderID_GeneratorByProgramId(programID);
            if (_result.Success == false)
            {
                _tran.RollbackTransaction();
                return _result;
            }
            oID = _result.Object as TOrderID_Generator;

            if (oID.OrderID == 0)
            {
                _result.ErrMessage = string.Format("Can't generate Order ID for Program ({0}).", programID.ToString());
                _result.Success = false;

                _tran.RollbackTransaction();
                return _result;
            }
            zOrder.OrderId = oID.OrderID;

            #endregion

            #region save Zorder

            if (string.IsNullOrWhiteSpace(sOrder.shipTo.phone) == true)
            {
                sOrder.shipTo.phone = "xxx";
            }
            _result = (new TPhone { Number = sOrder.shipTo.phone }).Save(_tran);
            if (_result.Success == false)
            {
                _tran.RollbackTransaction();
                return _result;
            }
            zOrder.Address.PhoneId = _result.IdentityId;

            _result = zOrder.Address.Save(_tran);
            if (_result.Success == false)
            {
                _tran.RollbackTransaction();
                return _result;
            }
            zOrder.CustomerAddressId = _result.IdentityId;

            zOrder.Customer.UserGUID = System.Guid.NewGuid().ToString();
            _result = zOrder.Customer.Save(_tran);
            if (_result.Success == false)
            {
                _tran.RollbackTransaction();
                return _result;
            }
            zOrder.CustomerId = _result.IdentityId;

            _result = zOrder.Save(_tran);
            if (_result.Success == false)
            {
                _tran.RollbackTransaction();
                return _result;

            }

            foreach (TOrder_Line_Item item in zOrder.OrderLines)
            {
                item.ShipToAddressId = zOrder.CustomerAddressId;
                item.ShipToCustomerId = zOrder.CustomerId;
                item.OrderId = zOrder.OrderId;

                _result = item.Save(_tran);
                if (_result.Success == false)
                {
                    _tran.RollbackTransaction();
                    return _result;
                }
            }



            #endregion

            #region save ShipStationOrders

            StringWriter sw = new StringWriter();
            JsonSerializer serializer = new JsonSerializer();

            TShipStationOrders shipStationOrders = new TShipStationOrders();

            shipStationOrders = new TShipStationOrders();
            shipStationOrders.storeId = sOrder.advancedOptions.storeId;
            shipStationOrders.SOrderId = sOrder.orderId.ToString();
            shipStationOrders.ZOrderId = zOrder.OrderId;
            serializer.Serialize(new JsonTextWriter(sw), sOrder);
            shipStationOrders.FullContent = sw.ToString();
            shipStationOrders.OrderCreatedDate = DateTime.Now;
            shipStationOrders.PullDate = DateTime.Now;
            shipStationOrders.PrevProcessDate = DateTime.Now;

            _result = shipStationOrders.Save(_tran);
            if (_result.Success == false)
            {
                _tran.RollbackTransaction();
                return _result;
            }

            #endregion


            _tran.CommitTransaction();

            return _result;


        }
    }
}

