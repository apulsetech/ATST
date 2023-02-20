using Apulsetech.Event;
using Apulsetech.Rfid.Type;
using Apulsetech.Rfid;
using ATST.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Globalization;
using ATST.Diagnotics;
using Apulsetech.Rfid.Vendor.Chip.Impinj;
using System.Diagnostics;
using static Apulsetech.Rfid.Type.RFID.Untraceable;
using ATST.Util;

namespace ATST.Forms
{
    public partial class MainForm
    {

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

            Invoke(new Action(delegate()
            {
                AddTagItem(epc, rssi, port);
            }));
        }

        private int SavePort = -1;

        private void AddTagItem(string epc,
                                string rssi,
                                string port)
        {
            //출고 로직
            output_proccess(epc, port, rssi);

            //입고 로직
            input_proccess(epc, port, rssi);
        }

        private async void btn_rfid_connect_Click(object sender, EventArgs e)
        {
            btn_rfid_connect.Enabled = false;

            if (SharedValues.Reader == null)
            {
                if (SharedValues.ConnectionType == SharedValues.InterfaceType.SERIAL)
                {
                    SharedValues.Reader = await Reader.GetReaderAsync(btn_test.Text, 115200, 128).ConfigureAwait(true);
                    Log.WriteLine("INFO. Reader Setting ConnectionType({0}).", SharedValues.ConnectionType);

                }
                else if (SharedValues.ConnectionType == SharedValues.InterfaceType.TCP)
                {
                    SharedValues.Reader = await Reader.GetReaderAsync(ipAddressBox.GetIpData(), 5000, false, 8).ConfigureAwait(true);
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

                        btn_rfid_connect.Text = Properties.Resources.StringDeviceConnect;
                        EnableControl(true);
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
