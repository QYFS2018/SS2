using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WComm;
using SS2.Model;

namespace SS2
{
    public class MarkOrderShip
    {
        int failedRecord = 0;
        string errorNotes = "";

        public ReturnValue Run()
        {
            ReturnValue _result = new ReturnValue();

            #region get order list

            TShipStationOrders _tShipStationOrders = new TShipStationOrders();
            _result = _tShipStationOrders.getlOrderNeedMarked();
            if (_result.Success == false)
            {
                _result.Success = false;
                _result.ErrMessage = "getlOrderNeedMarked failed. \r\n " + _result.ErrMessage;

                Common.Log("getlOrderNeedMarked---ER \r\n" + _result.ErrMessage);

                return _result;
            }

            EntityList orderList = _result.ObjectList;

            #endregion

            foreach (TShipStationOrders item in orderList)
            {
                #region get order info

                TOrder _tOrder = new TOrder();
                _result = _tOrder.getOrderShipStation(item.ZOrderId);
                if (_result.Success == false)
                {
                    errorNotes = errorNotes + item.SOrderId.ToString() + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("Order : " + item.SOrderId + "  getOrderShipStation---ER \r\n" + _result.ErrMessage);

                    continue;
                }
                _tOrder = _result.Object as TOrder;

                #endregion

                if (_tOrder.StatusCode != "SH")
                {
                    continue;
                }

                #region MarkAsShipped

                _result = ShipStationAPI.MarkAsShipped(_tOrder, item.SOrderId);
                if (_result.Success == false)
                {
                    errorNotes = errorNotes + item.SOrderId.ToString() + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("Order : " + item.SOrderId + "  MarkAsShipped---ER \r\n" + _result.ErrMessage);

                    continue;
                }

                #endregion

                #region update ShipStationOrders when success

                item.Notes = "";
                item.MarkedDate = DateTime.Now;
                item.PrevProcessDate = DateTime.Now;
                _result = item.Update();
                if (_result.Success == false)
                {
                    errorNotes = errorNotes + item.SOrderId.ToString() + "\r\n" + _result.ErrMessage + "\r\n";
                    failedRecord++;

                    Common.Log("Order : " + item.SOrderId + "ShipStationOrders  Update---ER \r\n" + _result.ErrMessage);

                    continue;
                }

                #endregion

                Common.Log("Order : " + item.SOrderId + "---OK");

            }

            Common.SentAlterEmail(failedRecord, errorNotes);

            _result.Success = true;

            return _result;
        }
    }
}
