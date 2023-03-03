using Apulsetech.Rfid.Type;
using ATST.Data;
using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class MainForm
    {
        private bool mRfidInventoryStarted = false;
        CancellationTokenSource tokenSource;

        private async void btn_rfid_inventory_Click(object sender, EventArgs e)
        {
            //btn_rfid_inventory.Enabled = false;

            await ToggleRfidInventory().ConfigureAwait(true);
            
            //btn_rfid_inventory.Enabled = true;
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
                    Log.WriteLine("INFO. Successed Inventory Stop.");
                    mRfidInventoryStarted = false;
                    ToggleRfidInventoryButton();

                    //await Task.Run(() => tokenSource.Cancel());\
                    //tokenSource.Cancel();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.StringFailedStopInventory);
                    Log.WriteLine("ERROR. Failed Inventory Stop.");
                }
            }
            else//Inventory Start
            {
                result = await SharedValues.Reader.StartInventoryAsync().ConfigureAwait(true);

                if (result == RfidResult.SUCCESS)
                {
                    Log.WriteLine("INFO. Successed Inventory Start.");
                    mRfidInventoryStarted = true;
                    ToggleRfidInventoryButton();

                    // tokenSource = new CancellationTokenSource();
                    if (SharedValues.NumberOfAntennaPorts == 1)
                        await one_port_proccess();
                }
                else
                {
                    MessageBox.Show(Properties.Resources.StringFailedStartInventory);
                    Log.WriteLine("ERROR. Failed Inventory Start.");
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
