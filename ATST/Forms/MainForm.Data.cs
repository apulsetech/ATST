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
        private void input_proccess(string epc, string port, string rssi)
        {
            try
            {
                //메모리에 중복된 epc가 있는지 검사
                if (!SharedValues.mTagSaveDictionary.ContainsKey(epc))
                {
                    //메모리에 중복된 epc가 없다면 데이터 추가
                    SharedValues.mTagSaveDictionary.Add(
                        epc, new TagInfo(epc, Int32.Parse(port), 
                        double.Parse(rssi), true));
                }
                else //메모리에 중복된 epc가 있을 경우
                {
                    if (SharedValues.mTagSaveDictionary[epc].Port != int.Parse(port))
                    {
                        int num = SharedValues.mTagSaveDictionary[epc].Port;

                        SharedValues.mTagSaveDictionary[epc].Port = int.Parse(port);

                        var save_port_cnt = SharedValues.mTagSaveDictionary.Where(
                            x => x.Value.Port.Equals(num)).ToList();
                        tablePanel1.DataViewTagCntNum(num, save_port_cnt.Count);
                    }

                    SharedValues.mTagSaveDictionary[epc].Rssi = Convert.ToDouble(rssi);
                    SharedValues.mTagSaveDictionary[epc].Check = true;
                }

                var tag_cnt = SharedValues.mTagSaveDictionary.Where(
                    x => x.Value.Port.Equals(Int32.Parse(port))).ToList();

                tablePanel1.DataViewTagCntNum(Int32.Parse(port), tag_cnt.Count);
            }
            catch
            {
                Log.WriteLine("ERROR. Failed input_proccess()");
            }
        }


        private void output_proccess(string epc, string port, string rssi)
        {
            //현재 리딩된 태그의 포트가 저장된 포트와 다를 때
            if (SavePort != Int32.Parse(port) && SavePort != -1) 
            {
                if (SharedValues.mTagSaveDictionary.Count > 0)
                {
                    allport_state_remove(SavePort);
                    allport_state_change(SavePort);
                }
            }
            SavePort = Int32.Parse(port);
        }

        private void allport_state_remove(int port)
        {
            var key_List = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.Check.Equals(false)).Select(x => x.Key).ToList();

            for (int i = 0; i < key_List.Count; i++)
                if (SharedValues.mTagSaveDictionary.ContainsKey(key_List[i]))
                    SharedValues.mTagSaveDictionary.Remove(key_List[i]);
        }


        private void allport_state_change(int port)
        {
            var key_List = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.Check.Equals(true)).Select(x => x.Key).ToList();

            for (int i = 0; i < key_List.Count; i++)
                if (SharedValues.mTagSaveDictionary.ContainsKey(key_List[i]))
                    SharedValues.mTagSaveDictionary[key_List[i]].Check = false;
        }
    }
}
