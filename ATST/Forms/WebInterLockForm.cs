using ATST.Data;
using ATST.Diagnotics;
using ATST.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Apulsetech.Rfid.Type.SelectionCriterias;

namespace ATST.Forms.Diagnotics
{
    public partial class WebInterLockForm : Form
    {
        private MainForm mainform;

        public WebInterLockForm(MainForm main)
        {
            InitializeComponent();
            if (!InternetConnectedCheck.IsInternetConnected())
            {
                MessageBox.Show(Properties.Resources.StringNetworkConnectionFail);
                Log.WriteLine(Properties.Resources.StringNetworkConnectionFail);
                this.Close();
            }

            mainform = main;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            int statuscode = await DataFormat.alterDeviceStartEvent().ConfigureAwait(true);
            if (statuscode == 200)
            {
                //MessageBox.Show(Properties.Resources.StringDeviceSelect);
                Log.WriteLine("INFO. Seleted as {0} device.", SharedValues.DeviceId);

                await mainform.Rfid_Connect().ConfigureAwait(true);
                if (SharedValues.ReaderConnected)
                {
                    this.DialogResult = DialogResult.OK;    
                    this.Close();
                }
            }
            else
            {
                Popup.Show(Properties.Resources.StringDeviceNotRegistered);
                Log.WriteLine("ERROR. Device selection failed.");
            }
        }

        private async void listViewDeviceList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewDeviceList.SelectedItems.Count == 1)
            {
                SharedValues.DeviceId = listViewDeviceList.SelectedItems[0].SubItems[0].Text;
                SharedValues.DeviceName = listViewDeviceList.SelectedItems[0].SubItems[1].Text;
                int statuscode = await DataFormat.alterDeviceStartEvent().ConfigureAwait(true);
                if (statuscode == 200)
                {
                    //MessageBox.Show(Properties.Resources.StringDeviceSelect);
                    Log.WriteLine("INFO. Seleted as {0} device.", SharedValues.DeviceId);

                    await mainform.Rfid_Connect().ConfigureAwait(true);
                    if (SharedValues.ReaderConnected)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    Popup.Show(Properties.Resources.StringDeviceNotRegistered);
                    Log.WriteLine("ERROR. Device selection failed.");
                }
            }
        }

        private async void WebInterLockForm_Load(object sender, EventArgs e)
        {
            await DataFormat.GetDeviceList(this);
        }

        private void listViewDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDeviceList.SelectedItems.Count != 0)
            {
                int SelectRow = listViewDeviceList.SelectedItems[0].Index;
                SharedValues.DeviceId = listViewDeviceList.Items[SelectRow].SubItems[0].Text;
                SharedValues.DeviceName = listViewDeviceList.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void listViewDeviceList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {

        }
    }

    /*
    // Masked ComboBox
    public class MaskedComboBox : ComboBox
    {
        public MaskedTextBox maskedTextBox = new MaskedTextBox();
        public MaskedComboBox()
        {
            maskedTextBox.Width = this.Width + 19;
            maskedTextBox.Mask = "000.000.000.000";
            maskedTextBox.ForeColor = Color.AliceBlue;
            this.Controls.Add(maskedTextBox);
            this.SelectedIndexChanged += (EventHandler)((sender, e) =>
            {
                maskedTextBox.Focus();
                maskedTextBox.SelectAll();
            });

        }

        public override string Text
        {
            get
            {
                return maskedTextBox.Text;
            }
            set
            {
                maskedTextBox.Text = value;
            }
        }
    }
    */
}
