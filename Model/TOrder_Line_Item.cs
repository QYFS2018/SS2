using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Order_Line_Item")]
     public class TOrder_Line_Item : Entity 
     {
          public TOrder_Line_Item()
          {
              
          }
          
        
          
          #region Basic Property
          private int _orderLineItemId;
          private int _orderId;
          private int? _programCategoryProductId;
          private int? _programProductCrossSellId;
          private int _programProductId;
          private string _partNumber;
          private string _productName;
          private int _lineNum;
          private int? _parentLineNum;
          private int? _offerId;
          private int _quantity;
          private double _price;
          private double _markupAmount;
          private double _discountAmount;
          private double _actualPrice;
          private bool _isCommissionable;
          private int _shipToCustomerId;
          private int _shipToAddressId;
          private int _shipMethodId;
          private double _shipMethodCost;
          private double _shipHandlingCost;
          private DateTime _orderLineItemDate;
          private string _statusCode;
          private DateTime? _releaseDate;
          private DateTime? _holdUntilDate;
          private DateTime? _shippedDate;
          private string _trackingNumber;
          private int _qtyshipped;
          private int _qtyshipnotinv;
          private int? _releaseNumber;
          private string _iNV_TYPE;
          private string _route;
          private DateTime? _clientShipNotificationDate;
          private string _warehouse;
          private DateTime? _pODDate;
          private string _deliveryDate;
          private string _exceptionDate;

          [BindingField("OrderLineItemId",true)]
          public int OrderLineItemId
          {
               set
               {
                    _orderLineItemId=value;
               }
               get
               {
                     return _orderLineItemId;
               }
           }
          [BindingField("OrderId",true)]
          public int OrderId
          {
               set
               {
                    _orderId=value;
               }
               get
               {
                     return _orderId;
               }
           }
          [BindingField("ProgramCategoryProductId",true)]
          public int? ProgramCategoryProductId
          {
               set
               {
                    _programCategoryProductId=value;
               }
               get
               {
                     return _programCategoryProductId;
               }
           }
          [BindingField("ProgramProductCrossSellId",true)]
          public int? ProgramProductCrossSellId
          {
               set
               {
                    _programProductCrossSellId=value;
               }
               get
               {
                     return _programProductCrossSellId;
               }
           }
          [BindingField("ProgramProductId",true)]
          public int ProgramProductId
          {
               set
               {
                    _programProductId=value;
               }
               get
               {
                     return _programProductId;
               }
           }
          [BindingField("PartNumber",true)]
          public string PartNumber
          {
               set
               {
                    _partNumber=value;
               }
               get
               {
                     return _partNumber;
               }
           }
          [BindingField("ProductName",true)]
          public string ProductName
          {
               set
               {
                    _productName=value;
               }
               get
               {
                     return _productName;
               }
           }
          [BindingField("LineNum",true)]
          public int LineNum
          {
               set
               {
                    _lineNum=value;
               }
               get
               {
                     return _lineNum;
               }
           }
          [BindingField("ParentLineNum",true)]
          public int? ParentLineNum
          {
               set
               {
                    _parentLineNum=value;
               }
               get
               {
                     return _parentLineNum;
               }
           }
          [BindingField("OfferId",true)]
          public int? OfferId
          {
               set
               {
                    _offerId=value;
               }
               get
               {
                     return _offerId;
               }
           }
          [BindingField("Quantity",true)]
          public int Quantity
          {
               set
               {
                    _quantity=value;
               }
               get
               {
                     return _quantity;
               }
           }
          [BindingField("Price",true)]
          public double Price
          {
               set
               {
                    _price=value;
               }
               get
               {
                     return _price;
               }
           }
          [BindingField("MarkupAmount",true)]
          public double MarkupAmount
          {
               set
               {
                    _markupAmount=value;
               }
               get
               {
                     return _markupAmount;
               }
           }
          [BindingField("DiscountAmount",true)]
          public double DiscountAmount
          {
               set
               {
                    _discountAmount=value;
               }
               get
               {
                     return _discountAmount;
               }
           }
          [BindingField("ActualPrice",true)]
          public double ActualPrice
          {
               set
               {
                    _actualPrice=value;
               }
               get
               {
                     return _actualPrice;
               }
           }
          [BindingField("IsCommissionable",true)]
          public bool IsCommissionable
          {
               set
               {
                    _isCommissionable=value;
               }
               get
               {
                     return _isCommissionable;
               }
           }
          [BindingField("ShipToCustomerId",true)]
          public int ShipToCustomerId
          {
               set
               {
                    _shipToCustomerId=value;
               }
               get
               {
                     return _shipToCustomerId;
               }
           }
          [BindingField("ShipToAddressId",true)]
          public int ShipToAddressId
          {
               set
               {
                    _shipToAddressId=value;
               }
               get
               {
                     return _shipToAddressId;
               }
           }
          [BindingField("ShipMethodId",true)]
          public int ShipMethodId
          {
               set
               {
                    _shipMethodId=value;
               }
               get
               {
                     return _shipMethodId;
               }
           }
          [BindingField("ShipMethodCost",true)]
          public double ShipMethodCost
          {
               set
               {
                    _shipMethodCost=value;
               }
               get
               {
                     return _shipMethodCost;
               }
           }
          [BindingField("ShipHandlingCost",true)]
          public double ShipHandlingCost
          {
               set
               {
                    _shipHandlingCost=value;
               }
               get
               {
                     return _shipHandlingCost;
               }
           }
          [BindingField("OrderLineItemDate",true)]
          public DateTime OrderLineItemDate
          {
               set
               {
                    _orderLineItemDate=value;
               }
               get
               {
                     return _orderLineItemDate;
               }
           }
          [BindingField("StatusCode",true)]
          public string StatusCode
          {
               set
               {
                    _statusCode=value;
               }
               get
               {
                     return _statusCode;
               }
           }
          [BindingField("ReleaseDate",true)]
          public DateTime? ReleaseDate
          {
               set
               {
                    _releaseDate=value;
               }
               get
               {
                     return _releaseDate;
               }
           }
          [BindingField("HoldUntilDate",true)]
          public DateTime? HoldUntilDate
          {
               set
               {
                    _holdUntilDate=value;
               }
               get
               {
                     return _holdUntilDate;
               }
           }
          [BindingField("ShippedDate",true)]
          public DateTime? ShippedDate
          {
               set
               {
                    _shippedDate=value;
               }
               get
               {
                     return _shippedDate;
               }
           }
          [BindingField("TrackingNumber",true)]
          public string TrackingNumber
          {
               set
               {
                    _trackingNumber=value;
               }
               get
               {
                     return _trackingNumber;
               }
           }
          [BindingField("qtyshipped",true)]
          public int qtyshipped
          {
               set
               {
                    _qtyshipped=value;
               }
               get
               {
                     return _qtyshipped;
               }
           }
          [BindingField("qtyshipnotinv",true)]
          public int qtyshipnotinv
          {
               set
               {
                    _qtyshipnotinv=value;
               }
               get
               {
                     return _qtyshipnotinv;
               }
           }
          [BindingField("ReleaseNumber",true)]
          public int? ReleaseNumber
          {
               set
               {
                    _releaseNumber=value;
               }
               get
               {
                     return _releaseNumber;
               }
           }
          [BindingField("INV_TYPE",true)]
          public string INV_TYPE
          {
               set
               {
                    _iNV_TYPE=value;
               }
               get
               {
                     return _iNV_TYPE;
               }
           }
          [BindingField("Route",true)]
          public string Route
          {
               set
               {
                    _route=value;
               }
               get
               {
                     return _route;
               }
           }
          [BindingField("ClientShipNotificationDate",true)]
          public DateTime? ClientShipNotificationDate
          {
               set
               {
                    _clientShipNotificationDate=value;
               }
               get
               {
                     return _clientShipNotificationDate;
               }
           }
          [BindingField("Warehouse",true)]
          public string Warehouse
          {
               set
               {
                    _warehouse=value;
               }
               get
               {
                     return _warehouse;
               }
           }
          [BindingField("PODDate",true)]
          public DateTime? PODDate
          {
               set
               {
                    _pODDate=value;
               }
               get
               {
                     return _pODDate;
               }
           }
          [BindingField("DeliveryDate",true)]
          public string DeliveryDate
          {
               set
               {
                    _deliveryDate=value;
               }
               get
               {
                     return _deliveryDate;
               }
           }
          [BindingField("ExceptionDate",true)]
          public string ExceptionDate
          {
               set
               {
                    _exceptionDate=value;
               }
               get
               {
                     return _exceptionDate;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 
          
          
      
     }
}