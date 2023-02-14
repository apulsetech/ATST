using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Apulsetech.Rfid.Type.RFID.Lbt;

namespace ATST.Forms.Diagnotics
{
    public partial class LogDialog : Form
    {
        public Log.LogEventHandler m_fnOutputLog;

        public LogDialog(MainForm main)
        {
            InitializeComponent();
            this.KeyPreview = true;
            txbLog.Text = main.txb.Text;
            m_fnOutputLog = new Log.LogEventHandler(OutputLog);
        }

        public void OutputLog(string msg)
        {
            if (InvokeRequired)
            {
                BeginInvoke(m_fnOutputLog, msg);
                return;
            }

            if (txbLog.TextLength + msg.Length > txbLog.MaxLength)
                txbLog.Text = String.Empty;

            txbLog.AppendText(msg);
            txbLog.Select(txbLog.TextLength, 0);
            txbLog.ScrollToCaret();
        }

        private void LogDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbLog.Clear();
        }

        private void LogDialog_Load(object sender, EventArgs e)
        {
            this.Owner.Focus();
        }
    }
}
