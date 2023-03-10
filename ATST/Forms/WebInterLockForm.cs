using ATST.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (!cbxAPIServer.Text.Contains(" ") && !cbxGatheringServer.Text.Contains(" "))
            {
                if (!Config.APiServerUri.Contains(cbxAPIServer.Text)) 
                    Config.APiServerUri.Add(cbxAPIServer.Text);


                if (!Config.GatheringServerUri.Contains(cbxGatheringServer.Text))
                    Config.GatheringServerUri.Add(cbxGatheringServer.Text);

                Assembly assembly = LoadConfig();
                Config.Save(assembly);
            }
        }

        private Assembly LoadConfig()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Config.Load(assembly);

            return assembly;
        }

        private void LoadApiInfo()
        {
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //XmlApiInfoSave();

            SharedValues.ApiServerUri = "http://" + "139.150.71.23" + ":" + txbApiServerPort.Text; //cbxAPIServer.Text + txbApiServerPort.Text;
            SharedValues.GatheringServerUri = "http://" + "139.150.71.49" + ":" + txbGatheringServerPort.Text; //cbxGatheringServer.Text + txbGatheringServerPort.Text;

             DataFormat.GetDeviceList();
        }

        private void cbxAPIServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxAPIServer.Text = cbxAPIServer.SelectedText;
        }

        private void cbxAPIServer_Enter(object sender, EventArgs e)
        {
            
        }

        private void cbxAPIServer_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c == 0x0D)
            {
                this.ActiveControl = cbxGatheringServer;
            }
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
