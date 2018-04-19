using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Type")]
     public class TType : Entity 
     {
          public TType()
          {
              
          }
          
        
          
          #region Basic Property
          private int _typeId;
          private string _code;
          private string _description;
          private int _contentStatusId;
          private string _groupBy;
          private string _createdBy;
          private DateTime _createdOn;
          private string _updatedBy;
          private DateTime _updatedOn;

          [BindingField("TypeId",true)]
          public int TypeId
          {
               set
               {
                    _typeId=value;
               }
               get
               {
                     return _typeId;
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
          [BindingField("GroupBy",true)]
          public string GroupBy
          {
               set
               {
                    _groupBy=value;
               }
               get
               {
                     return _groupBy;
               }
           }
          [BindingField("CreatedBy",true)]
          public string CreatedBy
          {
               set
               {
                    _createdBy=value;
               }
               get
               {
                     return _createdBy;
               }
           }
          [BindingField("CreatedOn",true)]
          public DateTime CreatedOn
          {
               set
               {
                    _createdOn=value;
               }
               get
               {
                     return _createdOn;
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
          
          
          public ReturnValue geTTypeList()
        {
            string Usp_SQL = String.Format(WComm.SqlDefine.getSQL("geTTypeList"));
            ReturnValue _result = this.getEntityList(Usp_SQL);
            return _result;
        }

     
     }
}