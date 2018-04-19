using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Phone")]
     public class TPhone : Entity 
     {
          public TPhone()
          {
              
          }
          
        
          
          #region Basic Property
          private int _phoneId;
          private string _number;

          [BindingField("PhoneId",true)]
          public int PhoneId
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
          [BindingField("Number",true)]
          public string Number
          {
               set
               {
                    _number=value;
               }
               get
               {
                     return _number;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 
          
    
     }
}