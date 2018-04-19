using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Country")]
     public class TCountry : Entity 
     {
          public TCountry()
          {
              
          }
          
        
          
          #region Basic Property
          private int _countryId;
          private int _shipAreaId;
          private int _contentStatusId;
          private string _name;
          private string _iSO2;
          private string _iSO3;
          private int _iSONum;
          private string _updatedBy;
          private DateTime _updatedOn;

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
          [BindingField("ShipAreaId",true)]
          public int ShipAreaId
          {
               set
               {
                    _shipAreaId=value;
               }
               get
               {
                     return _shipAreaId;
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
          [BindingField("Name",true)]
          public string Name
          {
               set
               {
                    _name=value;
               }
               get
               {
                     return _name;
               }
           }
          [BindingField("ISO2",true)]
          public string ISO2
          {
               set
               {
                    _iSO2=value;
               }
               get
               {
                     return _iSO2;
               }
           }
          [BindingField("ISO3",true)]
          public string ISO3
          {
               set
               {
                    _iSO3=value;
               }
               get
               {
                     return _iSO3;
               }
           }
          [BindingField("ISONum",true)]
          public int ISONum
          {
               set
               {
                    _iSONum=value;
               }
               get
               {
                     return _iSONum;
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
          
      

        public ReturnValue getCountryList()
        {
            string Usp_SQL = String.Format(WComm.SqlDefine.getSQL("getCountryList"));
            ReturnValue _result = this.getEntityList(Usp_SQL);
            return _result;
        }

       
     }
}