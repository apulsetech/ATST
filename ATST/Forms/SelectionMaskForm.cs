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
    public partial class SelectionMaskForm : Form, ReaderEventListener
    {

        private SelectionCriterias mCurrentSelectionCriterias;

        private int mSelectionMaskNodeEditIndex = -1;

        private bool mSelectionMaskEnabled = false;

        public SelectionMaskForm()
        {
            InitializeComponent();
            this.KeyPreview = true;

            if (SharedValues.Reader == null)
            {
                Popup.Show(Properties.Resources.StringInvalidRfidInstance);
                Dispose();
                return;
            }

            Initialize();
        }

        private void Initialize()
        {
            SharedValues.Reader.SetEventListener(this);
            EnableControls(false);
            InitializeControls();
            UpdateControlStates();
            EnableControls(true);

        }

        private void EnableControls(bool enabled)
        {
            cbxUseSelectionMask.Enabled = enabled;
            treeviewMask.Enabled = enabled;
            btnADD.Enabled = enabled;
            btnCancel.Enabled = enabled;
            btnClear.Enabled = enabled;
            btnRemove.Enabled = enabled;
            btnSave.Enabled = enabled;
            cbxSLFlag.Enabled = enabled;
            cbxSession.Enabled = enabled;
            cbxTaget.Enabled = enabled;

        }

        private void InitializeControls()
        {
            treeviewMask.CheckBoxes = true;
            treeviewMask.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            treeviewMask.DrawNode += new DrawTreeNodeEventHandler(DrawNode);
        }

        private async void UpdateControlStates()
        {
            if (SharedValues.Reader == null)
            {
                return;
            }

            mSelectionMaskEnabled =
                await SharedValues.Reader.GetSelectionMaskStateAsync().ConfigureAwait(true) == RFID.ON;
            cbxUseSelectionMask.Checked = mSelectionMaskEnabled;

            mCurrentSelectionCriterias = await SharedValues.Reader.GetSelectionMaskAsync().ConfigureAwait(true);
            if (mCurrentSelectionCriterias == null)
            {
                mCurrentSelectionCriterias = new SelectionCriterias();
            }

            List<SelectionCriterias.Criteria> criterias =
                    mCurrentSelectionCriterias.Criterias;
            int criteriaCount = criterias.Count;
            lbEntry.Text =
                criteriaCount.ToString(CultureInfo.CurrentCulture) + " Entry(s)";

            foreach (SelectionCriterias.Criteria c in criterias)
            {
                AddSelectionMaskNode(c);
            }

            if (criteriaCount > 0)
            {
                btnRemove.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
                btnClear.Enabled = false;
            }

            cbxSession.Items.AddRange(
                SharedValues.RfidInventorySessionArray);
            int session = await SharedValues.Reader.GetSessionAsync().ConfigureAwait(true);
            if ((session >= RFID.Session.SESSION_S0) &&
                (session <= RFID.Session.SESSION_S3))
            {
                cbxSession.SelectedIndex = session;
            }
            else
            {
                cbxSession.SelectedIndex =
                    RFID.Session.SESSION_S0;
            }

            cbxTaget.Items.AddRange(
                SharedValues.RfidInventoryTargetsArray);
            int target = await SharedValues.Reader.GetInventorySessionTargetAsync().ConfigureAwait(true);
            if ((target >= RFID.InvSessionTarget.TARGET_A) &&
                (target <= RFID.InvSessionTarget.TARGET_B))
            {
                cbxTaget.SelectedIndex = target;
            }
            else
            {
                cbxTaget.SelectedIndex =
                    RFID.InvSessionTarget.TARGET_A;
            }

            cbxSLFlag.Items.AddRange(
                SharedValues.RfidInventorySelectionsArray);
            int selection = await SharedValues.Reader.GetInventorySelectionTargetAsync().ConfigureAwait(true);
            if ((selection >= RFID.InvSelectionTarget.ALL) &&
                (selection <= RFID.InvSelectionTarget.SELECTED))
            {
                cbxSLFlag.SelectedIndex = selection;
            }
        }

        private void HandleSelectionMaskResult(object sender)
        {
            SelectionCriterias.Criteria criteria = (SelectionCriterias.Criteria)sender;
            if (criteria != null)
            {
                if (mSelectionMaskNodeEditIndex != -1)
                {
                    mCurrentSelectionCriterias.Replace(mSelectionMaskNodeEditIndex, criteria);
                    ReplaceSelectionMaskNode(criteria);
                }
                else
                {
                    mCurrentSelectionCriterias.Add(criteria);
                    AddSelectionMaskNode(criteria);
                    lbEntry.Text = mCurrentSelectionCriterias.Count + " " + Properties.Resources.StringEntry;
                    btnClear.Enabled = true;
                }
            }
        }

        private void AddSelectionMaskNode(SelectionCriterias.Criteria criteria)
        {
            if (criteria == null)
            {
                Popup.Show(
                    Properties.Resources.StringSelectionInvalidSelectionMask);
                return;
            }

            string mainNodeText = SharedValues.RfidSelectionActionsArray[criteria.Action]
                + ", " + SharedValues.RfidSelctionMemTypesArray[criteria.Bank];

            TreeNode mainNode = treeviewMask.Nodes.Add(mainNodeText);
            mainNode.Tag = criteria;
            string subNodeText = Properties.Resources.StringBank +
                ": " + SharedValues.RfidSelctionMemTypesArray[criteria.Bank];
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringTarget +
                ": " + SharedValues.RfidSelectionTargetsArray[criteria.Target];
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringAction +
                ": " + SharedValues.RfidSelectionActionsArray[criteria.Action];
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringOffset +
                ": " + criteria.Offset + " " + "Bit(s)";
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringLength +
                ": " + criteria.Length + " " + "Bit(s)";
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringMask + ": " + criteria.Mask.ToUpper(CultureInfo.CurrentCulture);
            mainNode.Nodes.Add(subNodeText);
        }

        private void ReplaceSelectionMaskNode(SelectionCriterias.Criteria criteria)
        {
            if (criteria == null)
            {
                Popup.Show(Properties.Resources.StringSelectionInvalidSelectionMask);
                return;
            }

            string mainNodeText = SharedValues.RfidSelectionActionsArray[criteria.Action]
                + ", " + SharedValues.RfidSelctionMemTypesArray[criteria.Bank];

            TreeNode mainNode = new TreeNode(mainNodeText);
            mainNode.Tag = criteria;
            string subNodeText = Properties.Resources.StringBank +
                ": " + SharedValues.RfidSelctionMemTypesArray[criteria.Bank];
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringTarget +
                ": " + SharedValues.RfidSelectionTargetsArray[criteria.Target];
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringAction +
                ": " + SharedValues.RfidSelectionActionsArray[criteria.Action];
            subNodeText = Properties.Resources.StringOffset +
                " " + criteria.Offset + " " + "Bit(s)";
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringLength +
                ": " + criteria.Length + " " + "Bit(s)";
            mainNode.Nodes.Add(subNodeText);
            subNodeText = Properties.Resources.StringMask + ": " + criteria.Mask.ToUpper(CultureInfo.CurrentCulture);
            mainNode.Nodes.Add(subNodeText);

            treeviewMask.Nodes.RemoveAt(mSelectionMaskNodeEditIndex);
            treeviewMask.Nodes.Insert(mSelectionMaskNodeEditIndex, mainNode);
            mSelectionMaskNodeEditIndex = -1;
        }

        private void SaveSelectionMaskSettings()
        {
            int result = SharedValues.Reader.SetSelectionMaskState(
                cbxUseSelectionMask.Checked ? RFID.ON : RFID.OFF);
            if (result != RfidResult.SUCCESS)
            {
                Popup.Show(
                    Properties.Resources.StringSelectionFailedToSetSElectionMaskState);
            }

            if (mCurrentSelectionCriterias != null)
            {
                if (mCurrentSelectionCriterias.Count > 0)
                {
                    result = SharedValues.Reader.SetSelectionMask(mCurrentSelectionCriterias);
                    if (result == RfidResult.SUCCESS)
                    {
                        mCurrentSelectionCriterias.Clear();
                    }
                    else
                    {
                        Popup.Show(
                            Properties.Resources.StringSelectionFailedToSetSElectionMaskState);
                    }
                }
                else
                {
                    result = SharedValues.Reader.RemoveSelectionMask();
                    if (result != RfidResult.SUCCESS)
                    {
                        Popup.Show(
                            Properties.Resources.StringSelectionFailedToSetSElectionMaskState);
                    }
                }
            }
        }

        private void SaveInventorySettings()
        {
            int result = SharedValues.Reader.SetSession(
                cbxSession.SelectedIndex);
            if (result != RfidResult.SUCCESS)
            {
                Popup.Show("Session Setting ERROR");
            }

            result = SharedValues.Reader.SetInventorySessionTarget(
                cbxTaget.SelectedIndex);
            if (result != RfidResult.SUCCESS)
            {
                Popup.Show("Target Setting ERROR");
            }

            result = SharedValues.Reader.SetInventorySelectionTarget(
                cbxSLFlag.SelectedIndex);
            if (result != RfidResult.SUCCESS)
            {
                Popup.Show("SelectionTarget Setting ERROR");
            }

        }

        private void RemoveSelectionMaskNode(int index)
        {
            if ((index >= 0) && (index < treeviewMask.Nodes.Count))
            {
                treeviewMask.Nodes.RemoveAt(index);
            }

            if (treeviewMask.Nodes.Count == 0)
            {
                btnClear.Enabled = false;
            }
            else
            {
                btnClear.Enabled = true;
            }
        }

        private void RemoveAllSelectionMaskNode()
        {
            treeviewMask.Nodes.Clear();
            btnRemove.Enabled = false;
            btnClear.Enabled = false;
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            using (SelectionMaskSelectionForm form = new SelectionMaskSelectionForm(null))
            {
                form.ResultEvent +=
                    new SelectionMaskSelectionForm.SelectionMaskResultHandler(HandleSelectionMaskResult);
                form.ShowDialog();
            }
        }

        private void treeviewMask_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeviewMask.SelectedNode;
            mSelectionMaskNodeEditIndex = node.Index;
            using (SelectionMaskSelectionForm form = new SelectionMaskSelectionForm((SelectionCriterias.Criteria)node.Tag))
            {
                form.ResultEvent +=
                    new SelectionMaskSelectionForm.SelectionMaskResultHandler(HandleSelectionMaskResult);
                if (form.ShowDialog() != DialogResult.OK)
                {
                    mSelectionMaskNodeEditIndex = -1;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSelectionMaskSettings();
            SaveInventorySettings();
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = (treeviewMask.Nodes.Count - 1); i  >= 0; i--)
            {
                if (treeviewMask.Nodes[i].Checked)
                {
                    mCurrentSelectionCriterias.RemoveAt(i);
                    RemoveSelectionMaskNode(i);
                    
                }
            }

            lbEntry.Text = mCurrentSelectionCriterias.Count + " " + Properties.Resources.StringEntry;

            btnRemove.Enabled = false;
            if (mCurrentSelectionCriterias.Count == 0)
            {
                btnClear.Enabled = false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mCurrentSelectionCriterias.Clear();
            RemoveAllSelectionMaskNode();
            lbEntry.Text = mCurrentSelectionCriterias.Count + " " + Properties.Resources.StringEntry;
            btnClear.Enabled = false;
        }

        private void treeviewMask_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int checkedCount = 0;
            foreach (TreeNode n in treeviewMask.Nodes)
            {
                if (n.Checked)
                {
                    checkedCount++;
                }
            }

            if (checkedCount > 0)
            {
                btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
            }
        }

        private void SelectionMaskForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Dispose();
            }
        }

        private void DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.DrawDefault = true;
            }
            else
            {
                Color backColor, foreColor;
                if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
                {
                    backColor = SystemColors.Highlight;
                    foreColor = SystemColors.HighlightText;
                }
                else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
                {
                    backColor = SystemColors.HotTrack;
                    foreColor = SystemColors.HighlightText;
                }
                else
                {
                    backColor = e.Node.BackColor;
                    foreColor = e.Node.ForeColor;
                }

                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, e.Node.Bounds);
                }

                TextRenderer.DrawText(e.Graphics,
                    e.Node.Text,
                    this.treeviewMask.Font,
                    e.Node.Bounds,
                    foreColor,
                    backColor);

                if ((e.State & TreeNodeStates.Focused) == TreeNodeStates.Focused)
                {
                    ControlPaint.DrawFocusRectangle(
                        e.Graphics, e.Node.Bounds, foreColor, backColor);
                }

                e.DrawDefault = false;
            }
        }
    }
}
