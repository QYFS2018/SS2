using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SS2.Model
{
    public class ShipStationResponse
    {
        public int total { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public List<ShipStationResponseOrder> orders { get; set; }
    }
    public class advancedOption
    {
        public int storeId { set; get; }
        public string customField1 { set; get; }
        public string customField2 { set; get; }
        public string customField3 { set; get; }
        //"advancedOptions":{
        //    "warehouseId":58636,
        //    "nonMachinable":false,
        //    "saturdayDelivery":false,
        //    "containsAlcohol":false,
        //    "mergedOrSplit":false,
        //    "mergedIds":[
        //    ],
        //    "parentId":null,
        //    "storeId":119267,
        //    "customField1":null,
        //    "customField2":null,
        //    "customField3":null,
        //    "source":null,
        //    "billToParty":null,
        //    "billToAccount":null,
        //    "billToPostalCode":null,
        //    "billToCountryCode":null,
        //    "billToMyOtherAccount":null
    }

    public class ShipStationResponseOrder
    {
        public int orderId { set; get; }
        public string orderNumber { set; get; }
        public string orderKey { set; get; }
        public DateTime orderDate { set; get; }
        public Decimal taxAmount { set; get; }
        public Decimal shippingAmount { set; get; }
        public Decimal orderTotal { set; get; }
        public string requestedShippingService { set; get; }
        public ShipStationResponseAddress shipTo { set; get; }
        public List<ShipStationResponseItem> items { set; get; }
        public advancedOption advancedOptions { get; set; }
        public string customerEmail { set; get; }
        public string customerNotes { set; get; }

        //"orderId":188313735,
        //"orderNumber":"115-7804519-6505017",
        //"orderKey":"115-7804519-6505017",
        //"orderDate":"2016-05-16T16:18:16.0000000",
        //"createDate":"2016-05-16T18:45:50.2000000",
        //"modifyDate":"2016-05-16T18:46:13.5870000",
        //"paymentDate":"2016-05-16T16:18:16.0000000",
        //"shipByDate":"2016-05-18T12:00:00.0000000",
        //"orderStatus":"awaiting_shipment",
        //"customerId":141050113,
        //"customerUsername":"hhrgnm1ymt0vvsk@marketplace.amazon.com",
        //"customerEmail":"hhrgnm1ymt0vvsk@marketplace.amazon.com",
        //"billTo":{
        //    "name":"Tammy A. Harri",
        //    "company":null,
        //    "street1":null,
        //    "street2":null,
        //    "street3":null,
        //    "city":null,
        //    "state":null,
        //    "postalCode":null,
        //    "country":null,
        //    "phone":null,
        //    "residential":null,
        //    "addressVerified":null
        //},
        //"shipTo":{
        //    "name":"Earl Schneider",
        //    "company":null,
        //    "street1":"5697 HOUSTON RD",
        //    "street2":"",
        //    "street3":null,
        //    "city":"EATON RAPIDS",
        //    "state":"MI",
        //    "postalCode":"48827-9597",
        //    "country":"US",
        //    "phone":"5176635239",
        //    "residential":true,
        //    "addressVerified":"Address validated successfully"
        //},
        //"items":[
        //    {
        //        "orderItemId":265590674,
        //        "lineItemKey":"09502323833906",
        //        "sku":"B00XNSBKEG",
        //        "name":"RFC0800A-P1 IcePure Water Filter to Replace Whirlpool, PUR, Kenmore, Sears, 4396710, 4396710B, 4396710P, 4396710T, 4396711B, 4396841, 4396841B, 4396841P, 4396841T, 4396842B, 4396842",
        //        "imageUrl":"http://ecx.images-amazon.com/images/I/41VACiy8TuL.jpg",
        //        "weight":{
        //            "value":15.00,
        //            "units":"ounces"
        //        },
        //        "quantity":1,
        //        "unitPrice":25.00,
        //        "taxAmount":0.00,
        //        "shippingAmount":4.49,
        //        "warehouseLocation":null,
        //        "options":[
        //        ],
        //        "productId":23253239,
        //        "fulfillmentSku":null,
        //        "adjustment":false,
        //        "upc":null,
        //        "createDate":"2016-05-16T18:45:50.293",
        //        "modifyDate":"2016-05-16T18:45:50.293"
        //    }
        //],
        //"orderTotal":29.49,
        //"amountPaid":29.49,
        //"taxAmount":0.00,
        //"shippingAmount":4.49,
        //"customerNotes":null,
        //"internalNotes":"",
        //"gift":false,
        //"giftMessage":null,
        //"paymentMethod":"Other",
        //"requestedShippingService":"Std US D2D Dom",
        //"carrierCode":"stamps_com",
        //"serviceCode":"usps_media_mail",
        //"packageCode":null,
        //"confirmation":"none",
        //"shipDate":null,
        //"holdUntilDate":null,
        //"weight":{
        //    "value":15.50,
        //    "units":"ounces"
        //},
        //"dimensions":null,
        //"insuranceOptions":{
        //    "provider":null,
        //    "insureShipment":false,
        //    "insuredValue":0.0
        //},
        //"internationalOptions":{
        //    "contents":null,
        //    "customsItems":null,
        //    "nonDelivery":null
        //},
        //"advancedOptions":{
        //    "warehouseId":58636,
        //    "nonMachinable":false,
        //    "saturdayDelivery":false,
        //    "containsAlcohol":false,
        //    "mergedOrSplit":false,
        //    "mergedIds":[
        //    ],
        //    "parentId":null,
        //    "storeId":119267,
        //    "customField1":null,
        //    "customField2":null,
        //    "customField3":null,
        //    "source":null,
        //    "billToParty":null,
        //    "billToAccount":null,
        //    "billToPostalCode":null,
        //    "billToCountryCode":null,
        //    "billToMyOtherAccount":null
    }
    public class ShipStationResponseAddress
    {
        public string name { set; get; }
        public string company { set; get; }
        public string street1 { set; get; }
        public string street2 { set; get; }
        public string street3 { set; get; }
        public string city { set; get; }
        public string state { set; get; }
        public string postalCode { set; get; }
        public string country { set; get; }
        public string phone { set; get; }

        public string fname
        {
            get
            {
                if (name == null) return "";
                else if (name.IndexOf(" ") == -1) return name;
                else return name.Substring(0, name.IndexOf(" "));
            }
        }
        public string lname
        {
            get
            {
                if (name == null) return "";
                else if (name.IndexOf(" ") == -1) return "";
                else return name.Substring(name.IndexOf(" ") + 1);
            }
        }
        //"shipTo":{
        //       "name":"emily lee",
        //       "company":"",
        //       "street1":"3616 richmond ave",
        //       "street2":"apt 2213",
        //       "street3":null,
        //       "city":"houston",
        //       "state":"TX",
        //       "postalCode":"77046",
        //       "country":"US",
        //       "phone":"6502006686",
        //       "residential":false,
        //       "addressVerified":"Address not yet validated"
        //   },
    }
    public class ShipStationResponseItem
    {
        public string sku { set; get; }
        public string fulfillmentSku { set; get; }
        public string name { set; get; }
        public int quantity { set; get; }
        public DateTime createDate { set; get; }
        public int? productId { set; get; }
        public string upc { set; get; }
        public Decimal unitPrice { set; get; }
        //public string name { set; get; }
        //public string name { set; get; }


        //"items":[
        //        {
        //            "orderItemId":260872392,
        //            "lineItemKey":"6088681412",
        //            "sku":"05104",
        //            "name":"05104 Christmas Lane",
        //            "imageUrl":"https://cdn.shopify.com/s/files/1/0986/1742/products/05104.jpg?v=1452832784",
        //            "weight":{
        //                "value":34.00,
        //                "units":"ounces"
        //            },
        //            "quantity":1,
        //            "unitPrice":0.00,
        //            "taxAmount":null,
        //            "shippingAmount":null,
        //            "warehouseLocation":null,
        //            "options":[
        //            ],
        //            "productId":24681167,
        //            "fulfillmentSku":null,
        //            "adjustment":false,
        //            "upc":"728162051042",
        //            "createDate":"2016-05-04T14:27:23.337",
        //            "modifyDate":"2016-05-04T14:27:23.337"
        //        },
    }

    public class MarkShipResponse
    {
        public int orderId { set; get; }
        public string orderNumber { set; get; }
    }
}
