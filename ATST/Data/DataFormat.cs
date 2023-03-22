using ATST.Diagnotics;
using ATST.Forms.Diagnotics;
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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uri = System.Uri;

namespace ATST.Data
{
    public class DataFormat
    {
        private static string jsonData = String.Empty;

        private static AsyncLock s_lock = new AsyncLock();

        public static async Task GetDeviceList(WebInterLockForm form)
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

                        Log.WriteLine("INFO. GetDeviceList - Successed to Stream Read.");
                        Debug.WriteLine(statusCode.ToString() + " | " + message);
                        RESULT_STREAM.Flush();
                        RESULT_STREAM.Close();
                        RESULT_READER.Close();
                    }
                });
                t.Dispose();

                DataList mResponsData = new DataList();
                mResponsData = JsonConvert.DeserializeObject<DataList>(jsonData);

                foreach (var v in mResponsData.datalist)
                {
                    Debug.WriteLine(v.DEVICE_ID + " | " + v.DEVICE_NAME);
                }

                await Task.Run(() =>
                {
                    ListViewItem item;
                    if (form.listViewDeviceList.InvokeRequired)
                    {
                        form.Invoke(new MethodInvoker(delegate ()
                        {
                            form.listViewDeviceList.Items.Clear();
                            for (int i = 0; i < mResponsData.datalist.Count; i++)
                            {
                                item = new ListViewItem(mResponsData.datalist[i].DEVICE_ID);
                                item.SubItems.Add(mResponsData.datalist[i].DEVICE_NAME);
                                form.listViewDeviceList.Items.Add(item);
                            }
                        }));
                    }
                });

                SharedValues.WebInterLockCheck = true;

                GC.Collect();
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
                Popup.Show(ex.Message);
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

            string str = JsonData.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            wReq.ContentLength = bytes.Length;

            Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
            ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
            await requestStream.ContinueWith(task =>
            {
                try
                {

                    using (StreamWriter streamwriter = new StreamWriter(task.Result))
                    {
                        streamwriter.Write(JsonData.ToString());
                        streamwriter.Flush();
                    }
                    Log.WriteLine("INFO. UpdateColRowNum - Successed to Stream Read.");
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                    Log.WriteLine("ERROR. UpdateColRowNum - Failed to Stream Read.");
                }
            });
            requestStream.Dispose();


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
                        RESULT_STREAM.Flush();
                        RESULT_STREAM.Close();
                        RESULT_READER.Close();
                    }
                }
                catch (Exception ex)
                {
                    Popup.Show(ex.Message);
                }
            });
            t.Dispose();
        }

        public static async void AlerInputEvent(string deviceId, string workerId, int location, string date, string epc, int count, int stock_count, int input_count)
        {
            try
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

                string items = JsonData.ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(items);
                wReq.ContentLength = (long)bytes.Length;

                using (await s_lock.LockAsync())
                {
                    Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
                    ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
                    await requestStream.ContinueWith(task =>
                    {
                        try
                        {
                            Stream stream = task.Result;

                            using (StreamWriter streamwriter = new StreamWriter(task.Result))
                            {
                                streamwriter.Write(JsonData.ToString());
                                streamwriter.Flush();
                            }

                        }
                        catch (Exception ex)
                        {
                            Popup.Show(ex.Message);
                            Log.WriteLine("ERROR. AlerInputEvent - Failed to Stream Write.");
                        }
                    });
                    requestStream.Dispose();

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

                                Debug.WriteLine("INPUT : " + statusCode.ToString() + "|" + message);
                                RESULT_STREAM.Flush();
                                RESULT_STREAM.Close();
                                RESULT_READER.Close();

                            }
                        }
                        catch (Exception ex)
                        {
                            Popup.Show(ex.Message);
                            Log.WriteLine("ERROR. AlerInputEvent - Failed to Stream Read.");
                        }
                    });
                    t.Dispose();

                }
            }
            catch (TargetInvocationException ex)
            {
                Log.WriteLine(ex.Message);
            }

        }

        public async static void AlertOutputEvent(string deviceId, string workerId, int location, string date, string epc, int count, int stock_count, int output_count)
        {
            try
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

                string items = JsonData.ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(items);
                wReq.ContentLength = (long)bytes.Length;

                using (await s_lock.LockAsync())
                {
                    Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
                    ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
                    await requestStream.ContinueWith(task =>
                    {
                        try
                        {

                            using (StreamWriter streamwriter = new StreamWriter(task.Result))
                            {
                                streamwriter.Write(JsonData.ToString());
                                streamwriter.Flush();
                            }

                        }
                        catch (Exception ex)
                        {
                            Popup.Show(ex.Message);
                            Log.WriteLine("ERROR. AlertOutputEvent - Failed to Stream Write.");
                        }
                    });
                    requestStream.Dispose();

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

                                Debug.WriteLine("OUTPUT : " + statusCode.ToString() + "|" + message);
                                RESULT_STREAM.Flush();
                                RESULT_STREAM.Close();
                                RESULT_READER.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            Popup.Show(ex.Message);
                            Log.WriteLine("ERROR. AlertOutputEvent - Failed to Stream Read.");
                        }
                    });
                    t.Dispose();
                }
            }
            catch (TargetInvocationException ex)
            {
                Log.WriteLine(ex.Message);
            }
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

                string items = JsonData.ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(items);
                wReq.ContentLength = (long)bytes.Length;

                Task<Stream> requestStream = Task.Factory.FromAsync<Stream>(wReq.BeginGetRequestStream, wReq.EndGetRequestStream, wReq);
                ThreadPool.RegisterWaitForSingleObject((requestStream as IAsyncResult).AsyncWaitHandle, TimeoutCallback, wReq, 3000, true);
                await requestStream.ContinueWith(task =>
                {
                    try
                    {
                        using (StreamWriter streamwriter = new StreamWriter(task.Result))
                        {
                            streamwriter.Write(JsonData.ToString());
                            streamwriter.Flush();
                        }

                    }
                    catch (Exception ex)
                    {
                        //Popup.Show(ex.Message);
                        Log.WriteLine("ERROR. RequestHartBit - Failed to Stream Write.");
                    }
                });
                requestStream.Dispose();


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
                            RESULT_STREAM.Flush();
                            RESULT_STREAM.Close();
                            RESULT_READER.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        //Popup.Show(ex.Message);
                        Log.WriteLine("ERROR. RequestHartBit - Failed to Stream Read.");
                    }
                });
                t.Dispose();
            }
            catch
            {

            }

        }

        public async static Task<int> alterDeviceStartEvent()
        {
            int statusCode = 201;
            string message = String.Empty;

            try
            {
                HttpWebRequest wReq;
                Uri uri = new Uri(SharedValues.GatheringServerUri + "/alertDeviceStartEvent/" + SharedValues.DeviceId);
                wReq = (HttpWebRequest)WebRequest.Create(uri);
                wReq.Method = "GET";


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
                        statusCode = (int)jObj["STATUS_CODE"];
                        message = (string)jObj["MESSAGE"];

                        Log.WriteLine("INFO. alterDeviceStartEvent - Successed to Stream Read.");
                        Debug.WriteLine(statusCode.ToString() + " | " + message);
                        RESULT_STREAM.Flush();
                        RESULT_STREAM.Close();
                        RESULT_READER.Close();

                    }
                });
                t.Dispose();
            }
            catch (Exception ex)
            {
                Popup.Show(ex.Message);
                Log.WriteLine("ERROR. alterDeviceStartEvent - Failed to Stream Read.");
            }

            return statusCode;
        }

        private static void TimeoutCallback(object state, bool timedOut)
        {
            if (timedOut)
            {
                //Popup.Show("TimeOut");
                HttpWebRequest request = state as HttpWebRequest;
                Uri uri = request.RequestUri;
                //Popup.Show(uri.ToString());
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


