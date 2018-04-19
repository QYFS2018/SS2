using System;
using System.Data;
using System.Web;
using WComm;

namespace SS2.Model
{
    [Serializable]
    [BindingClass("ShipStationOrders")]
    public partial class TShipStationOrders : Entity
    {
        public TShipStationOrders()
        {

        }

        #region Basic Property
        private int _iD;
        private int _storeId;
        private string _sOrderId;
        private int _zOrderId;
        private string _fullContent;
        private DateTime? _pullDate;
        private DateTime? _orderCreatedDate;
        private DateTime? _markedDate;
        private string _notes;
        private bool? _abort;
        private DateTime? _prevProcessDate;

        [BindingField("ID", true)]
        public int ID
        {
            set
            {
                _iD = value;
            }
            get
            {
                return _iD;
            }
        }
        [BindingField("storeId", true)]
        public int storeId
        {
            set
            {
                _storeId = value;
            }
            get
            {
                return _storeId;
            }
        }
        [BindingField("SOrderId", true)]
        public string SOrderId
        {
            set
            {
                _sOrderId = value;
            }
            get
            {
                return _sOrderId;
            }
        }
        [BindingField("ZOrderId", true)]
        public int ZOrderId
        {
            set
            {
                _zOrderId = value;
            }
            get
            {
                return _zOrderId;
            }
        }
        [BindingField("FullContent", true)]
        public string FullContent
        {
            set
            {
                _fullContent = value;
            }
            get
            {
                return _fullContent;
            }
        }
        [BindingField("PullDate", true)]
        public DateTime? PullDate
        {
            set
            {
                _pullDate = value;
            }
            get
            {
                return _pullDate;
            }
        }
        [BindingField("OrderCreatedDate", true)]
        public DateTime? OrderCreatedDate
        {
            set
            {
                _orderCreatedDate = value;
            }
            get
            {
                return _orderCreatedDate;
            }
        }
        [BindingField("MarkedDate", true)]
        public DateTime? MarkedDate
        {
            set
            {
                _markedDate = value;
            }
            get
            {
                return _markedDate;
            }
        }
        [BindingField("Notes", true)]
        public string Notes
        {
            set
            {
                _notes = value;
            }
            get
            {
                return _notes;
            }
        }
        [BindingField("Abort", true)]
        public bool? Abort
        {
            set
            {
                _abort = value;
            }
            get
            {
                return _abort;
            }
        }
        [BindingField("PrevProcessDate", true)]
        public DateTime? PrevProcessDate
        {
            set
            {
                _prevProcessDate = value;
            }
            get
            {
                return _prevProcessDate;
            }
        }

        #endregion 

        #region Extend Property
        #endregion


        public ReturnValue getOrderNeedCreated()
        {
            string Usp_SQL = String.Format(SqlDefine.getSQL("getOrderNeedCreated"));
            ReturnValue _result = this.getEntity(Usp_SQL);
            return _result;
        }

        public ReturnValue getlOrderNeedMarked()
        {
            string Usp_SQL = String.Format(SqlDefine.getSQL("getOrderNeedMarked"));
            ReturnValue _result = this.getEntityList(Usp_SQL);
            return _result;
        }

        public ReturnValue getOrderBySOrderId(int SOrderId)
        {
            string Usp_SQL = String.Format("SELECT * FROM ShipStationOrders WHERE SOrderId={0}", SOrderId);
            ReturnValue _result = this.getEntity(Usp_SQL);
            return _result;
        }
    }
}