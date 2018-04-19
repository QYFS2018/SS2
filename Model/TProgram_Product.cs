using System;
using System.Data;
using WComm;

namespace SS2.Model
{
     [Serializable]
     [BindingClass("Program_Product")]
     public class TProgram_Product : Entity 
     {
          public TProgram_Product()
          {
              
          }
          
          #region Basic Property
          private int _programProductId;
          private int _programId;
          private int _productId;
          private int _contentStatusId;
          private string _partNumber;
          private string _name;
          private string _shortDesc;
          private string _longDesc;
          private double _price;
          private double _weight;
          private double _estUnits;
          private double _estCommitted;
          private double _estLow;
          private int _maxQtySell;
          private int _maxBackOrder;
          private int _maxPreOrder;
          private bool _isSellOnline;
          private bool _isCommissionable;
          private bool _isOptionKit;
          private DateTime _onlineDate;
          private DateTime _offlineDate;
          private string _updatedBy;
          private DateTime _updatedOn;
          private int _safeStockLevel;
          private int _pHOnHand;
          private int _pHCommitted;
          private int _pHBlocked;
          private int _pHOnhold;
          private int _pHHard;
          private bool _phantom;
          private int _phpending;
          private string _itemClass;
          private string _defaultInventoryType;

          [BindingField("ProgramProductId",true)]
          public int ProgramProductId
          {
               set
               {
                    _programProductId=value;
               }
               get
               {
                     return _programProductId;
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
          [BindingField("MaxQtySell",true)]
          public int MaxQtySell
          {
               set
               {
                    _maxQtySell=value;
               }
               get
               {
                     return _maxQtySell;
               }
           }
          [BindingField("MaxBackOrder",true)]
          public int MaxBackOrder
          {
               set
               {
                    _maxBackOrder=value;
               }
               get
               {
                     return _maxBackOrder;
               }
           }
          [BindingField("MaxPreOrder",true)]
          public int MaxPreOrder
          {
               set
               {
                    _maxPreOrder=value;
               }
               get
               {
                     return _maxPreOrder;
               }
           }
          [BindingField("IsSellOnline",true)]
          public bool IsSellOnline
          {
               set
               {
                    _isSellOnline=value;
               }
               get
               {
                     return _isSellOnline;
               }
           }
          [BindingField("IsCommissionable",true)]
          public bool IsCommissionable
          {
               set
               {
                    _isCommissionable=value;
               }
               get
               {
                     return _isCommissionable;
               }
           }
          [BindingField("IsOptionKit",true)]
          public bool IsOptionKit
          {
               set
               {
                    _isOptionKit=value;
               }
               get
               {
                     return _isOptionKit;
               }
           }
          [BindingField("OnlineDate",true)]
          public DateTime OnlineDate
          {
               set
               {
                    _onlineDate=value;
               }
               get
               {
                     return _onlineDate;
               }
           }
          [BindingField("OfflineDate",true)]
          public DateTime OfflineDate
          {
               set
               {
                    _offlineDate=value;
               }
               get
               {
                     return _offlineDate;
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
          [BindingField("safeStockLevel",true)]
          public int safeStockLevel
          {
               set
               {
                    _safeStockLevel=value;
               }
               get
               {
                     return _safeStockLevel;
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
          [BindingField("DefaultInventoryType",true)]
          public string DefaultInventoryType
          {
               set
               {
                    _defaultInventoryType=value;
               }
               get
               {
                     return _defaultInventoryType;
               }
           }

          #endregion 

          #region Extend Property

          #endregion 

          public ReturnValue getProgramProductList()
          {
              string Usp_SQL = String.Format(SqlDefine.getSQL("getProgramProductList"));
              ReturnValue _result = this.getEntityList(Usp_SQL);

              return _result;
          }
          
     
     }
}