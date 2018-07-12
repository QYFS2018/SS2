using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using WComm;
using SS2.Model;

namespace SS2
{
    public class ShipStationAPI
    {

        private static string authorization = System.Configuration.ConfigurationSettings.AppSettings["Authorization"];
        private static Uri apiURL = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ShipSationAPI"]);


        public ShipStationAPI()
        {
          
        }


        public static ReturnValue PULLOrders()
        {
            ReturnValue _result = new ReturnValue();

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            int pageIndex = 1;
            ShipStationResponse responseInfo = new Model.ShipStationResponse();
            List<ShipStationResponseOrder> orderList = new List<ShipStationResponseOrder>();

            do
            {

                HttpClient httpClient = new HttpClient { BaseAddress = apiURL };

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", authorization);

                try
                {
                    var task = httpClient.GetAsync("orders?orderStatus=awaiting_shipment&page=" + pageIndex);
                    task.Result.EnsureSuccessStatusCode();
                    HttpResponseMessage response = task.Result;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        _result.Success = false;
                        _result.ErrMessage = response.ToString();
                        return _result;
                    }

                    try
                    {
                        JsonToObject(response.Content.ReadAsStringAsync().Result, ref responseInfo);
                    }
                    catch (Exception ex)
                    {
                        _result.Success = false;
                        _result.ErrMessage = ex.ToString();
                        return _result;
                    }

                    if (responseInfo.total > 0)
                    {
                        foreach (ShipStationResponseOrder item in responseInfo.orders)
                        {
                            orderList.Add(item);
                        }
                    }
                }
                catch (System.AggregateException ex2)
                {
                   _result.Success = false;
                   _result.ErrMessage = ex2.ToString();
                    return _result;
                }
                catch (System.Net.Http.HttpRequestException ex3)
                {
                    _result.Success = false;
                    _result.ErrMessage = ex3.ToString();
                    return _result;
                }
                catch (System.Net.WebException ex)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                }
                catch (Exception e)
                {
                    _result.Success = false;
                    _result.ErrMessage = e.ToString();
                    return _result;
                }
            } while (pageIndex++ <= responseInfo.pages);


            _result.ObjectValue = orderList;

            return _result;
        }


        public static ReturnValue MarkAsShipped(TOrder order, string sOrderID)
        {
            ReturnValue _result = new ReturnValue();

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            try
            {
                using (var httpClient = new HttpClient { BaseAddress = apiURL })
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("authorization", authorization);

                    var contentStr = "{"+string.Format("  \"orderId\": {0},  \"carrierCode\": \"{1}\",  \"shipDate\": \"{2}\",  \"trackingNumber\": \"{3}\",  \"notifySalesChannel\": true"
                        , sOrderID//185440447
                        , order.CarrierCode
                        , order.ShippedDate.Value.ToString("yyyy-MM-dd")
                        , order.TrackingNumber)+"}";
                    //"{  \"orderId\": 185440447,  \"carrierCode\": \"usps\",  \"shipDate\": \"2016-05-16\",  \"trackingNumber\": \"111111\",  \"notifyCustomer\": true,  \"notifySalesChannel\": true}"

                    Common.Log(contentStr);

                    using (var content = new StringContent(contentStr, System.Text.Encoding.Default, "application/json"))
                    {
                        using (var task = httpClient.PostAsync("orders/markasshipped", content))
                        {
                            task.Result.EnsureSuccessStatusCode();
                            HttpResponseMessage response = task.Result;

                            if (response.StatusCode != HttpStatusCode.OK)
                            {
                                _result.Success = false;
                                _result.ErrMessage = "response.StatusCode != HttpStatusCode.OK ------"+response.ToString();
                                return _result;
                            }

                            var _markShipResponse = JsonToMarkShipResponse(response.Content.ReadAsStringAsync().Result);
                            if (_markShipResponse.orderId.ToString() != sOrderID)
                            {
                                _result.Success = false;
                                _result.ErrMessage = "Response.orderId.ToString() != sOrderID----" + response.Content.ReadAsStringAsync().Result;
                                return _result;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _result.Success = false;
                _result.ErrMessage = e.ToString();

                if (_result.ErrMessage.IndexOf("404 (Not Found)") > -1)
                {
                    _result.Success = true;
                }

                return _result;
            }

            return _result;
        }

        public static void JsonToObject(string jsonString, ref ShipStationResponse p1)
        {
            StringReader sr = new StringReader(jsonString); 

            JsonSerializer serializer = new JsonSerializer();
            p1 = (Model.ShipStationResponse)serializer.Deserialize(new JsonTextReader(sr), typeof(Model.ShipStationResponse));
        }
        public static void JsonToObject(string jsonString, ref Model.ShipStationResponseOrder p1)
        {
            StringReader sr = new StringReader(jsonString);

            JsonSerializer serializer = new JsonSerializer();
            p1 = (Model.ShipStationResponseOrder)serializer.Deserialize(new JsonTextReader(sr), typeof(Model.ShipStationResponseOrder));
        }
        private static Model.MarkShipResponse JsonToMarkShipResponse(string jsonString)
        {
            StringReader sr = new StringReader(jsonString);
            JsonSerializer serializer = new JsonSerializer();
            return (Model.MarkShipResponse)serializer.Deserialize(new JsonTextReader(sr), typeof(Model.MarkShipResponse));
        }
       
    }
}
