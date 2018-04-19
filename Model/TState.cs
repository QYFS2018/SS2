using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("State")]
     public class TState : Entity 
     {
          public TState()
          {
              
          }
          
        
          
          #region Basic Property
          private int _stateId;
          private int _countryId;
          private int _contentStatusId;
          private string _code;
          private string _description;
          private string _updatedBy;
          private DateTime _updatedOn;

          [BindingField("StateId",true)]
          public int StateId
          {
               set
               {
                    _stateId=value;
               }
               get
               {
                     return _stateId;
               }
           }
          [BindingField("CountryId",true)]
          public int CountryId
          {
               set
               {
                    _countryId=value;
               }
               get
               {
                     return _countryId;
               }
           }
          [BindingField("ContentStatusId",true)]
          public int ContentStatusId
          {
               set
               {
                    _contentStatusId=value;
               }
               get
               {
                     return _contentStatusId;
               }
           }
          [BindingField("Code",true)]
          public string Code
          {
               set
               {
                    _code=value;
               }
               get
               {
                     return _code;
               }
           }
          [BindingField("Description",true)]
          public string Description
          {
               set
               {
                    _description=value;
               }
               get
               {
                     return _description;
               }
           }
          [BindingField("UpdatedBy",true)]
          public string UpdatedBy
          {
               set
               {
                    _updatedBy=value;
               }
               get
               {
                     return _updatedBy;
               }
           }
          [BindingField("UpdatedOn",true)]
          public DateTime UpdatedOn
          {
               set
               {
                    _updatedOn=value;
               }
               get
               {
                     return _updatedOn;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 
          
     
        public ReturnValue getStateList()
        {
            string Usp_SQL = String.Format(WComm.SqlDefine.getSQL("getStateList"));
            ReturnValue _result = this.getEntityList(Usp_SQL);
            return _result;
        }

    
     }
}