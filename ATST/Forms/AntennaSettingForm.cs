using Apulsetech.Rfid.Type;
using ATST.Data;
using ATST.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ATST.Forms
{
    public partial class AntennaSettingForm : Form
    {

        private bool[] mAntennaStates;
        private int[] mAntennaPowerGains;
        private int[] mAntennaDwellTimes;

        private object mAntennaAllEnableCheckBox = new object();
        private object mAntennaAllPowerGainComboBox = new object();
        private object mAntennaAllDwellTimeTextBox = new object();

        private object[] mAntennaLabels = new object[16];
        private object[] mAntennaEnableCheckBoxs = new object[16];
        private object[] mAntennaPowerGainComboBoxes = new object[16];
        private object[] mAntennaDwellTimeTextBoxes = new object[16];

        private TextBox SaveTextBox = new TextBox();

        private List<TextBox> SaveTextBoxList = new List<TextBox>(SharedValues.NumberOfAntennaPorts);

        public delegate void RfidAntennaRsultHandler(bool[] Enables, int[] gains, int[] dwells);
        public event RfidAntennaRsultHandler ResultEvent;

        public AntennaSettingForm()
        {
            InitializeComponent();


            if (SharedValues.Reader == null)
            {
                Dispose();
                return;
            }

            Initialize();

            this.KeyPreview = true;
        }

        private async void Initialize()
        {
            InitializeControls();
            EnableControls(false);
            await LoadAntenaInformation().ConfigureAwait(true);
            UpdateAntennaControlStatesByPortGroup(tabAntennaPorts.SelectedIndex);
            EnableControls(true);
            cbxAllPowerGain.Enabled = false;
            txbAllDwellTime.Enabled = false;
            cbAllEnable.Enabled = false;
        }

        private void EnableControls(bool enabled)
        {
            foreach (TabPage page in tabAntennaPorts.TabPages)
            {
                page.Enabled = enabled;
            }

            int groupIndex = tabAntennaPorts.SelectedIndex;
            int baseNumberOfAntennaPorts = SharedValues.NumberOfAntennaPorts - 16 * groupIndex;
            int numberOfAntennaPorts = Math.Min(baseNumberOfAntennaPorts, 16);

            for (int i = 0; i < numberOfAntennaPorts; i++)
            {
                ((CheckBox)mAntennaEnableCheckBoxs[i]).Enabled = enabled;
                ((ComboBox)mAntennaPowerGainComboBoxes[i]).Enabled = enabled;
                ((TextBox)mAntennaDwellTimeTextBoxes[i]).Enabled = enabled;

                ((CheckBox)mAntennaAllEnableCheckBox).Enabled = enabled;
                ((ComboBox)mAntennaAllPowerGainComboBox).Enabled = enabled;
                ((TextBox)mAntennaAllDwellTimeTextBox).Enabled = enabled;
            }

            btnSave.Enabled = enabled;
            btnCancle.Enabled = enabled;
        }

        // 컨트롤 초기화
        private void InitializeControls()
        {
            int numberOfAntennaTabGroups = (SharedValues.NumberOfAntennaPorts + 15) / 16;
            for (int i = numberOfAntennaTabGroups; i < 8; i++)
            {
                tabAntennaPorts.TabPages.RemoveAt(tabAntennaPorts.TabPages.Count - 1);
            }

            mAntennaAllEnableCheckBox = cbAllEnable;
            mAntennaAllPowerGainComboBox = cbxAllPowerGain;
            mAntennaAllDwellTimeTextBox = txbAllDwellTime;

            mAntennaLabels[0] = labelAntenna0;
            mAntennaLabels[1] = labelAntenna1;
            mAntennaLabels[2] = labelAntenna2;
            mAntennaLabels[3] = labelAntenna3;
            mAntennaLabels[4] = labelAntenna4;
            mAntennaLabels[5] = labelAntenna5;
            mAntennaLabels[6] = labelAntenna6;
            mAntennaLabels[7] = labelAntenna7;
            mAntennaLabels[8] = labelAntenna8;
            mAntennaLabels[9] = labelAntenna9;
            mAntennaLabels[10] = labelAntenna10;
            mAntennaLabels[11] = labelAntenna11;
            mAntennaLabels[12] = labelAntenna12;
            mAntennaLabels[13] = labelAntenna13;
            mAntennaLabels[14] = labelAntenna14;
            mAntennaLabels[15] = labelAntenna15;

            mAntennaEnableCheckBoxs[0] = checkBoxAntenna0Enable;
            mAntennaEnableCheckBoxs[1] = checkBoxAntenna1Enable;
            mAntennaEnableCheckBoxs[2] = checkBoxAntenna2Enable;
            mAntennaEnableCheckBoxs[3] = checkBoxAntenna3Enable;
            mAntennaEnableCheckBoxs[4] = checkBoxAntenna4Enable;
            mAntennaEnableCheckBoxs[5] = checkBoxAntenna5Enable;
            mAntennaEnableCheckBoxs[6] = checkBoxAntenna6Enable;
            mAntennaEnableCheckBoxs[7] = checkBoxAntenna7Enable;
            mAntennaEnableCheckBoxs[8] = checkBoxAntenna8Enable;
            mAntennaEnableCheckBoxs[9] = checkBoxAntenna9Enable;
            mAntennaEnableCheckBoxs[10] = checkBoxAntenna10Enable;
            mAntennaEnableCheckBoxs[11] = checkBoxAntenna11Enable;
            mAntennaEnableCheckBoxs[12] = checkBoxAntenna12Enable;
            mAntennaEnableCheckBoxs[13] = checkBoxAntenna13Enable;
            mAntennaEnableCheckBoxs[14] = checkBoxAntenna14Enable;
            mAntennaEnableCheckBoxs[15] = checkBoxAntenna15Enable;

            mAntennaPowerGainComboBoxes[0] = comboBoxAntenna0PowerGain;
            mAntennaPowerGainComboBoxes[1] = comboBoxAntenna1PowerGain;
            mAntennaPowerGainComboBoxes[2] = comboBoxAntenna2PowerGain;
            mAntennaPowerGainComboBoxes[3] = comboBoxAntenna3PowerGain;
            mAntennaPowerGainComboBoxes[4] = comboBoxAntenna4PowerGain;
            mAntennaPowerGainComboBoxes[5] = comboBoxAntenna5PowerGain;
            mAntennaPowerGainComboBoxes[6] = comboBoxAntenna6PowerGain;
            mAntennaPowerGainComboBoxes[7] = comboBoxAntenna7PowerGain;
            mAntennaPowerGainComboBoxes[8] = comboBoxAntenna8PowerGain;
            mAntennaPowerGainComboBoxes[9] = comboBoxAntenna9PowerGain;
            mAntennaPowerGainComboBoxes[10] = comboBoxAntenna10PowerGain;
            mAntennaPowerGainComboBoxes[11] = comboBoxAntenna11PowerGain;
            mAntennaPowerGainComboBoxes[12] = comboBoxAntenna12PowerGain;
            mAntennaPowerGainComboBoxes[13] = comboBoxAntenna13PowerGain;
            mAntennaPowerGainComboBoxes[14] = comboBoxAntenna14PowerGain;
            mAntennaPowerGainComboBoxes[15] = comboBoxAntenna15PowerGain;

            mAntennaDwellTimeTextBoxes[0] = textBoxAntenna0DwellTime;
            mAntennaDwellTimeTextBoxes[1] = textBoxAntenna1DwellTime;
            mAntennaDwellTimeTextBoxes[2] = textBoxAntenna2DwellTime;
            mAntennaDwellTimeTextBoxes[3] = textBoxAntenna3DwellTime;
            mAntennaDwellTimeTextBoxes[4] = textBoxAntenna4DwellTime;
            mAntennaDwellTimeTextBoxes[5] = textBoxAntenna5DwellTime;
            mAntennaDwellTimeTextBoxes[6] = textBoxAntenna6DwellTime;
            mAntennaDwellTimeTextBoxes[7] = textBoxAntenna7DwellTime;
            mAntennaDwellTimeTextBoxes[8] = textBoxAntenna8DwellTime;
            mAntennaDwellTimeTextBoxes[9] = textBoxAntenna9DwellTime;
            mAntennaDwellTimeTextBoxes[10] = textBoxAntenna10DwellTime;
            mAntennaDwellTimeTextBoxes[11] = textBoxAntenna11DwellTime;
            mAntennaDwellTimeTextBoxes[12] = textBoxAntenna12DwellTime;
            mAntennaDwellTimeTextBoxes[13] = textBoxAntenna13DwellTime;
            mAntennaDwellTimeTextBoxes[14] = textBoxAntenna14DwellTime;
            mAntennaDwellTimeTextBoxes[15] = textBoxAntenna15DwellTime;

            SaveTextBoxList.Add(textBoxAntenna0DwellTime);
            SaveTextBoxList.Add(textBoxAntenna1DwellTime);
            SaveTextBoxList.Add(textBoxAntenna2DwellTime);
            SaveTextBoxList.Add(textBoxAntenna3DwellTime);
            SaveTextBoxList.Add(textBoxAntenna4DwellTime);
            SaveTextBoxList.Add(textBoxAntenna5DwellTime);
            SaveTextBoxList.Add(textBoxAntenna6DwellTime);
            SaveTextBoxList.Add(textBoxAntenna7DwellTime);
            SaveTextBoxList.Add(textBoxAntenna8DwellTime);
            SaveTextBoxList.Add(textBoxAntenna9DwellTime);
            SaveTextBoxList.Add(textBoxAntenna10DwellTime);
            SaveTextBoxList.Add(textBoxAntenna11DwellTime);
            SaveTextBoxList.Add(textBoxAntenna12DwellTime);
            SaveTextBoxList.Add(textBoxAntenna13DwellTime);
            SaveTextBoxList.Add(textBoxAntenna14DwellTime);
            SaveTextBoxList.Add(textBoxAntenna15DwellTime);

            // 콤보박스에 파워 목록 추가
            for (int i = 0; i < 16; i++)
            {
                for (int j = RFID.Power.MIN_POWER; j <= RFID.Power.MAX_POWER; j++)
                {
                    ((ComboBox)mAntennaPowerGainComboBoxes[i]).Items.Add(string.Format(CultureInfo.CurrentCulture, "{0:F1} dBm", j / 1.0));
                    ((ComboBox)mAntennaAllPowerGainComboBox).Items.Add(string.Format(CultureInfo.CurrentCulture, "{0:F1} dBm", j / 1.0));
                }
            }

            ShowControlsByPortGroup(tabAntennaPorts.SelectedIndex);
        }

        private void ShowControlsByPortGroup(int groupIndex)
        {
            // 선택한 탭 인덱스에 따른 안테나 포트
            // 만약 선택된 탭 인덱스가 0이고 포트수가 16을 넘었을 경우 0번 탭에서는 0~15번 포트가 보여지겠지....
            int baseNumberOfAntennaPorts = SharedValues.NumberOfAntennaPorts - 16 * groupIndex;
            int numberOfAntennaPorts = baseNumberOfAntennaPorts > 16 ? 16 : baseNumberOfAntennaPorts;

            for (int i = 0; i < numberOfAntennaPorts; i++)
            {
                ((Label)(mAntennaLabels[i])).Visible = true;
                ((CheckBox)(mAntennaEnableCheckBoxs[i])).Visible = true;
                ((ComboBox)(mAntennaPowerGainComboBoxes[i])).Visible = true;
                ((TextBox)(mAntennaDwellTimeTextBoxes[i])).Visible = true;
            }

            for (int i = numberOfAntennaPorts; i < 16; i++)
            {
                ((Label)(mAntennaLabels[i])).Visible = false;
                ((CheckBox)(mAntennaEnableCheckBoxs[i])).Visible = false;
                ((ComboBox)(mAntennaPowerGainComboBoxes[i])).Visible = false;
                ((TextBox)(mAntennaDwellTimeTextBoxes[i])).Visible = false;
            }
        }

        private void SettingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private async Task LoadAntenaInformation()
        {
            if (SharedValues.Reader != null)
            {
                mAntennaStates = new bool[SharedValues.NumberOfAntennaPorts];
                mAntennaPowerGains = new int[SharedValues.NumberOfAntennaPorts];
                mAntennaDwellTimes = new int[SharedValues.NumberOfAntennaPorts];

                for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
                {
                    mAntennaStates[i] = await SharedValues.Reader.GetAntennaPortStateAsync(i).ConfigureAwait(true) == RFID.ON;
                    int powerGain = await SharedValues.Reader.GetRadioPowerAsync(i).ConfigureAwait(true);
                    mAntennaPowerGains[i] = (powerGain >= RFID.Power.MIN_POWER) &&
                                            (powerGain <= RFID.Power.MAX_POWER) ? powerGain : RFID.Power.MAX_POWER;
                    mAntennaDwellTimes[i] = await SharedValues.Reader.GetDwellTimeAsync(i).ConfigureAwait(true);
                }
            }
        }

        private void UpdateAntennaControlStatesByPortGroup(int groupIndex)
        {
            int baseNumberOfAntennaPorts = SharedValues.NumberOfAntennaPorts - 16 * groupIndex;
            int numberOfAntennaPorts = Math.Min(baseNumberOfAntennaPorts, 16);

            for (int i = 0; i < numberOfAntennaPorts; i++)
            {
                ((Label)mAntennaLabels[i]).Text = "#" + (groupIndex * 16 + i);
                ((CheckBox)mAntennaEnableCheckBoxs[i]).Checked = mAntennaStates[groupIndex * 16 + i];
                ComboBox antennaPowerGainComboBox = (ComboBox)mAntennaPowerGainComboBoxes[i];
                antennaPowerGainComboBox.Enabled = mAntennaStates[groupIndex * 16 + i];

                string powerString = string.Format(CultureInfo.CurrentCulture,
                                                        "{0:F1} dBm", mAntennaPowerGains[groupIndex * 16 + i] / 1.0);
                for (int j = 0; j < antennaPowerGainComboBox.Items.Count; j++)
                {
                    string item = (string)antennaPowerGainComboBox.Items[j];
                    if (item.Equals(powerString, StringComparison.CurrentCulture))
                    {
                        antennaPowerGainComboBox.SelectedIndex = j;
                    }
                }

                ((TextBox)mAntennaDwellTimeTextBoxes[i]).Text = string.Format(CultureInfo.CurrentCulture,
                                                                    "{0} ms", mAntennaDwellTimes[groupIndex * 16 + i]);

            }
        } 

        private void SaveAntennaSettings()
        {
            if (SharedValues.Reader != null)
            {
                for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
                {
                    SharedValues.Reader.SetAntennaPortState(i, mAntennaStates[i] ? RFID.ON : RFID.OFF);
                    SharedValues.Reader.SetRadioPower(i, mAntennaPowerGains[i]);
                    SharedValues.Reader.SetDwellTime(i, mAntennaDwellTimes[i]);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 안테나 설정 정보 내보내기
            ResultEvent(mAntennaStates, mAntennaPowerGains, mAntennaDwellTimes);
            // 안테나 설정
            SaveAntennaSettings();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbAllEnable_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
            {
                if (cbxAll.Checked)
                    mAntennaStates[i] = true;
                else
                    mAntennaStates[i] = false;
            }
        }

        private void cbxAllPowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cbxAllPowerGain.Focused)
                return;

            for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
            {
                mAntennaPowerGains[i] = cbxAllPowerGain.SelectedIndex + RFID.Power.MIN_POWER;
            }
        }

        private void txbAllDwellTime_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txbAllDwellTime_Leave(object sender, EventArgs e)
        {

            int length = txbAllDwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(txbAllDwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime > RFID.Dwell.MIN_DWELL)
                {
                    for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
                    {
                        mAntennaDwellTimes[i] = dwellTime;
                    }
                }
                else
                {
                    Popup.Show(Properties.Resources.StringInvalidParameterRange);
                }

                txbAllDwellTime.Text = dwellTime + " ms";
            }
            else
            {
                txbAllDwellTime.Text = SaveTextBox.Text;
            }
        }

        private void txbAllDwellTime_Enter(object sender, EventArgs e)
        {
            txbAllDwellTime.Text = null;
        }

        private void txbAllDwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            txbAllDwellTime.Text = null;
        }

        private void txbAllDwellTime_TextChanged(object sender, EventArgs e)
        {
            if (txbAllDwellTime.Text.Length > 0)
            {
                SaveTextBox.Text = txbAllDwellTime.Text;
            }
        }

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAll.Checked)
            {
                tabAntennaPorts.Enabled = false;
                for (int i = 0; i < 16; i++)
                {
                    ((CheckBox)mAntennaEnableCheckBoxs[i]).Enabled = false;
                    ((ComboBox)mAntennaPowerGainComboBoxes[i]).Enabled = false;
                    ((TextBox)mAntennaDwellTimeTextBoxes[i]).Enabled = false;
                }

                ((CheckBox)mAntennaAllEnableCheckBox).Enabled = true;
                ((ComboBox)mAntennaAllPowerGainComboBox).Enabled = true;
                ((TextBox)mAntennaAllDwellTimeTextBox).Enabled = true;
            }
            else
            {
                tabAntennaPorts.Enabled = true;
                for (int i = 0; i < 16; i++)
                {
                    ((CheckBox)mAntennaEnableCheckBoxs[i]).Enabled = true;
                    ((ComboBox)mAntennaPowerGainComboBoxes[i]).Enabled = true;
                    ((TextBox)mAntennaDwellTimeTextBoxes[i]).Enabled = true;
                }

                ((CheckBox)mAntennaAllEnableCheckBox).Enabled = false;
                ((ComboBox)mAntennaAllPowerGainComboBox).Enabled = false;
                ((TextBox)mAntennaAllDwellTimeTextBox).Enabled = false;
            }
        }

        private void checkBoxAntenna0Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna0Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna0Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16] = enabled;
            comboBoxAntenna0PowerGain.Enabled = enabled;
            textBoxAntenna0DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna1Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna1Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna1Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 1] = enabled;
            comboBoxAntenna1PowerGain.Enabled = enabled;
            textBoxAntenna1DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna2Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna2Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna2Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 2] = enabled;
            comboBoxAntenna2PowerGain.Enabled = enabled;
            textBoxAntenna2DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna3Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna3Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna3Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 3] = enabled;
            comboBoxAntenna3PowerGain.Enabled = enabled;
            textBoxAntenna3DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna4Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna4Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna4Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 4] = enabled;
            comboBoxAntenna4PowerGain.Enabled = enabled;
            textBoxAntenna4DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna5Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna5Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna5Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 5] = enabled;
            comboBoxAntenna5PowerGain.Enabled = enabled;
            textBoxAntenna5DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna6Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna6Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna6Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 6] = enabled;
            comboBoxAntenna6PowerGain.Enabled = enabled;
            textBoxAntenna6DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna7Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna7Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna7Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 7] = enabled;
            comboBoxAntenna7PowerGain.Enabled = enabled;
            textBoxAntenna7DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna8Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna8Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna8Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 8] = enabled;
            comboBoxAntenna8PowerGain.Enabled = enabled;
            textBoxAntenna8DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna9Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna9Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna9Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 9] = enabled;
            comboBoxAntenna9PowerGain.Enabled = enabled;
            textBoxAntenna9DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna10Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna10Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna10Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 10] = enabled;
            comboBoxAntenna10PowerGain.Enabled = enabled;
            textBoxAntenna10DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna11Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna11Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna11Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 11] = enabled;
            comboBoxAntenna11PowerGain.Enabled = enabled;
            textBoxAntenna11DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna12Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna12Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna12Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 12] = enabled;
            comboBoxAntenna12PowerGain.Enabled = enabled;
            textBoxAntenna12DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna13Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna13Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna13Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 13] = enabled;
            comboBoxAntenna13PowerGain.Enabled = enabled;
            textBoxAntenna13DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna14Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna14Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna14Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 14] = enabled;
            comboBoxAntenna14PowerGain.Enabled = enabled;
            textBoxAntenna14DwellTime.Enabled = enabled;
        }

        private void checkBoxAntenna15Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAntenna15Enable.Focused)
            {
                return;
            }

            bool enabled = checkBoxAntenna15Enable.Checked;
            mAntennaStates[tabAntennaPorts.SelectedIndex * 16 + 15] = enabled;
            comboBoxAntenna15PowerGain.Enabled = enabled;
            textBoxAntenna15DwellTime.Enabled = enabled;
        }

        private void comboBoxAntenna0PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna0PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16] =
                comboBoxAntenna0PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna1PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna1PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 1] =
                comboBoxAntenna1PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna2PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna2PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 2] =
                comboBoxAntenna2PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna3PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna3PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 3] =
                comboBoxAntenna3PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna4PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna4PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 4] =
                comboBoxAntenna4PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna5PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna5PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 5] =
                comboBoxAntenna5PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna6PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna6PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 6] =
                comboBoxAntenna6PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna7PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna7PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 7] =
                comboBoxAntenna7PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna8PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna8PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 8] =
                comboBoxAntenna8PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna9PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna9PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 9] =
                comboBoxAntenna9PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna10PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna10PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 10] =
                comboBoxAntenna10PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna11PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna11PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 11] =
                comboBoxAntenna11PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna12PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna12PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 12] =
                comboBoxAntenna12PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna13PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna13PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 13] =
                comboBoxAntenna13PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna14PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna14PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 14] =
                comboBoxAntenna14PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void comboBoxAntenna15PowerGain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxAntenna15PowerGain.Focused)
                return;

            mAntennaPowerGains[tabAntennaPorts.SelectedIndex * 16 + 15] =
                comboBoxAntenna15PowerGain.SelectedIndex + RFID.Power.MIN_POWER;
        }

        private void textBoxAntenna0DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna1DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna2DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna3DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna4DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna5DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna6DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna7DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna8DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna9DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna10DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna11DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna12DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna13DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna14DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna15DwellTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if ((c >= '0') && (c <= '9') || (c == 0x7c) || (c == 0x08))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBoxAntenna0DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna0DwellTime.Text?.Length ?? 0;
            
            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna0DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna0DwellTime.Text = SaveTextBoxList[0].Text + " ms";
            }
        }

        private void textBoxAntenna1DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna1DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna1DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 1] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna1DwellTime.Text = SaveTextBoxList[1].Text + " ms";
            }
        }

        private void textBoxAntenna2DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna2DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna2DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 2] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna2DwellTime.Text = SaveTextBoxList[2].Text + " ms";
            }
        }

        private void textBoxAntenna3DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna3DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna3DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 3] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna3DwellTime.Text = SaveTextBoxList[3].Text + " ms";
            }
        }

        private void textBoxAntenna4DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna4DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna4DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 4] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna4DwellTime.Text = SaveTextBoxList[4].Text + " ms";
            }
        }

        private void textBoxAntenna5DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna5DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna5DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 5] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna5DwellTime.Text = SaveTextBoxList[5].Text + " ms";
            }
        }

        private void textBoxAntenna6DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna6DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna6DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 6] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna6DwellTime.Text = SaveTextBoxList[6].Text + " ms";
            }
        }

        private void textBoxAntenna7DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna7DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna7DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 7] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna7DwellTime.Text = SaveTextBoxList[7].Text + " ms";
            }
        }

        private void textBoxAntenna8DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna8DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna8DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 8] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna8DwellTime.Text = SaveTextBoxList[8].Text + " ms";
            }
        }

        private void textBoxAntenna9DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna9DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna9DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 9] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna9DwellTime.Text = SaveTextBoxList[9].Text + " ms";
            }
        }

        private void textBoxAntenna10DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna10DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna10DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 10] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna10DwellTime.Text = SaveTextBoxList[10].Text + " ms";
            }
        }

        private void textBoxAntenna11DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna11DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna11DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 11] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna11DwellTime.Text = SaveTextBoxList[11].Text + " ms";
            }
        }

        private void textBoxAntenna12DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna12DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna12DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 12] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna12DwellTime.Text = SaveTextBoxList[12].Text + " ms";
            }
        }

        private void textBoxAntenna13DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna13DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna13DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 13] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna13DwellTime.Text = SaveTextBoxList[13].Text + " ms";
            }
        }

        private void textBoxAntenna14DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna14DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna14DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 14] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna14DwellTime.Text = SaveTextBoxList[14].Text + " ms";
            }
        }

        private void textBoxAntenna15DwellTime_Leave(object sender, EventArgs e)
        {
            int length = textBoxAntenna15DwellTime.Text?.Length ?? 0;

            if (length > 0)
            {
                int dwellTime = Convert.ToInt32(textBoxAntenna15DwellTime.Text, CultureInfo.CurrentCulture);
                if (dwellTime >= RFID.Dwell.MIN_DWELL)
                {
                    mAntennaDwellTimes[tabAntennaPorts.SelectedIndex * 16 + 15] = dwellTime;
                }
            }
            else
            {
                textBoxAntenna15DwellTime.Text = SaveTextBoxList[15].Text + " ms";
            }
        }

        private void textBoxAntenna0DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna0DwellTime.Text = null;
        }

        private void textBoxAntenna1DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna1DwellTime.Text = null;
        }

        private void textBoxAntenna2DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna2DwellTime.Text = null;
        }

        private void textBoxAntenna3DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna3DwellTime.Text = null;
        }

        private void textBoxAntenna4DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna4DwellTime.Text = null;
        }

        private void textBoxAntenna5DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna5DwellTime.Text = null;
        }

        private void textBoxAntenna6DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna6DwellTime.Text = null;
        }

        private void textBoxAntenna7DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna7DwellTime.Text = null;
        }

        private void textBoxAntenna8DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna8DwellTime.Text = null;
        }

        private void textBoxAntenna9DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna9DwellTime.Text = null;
        }

        private void textBoxAntenna10DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna10DwellTime.Text = null;
        }

        private void textBoxAntenna11DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna11DwellTime.Text = null;
        }

        private void textBoxAntenna12DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna12DwellTime.Text = null;
        }

        private void textBoxAntenna13DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna13DwellTime.Text = null;
        }

        private void textBoxAntenna14DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna14DwellTime.Text = null;
        }

        private void textBoxAntenna15DwellTime_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxAntenna15DwellTime.Text = null;
        }

        private void textBoxAntenna0DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna0DwellTime.Text.Length > 0)
                SaveTextBoxList[0].Text = textBoxAntenna0DwellTime.Text;
        }

        private void textBoxAntenna1DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna1DwellTime.Text.Length > 0)
                SaveTextBoxList[1].Text = textBoxAntenna1DwellTime.Text;
        }

        private void textBoxAntenna2DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna2DwellTime.Text.Length > 0)
                SaveTextBoxList[2].Text = textBoxAntenna2DwellTime.Text;
        }

        private void textBoxAntenna3DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna3DwellTime.Text.Length > 0)
                SaveTextBoxList[3].Text = textBoxAntenna3DwellTime.Text;
        }

        private void textBoxAntenna4DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna4DwellTime.Text.Length > 0)
                SaveTextBoxList[4].Text = textBoxAntenna4DwellTime.Text;
        }

        private void textBoxAntenna5DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna5DwellTime.Text.Length > 0)
                SaveTextBoxList[5].Text = textBoxAntenna5DwellTime.Text;
        }

        private void textBoxAntenna6DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna6DwellTime.Text.Length > 0)
                SaveTextBoxList[6].Text = textBoxAntenna6DwellTime.Text;
        }

        private void textBoxAntenna7DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna7DwellTime.Text.Length > 0)
                SaveTextBoxList[7].Text = textBoxAntenna7DwellTime.Text;
        }

        private void textBoxAntenna8DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna8DwellTime.Text.Length > 0)
                SaveTextBoxList[8].Text = textBoxAntenna8DwellTime.Text;
        }

        private void textBoxAntenna9DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna9DwellTime.Text.Length > 0)
                SaveTextBoxList[9].Text = textBoxAntenna9DwellTime.Text;
        }

        private void textBoxAntenna10DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna10DwellTime.Text.Length > 0)
                SaveTextBoxList[10].Text = textBoxAntenna10DwellTime.Text;
        }

        private void textBoxAntenna11DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna11DwellTime.Text.Length > 0)
                SaveTextBoxList[11].Text = textBoxAntenna11DwellTime.Text;
        }

        private void textBoxAntenna12DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna12DwellTime.Text.Length > 0)
                SaveTextBoxList[12].Text = textBoxAntenna12DwellTime.Text;
        }

        private void textBoxAntenna13DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna13DwellTime.Text.Length > 0)
                SaveTextBoxList[13].Text = textBoxAntenna13DwellTime.Text;
        }

        private void textBoxAntenna14DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna14DwellTime.Text.Length > 0)
                SaveTextBoxList[14].Text = textBoxAntenna14DwellTime.Text;
        }

        private void textBoxAntenna15DwellTime_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAntenna15DwellTime.Text.Length > 0)
                SaveTextBoxList[15].Text = textBoxAntenna15DwellTime.Text;
        }
    }
}
