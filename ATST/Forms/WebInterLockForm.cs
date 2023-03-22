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

namespace ATST.Forms.Diagnotics
{
    public partial class WebInterLockForm : Form
    {

        private string apiUri = string.Empty;
        private string gatheringUri = string.Empty;

        public WebInterLockForm()
        {
            InitializeComponent();
            LoadApiInfo();
            this.ActiveControl = cbxAPIServer.maskedTextBox;

            cbxAPIServer.maskedTextBox.KeyPress += (KeyPressEventHandler)((sender, e) =>
            {
                char c = e.KeyChar;
                if (c == 0x0D)
                    this.ActiveControl = cbxGatheringServer.maskedTextBox;
            });

            
        }

        private void XmlApiInfoSave()
        {
            cbxAPIServer.Text.Replace("-", "");
            cbxGatheringServer.Text.Replace("-", "");

            apiUri = string.Concat(cbxAPIServer.Text.Where(x => !char.IsWhiteSpace(x)));
            gatheringUri = string.Concat(cbxGatheringServer.Text.Where(x => !char.IsWhiteSpace(x)));

            Config.mApiServerPort = Convert.ToInt32(txbApiServerPort.Text);
            Config.mGatheringServerPort = Convert.ToInt32(txbGatheringServerPort.Text);

            if (!Config.APiServerUri.Contains(apiUri))
                Config.APiServerUri.Add(apiUri);
            if (!Config.GatheringServerUri.Contains(gatheringUri))
                Config.GatheringServerUri.Add(gatheringUri);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Config.Save(assembly);
        }

        private void LoadApiInfo()
        {
            txbApiServerPort.Text = Config.mApiServerPort.ToString();
            txbGatheringServerPort.Text = Config.mGatheringServerPort.ToString();

            foreach (var u in Config.APiServerUri)
            {
                if (!cbxAPIServer.Items.Contains(u))
                    cbxAPIServer.Items.Add(u);
            }

            foreach (var u in Config.GatheringServerUri)
            {
                if (!cbxGatheringServer.Items.Contains(u))
                    cbxGatheringServer.Items.Add(u);
            }

            SelectIndex();
        }

        private void SelectIndex()
        {
            if (cbxAPIServer.Items.Count > 0)
            {
                string item = cbxAPIServer.Items[0].ToString();
                string[] spstring = item.Split('.');
                string sb = fixAddressType(spstring);
                cbxAPIServer.Text = sb.ToString();
            }

            if (cbxGatheringServer.Items.Count > 0)
            {
                string item = cbxGatheringServer.Items[0].ToString();
                string[] spstring = item.Split('.');
                string sb = fixAddressType(spstring);
                cbxGatheringServer.Text = sb.ToString();
            }
        }

        private string fixAddressType(string[] spstring)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < spstring.Length; i++)
            {
                if (i != spstring.Length - 1)
                {
                    if (spstring[i].Length == 2)
                    {
                        sb.Append(spstring[i] + " .");

                    }
                    else if (spstring[i].Length == 1)
                    {
                        sb.Append(spstring[i] + "  .");
                    }
                    else if (spstring[i].Length == 0)
                    {
                        sb.Append("  .");
                    }
                    else
                    {
                        sb.Append(spstring[i] + ".");
                    }
                }
                else
                {
                    if (spstring[i].Length == 2)
                    {
                        sb.Append(spstring[i] + " ");

                    }
                    else if (spstring[i].Length == 1)
                    {
                        sb.Append(spstring[i] + "  ");
                    }
                    else if (spstring[i].Length == 0)
                    {
                        sb.Append("  ");
                    }
                    else
                    {
                        sb.Append(spstring[i]);
                    }
                }
            }

            return sb.ToString();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            XmlApiInfoSave();

            SharedValues.ApiServerUri = "http://" + apiUri + ":" + txbApiServerPort.Text;
            SharedValues.GatheringServerUri = "http://" + gatheringUri + ":" + txbGatheringServerPort.Text;

            bool result = InternetConnectedCheck.IsInternetConnected();
            if (result)
            {
                btnSave.Enabled = false;
                await DataFormat.GetDeviceList(this).ConfigureAwait(true);
                btnSave.Enabled = true;
            }
            else
            {
                Popup.Show(Properties.Resources.StringNetworkConnectionFail);
                Log.WriteLine(Properties.Resources.StringNetworkConnectionFail);
            }
        }

        private void cbxAPIServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxAPIServer.Items[cbxAPIServer.SelectedIndex].ToString();
            string[] spstring = item.Split('.');
            string sb = fixAddressType(spstring);
            cbxAPIServer.Text = sb.ToString();
        }

        private void cbxGatheringServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = cbxGatheringServer.Items[cbxGatheringServer.SelectedIndex].ToString();
            string[] spstring = item.Split('.');
            string sb = fixAddressType(spstring);
            cbxGatheringServer.Text = sb.ToString();
        }

        private void cbxAPIServer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c >= '0' && c <= '9' || (c == 0x7c) || (c == 0x08) || (c == 0x0D))
            {
                e.Handled = false;
                if (c == 0x0D)
                {
                    this.ActiveControl = cbxGatheringServer;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbApiServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c >= '0' && c <= '9' || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbGatheringServerPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c >= '0' && c <= '9' || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private async void listViewDeviceList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewDeviceList.SelectedItems.Count == 1)
            {
                SharedValues.DeviceId = listViewDeviceList.SelectedItems[0].SubItems[0].Text;
                int statuscode = await DataFormat.alterDeviceStartEvent().ConfigureAwait(true);
                if (statuscode == 200) {
                    MessageBox.Show(Properties.Resources.StringDeviceSelect);
                    Log.WriteLine("INFO. Seleted as {0} device.", SharedValues.DeviceId);
                    this.Dispose();
                    //this.Close();
                }
                else
                {
                    Popup.Show(Properties.Resources.StringDeviceNotRegistered);
                    Log.WriteLine("ERROR. Device selection failed.");
                }
            }
        }

        private void WebInterLockForm_Load(object sender, EventArgs e)
        {

        }
    }

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
}
