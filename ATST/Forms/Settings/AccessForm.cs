using ATST.Data;
using ATST.Forms.Diagnotics;
using ControlIpAddressBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserControls.Controls;
using CircularProgressBar;
using Apulsetech.Event;
using Apulsetech.Rfid;

namespace ATST.Forms.Settings
{
    public partial class AccessForm : Form
    {
        private MainForm mainform;

        public AccessForm(MainForm main)
        {
            InitializeComponent();

            object[] AntPortCount = Config.AntPortCount.Select(x => x.ToString()).ToArray();
            cbxAntennaPort.Items.AddRange(AntPortCount);

            ipAddressComboBox1.AddItem(Config.APiServerUri.ToArray());
            ipAddressComboBox2.AddItem(Config.GatheringServerUri.ToArray());
            txbApiServerPort.Text = Config.mApiServerPort.ToString();
            txbGatheringServerPort.Text = Config.mGatheringServerPort.ToString();

            mainform = main;

        }

        private void lbSerial_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxSerial.DisplayMember = "Display";
            SharedValues.SelectedPort = (cbxSerial.SelectedItem as dynamic).Display;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ipAddressComboBox2_Load(object sender, EventArgs e)
        {

        }

        private void ipAddressComboBox1_Load(object sender, EventArgs e)
        {

        }

