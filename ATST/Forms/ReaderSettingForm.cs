using Apulsetech.Event;
using Apulsetech.Rfid;
using Apulsetech.Rfid.Type;
using ATST.Data;
using ATST.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class ReaderSettingForm : Form, ReaderEventListener
    {
        private bool mRemoteFilterEnabled = false;
        private bool mBeepUniqueEnabled = false;
        private bool mRfidInventoryFilterEnabled = true;
        private bool mRfidInventorySoundEnabled = true;
        private bool mRfidInventoryHoldTriggerEnabled = true;
        private bool mRfidInventoryContinuousModeEnabled = true;
        private bool mRfidInventoryToggleEnabled = true;
        private bool mRfidInventoryPcReportEnabled = true;
        private bool mRfidInventoryRssiReportEnabled = true;
        private bool mRfidInventoryPhaseReportEnabled = false;
        private bool mRfidInventoryChannelReportEnabled = false;
        private bool mRfidInventoryFastIdReportEnabled = false;

        private int mCurrentAccesTimeout = 0;
        private int mAccesTimeout = 0;
        private int mCurrentAccessRetryInterval = 0;
        private int mAccessRetryInterval = 0;
        private int mCurrentRfTxOnTime = 0;
        private int mRfTxOnTime = 0;
        private int mCurrentRfTxOffTime = 0;
        private int mRfTxOffTime = 0;

        private List<string> SaveTextString = new List<string>();

        public ReaderSettingForm()
        {
            InitializeComponent();

            if (SharedValues.Reader == null)
            {
                Popup.Show(Properties.Resources.StringInvalidRfidInstance);
                Dispose();
                return;
            }

            InitializeRfidSettings();
            Initialize();
        }

        private void InitializeControls()
        {
            SaveTextString.Add(txbTimeout.Text);
            SaveTextString.Add(txbInterval.Text);
            SaveTextString.Add(txbTxOnTime.Text);
            SaveTextString.Add(txbTxOffTime.Text);
        }

        private async void Initialize()
        {
            SharedValues.Reader.SetEventListener(this);
            EnableControls(false);
            await UpdateControlsSates().ConfigureAwait(true);
            InitializeControls();
            EnableControls(true);
        }

        private async Task UpdateControlsSates()
        {
            mCurrentAccesTimeout = await SharedValues.Reader.GetAccessTimeoutAsync().ConfigureAwait(true);
            mAccesTimeout = mCurrentAccesTimeout;
            txbTimeout.Text = mAccesTimeout + "Ms";

            mCurrentAccessRetryInterval = await SharedValues.Reader.GetAccessRetryIntervalAsync().ConfigureAwait(true);
            mAccessRetryInterval = mCurrentAccessRetryInterval;
            txbInterval.Text = mAccessRetryInterval + "Ms";

            mCurrentRfTxOnTime = await SharedValues.Reader.GetTxOnTimeAsync().ConfigureAwait(true);
            mRfTxOnTime = mCurrentRfTxOnTime;
            txbTxOnTime.Text = mRfTxOnTime + "Ms";

            mCurrentRfTxOffTime = await SharedValues.Reader.GetTxOffTimeAsync().ConfigureAwait(true);   
            mRfTxOffTime = mCurrentRfTxOffTime;
            txbTxOffTime.Text = mRfTxOffTime + "Ms";
        }

        private void EnableControls(bool enable)
        {
            cbxRemoteFilter.Enabled = enable;
            cbxBeepUniqueOnly.Enabled = enable;
            cbxFilter.Enabled = enable;
            cbxSound.Enabled = enable;
            cbxTrigger.Enabled = enable;
            cbxContinuousMode.Enabled = enable;
            cbxToggle.Enabled = enable;
            cbxPC.Enabled = enable;
            cbxRssi.Enabled = enable;
            cbxPhase.Enabled = enable;
            cbxChannel.Enabled = enable;
            cbxFastID.Enabled = enable;

            txbInterval.Enabled = enable;
            txbTimeout.Enabled = enable;
            txbTxOffTime.Enabled = enable;
            txbTxOnTime.Enabled = enable;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
        }

        private void InitializeRfidSettings()
        {
            cbxRemoteFilter.Checked = mRemoteFilterEnabled;
            cbxBeepUniqueOnly.Checked = mBeepUniqueEnabled;
            cbxFilter.Checked = mRfidInventoryFilterEnabled;
            cbxSound.Checked = mRfidInventorySoundEnabled;
            cbxTrigger.Checked = mRfidInventoryHoldTriggerEnabled;
            cbxContinuousMode.Checked = mRfidInventoryContinuousModeEnabled;
            cbxToggle.Checked = mRfidInventoryToggleEnabled;
            cbxPC.Checked = mRfidInventoryPcReportEnabled;
            cbxRssi.Checked = mRfidInventoryRssiReportEnabled;
            cbxPhase.Checked = mRfidInventoryPhaseReportEnabled;
            cbxChannel.Checked = mRfidInventoryChannelReportEnabled;
            cbxFastID.Checked = mRfidInventoryFastIdReportEnabled;
        }

        private void SaveSettings()
        {
            int Timeout = Convert.ToInt32(txbTimeout.Text.Replace("Ms", ""));
            int Interval = Convert.ToInt32(txbInterval.Text.Replace("Ms", ""));
            int TxOnTime = Convert.ToInt32(txbTxOnTime.Text.Replace("Ms", ""));
            int TxOffTime = Convert.ToInt32(txbTxOffTime.Text.Replace("Ms", ""));

            SharedValues.Reader.SetAccessTimeout(Timeout);
            SharedValues.Reader.SetAccessRetryInterval(Interval);
            SharedValues.Reader.SetTxOnTime(TxOnTime);
            SharedValues.Reader.SetTxOffTime(TxOffTime);

            Popup.Show(Properties.Resources.StringReaderSettingSuccess);
        }

        private void ReaderSettingForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(296, 478);
        }

        private async void cbxContinuousMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxContinuousMode.Focused)
            {
                return;
            }

            cbxContinuousMode.Enabled = false;

            int mode = cbxContinuousMode.Checked ? RFID.InventoryMode.MULTI : RFID.InventoryMode.SINGLE;
            if (await SharedValues.Reader.SetInventoryModeAsync(mode).ConfigureAwait(true) == RfidResult.SUCCESS)
            {
                mRfidInventoryContinuousModeEnabled = cbxContinuousMode.Checked;
            }
            else
            {
                cbxContinuousMode.Checked = !cbxContinuousMode.Checked;
            }

            cbxContinuousMode.Enabled = true;
        }

        private async void cbxToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxToggle.Focused)
            {
                return;
            }

            cbxToggle.Enabled = false;

            mRfidInventoryToggleEnabled = cbxToggle.Checked;

            if (mRfidInventoryToggleEnabled)
            {
                await SharedValues.Reader.SetToggleAsync(RFID.ON).ConfigureAwait(true);
            }
            else
            {
                await SharedValues.Reader.SetToggleAsync(RFID.OFF).ConfigureAwait(true);
            }

            cbxToggle.Enabled = true;
        }   

        private async void cbxBeepUniqueOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxBeepUniqueOnly.Focused)
            {
                return;
            }

            cbxBeepUniqueOnly.Enabled = false;

            mBeepUniqueEnabled = cbxBeepUniqueOnly.Checked;
            await SharedValues.Reader.SetInventoryBeepUniqueTagOnlyStateAsync(mBeepUniqueEnabled ? RFID.ON : RFID.OFF).ConfigureAwait(true);

            cbxBeepUniqueOnly.Enabled = true;
        }
         
        private async void cbxRemoteFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxRemoteFilter.Focused)
            {
                return;
            }

            cbxRemoteFilter.Enabled = false;

            mRemoteFilterEnabled = cbxRemoteFilter.Checked;
            await SharedValues.Reader.SetInventoryEpcFilterStateAsync(mRemoteFilterEnabled ? RFID.ON : RFID.OFF).ConfigureAwait(true);

            cbxRemoteFilter.Enabled = true;


        }

        private async void cbxRssi_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxRssi.Focused)
            {
                return;
            }

            cbxRssi.Enabled = false;    

            mRfidInventoryRssiReportEnabled = cbxRssi.Checked;
            if (mRfidInventoryRssiReportEnabled)
            {
                await SharedValues.Reader.SetInventoryRssiReportStateAsync(RFID.ON).ConfigureAwait(true);
            }
            else
            {
                await SharedValues.Reader.SetInventoryRssiReportStateAsync(RFID.OFF).ConfigureAwait(true);
            }

            cbxRssi.Enabled = true;
        }

        private async void cbxPhase_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxPhase.Focused)
            {
                return;
            }

            cbxPhase.Enabled = false;

            mRfidInventoryPhaseReportEnabled = cbxPhase.Checked;
            if (mRfidInventoryPhaseReportEnabled)
            {
                await SharedValues.Reader.SetInventoryPhaseReportStateAsync(RFID.ON).ConfigureAwait(true);
            }
            else
            {
                await SharedValues.Reader.SetInventoryPhaseReportStateAsync(RFID.OFF).ConfigureAwait(true);
            }

            cbxPhase.Enabled = true;
        }

        private void cbxSound_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxSound.Focused)
            {
                return;
            }

            mRfidInventorySoundEnabled = cbxSound.Checked;
        }

        private void cbxTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxTrigger.Focused)
            {
                return;
            }

            mRfidInventoryHoldTriggerEnabled = cbxTrigger.Checked;  
        }

        private void cbxFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxFilter.Focused)
            {
                return;
            }

            mRfidInventoryFilterEnabled = cbxFilter.Checked;
        }

        private async void cbxPC_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxPC.Focused)
            {
                return;
            }

            cbxPC.Enabled = false;

            mRfidInventoryPcReportEnabled = cbxPC.Checked;
            if (mRfidInventoryPcReportEnabled)
            {
                await SharedValues.Reader.SetInventoryPcReportStateAsync(RFID.ON).ConfigureAwait(true);
            }
            else
            {
                await SharedValues.Reader.SetInventoryPcReportStateAsync(RFID.OFF).ConfigureAwait(true);
            }

            cbxPC.Enabled = true;
        }

        private async void cbxChannel_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxChannel.Focused)
            {
                return;
            }

            cbxChannel.Enabled = false;

            mRfidInventoryChannelReportEnabled = cbxChannel.Checked;
            if (mRfidInventoryChannelReportEnabled)
            {
                await SharedValues.Reader.SetInventoryChannelReportStateAsync(RFID.ON).ConfigureAwait(true);
            }
            else
            {
                await SharedValues.Reader.SetInventoryChannelReportStateAsync(RFID.OFF).ConfigureAwait(true);
            }

            cbxChannel.Enabled = true;
        }

        private async void cbxFastID_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxFastID.Focused)
            {
                return;
            }

            cbxFastID.Enabled = false;

            mRfidInventoryFastIdReportEnabled = cbxFastID.Checked;
            if (mRfidInventoryFastIdReportEnabled)
            {
                await SharedValues.Reader.SetInventoryFastIdReportStateAsync(RFID.ON).ConfigureAwait(true);
            }
            else
            {
                await SharedValues.Reader.SetInventoryFastIdReportStateAsync(RFID.OFF).ConfigureAwait(true);
            }

            cbxFastID.Enabled = true;
        }

        private void txbTimeout_MouseClick(object sender, MouseEventArgs e)
        {
            txbTimeout.Text = null;
        } 

        private void txbInterval_MouseClick(object sender, MouseEventArgs e)
        {
            txbInterval.Text = null;
        }

        private void txbTxOnTime_MouseClick(object sender, MouseEventArgs e)
        {
            txbTxOnTime.Text = null;
        }

        private void txbTxOffTime_MouseClick(object sender, MouseEventArgs e)
        {
            txbTxOffTime.Text = null;
        }

        private void txbTimeout_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0' && c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txbInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0' && c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbTxOnTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0' && c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbTxOffTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0' && c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbTimeout_TextChanged(object sender, EventArgs e)
        {
            if (txbTimeout.Text.Length > 0 && SaveTextString.Count > 0)
                SaveTextString[0] = txbTimeout.Text;
        }

        private void txbInterval_TextChanged(object sender, EventArgs e)
        {
            if (txbInterval.Text.Length > 0 && SaveTextString.Count > 0)
            {
                SaveTextString[1] = txbInterval.Text;
            }
        }

        private void txbTxOnTime_TextChanged(object sender, EventArgs e)
        {
            if (txbTxOnTime.Text.Length > 0 && SaveTextString.Count > 0)
            {
                SaveTextString[2] = txbTxOnTime.Text;
            }
        }

        private void txbTxOffTime_TextChanged(object sender, EventArgs e)
        {
            if (txbTxOffTime.Text.Length > 0 && SaveTextString.Count > 0)
            {
                SaveTextString[3] = txbTxOffTime.Text;
            }
        }

        private void txbTimeout_Leave(object sender, EventArgs e)
        {
            int length = txbTimeout.Text?.Length ?? 0;

            if (length > 0)
            {
                txbTimeout.Text = txbTimeout.Text + "Ms";
            }
            else
            {
                txbTimeout.Text = SaveTextString[0];
            }
        }

        private void txbInterval_Leave(object sender, EventArgs e)
        {
            int length = txbInterval.Text?.Length ?? 0;

            if (length > 0)
            {
                txbInterval.Text = txbInterval.Text + "Ms";
            }
            else
            {
                txbInterval.Text = SaveTextString[1];
            }
        }

        private void txbTxOnTime_Leave(object sender, EventArgs e)
        {
            int length = txbTxOnTime.Text?.Length ?? 0;

            if (length > 0)
            {
                txbTxOnTime.Text = txbTxOnTime.Text + "Ms";
            }
            else
            {
                txbTxOnTime.Text = SaveTextString[2];
            }
        }

        private void txbTxOffTime_Leave(object sender, EventArgs e)
        {
            int length = txbTxOffTime.Text?.Length ?? 0;

            if (length > 0)
            {
                txbTxOffTime.Text = txbTxOffTime.Text + "Ms";
            }
            else
            {
                txbTxOffTime.Text = SaveTextString[3];
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void OnReaderDeviceStateChanged(Reader reader, DeviceEvent state)
        {
        }

        public void OnReaderEvent(Reader reader, int eventId, int result, string data)
        {
        }

        public void OnReaderRemoteKeyEvent(Reader reader, int action, int keyCode)
        {
        }

        public void OnReaderRemoteSettingChanged(Reader reader, int type, object value)
        {
        }
       
    }
}
