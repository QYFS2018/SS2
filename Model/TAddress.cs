using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Address")]
     public class TAddress : Entity 
     {
          public TAddress()
          {
              
          }
          
        
          
          #region Basic Property
          private int _addressId;
          private string _address1;
          private string _address2;
          private string _address3;
          private string _city;
          private int _stateId;
          private string _postalCode;
          private string _blockCode;
          private string _county;
          private int _countryId;
          private int? _phoneId;
          private string _matchKey;
          private string _updatedBy;
          private DateTime _updatedOn;
          private int _programId;

          [BindingField("AddressId",true)]
          public int AddressId
          {
               set
               {
                    _addressId=value;
               }
               get
               {
                     return _addressId;
               }
           }
          [BindingField("Address1",true)]
          public string Address1
          {
               set
               {
                    _address1=value;
               }
               get
               {
                     return _address1;
               }
           }
          [BindingField("Address2",true)]
          public string Address2
          {
               set
               {
                    _address2=value;
               }
               get
               {
                     return _address2;
               }
           }
          [BindingField("Address3",true)]
          public string Address3
          {
               set
               {
                    _address3=value;
               }
               get
               {
                     return _address3;
               }
           }
          [BindingField("City",true)]
          public string City
          {
               set
               {
                    _city=value;
               }
               get
               {
                     return _city;
               }
           }
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
          [BindingField("PostalCode",true)]
          public string PostalCode
          {
               set
               {
                    _postalCode=value;
               }
               get
               {
                     return _postalCode;
               }
           }
          [BindingField("BlockCode",true)]
          public string BlockCode
          {
               set
               {
                    _blockCode=value;
               }
               get
               {
                     return _blockCode;
               }
           }
          [BindingField("County",true)]
          public string County
          {
               set
               {
                    _county=value;
               }
               get
               {
                     return _county;
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
          [BindingField("PhoneId",true)]
          public int? PhoneId
          {
               set
               {
                    _phoneId=value;
               }
               get
               {
                     return _phoneId;
               }
           }
          [BindingField("MatchKey",true)]
          public string MatchKey
          {
               set
               {
                    _matchKey=value;
               }
               get
               {
                     return _matchKey;
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