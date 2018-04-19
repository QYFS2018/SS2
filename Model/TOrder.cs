using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Order")]
     public class TOrder : Entity 
     {
          public TOrder()
          {
              OrderLines = new EntityList();
              Address = new TAddress();
              Customer = new TCustomer();
          }
          
        
          
          #region Basic Property
          private int _orderId;
          private string _altOrderNum;
          private int _programId;
          private int _sourceId;
          private int _orderTypeId;
          private int _customerId;
          private int _customerAddressId;
          private int? _cSRUserId;
          private DateTime _orderDate;
          private double _totalProductAmount;
          private double _totalMarkupAmount;
          private double _totalDiscountAmount;
          private double _totalTax;
          private double _totalShipping;
          private double _totalHandling;
          private double _totalOrderAmount;
          private DateTime _expirationDate;
          private DateTime _expectedShipDate;
          private string _statusCode;
          private bool _forceReDownload;
          private string _route;

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
          [BindingField("AltOrderNum",true)]
          public string AltOrderNum
          {
               set
               {
                    _altOrderNum=value;
               }
               get
               {
                     return _altOrderNum;
               }
           }
          [BindingField("ProgramId",true)]
          public int ProgramId
          {
               set
               {
                    _programId=value;
               }
               get
               {
                     return _programId;
               }
           }
          [BindingField("SourceId",true)]
          public int SourceId
          {
               set
               {
                    _sourceId=value;
               }
               get
               {
                     return _sourceId;
               }
           }
          [BindingField("OrderTypeId",true)]
          public int OrderTypeId
          {
               set
               {
                    _orderTypeId=value;
               }
               get
               {
                     return _orderTypeId;
               }
           }
          [BindingField("CustomerId",true)]
          public int CustomerId
          {
               set
               {
                    _customerId=value;
               }
               get
               {
                     return _customerId;
               }
           }
          [BindingField("CustomerAddressId",true)]
          public int CustomerAddressId
          {
               set
               {
                    _customerAddressId=value;
               }
               get
               {
                     return _customerAddressId;
               }
           }
          [BindingField("CSRUserId",true)]
          public int? CSRUserId
          {
               set
               {
                    _cSRUserId=value;
               }
               get
               {
                     return _cSRUserId;
               }
           }
          [BindingField("OrderDate",true)]
          public DateTime OrderDate
          {
               set
               {
                    _orderDate=value;
               }
               get
               {
                     return _orderDate;
               }
           }
          [BindingField("TotalProductAmount",true)]
          public double TotalProductAmount
          {
               set
               {
                    _totalProductAmount=value;
               }
               get
               {
                     return _totalProductAmount;
               }
           }
          [BindingField("TotalMarkupAmount",true)]
          public double TotalMarkupAmount
          {
               set
               {
                    _totalMarkupAmount=value;
               }
               get
               {
                     return _totalMarkupAmount;
               }
           }
          [BindingField("TotalDiscountAmount",true)]
          public double TotalDiscountAmount
          {
               set
               {
                    _totalDiscountAmount=value;
               }
               get
               {
                     return _totalDiscountAmount;
               }
           }
          [BindingField("TotalTax",true)]
          public double TotalTax
          {
               set
               {
                    _totalTax=value;
               }
               get
               {
                     return _totalTax;
               }
           }
          [BindingField("TotalShipping",true)]
          public double TotalShipping
          {
               set
               {
                    _totalShipping=value;
               }
               get
               {
                     return _totalShipping;
               }
           }
          [BindingField("TotalHandling",true)]
          public double TotalHandling
          {
               set
               {
                    _totalHandling=value;
               }
               get
               {
                     return _totalHandling;
               }
           }
          [BindingField("TotalOrderAmount",true)]
          public double TotalOrderAmount
          {
               set
               {
                    _totalOrderAmount=value;
               }
               get
               {
                     return _totalOrderAmount;
               }
           }
          [BindingField("ExpirationDate",true)]
          public DateTime ExpirationDate
          {
               set
               {
                    _expirationDate=value;
               }
               get
               {
                     return _expirationDate;
               }
           }
          [BindingField("ExpectedShipDate",true)]
          public DateTime ExpectedShipDate
          {
               set
               {
                    _expectedShipDate=value;
               }
               get
               {
                     return _expectedShipDate;
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
          [BindingField("ForceReDownload",true)]
          public bool ForceReDownload
          {
               set
               {
                    _forceReDownload=value;
               }
               get
               {
                     return _forceReDownload;
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

          #endregion 

          #region Extend Property

          private DateTime? _shippedDate;
          private string _trackingNumber;
          private string _carrierCode;
          private string _sOrderId;

          [BindingField("ShippedDate", true)]
          public DateTime? ShippedDate
          {
              set
              {
                  _shippedDate = value;
              }
              get
              {
                  return _shippedDate;
              }
          }
          [BindingField("TrackingNumber", true)]
          public string TrackingNumber
          {
              set
              {
                  _trackingNumber = value;
              }
              get
              {
                  return _trackingNumber;
              }
          }
          [BindingField("CarrierCode", true)]
          public string CarrierCode
          {
              set
              {
                  _carrierCode = value;
              }
              get
              {
                  return _carrierCode;
              }
          }
          [BindingField("SOrderId", true)]
          public string SOrderId
          {
              set
              {
                  _sOrderId = value;
              }
              get
              {
                  return _sOrderId;
              }
          }


          public EntityList OrderLines;
          public TAddress Address;
          public TCustomer Customer;

          #endregion 
          
   
         
          public ReturnValue getOrderShipStation(int OrderID)
          {
              string Usp_SQL = String.Format(SqlDefine.getSQL("getOrderShipStation"), OrderID);
              ReturnValue _result = this.getEntity(Usp_SQL);
              return _result;
          }

     }
}