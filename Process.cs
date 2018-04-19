using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WComm;

namespace SS2
{
    public class Process
    {
        public ReturnValue Run(string action)
        {
            ReturnValue _result = new ReturnValue();
        
            Common.ProcessType = action;

            if (action.ToUpper() == "PullOrder".ToUpper())
            {
                Common.Log("Start PullOrder");

                PULLOrders PULLOrders = new PULLOrders();
                _result = PULLOrders.Run();
            }

            if (action.ToUpper() == "MarkOrderShip".ToUpper())
            {
                Common.Log("Start MarkOrderShip");

                MarkOrderShip MarkOrderShip = new SS2.MarkOrderShip();
                _result = MarkOrderShip.Run();
            }

          
            if (_result.Success == false)
            {
                Common.ProcessError(_result, false);
            }

            Common.Log("Finish");


            return _result;
        }
    }
}
