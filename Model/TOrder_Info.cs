using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Order_Info")]
     public class TOrder_Info : Entity 
     {
          public TOrder_Info()
          {
              
          }
          
        
          
          #region Basic Property
          private int _orderInfoId;
          private int _orderId;
          private int _formFieldId;
          private int _fieldId;
          private int _orderLineItemId;
          private string _keyName;
          private string _keyValue;

          [BindingField("OrderInfoId",true)]
          public int OrderInfoId
          {
               set
               {
                    _orderInfoId=value;
               }
               get
               {
                     return _orderInfoId;
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
          [BindingField("FormFieldId",true)]
          public int FormFieldId
          {
               set
               {
                    _formFieldId=value;
               }
               get
               {
                     return _formFieldId;
               }
           }
          [BindingField("FieldId",true)]
          public int FieldId
          {
               set
               {
                    _fieldId=value;
               }
               get
               {
                     return _fieldId;
               }
           }
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
          [BindingField("KeyName",true)]
          public string KeyName
          {
               set
               {
                    _keyName=value;
               }
               get
               {
                     return _keyName;
               }
           }
          [BindingField("KeyValue",true)]
          public string KeyValue
          {
               set
               {
                    _keyValue=value;
               }
               get
               {
                     return _keyValue;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 
          
          
    
     }
}