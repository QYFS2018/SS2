using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("OrderID_Generator")]
    public partial class TOrderID_Generator : Entity 
     {
          public TOrderID_Generator()
          {
              this.DataConnectProviders = "ZoytoCommon";
          }

       
          
          #region Basic Property
          private int _orderID;

          [BindingField("OrderID",true)]
          public int OrderID
          {
               set
               {
                    _orderID=value;
               }
               get
               {
                     return _orderID;
               }
           }


          #endregion 

          #region Extend Property

          #endregion 
          
          
        public ReturnValue getOrderID_GeneratorByProgramId(int id)
        {
            string Usp_SQL = String.Format(SqlDefine.getSQL("getNextOrderId"), id);
            ReturnValue _result = this.getEntity(Usp_SQL);
            return _result;
        }
     }
}