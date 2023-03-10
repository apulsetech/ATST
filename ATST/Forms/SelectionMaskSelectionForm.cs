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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class SelectionMaskSelectionForm : Form, ReaderEventListener
    {

        private SelectionCriterias.Criteria mCriteria;

        public delegate void SelectionMaskResultHandler(SelectionCriterias.Criteria criteria);
        public event SelectionMaskResultHandler ResultEvent;

        public SelectionMaskSelectionForm(SelectionCriterias.Criteria criteria)
        {
            InitializeComponent();
            Initialize(criteria);
            this.KeyPreview = true;
        }

        private void Initialize(SelectionCriterias.Criteria criteria)
        {
            SharedValues.Reader.SetEventListener(this);
            EnableControls(false);

            if (criteria == null)
            {
                mCriteria = new SelectionCriterias.Criteria(SelectionCriterias.Target.SELECTED,
                    SelectionCriterias.Bank.EPC,
                    "",
                    16,
                    0,
                    SelectionCriterias.Action.ASLINVA_DSLINVB);
            }
            else
            {
                mCriteria = criteria;
            }

            UpdateControlStates();
            EnableControls(true);
        }

        private void EnableControls(bool enable)
        {
            cbxBank.Enabled = enable;
            cbxTarget.Enabled = enable;
            cbxAction.Enabled = enable;
            txbOffset.Enabled = enable;
            txbLength.Enabled = enable;
            txbMask.Enabled = enable;
        }

        private void UpdateControlStates()
        {
            cbxBank.Items.AddRange(SharedValues.RfidSelctionMemTypesArray);
            cbxBank.SelectedIndex =
                cbxBank.FindString(SharedValues.RfidMemTypesArray[mCriteria.Bank]);

            cbxTarget.Items.AddRange(SharedValues.RfidSelectionTargetsArray);
            cbxTarget.SelectedIndex =
                cbxTarget.FindString(SharedValues.RfidSelectionTargetsArray[mCriteria.Target]);

            cbxAction.Items.AddRange(SharedValues.RfidSelectionActionsArray);
            cbxAction.SelectedItem =
                cbxAction.FindString(SharedValues.RfidSelectionActionsArray[mCriteria.Action]);

            txbOffset.Text = mCriteria.Offset + " " + "Bit(s)";
            txbLength.Text = mCriteria.Length + " " + "Bit(s)";
            txbMask.Text = mCriteria.Mask;
        }

        public void OnReaderDeviceStateChanged(Reader reader, DeviceEvent state)
        {
            switch (state)
            {
                case DeviceEvent.CONNECTED:
                    break;
                case DeviceEvent.DISCONNECTED:
                    Invoke(new Action(delegate ()
                    {
                        EnableControls(false);
                    }));
                    break;
            }
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

        private void cbxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbxBank.Focused)
            {
                return;
            }
            mCriteria.Bank = cbxBank.SelectedIndex;
        }

        private void cbxTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbxTarget.Focused)
            {
                return;
            }
            mCriteria.Target = cbxTarget.SelectedIndex;
        }

        private void cbxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbxAction.Focused)
            {
                return;
            }
            mCriteria.Action = cbxAction.SelectedIndex;
        }

        private void txbOffset_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c >= '0') && (c <= '9') || (c == 0xf7) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbOffset_Enter(object sender, EventArgs e)
        {
            txbOffset.Text = null;
        }

        private void txbOffset_Leave(object sender, EventArgs e)
        {
            string textValue = txbOffset.Text;
            if ((textValue != null) && (textValue.Length > 0))
            {
                mCriteria.Offset = Convert.ToInt16(textValue, CultureInfo.CurrentCulture);
            }
            txbOffset.Text = mCriteria.Offset + " " + "Bit(s)";
        }

        private void txbLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c >= '0') && (c <= '9') || (c == 0x7f) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbLength_Enter(object sender, EventArgs e)
        {
            txbLength.Text = null;
        }

        private void txbLength_Leave(object sender, EventArgs e)
        {
            string textValue = txbLength.Text;
            if ((textValue != null) && (textValue.Length > 0))
            {
                mCriteria.Length = Convert.ToInt16(textValue, CultureInfo.CurrentCulture);
            }
            txbLength.Text = mCriteria.Length + " " + "Bit(s)";
        }

        private void txbMask_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbMask_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if ((c >= '0') && (c <= '9') || (c == 0x7f) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txbMask_Enter(object sender, EventArgs e)
        {
            txbMask.Text = null;
        }

        private void txbMask_Leave(object sender, EventArgs e)
        {
            string textValue = txbMask.Text;
            if ((textValue != null) && (textValue.Length > 0))
            {
                mCriteria.Mask = textValue;
            }
            mCriteria.Mask = mCriteria.Mask.ToUpper(CultureInfo.CurrentCulture);
            txbMask.Text = mCriteria.Mask;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mCriteria.IsValid)
            {
                ResultEvent(mCriteria);
            }
            else
            {
                Popup.Show(Properties.Resources.StringSelectionMaskParamIsNoValid);
            }

            SharedValues.Reader.RemoveEventListener(this);

            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (SharedValues.Reader != null)
            {
                SharedValues.Reader.RemoveEventListener(this);
            }

            Dispose();
        }

        private void SelectionMaskSelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Dispose();
            }
        }
    }
}
