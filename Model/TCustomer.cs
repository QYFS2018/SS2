using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Customer")]
     public class TCustomer : Entity 
     {
          public TCustomer()
          {
              
          }
          
        
          
          #region Basic Property
          private int _customerId;
          private string _company;
          private int _sourceId;
          private string _userGUID;
          private string _altCustNum;
          private string _email;
          private string _firstName;
          private string _lastName;
          private string _middleName;
          private string _title;
          private string _sSN;
          private string _taxExemptCode;
          private DateTime _createdOn;
          private string _updatedBy;
          private DateTime _updatedOn;
          private int _programId;

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
          [BindingField("Company",true)]
          public string Company
          {
               set
               {
                    _company=value;
               }
               get
               {
                     return _company;
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
          [BindingField("UserGUID",true)]
          public string UserGUID
          {
               set
               {
                    _userGUID=value;
               }
               get
               {
                     return _userGUID;
               }
           }
          [BindingField("AltCustNum",true)]
          public string AltCustNum
          {
               set
               {
                    _altCustNum=value;
               }
               get
               {
                     return _altCustNum;
               }
           }
          [BindingField("Email",true)]
          public string Email
          {
               set
               {
                    _email=value;
               }
               get
               {
                     return _email;
               }
           }
          [BindingField("FirstName",true)]
          public string FirstName
          {
               set
               {
                    _firstName=value;
               }
               get
               {
                     return _firstName;
               }
           }
          [BindingField("LastName",true)]
          public string LastName
          {
               set
               {
                    _lastName=value;
               }
               get
               {
                     return _lastName;
               }
           }
          [BindingField("MiddleName",true)]
          public string MiddleName
          {
               set
               {
                    _middleName=value;
               }
               get
               {
                     return _middleName;
               }
           }
          [BindingField("Title",true)]
          public string Title
          {
               set
               {
                    _title=value;
               }
               get
               {
                     return _title;
               }
           }
          [BindingField("SSN",true)]
          public string SSN
          {
               set
               {
                    _sSN=value;
               }
               get
               {
                     return _sSN;
               }
           }
          [BindingField("TaxExemptCode",true)]
          public string TaxExemptCode
          {
               set
               {
                    _taxExemptCode=value;
               }
               get
               {
                     return _taxExemptCode;
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

          #endregion 

          #region Extend Property

          #endregion 
          
          
      
     }
}