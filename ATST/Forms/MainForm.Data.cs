using Apulsetech.Rfid;
using Apulsetech.Rfid.Type;
using ATST.Data;
using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Apulsetech.Rfid.Type.RFID.Untraceable;

namespace ATST.Forms
{
    public partial class MainForm
    {
        private void allport_inputstate_change(int save_port)
        {

        }

        private void previous_port_search(int current_port)
        {

        }

        private void input_proccess(string epc, string port, string rssi)
        {
            try
            {
                // 중복된 태그가 메모리에 있는지 검사
                if (!SharedValues.mTagSaveDictionary.ContainsKey(epc))
                {
                    // 없으면 추가
                    SharedValues.mTagSaveDictionary.Add(epc, new TagInfo(epc, Int32.Parse(port), double.Parse(rssi), true));
                }
                else
                {
                    SharedValues.mTagSaveDictionary[epc].Port = int.Parse(port);
                    SharedValues.mTagSaveDictionary[epc].Rssi = Convert.ToDouble(rssi);
                    SharedValues.mTagSaveDictionary[epc].Check = true;
                }
                var tag_cnt = SharedValues.mTagSaveDictionary.Where(x => x.Value.Port.Equals(Int32.Parse(port))).ToList();
                tablePanel1.DataViewTagCntNum(Int32.Parse(port), tag_cnt.Count);
            }
            catch
            {
                Log.WriteLine("ERROR. Failed input_proccess()");
            }
        }


        private void output_proccess(string epc, string port, string rssi)
        {
            //이전 포트를 초기화
            if (SavePort != Int32.Parse(port))
            {
                if (SavePort != -1)
                {
                    if (SharedValues.mTagSaveDictionary.Count > 0)
                    {
                        var previous_port_value = SharedValues.mTagSaveDictionary.Where(
                            x => x.Value.Port.Equals(SavePort) && x.Value.Check.Equals(false)).Select(x => x.Key).ToList();

                        for (int i = 0; i < previous_port_value.Count; i++)
                            if (SharedValues.mTagSaveDictionary.ContainsKey(previous_port_value[i]))
                                SharedValues.mTagSaveDictionary.Remove(previous_port_value[i]);

                        var KeyList = SharedValues.mTagSaveDictionary.Where(
                            x => x.Value.Port.Equals(SavePort) && x.Value.Check.Equals(true)).Select(x => x.Key).ToList();

                        for (int i = 0; i < KeyList.Count; i++)
                            if (SharedValues.mTagSaveDictionary.ContainsKey(KeyList[i]))
                                SharedValues.mTagSaveDictionary[KeyList[i]].Check = false;
                    }
                    Log.WriteLine("Test");
                }
                SavePort = Int32.Parse(port);
            }
        }
    }
}
