using Apulsetech.Rfid.Type;
using ATST.Data;
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
    public partial class MainForm
    {
        private bool mRfidInventoryStarted = false;

        private async void btn_rfid_inventory_Click(object sender, EventArgs e)
        {
            btn_rfid_inventory.Enabled = false;

            await ToggleRfidInventory().ConfigureAwait(true);

            btn_rfid_inventory.Enabled = true;
        }

        private async Task ToggleRfidInventory()
        {
            int result;

            if (mRfidInventoryStarted)//Inventory Stop
            {
                result = await SharedValues.Reader.StopOperationAsync().ConfigureAwait(true);

                if ((result == RfidResult.SUCCESS) ||
                    (result == RfidResult.NOT_INVENTORY_STATE))
                {
                    mRfidInventoryStarted = false;
                    ToggleRfidInventoryButton();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.StringFailedStopInventory);
                }
            }
            else//Inventory Start
            {
                result = await SharedValues.Reader.StartInventoryAsync().ConfigureAwait(true);

                if (result == RfidResult.SUCCESS)
                {
                    mRfidInventoryStarted = true;
                    ToggleRfidInventoryButton();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.StringFailedStartInventory);
                }
            }
        }

        private void ToggleRfidInventoryButton()
        {
            if (mRfidInventoryStarted)
            {
                btn_rfid_inventory.Text = Properties.Resources.StringStopInventory;
            }
            else
            {
                btn_rfid_inventory.Text = Properties.Resources.StringStartInventory;
            }
            btn_rfid_inventory.Focus();
        }

    }
}
