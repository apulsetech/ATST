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

        private void AddTagItem(string epc,
                                string rssi,
                                string port)
        {
            ListViewItem item = listview_rfid_inventory_tag_data.FindItemWithText(epc);
            if (item != null)
            {
                item.SubItems[1].Text = rssi;
                item.SubItems[2].Text = port;
            }
            else
            {
                string[] items = new string[3];
                items[0] = epc;
                items[1] = rssi;
                items[2] = port;
                item = new ListViewItem(items);
                listview_rfid_inventory_tag_data.BeginUpdate();
                listview_rfid_inventory_tag_data.Items.Add(item);
                listview_rfid_inventory_tag_data.EndUpdate();
            }
        }


        private async void btn_rfid_connect_Click(object sender, EventArgs e)
        {
            btn_rfid_connect.Enabled = false;

            if (SharedValues.Reader == null)
            {
                if (SharedValues.ConnectionType == SharedValues.InterfaceType.SERIAL)
                {
                    await Reader.GetReaderAsync("COM11", 115200, 8).ConfigureAwait(true);
                }
                else if (SharedValues.ConnectionType == SharedValues.InterfaceType.TCP)
                {
                    SharedValues.Reader = await Reader.GetReaderAsync(ipAddressBox.GetIpData(), 5000, false, 8).ConfigureAwait(true);
                }
                else // ConnectionType != SERIAL && ConnectionType != TCP
                {
                    return;
                }

                if (SharedValues.Reader != null)
                {
                    SharedValues.Reader.SetEventListener(this);
                    if (await SharedValues.Reader.StartAsync().ConfigureAwait(true))
                    {
                        await LoadRfidSettings().ConfigureAwait(true);

                        btn_rfid_connect.Enabled = true;
                    }
                    else // error - Connection failed
                    {

                    }
                }
                else // error - Connection failed
                {

                }
            }
            else // SharedValues.Reader != null
            {
                if (await SharedValues.Reader.GetConnectionStatusAsync().ConfigureAwait(true))
                {
                    await SharedValues.Reader.DestroyAsync().ConfigureAwait(true);
                }
                SharedValues.Reader.RemoveEventListener(this);
                SharedValues.Reader = null;

                btn_rfid_connect.Enabled = true;
            }
        }

        private async Task LoadRfidSettings()
        {
            await SharedValues.Reader.SetInventoryAntennaPortReportStateAsync(RFID.ON).ConfigureAwait(true);
        }
    }
}