        private void rbtn_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnEthernet.Checked)
            {
                rbtnSerial.Checked = false;
                lbSerial.Visible = false;
                cbxSerial.Enabled = false;
                cbxSerial.Visible = false;

                lbAddress.Visible = true;
                ipAddressMiniBox1.Enabled = true;
                ipAddressMiniBox1.Visible = true;

                if (cbxAntennaPort.Text.Length > 0)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }

            }
            else if (rbtnSerial.Checked)
            {
                rbtnEthernet.Checked = false;
                lbAddress.Visible = false;
                ipAddressMiniBox1.Enabled = false;
                ipAddressMiniBox1.Visible = false;

                lbSerial.Visible = true;
                cbxSerial.Enabled = true;
                cbxSerial.Visible = true;

                if (cbxSerial.Text.Length > 0 && cbxAntennaPort.Text.Length > 0)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
           
        }


        private void ServerLinkage_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnServerLinkage_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbtnServerLinkageNonChecked.Checked)
            {
                rbtnServerLinkageNonChecked.Visible = false;
                if (txbGatheringServerPort.Text.Length < 1)
                    button1.Enabled = false;

                rbtnServerLinkageChecked.Checked = true;
                rbtnServerLinkageChecked.Visible = true;
                label5.ForeColor = SystemColors.ControlText;
                label6.ForeColor = SystemColors.ControlText;
                ipAddressComboBox1.Enabled = true;
                txbApiServerPort.Enabled = true;
                ipAddressComboBox2.Enabled = true;
                txbGatheringServerPort.Enabled = true;
            }
            
        }

        private void rbtnServerLinkageChecked_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbtnServerLinkageChecked.Checked)
            {
                rbtnServerLinkageNonChecked.Visible = true;
                

                rbtnServerLinkageChecked.Visible = false;
                label5.ForeColor = SystemColors.ControlLight;
                label6.ForeColor = SystemColors.ControlLight;
                ipAddressComboBox1.Enabled = false;
                txbApiServerPort.Enabled = false;
                ipAddressComboBox2.Enabled = false;
                txbGatheringServerPort.Enabled = false;
            }
        }

        private void btnDeviceSearch_Click(object sender, EventArgs e)
        {
            if (rbtnSerial.Checked)
            {
                InitializePorts();
            }
            else if (rbtnEthernet.Checked)
            {
                using (SearchForm dlg = new SearchForm())
                {
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ipAddressMiniBox1.SetIpData(SharedValues.Ethernet);
                    }
                }
            }
        }

        private void InitializePorts()
        {
            cbxSerial.Items.Clear();
            cbxSerial.DisplayMember = "Display";
            cbxSerial.ValueMember = "Value";

            List<string> ComportList = new List<string>();

            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%Com%'"))
            {
                var ComportNames = SerialPort.GetPortNames();
                var ComPorts = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                var ComPortList = ComportNames.Select(n => ComPorts.FirstOrDefault(s => s.Contains(n))).ToArray();

                string comPort;
                for (int i = 0; i < ComPortList.Length; i++)
                {
                    comPort = Convert.ToString(ComPortList[i]);
                    if (!String.IsNullOrEmpty(comPort)) { ComportList.Add(comPort); }
                }
            }

            string[] comPorts = ComportList.ToArray();
            if (comPorts.Length > 0)
            {
                for (int i = 0; i < comPorts.Length; i++)
                {
                    cbxSerial.Items.Add(new { Display = comPorts[i].Substring(comPorts[i].IndexOf("(") + 1, comPorts[i].IndexOf(")") - comPorts[i].IndexOf("(") - 1), Value = comPorts[i] });
                }
            }

        }

        private void AccessForm_Load(object sender, EventArgs e)
        {
            InitializePorts();

            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (rbtnSerial.Checked)
            {
                SharedValues.SelectedPort = (cbxSerial.SelectedItem as dynamic).Display;
                SharedValues.SelectedPortCount = Convert.ToInt32(cbxAntennaPort.Text);

                if (rbtnServerLinkageNonChecked.Visible)
                {
                    await mainform.Rfid_Connect().ConfigureAwait(true);
                    if (SharedValues.ReaderConnected)
                        this.Close();
                }
                
                if (!rbtnServerLinkageNonChecked.Visible)
                {
                    if (!Config.APiServerUri.Contains(ipAddressComboBox1.GetIpData()))
                        Config.APiServerUri.Add(ipAddressComboBox1.GetIpData());
                    if (!Config.GatheringServerUri.Contains(ipAddressComboBox2.GetIpData()))
                        Config.GatheringServerUri.Add(ipAddressComboBox2.GetIpData());
                    Config.mApiServerPort = Convert.ToInt32(txbApiServerPort.Text);
                    Config.mGatheringServerPort = Convert.ToInt32(txbGatheringServerPort.Text);

                    ipAddressComboBox1.AddItem(Config.APiServerUri.ToArray());
                    ipAddressComboBox2.AddItem(Config.GatheringServerUri.ToArray());

                    SharedValues.ApiServerUri = ipAddressComboBox1.GetIpData() + ":" + txbApiServerPort.Text;
                    SharedValues.GatheringServerUri = ipAddressComboBox2.GetIpData() + ":" + txbGatheringServerPort.Text;

                    using (WebInterLockForm dig = new WebInterLockForm(mainform))
                    {
                        if (dig.ShowDialog() == DialogResult.OK)
                        {
                            if (SharedValues.ReaderConnected)
                                this.Close();
                        }
                    }
                }
                
            }
            else if (rbtnEthernet.Checked)
            {
                SharedValues.EthernetIpAddress = ipAddressMiniBox1.GetIpData();
                SharedValues.SelectedPortCount = Convert.ToInt32(cbxAntennaPort.SelectedItem.ToString());

                if (rbtnServerLinkageNonChecked.Visible)
                {
                    await mainform.Rfid_Connect().ConfigureAwait(true);
                    if (SharedValues.ReaderConnected)
                        this.Close();
                }

                if (!rbtnServerLinkageNonChecked.Visible)
                {
                    if (!Config.APiServerUri.Contains(ipAddressComboBox1.GetIpData()))
                        Config.APiServerUri.Add(ipAddressComboBox1.GetIpData());
                    if (!Config.GatheringServerUri.Contains(ipAddressComboBox2.GetIpData()))
                        Config.GatheringServerUri.Add(ipAddressComboBox2.GetIpData());
                    Config.mApiServerPort = Convert.ToInt32(txbApiServerPort.Text);
                    Config.mGatheringServerPort = Convert.ToInt32(txbGatheringServerPort.Text);

                    ipAddressComboBox1.AddItem(Config.APiServerUri.ToArray());
                    ipAddressComboBox2.AddItem(Config.GatheringServerUri.ToArray());

                    SharedValues.ApiServerUri = ipAddressComboBox1.GetIpData() + ":" + txbApiServerPort.Text;
                    SharedValues.GatheringServerUri = ipAddressComboBox2.GetIpData() + ":" + txbGatheringServerPort.Text;

                    using (WebInterLockForm dig = new WebInterLockForm(mainform))
                    {
                        if (dig.ShowDialog() == DialogResult.OK)
                        {
                            if (SharedValues.ReaderConnected)
                                this.Close();
                        }
                    }
                }
            }
        }

        private void txbGatheringServerPort_TextChanged(object sender, EventArgs e)
        {
            if (txbGatheringServerPort.Text.Length > 0 && txbApiServerPort.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void txbApiServerPort_TextChanged(object sender, EventArgs e)
        {
            if (txbGatheringServerPort.Text.Length > 0 && txbApiServerPort.Text.Length > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void cbxSerial_TextChanged(object sender, EventArgs e)
        {
            if (rbtnSerial.Checked)
            {
                if (cbxSerial.Text.Length > 0 && cbxAntennaPort.Text.Length > 0)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }

        private void cbxAntennaPort_TextChanged(object sender, EventArgs e)
        {
            if (rbtnSerial.Checked)
            {
                if (cbxSerial.Text.Length > 0 && cbxAntennaPort.Text.Length > 0)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            else if (rbtnEthernet.Checked)
            {
                if (cbxAntennaPort.Text.Length > 0)
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AccessForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
