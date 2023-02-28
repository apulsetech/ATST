
using Apulsetech.Rfid.Vendor.Chip.Impinj;
using ATST.Data;
using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;


namespace ATST.Forms
{
    public partial class MainForm
    {
        private List<string> SaveEpcData = new List<string>();

        private void input_count(string epc, string port, string rssi)
        {
            int current_port = Convert.ToInt32(port);

            // 한번 읽힌 태그는 안읽히도록
            if (SavePort2 != current_port && SavePort2 != -1)
            {
                SaveEpcData.Clear();
            }
            SavePort2 = current_port;

            if (!SaveEpcData.Contains(epc))
            {
                SaveEpcData.Add(epc);
            }
            else
                return;

            //메모리에 중복된 epc가 있는지 검사하고 없으면 넣어주고 카운트 있으면 그냥 카운트

            // 카운트가 3미만일때
            // 같은 포트에서 읽혔으면 그냥 카운트
            // 만약 다른 포트의 안테나에서 읽혔으면 카운트 0으로 초기화하고 다시 카운트   

            // 카운트가 3일때 
            // 같은 포트에서 읽혔으면 그냥 리턴
            // 다른 포트에서 읽혔으면 그 포트를 저장 후 기존 포트에서 카운트가 0까지 줄었다면
            // 제거하지 않고 저장된 포트와 카운트로 교체
            if (!SharedValues.mTagStateDictionary.ContainsKey(epc))
            {
                SharedValues.mTagStateDictionary.Add(epc, new ReadInfo(0, true, current_port, -1, 0));
                SharedValues.mTagStateDictionary[epc].read_count += 1;
                Debug.WriteLine("Count Port : {0} Key : {1}, Count : {2}",
                    current_port, epc, SharedValues.mTagStateDictionary[epc].read_count);
            }
            else if (SharedValues.mTagStateDictionary[epc].read_count < 3 &&
                        SharedValues.mTagStateDictionary.ContainsKey(epc) &&
                        SharedValues.mTagStateDictionary[epc].Port != current_port &&
                        !SharedValues.mTagSaveDictionary.ContainsKey(epc))
            {
                SharedValues.mTagStateDictionary[epc].Port = current_port;
                SharedValues.mTagStateDictionary[epc].read_count = 1;
                SharedValues.mTagStateDictionary[epc].state_switch = true;
                Debug.WriteLine("func1 Count Port : {0} Key : {1}, Count : {2}",
                    current_port, epc, SharedValues.mTagStateDictionary[epc].read_count);
            }
            else if (SharedValues.mTagStateDictionary[epc].read_count < 3 &&
                        SharedValues.mTagStateDictionary[epc].Port == current_port &&
                        !SharedValues.mTagSaveDictionary.ContainsKey(epc))
            {
                SharedValues.mTagStateDictionary[epc].read_count += 1;
                SharedValues.mTagStateDictionary[epc].state_switch = true;
                Debug.WriteLine("func2 Count Port : {0} Key : {1}, Count : {2}",
                    current_port, epc, SharedValues.mTagStateDictionary[epc].read_count);
            }
            else if (SharedValues.mTagStateDictionary[epc].Port != current_port &&
                    SharedValues.mTagStateDictionary[epc].other_count < 3)
            {
                SharedValues.mTagStateDictionary[epc].other_port = current_port;
                SharedValues.mTagStateDictionary[epc].other_count += 1;
                SharedValues.mTagStateDictionary[epc].state_switch = true;
                Debug.WriteLine("Other Key : {0}, o_Port : {1}, o_Count : {2}"
                    , epc, SharedValues.mTagStateDictionary[epc].other_port, SharedValues.mTagStateDictionary[epc].other_count);
            }
            else if (SharedValues.mTagStateDictionary[epc].other_port == current_port &&
                       SharedValues.mTagStateDictionary[epc].other_count == 3)
            {
                SharedValues.mTagStateDictionary[epc].Port = SharedValues.mTagStateDictionary[epc].other_port;
                SharedValues.mTagStateDictionary[epc].read_count = SharedValues.mTagStateDictionary[epc].other_count;
                SharedValues.mTagStateDictionary[epc].other_port = -1;
                SharedValues.mTagStateDictionary[epc].other_count = 0;
                input_proccess(epc, port, rssi);
            }
            else if (SharedValues.mTagStateDictionary[epc].Port == current_port)
            {
                if (SharedValues.mTagStateDictionary[epc].read_count < 3)
                {
                    SharedValues.mTagStateDictionary[epc].read_count += 1;
                    Debug.WriteLine("Count Port : {0} Key : {1}, Count : {2}",
                   current_port, epc, SharedValues.mTagStateDictionary[epc].read_count);
                }
                SharedValues.mTagStateDictionary[epc].state_switch = true;  // 입고 후에도 읽히고 있다는 뜻
                input_proccess(epc, port, rssi);
            }

        }

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
                    Debug.WriteLine("Add Key : {0}", epc);
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
                    //Debug.WriteLine("Port : {0}, Key : {1} ,Switch : {2}"
                    //, port, epc, SharedValues.mTagStateDictionary[epc].state_switch);
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
                    switch_countdown(SavePort);
                    allport_state_remove(SavePort);
                    allport_state_change(SavePort);
                }
            }
            SavePort = Int32.Parse(port);
        }

        private void one_out_proccess(int currentport)
        {
            if (SharedValues.mTagSaveDictionary.Count > 0)
            {
                switch_countdown(currentport);
                oneport_state_remove(currentport);
                oneport_state_change(currentport);
            }
        }

        private void allport_state_remove(int port)
        {
            /*
            var key_List = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.Check.Equals(false)).Select(x => x.Key).ToList();
            for (int i = 0; i < key_List.Count; i++)
                if (SharedValues.mTagSaveDictionary.ContainsKey(key_List[i]))
                    SharedValues.mTagSaveDictionary.Remove(key_List[i]);
            */

            var Key_List = SharedValues.mTagStateDictionary.Where(
                       x => x.Value.Port.Equals(port) &&
                       x.Value.state_switch.Equals(false)).Select(x => x.Key).ToList();

            for (int i = 0; i < Key_List.Count; i++)
            {
                if (SharedValues.mTagStateDictionary[Key_List[i]].read_count < 1)
                {
                    SharedValues.mTagStateDictionary.Remove(Key_List[i]);
                    Debug.WriteLine("mTagStateDictionary Remove Key : {0}", Key_List[i]);
                    if (SharedValues.mTagSaveDictionary.ContainsKey(Key_List[i]))
                    {
                        SharedValues.mTagSaveDictionary.Remove(Key_List[i]);
                        var tag_cnt = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port)).ToList();
                        tablePanel1.DataViewTagCntNum(port, tag_cnt.Count);
                        Debug.WriteLine("mTagSaveDictionary Remove Key : {0}", Key_List[i]);
                    };
                }
            }
        }

        private void oneport_state_remove(int port)
        {
            /*
            var key_List = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.Check.Equals(false)).Select(x => x.Key).ToList();
            for (int i = 0; i < key_List.Count; i++)
                if (SharedValues.mTagSaveDictionary.ContainsKey(key_List[i]))
                    SharedValues.mTagSaveDictionary.Remove(key_List[i]);
            */

            var Key_List = SharedValues.mTagStateDictionary.Where(
                      x => x.Value.Port.Equals(port) &&
                      x.Value.state_switch.Equals(false)).Select(x => x.Key).ToList();

            for (int i = 0; i < Key_List.Count; i++)
            {
                if (SharedValues.mTagStateDictionary[Key_List[i]].read_count < 1)
                {
                    SharedValues.mTagStateDictionary.Remove(Key_List[i]);
                    Debug.WriteLine("mTagStateDictionary Remove Key : {0}", Key_List[i]);
                    if (SharedValues.mTagSaveDictionary.ContainsKey(Key_List[i]))
                    {
                        SharedValues.mTagSaveDictionary.Remove(Key_List[i]);
                        var tag_cnt = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port)).ToList();
                        tablePanel1.DataViewTagCntNum(port, tag_cnt.Count);
                        Debug.WriteLine("mTagSaveDictionary Remove Key : {0}", Key_List[i]);
                    };
                }
            }
        }

        private void switch_countdown(int port)
        {
            // state_switch가 false인 것들 모아서 일괄 카운트 감소
            var Key_List = SharedValues.mTagStateDictionary.Where(
                       x => x.Value.Port.Equals(port) &&
                       x.Value.state_switch.Equals(false)).Select(x => x.Key).ToList();
            for (int i = 0; i < Key_List.Count; i++)
            {
                SharedValues.mTagStateDictionary[Key_List[i]].read_count -= 1;
                Debug.WriteLine("CountDown Key : {0}, Count : {1}", Key_List[i], SharedValues.mTagStateDictionary[Key_List[i]].read_count);
            }
        }

        private void allport_state_change(int port)
        {
            /*
            var key_List = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.Check.Equals(true)).Select(x => x.Key).ToList();
            for (int i = 0; i < key_List.Count; i++)
                if (SharedValues.mTagSaveDictionary.ContainsKey(key_List[i]))
                    SharedValues.mTagSaveDictionary[key_List[i]].Check = false;
            */

            var Key_List = SharedValues.mTagStateDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.state_switch.Equals(true)).Select(x => x.Key).ToList();
            for (int i = 0; i < Key_List.Count; i++)
            {
                if (SharedValues.mTagStateDictionary.ContainsKey(Key_List[i]))
                {
                    SharedValues.mTagStateDictionary[Key_List[i]].state_switch = false;
                }
            }
        }

        private void oneport_state_change(int port)
        {
            /*
            var key_List = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.Check.Equals(true)).Select(x => x.Key).ToList();
            for (int i = 0; i < key_List.Count; i++)
                if (SharedValues.mTagSaveDictionary.ContainsKey(key_List[i]))
                    SharedValues.mTagSaveDictionary[key_List[i]].Check = false;
            */
            var Key_List = SharedValues.mTagStateDictionary.Where(
                        x => x.Value.Port.Equals(port) &&
                        x.Value.state_switch.Equals(true)).Select(x => x.Key).ToList();
            for (int i = 0; i < Key_List.Count; i++)
            {
                if (SharedValues.mTagStateDictionary.ContainsKey(Key_List[i]))
                {
                    SharedValues.mTagStateDictionary[Key_List[i]].state_switch = false;
                }
            }
        }
    }
}