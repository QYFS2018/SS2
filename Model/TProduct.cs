using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Product")]
     public class TProduct : Entity 
     {
          public TProduct()
          {
              
          }
          
        
          
          #region Basic Property
          private int _productId;
          private int _programID;
          private string _partNumber;
          private string _name;
          private string _shortDesc;
          private string _longDesc;
          private double _price;
          private double _weight;
          private double _estUnits;
          private double _estCommitted;
          private double _estLow;
          private string _createdBy;
          private DateTime _createdOn;
          private string _updatedBy;
          private DateTime _updatedOn;
          private int _pHOnHand;
          private int _pHCommitted;
          private int _pHBlocked;
          private int _pHOnhold;
          private int _pHHard;
          private bool _phantom;
          private int _phpending;
          private string _itemClass;

          [BindingField("ProductId",true)]
          public int ProductId
          {
               set
               {
                    _productId=value;
               }
               get
               {
                     return _productId;
               }
           }
          [BindingField("ProgramID",true)]
          public int ProgramID
          {
               set
               {
                    _programID=value;
               }
               get
               {
                     return _programID;
               }
           }
          [BindingField("PartNumber",true)]
          public string PartNumber
          {
               set
               {
                    _partNumber=value;
               }
               get
               {
                     return _partNumber;
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
          [BindingField("ShortDesc",true)]
          public string ShortDesc
          {
               set
               {
                    _shortDesc=value;
               }
               get
               {
                     return _shortDesc;
               }
           }
          [BindingField("LongDesc",true)]
          public string LongDesc
          {
               set
               {
                    _longDesc=value;
               }
               get
               {
                     return _longDesc;
               }
           }
          [BindingField("Price",true)]
          public double Price
          {
               set
               {
                    _price=value;
               }
               get
               {
                     return _price;
               }
           }
          [BindingField("Weight",true)]
          public double Weight
          {
               set
               {
                    _weight=value;
               }
               get
               {
                     return _weight;
               }
           }
          [BindingField("EstUnits",true)]
          public double EstUnits
          {
               set
               {
                    _estUnits=value;
               }
               get
               {
                     return _estUnits;
               }
           }
          [BindingField("EstCommitted",true)]
          public double EstCommitted
          {
               set
               {
                    _estCommitted=value;
               }
               get
               {
                     return _estCommitted;
               }
           }
          [BindingField("EstLow",true)]
          public double EstLow
          {
               set
               {
                    _estLow=value;
               }
               get
               {
                     return _estLow;
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
          [BindingField("PHOnHand",true)]
          public int PHOnHand
          {
               set
               {
                    _pHOnHand=value;
               }
               get
               {
                     return _pHOnHand;
               }
           }
          [BindingField("PHCommitted",true)]
          public int PHCommitted
          {
               set
               {
                    _pHCommitted=value;
               }
               get
               {
                     return _pHCommitted;
               }
           }
          [BindingField("PHBlocked",true)]
          public int PHBlocked
          {
               set
               {
                    _pHBlocked=value;
               }
               get
               {
                     return _pHBlocked;
               }
           }
          [BindingField("PHOnhold",true)]
          public int PHOnhold
          {
               set
               {
                    _pHOnhold=value;
               }
               get
               {
                     return _pHOnhold;
               }
           }
          [BindingField("PHHard",true)]
          public int PHHard
          {
               set
               {
                    _pHHard=value;
               }
               get
               {
                     return _pHHard;
               }
           }
          [BindingField("Phantom",true)]
          public bool Phantom
          {
               set
               {
                    _phantom=value;
               }
               get
               {
                     return _phantom;
               }
           }
          [BindingField("phpending",true)]
          public int phpending
          {
               set
               {
                    _phpending=value;
               }
               get
               {
                     return _phpending;
               }
           }
          [BindingField("ItemClass",true)]
          public string ItemClass
          {
               set
               {
                    _itemClass=value;
               }
               get
               {
                     return _itemClass;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 
          
          
     
     }
}