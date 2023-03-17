using ATST.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Uri = System.Uri;

namespace ATST.Data
{
    public class DataFormat
    {
        private static string jsonData = String.Empty;

        public static async Task GetDeviceList()
        {
            try
            {
                // 비동기 Client
                HttpWebRequest wReq;
                Uri uri = new Uri(SharedValues.ApiServerUri + "/mwCon/getDeviceList");
                wReq = (HttpWebRequest)WebRequest.Create(uri);
                wReq.Method = "GET";
                wReq.ContentType = "application/json";

                Task<WebResponse> t = Task.Factory.FromAsync<WebResponse>(wReq.BeginGetResponse, wReq.EndGetResponse, null);
                ThreadPool.RegisterWaitForSingleObject((t as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
                await t.ContinueWith(task =>
                {
                    HttpWebResponse wResp = (HttpWebResponse)task.Result;
                    if (wResp.StatusCode == HttpStatusCode.OK)
                    {
                        Stream RESULT_STREAM = wResp.GetResponseStream();
                        StreamReader RESULT_READER = new StreamReader(RESULT_STREAM);
                        jsonData = RESULT_READER.ReadToEnd();

                        JObject jObj = JObject.Parse(jsonData);
                        int statusCode = (int)jObj["code"];
                        string message = (string)jObj["message"];

                        Debug.WriteLine(statusCode.ToString() + " | " + message);
                    }
                });

                DataList mResponsData = new DataList();
                mResponsData = JsonConvert.DeserializeObject<DataList>(jsonData);

                foreach (var v in mResponsData.datalist)
                {
                    Debug.WriteLine(v.DEVICE_ID + " | " + v.DEVICE_NAME);
                }

                SharedValues.DeviceId = mResponsData.datalist[0].DEVICE_ID;

                SharedValues.WebInterLockCheck = true;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.Timeout)
                {
                    Popup.Show("TimeOut");
                }
            }
            catch (Exception ex)
            {
                Popup.Show("Error");
            }
        }

        public static async void UpdateColRowNum(string deviceId, int colNum, int rowNum)
        {
            JObject JsonData = new JObject();
            JsonData.Add("DEVICE_ID", deviceId);
            JsonData.Add("COL_NUM", colNum);
            JsonData.Add("ROW_NUM", rowNum);

            HttpWebRequest wReq;
            Uri uri = new Uri(SharedValues.ApiServerUri + "/mwCon/updateColRowNum");
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "POST";
            wReq.ContentType = "application/json";

            Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
            ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 1000, true);
            await requestStream.ContinueWith(task =>
            {
                try
                {
                    using (StreamWriter streamwriter = new StreamWriter(task.Result))
                    {
                        streamwriter.Write(JsonData.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });


            Task<WebResponse> t = Task.Factory.FromAsync<WebResponse>(wReq.BeginGetResponse, wReq.EndGetResponse, wReq);
            ThreadPool.RegisterWaitForSingleObject((t as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
            await t.ContinueWith(task =>
            {
                try
                {
                    HttpWebResponse wResp = (HttpWebResponse)task.Result;
                    if (wResp.StatusCode == HttpStatusCode.OK)
                    {
                        Stream RESULT_STREAM = wResp.GetResponseStream();
                        StreamReader RESULT_READER = new StreamReader(RESULT_STREAM);
                        jsonData = RESULT_READER.ReadToEnd();


                        JObject jObj = JObject.Parse(jsonData);
                        int statusCode = (int)jObj["code"];
                        string message = (string)jObj["message"];

                        Debug.WriteLine(statusCode.ToString() + " | " + message);
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });



            /*
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
            */
        }

        public static async void AlerInputEvent(string deviceId, string workerId, int location, string date, string epc, int count, int stock_count, int input_count)
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
            Uri uri = new Uri(SharedValues.GatheringServerUri + "/alertInputEvent");
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "POST";
            wReq.ContentType = "application/json";

            Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
            ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 1000, true);
            await requestStream.ContinueWith(task =>
            {
                try
                {
                    using (StreamWriter streamwriter = new StreamWriter(task.Result))
                    {
                        streamwriter.Write(JsonData.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });

            Task<WebResponse> t = Task.Factory.FromAsync<WebResponse>(wReq.BeginGetResponse, wReq.EndGetResponse, wReq);
            ThreadPool.RegisterWaitForSingleObject((t as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
            await t.ContinueWith(task =>
            {
                try
                {
                    HttpWebResponse wResp = (HttpWebResponse)task.Result;
                    if (wResp.StatusCode == HttpStatusCode.OK)
                    {
                        Stream RESULT_STREAM = wResp.GetResponseStream();
                        StreamReader RESULT_READER = new StreamReader(RESULT_STREAM);
                        jsonData = RESULT_READER.ReadToEnd();


                        JObject jObj = JObject.Parse(jsonData);
                        int statusCode = (int)jObj["code"];
                        string message = (string)jObj["message"];

                        Debug.WriteLine("INPUT : " + statusCode.ToString() + "|" + message);
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });

            /*
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
            */
        }

        public async static void AlertOutputEvent(string deviceId, string workerId, int location, string date, string epc, int count, int stock_count, int output_count)
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
            Uri uri = new Uri(SharedValues.GatheringServerUri + "/alertOutputEvent");
            wReq = (HttpWebRequest)WebRequest.Create(uri);
            wReq.Method = "POST";
            wReq.ContentType = "application/json";

            Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
            ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 1000, true);
            await requestStream.ContinueWith(task =>
            {
                try
                {
                    using (StreamWriter streamwriter = new StreamWriter(task.Result))
                    {
                        streamwriter.Write(JsonData.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });

            Task<WebResponse> t = Task.Factory.FromAsync<WebResponse>(wReq.BeginGetResponse, wReq.EndGetResponse, wReq);
            ThreadPool.RegisterWaitForSingleObject((t as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
            await t.ContinueWith(task =>
            {
                try
                {
                    HttpWebResponse wResp = (HttpWebResponse)task.Result;
                    if (wResp.StatusCode == HttpStatusCode.OK)
                    {
                        Stream RESULT_STREAM = wResp.GetResponseStream();
                        StreamReader RESULT_READER = new StreamReader(RESULT_STREAM);
                        jsonData = RESULT_READER.ReadToEnd();

                        JObject jObj = JObject.Parse(jsonData);
                        int statusCode = (int)jObj["code"];
                        string message = (string)jObj["message"];

                        Debug.WriteLine("OUTPUT : " + statusCode.ToString() + "|" + message);
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });

            /*
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
            */
        }

        public async static Task RequestHartBit(string DeviceId, string DateTime)
        {
            if (SharedValues.tokenSource.IsCancellationRequested)
            {
                return;
            }

            try
            {
                JObject JsonData = new JObject();
                JsonData.Add("DEVICE_ID", DeviceId);
                JsonData.Add("DATE_TIME", DateTime);

                HttpWebRequest wReq;
                Uri uri = new Uri(SharedValues.GatheringServerUri + "/alertDeviceConnected");
                wReq = (HttpWebRequest)WebRequest.Create(uri);
                wReq.Method = "POST";
                wReq.ContentType = "application/json";
                wReq.ContentLength = JsonData.ToString().Length;

                Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
                ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 1000, true);
                await requestStream.ContinueWith(task =>
                {
                    try
                    {
                        using (StreamWriter streamwriter = new StreamWriter(task.Result))
                        {
                            streamwriter.Write(JsonData.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Popup.Show(ex.Message);
                    }
                });

                Task<WebResponse> t = Task.Factory.FromAsync<WebResponse>(wReq.BeginGetResponse, wReq.EndGetResponse, wReq);
                ThreadPool.RegisterWaitForSingleObject((t as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
                await t.ContinueWith(task =>
                {
                    try
                    {
                        HttpWebResponse wResp = (HttpWebResponse)task.Result;
                        if (wResp.StatusCode == HttpStatusCode.OK)
                        {
                            Stream RESULT_STREAM = wResp.GetResponseStream();
                            StreamReader RESULT_READER = new StreamReader(RESULT_STREAM);
                            jsonData = RESULT_READER.ReadToEnd();

                            JObject jObj = JObject.Parse(jsonData);
                            int statusCode = (int)jObj["STATUS_CODE"];
                            string message = (string)jObj["MESSAGE"];

                            Debug.WriteLine("HartBit : " + statusCode.ToString() + " | " + message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Popup.Show(ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Popup.Show(ex.Message);
            }
        }

        private static void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                Popup.Show("TimeOut");
                HttpWebRequest request = state as HttpWebRequest;
                if (request != null)
                {
                    request.Abort();
                }
            }
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


