using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Data
{
    public class DataFormat
    {
        private static string jsonData = String.Empty;

        public static void GetDeviceList()
        {
            try
            {
                HttpWebRequest wReq;
                HttpWebResponse wResp;
                Uri uri = new Uri(SharedValues.ApiServerUri + "/mwCon/getDeviceList");
                wReq = (HttpWebRequest)WebRequest.Create(uri);
                wReq.Method = "GET";

                wResp = (HttpWebResponse)wReq.GetResponse();
                using (StreamReader streamReader = new StreamReader(wResp.GetResponseStream()))
                {
                    jsonData = streamReader.ReadToEnd();
                }

                DataList mResponsData = new DataList();
                mResponsData = JsonConvert.DeserializeObject<DataList>(jsonData);

                foreach (var v in mResponsData.datalist)
                {
                    Debug.WriteLine(v.DEVICE_ID + " | " + v.DEVICE_NAME);
                }

                SharedValues.DeviceId = mResponsData.datalist[0].DEVICE_ID;
            }
            catch
            {

            }
        }

        public static void UpdateColRowNum(string deviceId, int colNum, int rowNum)
        {
            JObject JsonData = new JObject();
            JsonData.Add("DEVICE_ID", deviceId);
            JsonData.Add("COL_NUM", colNum);
            JsonData.Add("ROW_NUM", rowNum);

            HttpWebRequest wReq;
            HttpWebResponse wResp;
            Uri uri = new Uri(SharedValues.ApiServerUri + "/mwCon/updateColRowNum");
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "POST";
            wReq.ContentType = "application/json";

            using (StreamWriter streamwriter = new StreamWriter(wReq.GetRequestStream()))
            {
                streamwriter.Write(JsonData.ToString());
            }

            wResp = (HttpWebResponse)wReq.GetResponse();
            using (StreamReader streamreader = new StreamReader(wResp.GetResponseStream()))
            {
                jsonData = streamreader.ReadToEnd();

                // DeSerialize Jsonstring to Object
                JObject jObj = JObject.Parse(jsonData);

                int statusCode = (int)jObj["code"];
                string message = (string)jObj["message"];

                Debug.WriteLine(statusCode.ToString() + " | " + message);
            }
        }

        public static void AlerInputEvent(string deviceId, string workerId, int location, string date, string epc, int count, int stock_count, int input_count)
        {
            JObject JsonData = new JObject();
            JsonData.Add("DEVICE_ID", deviceId);
            JsonData.Add("WORKER_ID", workerId);
            JsonData.Add("LOCATION", location);
            JsonData.Add("DATE_TIME", date);
            JsonData.Add("EPC", epc);
            JsonData.Add("COUNT", count);
            JsonData.Add("STOCK_COUNT", stock_count);
            JsonData.Add("INPUT_COUNT", input_count); 

            HttpWebRequest wReq;
            HttpWebResponse wResp;
            Uri uri = new Uri(SharedValues.GatheringServerUri + "/alertInputEvent");
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "POST";
            wReq.ContentType = "application/json";

            using (StreamWriter streamwriter = new StreamWriter(wReq.GetRequestStream()))
            {
                streamwriter.Write(JsonData.ToString());
            }

            wResp = (HttpWebResponse)wReq.GetResponse();

            using (StreamReader streamreader = new StreamReader(wResp.GetResponseStream()))
            {
                jsonData = streamreader.ReadToEnd();
            }

            JObject jObj = JObject.Parse(jsonData);

            int statusCode = (int)jObj["STATUS_CODE"];
            string message = (string)jObj["MESSAGE"];

            Debug.WriteLine("INPUT : " + statusCode.ToString()+ "|" + message);
        }

        public static void AlertOutputEvent(string deviceId, string workerId, int location, string date, string epc, int count, int stock_count, int output_count)
        {
            JObject JsonData = new JObject();
            JsonData.Add("DEVICE_ID", deviceId);
            JsonData.Add("WORKER_ID", workerId);
            JsonData.Add("LOCATION", location);
            JsonData.Add("DATE_TIME", date);
            JsonData.Add("EPC", epc);
            JsonData.Add("COUNT", count);
            JsonData.Add("STOCK_COUNT", stock_count);
            JsonData.Add("OUTPUT_COUNT", output_count);

            HttpWebRequest wReq;
            HttpWebResponse wResp;
            Uri uri = new Uri(SharedValues.GatheringServerUri + "/alertOutputEvent");
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "POST";
            wReq.ContentType = "application/json";

            using (StreamWriter streamwriter = new StreamWriter(wReq.GetRequestStream()))
            {
                streamwriter.Write(JsonData.ToString());
            }

            wResp = (HttpWebResponse)wReq.GetResponse();

            using (StreamReader streamreader = new StreamReader(wResp.GetResponseStream()))
            {
                jsonData = streamreader.ReadToEnd();
            }

            JObject jObj = JObject.Parse(jsonData);

            int statusCode = (int)jObj["STATUS_CODE"];
            string message = (string)jObj["MESSAGE"];

            Debug.WriteLine("OUTPUT : " + statusCode.ToString() + "|" + message);
        }
    }

    public class Response
    {
        public string code;
        public string message;
    }

    public class DataList : Response
    {
        public List<GetData> datalist;
    }

    public class GetData
    {
        public string DEVICE_ID { get; set; }

        public string DEVICE_NAME { get; set; }
    }
}


