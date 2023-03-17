using Apulsetech.Event;
using Apulsetech.Rfid.Type;
using Apulsetech.Rfid;
using ATST.Data;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ATST.Diagnotics;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class MainForm
    {
        private const int HARTBIT_INTERVAL = 1000;
        private int delay_time = HARTBIT_INTERVAL;

        public virtual void OnReaderDeviceStateChanged(Reader reader, DeviceEvent state)
        {
            switch (state)
            {

                case DeviceEvent.CONNECTED:
                    break;

                case DeviceEvent.DISCONNECTED:
                    Invoke(new Action(delegate ()
                    {
                        if (SharedValues.ReaderConnected)
                        {
                            SharedValues.Reader = null;
                            btn_rfid_connect.Enabled = true;
                            SharedValues.ReaderConnected = false;
                        }

                        //Thread t = new Thread( () => MessageBox.Show("Test"));
                        //t.Start();
                    }));
                    break;
            }
        }

        public virtual void OnReaderEvent(Reader reader, int eventId, int result, string data)
        {
            switch (eventId)
            {
                case Reader.READER_CALLBACK_EVENT_INVENTORY:
                    if (result == RfidResult.SUCCESS)
                    {
                        if (data != null)
                        {
                            ProcessRfidTagData(data);
                        }
                    }
                    break;
                case Reader.READER_CALLBACK_EVENT_START_INVENTORY:
                case Reader.READER_CALLBACK_EVENT_STOP_INVENTORY:
                default:
                    break;
            }
        }
        public virtual void OnReaderRemoteKeyEvent(Reader reader, int action, int keyCode)
        {

        }

        public virtual void OnReaderRemoteSettingChanged(Reader reader, int type, object value)
        {

        }

        private void ProcessRfidTagData(string data)
        {
            string epc = String.Empty;
            string rssi = String.Empty;
            string port = String.Empty;

            string[] dataItems = data.Split(';');

            foreach (string dataItem in dataItems)
            {
                if (dataItem.Contains("rssi"))
                {
                    int point = dataItem.IndexOf(':') + 1;
                    rssi = dataItem.Substring(point, dataItem.Length - point);
                }
                else if (dataItem.Contains("antenna"))
                {
                    int point = dataItem.IndexOf(':') + 1;
                    port = dataItem.Substring(point, dataItem.Length - point);
                }
                else
                {
                    epc = dataItem;
                }
            }

            Invoke(new Action(delegate ()
            {
                AddTagItem(epc, rssi, port);
            }));
        }

        private int currentPort = 0;
        private int SavePort = -1;
        private int SavePort2 = -1;

        private void AddTagItem(string epc,
                                string rssi,
                                string port)
        {


            currentPort = Convert.ToInt32(port);

            // 출고
            if (SharedValues.NumberOfAntennaPorts > 1)
                output_proccess(epc, port, rssi);

            // 입고 카운트 및 입고 처리
            input_count(epc, port, rssi);

            //input_proccess(epc, port, rssi);

            // 리스트 뷰 출력
            output_to_list(port);

        }

        private async Task one_port_proccess()
        {
            int delay_time = SharedValues.Reader.GetDwellTime(0);

            if (mRfidInventoryStarted)
            {
                await Task.Delay(delay_time);

                one_output_proccess(currentPort);

                await one_port_proccess();
            }
            else
            {
                return;
            }
        }

        
        private async Task request_hartbit()
        {
            if (SharedValues.tokenSource.IsCancellationRequested)
            {
                return;
            }
            await Task.Delay(delay_time, SharedValues.tokenSource.Token).ContinueWith(task => { });

            await DataFormat.RequestHartBit(SharedValues.DeviceId, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            await request_hartbit();
        }

        private void output_to_list(string port)
        {
            var datacount = SharedValues.mTagSaveDictionary.Where(x => x.Value.Port.Equals(Int32.Parse(port))).ToList();
            tablePanel1.DataViewTagCntNum(Int32.Parse(port), datacount.Count());
        }

        private async void btn_rfid_connect_Click(object sender, EventArgs e)
        {
            btn_rfid_connect.Enabled = false;

            if (SharedValues.Reader == null)
            {
                if (SharedValues.ConnectionType == SharedValues.InterfaceType.SERIAL)
                {
                    SharedValues.Reader = await Reader.GetReaderAsync(SharedValues.SelectedPort, 115200, Config.mAntCount).ConfigureAwait(true);
                    Log.WriteLine("INFO. Reader Setting ConnectionType({0}).", SharedValues.ConnectionType);

                }
                else if (SharedValues.ConnectionType == SharedValues.InterfaceType.TCP)
                {
                    SharedValues.Reader = await Reader.GetReaderAsync(ipAddressBox.GetIpData(), 5000, false, Config.mAntCount).ConfigureAwait(true);
                    Log.WriteLine("INFO. Reader Setting ConnectionType({0}).", SharedValues.ConnectionType);
                }
                else // ConnectionType != SERIAL && ConnectionType != TCP
                {
                    Log.WriteLine("ERROR. NonExistent ConnectionType.");
                    return;
                }

                if (SharedValues.Reader != null)
                {
                    Log.WriteLine("INFO. Start Device Connect.");
                    // 현재 폼에 이벤트 발생 설정
                    SharedValues.Reader.SetEventListener(this);
                    if (await SharedValues.Reader.StartAsync().ConfigureAwait(true))
                    {
                        Log.WriteLine("INFO. Sucessed Device Connect.");
                        await LoadRfidSettings().ConfigureAwait(true);

                        SharedValues.NumberOfAntennaPorts = SharedValues.Reader.GetAntennaPortCount();

                        btn_rfid_connect.Text = Properties.Resources.StringDeviceConnect;
                        EnableControl(true);

                        LoadConfigInfo(SharedValues.NumberOfAntennaPorts);

                        SharedValues.tokenSource = new CancellationTokenSource();
                        if (SharedValues.WebInterLockCheck)
                            await request_hartbit();
                    }
                    else // error - Connection failed
                    {
                        Log.WriteLine("ERROR. Failed Device Connect.");
                    }
                }
                else // error - Connection failed
                {
                    Log.WriteLine("ERROR. Failed Device Connect(No Reader Info).");
                }
            }
            else // SharedValues.Reader != null
            {
                if (await SharedValues.Reader.GetConnectionStatusAsync().ConfigureAwait(true))
                {
                    await SharedValues.Reader.DestroyAsync().ConfigureAwait(true);
                    Log.WriteLine("INFO. Sucessed Device DisConnect.");

                    if (SharedValues.tokenSource != null)
                    {
                        SharedValues.tokenSource.Cancel();
                        SharedValues.tokenSource.Dispose();
                    }
                }

                Log.WriteLine("INFO. RemoveEventListener().");
                SharedValues.Reader.RemoveEventListener(this);
                SharedValues.Reader = null;

                btn_rfid_connect.Text = Properties.Resources.StringDeviceDisConnect;
                EnableControl(false);
            }
        }

        private async Task LoadRfidSettings()
        {
            Log.WriteLine("INFO. SetInventoryAntennaPortReportStateAsync({0}).", RFID.ON);
            await SharedValues.Reader.SetInventoryAntennaPortReportStateAsync(RFID.ON).ConfigureAwait(true);
        }
    }
}
