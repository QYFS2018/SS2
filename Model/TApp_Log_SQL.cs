using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("App_Log_SQL")]
     public class TApp_Log_SQL : Entity 
     {
          public TApp_Log_SQL()
          {
              
          }
          
        
          
          #region Basic Property
          private int _iD;
          private DateTime _createdOn;
          private string _source;
          private string _sQLText;
          private int _priority;
          private string _oId;
          private bool _success;
          private string _notes;
          private int _programId;
          private string _type;
          private string _tableName;
          private string _sQLType;
          private string _url;

          [BindingField("ID",true)]
          public int ID
          {
               set
               {
                    _iD=value;
               }
               get
               {
                     return _iD;
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
          [BindingField("Source",true)]
          public string Source
          {
               set
               {
                    _source=value;
               }
               get
               {
                     return _source;
               }
           }
          [BindingField("SQLText",true)]
          public string SQLText
          {
               set
               {
                    _sQLText=value;
               }
               get
               {
                     return _sQLText;
               }
           }
          [BindingField("Priority",true)]
          public int Priority
          {
               set
               {
                    _priority=value;
               }
               get
               {
                     return _priority;
               }
           }
          [BindingField("OId",true)]
          public string OId
          {
               set
               {
                    _oId=value;
               }
               get
               {
                     return _oId;
               }
           }
          [BindingField("Success",true)]
          public bool Success
          {
               set
               {
                    _success=value;
               }
               get
               {
                     return _success;
               }
           }
          [BindingField("Notes",true)]
          public string Notes
          {
               set
               {
                    _notes=value;
               }
               get
               {
                     return _notes;
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
          [BindingField("Type",true)]
          public string Type
          {
               set
               {
                    _type=value;
               }
               get
               {
                     return _type;
               }
           }
          [BindingField("TableName",true)]
          public string TableName
          {
               set
               {
                    _tableName=value;
               }
               get
               {
                     return _tableName;
               }
           }
          [BindingField("SQLType",true)]
          public string SQLType
          {
               set
               {
                    _sQLType=value;
               }
               get
               {
                     return _sQLType;
               }
           }
          [BindingField("Url",true)]
          public string Url
          {
               set
               {
                    _url=value;
               }
               get
               {
                     return _url;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 
          
          
   
     }
}