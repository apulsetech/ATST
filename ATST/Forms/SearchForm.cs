using Apulsetech.Remote;
using Apulsetech.Remote.Type;
using Apulsetech.Type;
using ATST.Data;
using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class SearchForm : Form
    {
        private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_TYPE = 110;
        private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_ADDRESS = 260;
        //private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_BARCODE = 100;
        //private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_RFID = 100;
        //private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_STATUS = 70;
        //private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_FORCE_CONNECTION = 100;
        private const int SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_INFO =
            SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_TYPE +
            SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_ADDRESS;
            //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_BARCODE +
            //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_RFID +
            //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_STATUS +
            //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_FORCE_CONNECTION;

        public delegate void OpenFormReturn(SearchForm form);
        public static event OpenFormReturn OpenFormEvent;

        private RemoteDeviceScanner mRemoteDeviceScanner;
        private MsgEvent mMainFormEvent;
        private MsgEvent mMsgEvent = new MsgEvent();

        private System.Windows.Forms.Timer mScanTimeOutTimer;
        private int mScanTimeOut = 30000;


        private int mSelectedRemoteDeviceIndex = -1;
        public SearchForm()
        {
            InitializeComponent();
            Initialize();
            //OpenFormEvent(this);
            this.KeyPreview = true;

            
        }

        private void Initialize()
        {
            mRemoteDeviceScanner = new RemoteDeviceScanner(mMsgEvent);
            mMsgEvent.msgEvent += new MsgEvent.MsgEventDelegate(HandleEvent);

            listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceName,
                listviewDeviceList.Size.Width - SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_INFO);
            listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceType,
                SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_TYPE);
            listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceAddress,
                SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_ADDRESS);
            //listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceBarcode,
                //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_BARCODE);
            //listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceRfid,
                //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_RFID);
            //listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceStatus,
                //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_STATUS);
            //listviewDeviceList.Columns.Add(Properties.Resources.StringDeviceConnection,
                //SIZE_REMOTE_DEVICE_LISTVIEW_COLUMN_FORCE_CONNECTION);

            InitInterfaceEthernet();
        }

        public void HandleEvent(object sender, MsgEventArg e)
        {
            if (e != null)
            {

            }
            else
            {
                return;
            }

            switch (e.Arg1)
            {
                case Msg.E2S_ADD_DEVICE:
                    {
                        RemoteDevice device = (RemoteDevice)e.Arg4;

                        string[] items = new string[7];
                        items[0] = device.Name;
                        items[1] = device.TypeName;
                        items[2] = device.Address.ToUpper(CultureInfo.CurrentCulture);
                        items[3] = "";
                        items[4] = "";
                        items[5] = "";
                        items[6] = "";
                        ListViewItem item = new ListViewItem(items);
                        item.Tag = device;
                        Invoke(new Action(delegate ()
                        {
                            listviewDeviceList.Items.Add(item);
                            if (!btnClear.Enabled)
                            {
                                btnClear.Enabled = true;
                            }
                        }));
                    }
                    break;
            }
        }

        private void InitInterfaceEthernet()
        {
            mRemoteDeviceScanner.EthernetScanEnabled = true;
        }

        private void btnStartSearch_Click(object sender, EventArgs e)
        {
            if (mRemoteDeviceScanner.Started)
            {
                Log.WriteLine("INFO. Stop RemoteDevice Scan.");
                mRemoteDeviceScanner.ScanRemoteDevice(false);
                btnStartSearch.Text = Properties.Resources.StringDeviceNoSearch;
            }
            else
            {
                Log.WriteLine("INFO. Start RemoteDevice Scan.");
                listviewDeviceList.Items.Clear();
                mRemoteDeviceScanner.ScanRemoteDevice(true);
                btnStartSearch.Text = Properties.Resources.StringDeviceSearch;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listviewDeviceList.Items.Clear();
            btnClear.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mRemoteDeviceScanner.Started)
                mRemoteDeviceScanner.ScanRemoteDevice(false);
            SharedValues.Ethernet = listviewDeviceList.Items[listviewDeviceList.FocusedItem.Index].SubItems[2].Text;//텍스트 전송
            if (SharedValues.Ethernet != null)
            {
                Log.WriteLine("INFO. Set RemoteDevice Address.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                Log.WriteLine("ERROR. Failed Set RemoteDevice Address.");
        }

        private void listviewDeviceList_DoubleClick(object sender, EventArgs e)
        {
            if (mRemoteDeviceScanner.Started)
                mRemoteDeviceScanner.ScanRemoteDevice(false);
            MainForm mainform = (MainForm)Owner;
            SharedValues.Ethernet = listviewDeviceList.Items[listviewDeviceList.FocusedItem.Index].SubItems[2].Text;//텍스트 전송
            if (SharedValues.Ethernet != null)
            {
                Log.WriteLine("INFO. Set RemoteDevice Address.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                Log.WriteLine("ERROR. Failed Set RemoteDevice Address.");
        }

        private void SearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC키를 눌렀을 때 창이 닫히게 처리함.
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
