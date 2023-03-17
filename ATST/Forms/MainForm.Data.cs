
using Apulsetech.Rfid.Vendor.Chip.Impinj;
using ATST.Data;
using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using static Apulsetech.Rfid.Type.RFID.Untraceable;

namespace ATST.Forms
{
    public partial class MainForm
    {
        private List<string> SaveEpcData = new List<string>();  // 한 차례의 인벤토리 라운지 때 중복된 태그가 로직을 타지 않도록 필터링하기 위한 태그 저장 리스트

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

                if (SharedValues.mTagStateDictionary[epc].read_count == 3)
                    input_proccess(epc, port, rssi);

            }
            else if (SharedValues.mTagStateDictionary[epc].Port != current_port &&
                    SharedValues.mTagStateDictionary[epc].other_count < 3)
            {
                SharedValues.mTagStateDictionary[epc].other_port = current_port;
                SharedValues.mTagStateDictionary[epc].other_count += 1;
                SharedValues.mTagStateDictionary[epc].state_switch = true;
                Debug.WriteLine("Other Key : {0}, o_Port : {1}, o_Count : {2}"
                    , epc, SharedValues.mTagStateDictionary[epc].other_port, SharedValues.mTagStateDictionary[epc].other_count);

                if (SharedValues.mTagStateDictionary[epc].other_count == 3)
                {
                    SharedValues.mTagStateDictionary[epc].Port = SharedValues.mTagStateDictionary[epc].other_port;
                    SharedValues.mTagStateDictionary[epc].read_count = SharedValues.mTagStateDictionary[epc].other_count;
                    SharedValues.mTagStateDictionary[epc].other_port = -1;
                    SharedValues.mTagStateDictionary[epc].other_count = 0;
                    SharedValues.mTagStateDictionary[epc].state_switch = true;
                    input_proccess(epc, port, rssi);
                }
            }
            else if (SharedValues.mTagStateDictionary[epc].Port == current_port &&
                     SharedValues.mTagStateDictionary[epc].other_port != -1)
            {
                SharedValues.mTagStateDictionary[epc].other_port = -1;
                SharedValues.mTagStateDictionary[epc].other_count = 0;
                SharedValues.mTagStateDictionary[epc].state_switch = true;
            }
            else if (SharedValues.mTagStateDictionary[epc].Port == current_port)
            {
                // 입고된 태그가 한두번 안읽혀서 카운트가 감소했었는데, 이번에 읽혀서 카운트를 3으로 복구시켜줌
                if (SharedValues.mTagStateDictionary[epc].read_count < 3)
                {
                    SharedValues.mTagStateDictionary[epc].read_count = 3;
                    Debug.WriteLine("ReCount Port : {0} Key : {1}, Count : {2}",
                    current_port, epc, SharedValues.mTagStateDictionary[epc].read_count);
                }
                SharedValues.mTagStateDictionary[epc].state_switch = true;  // 입고 후에도 읽히고 있다는 뜻
                //input_proccess(epc, port, rssi);
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
                        //io_data_listview.add_listview_items("o", DateTime.Now, epc, "정보 없음");
                        virtualListViewOutput.AddListViewItem(DateTime.Now, null, num, epc, "null");
                        virtualListViewOutput.UpdateListViewItem();
                        if (SharedValues.WebInterLockCheck)
                        {
                            DataFormat.AlerInputEvent(SharedValues.DeviceId, SharedValues.WorkerId,
                                SharedValues.mTagSaveDictionary[epc].Port, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), SharedValues.mTagSaveDictionary[epc].Epc, save_port_cnt.Count, 0, 0);
                        }
                    }
                    SharedValues.mTagSaveDictionary[epc].Rssi = Convert.ToDouble(rssi);
                    SharedValues.mTagSaveDictionary[epc].Check = true;
                    //Debug.WriteLine("Port : {0}, Key : {1} ,Switch : {2}"
                    //, port, epc, SharedValues.mTagStateDictionary[epc].state_switch);
                }
                var tag_cnt = SharedValues.mTagSaveDictionary.Where(
                    x => x.Value.Port.Equals(Int32.Parse(port))).ToList();
                tablePanel1.DataViewTagCntNum(Int32.Parse(port), tag_cnt.Count);
                //io_data_listview.add_listview_items("i", DateTime.Now, epc, "정보 없음");
                virtualListViewInput.AddListViewItem(DateTime.Now, null,Int32.Parse(port), epc, "null");
                virtualListViewInput.UpdateListViewItem();
                if (SharedValues.WebInterLockCheck)
                {
                    DataFormat.AlerInputEvent(SharedValues.DeviceId, SharedValues.WorkerId,
                                SharedValues.mTagSaveDictionary[epc].Port, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), SharedValues.mTagSaveDictionary[epc].Epc, tag_cnt.Count, 0, 0);
                }

                GC.Collect();
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

        private void one_output_proccess(int currentport)
        {
            if (SharedValues.mTagSaveDictionary.Count > 0)
            {
                switch_countdown(currentport);
                allport_state_remove(currentport);
                allport_state_change(currentport);
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
                // mTagSaveDictionary에는 포함되어 있지 않은 즉, 아직 입고되지 않은 태그는 한번만 안읽혀도 0처리
                if (SharedValues.mTagStateDictionary[Key_List[i]].other_port == -1 &&
                    !SharedValues.mTagSaveDictionary.ContainsKey(Key_List[i]))
                {
                    //SharedValues.mTagStateDictionary[Key_List[i]].read_count -= 1;
                    SharedValues.mTagStateDictionary[Key_List[i]].read_count = 0;
                    Debug.WriteLine("CountDown Key : {0}, Count : {1}", Key_List[i], SharedValues.mTagStateDictionary[Key_List[i]].read_count);
                }
                // other_port가 -1이 아닌 즉, 입고되었던 태그가 다른 태그에서 읽혔는데 입고 전에 한번이라도 안읽히면 0처리
                else if (SharedValues.mTagStateDictionary[Key_List[i]].other_port != -1)
                {
                    SharedValues.mTagStateDictionary[Key_List[i]].read_count =
                        SharedValues.mTagStateDictionary[Key_List[i]].read_count - SharedValues.mTagStateDictionary[Key_List[i]].other_count < 0 ? 0 : SharedValues.mTagStateDictionary[Key_List[i]].read_count - SharedValues.mTagStateDictionary[Key_List[i]].other_count;
                    SharedValues.mTagStateDictionary[Key_List[i]].other_count = 0;
                    SharedValues.mTagStateDictionary[Key_List[i]].other_port = -1;
                    Debug.WriteLine("CountDown Key (other == 0): {0}, Count : {1}", Key_List[i], SharedValues.mTagStateDictionary[Key_List[i]].read_count);
                }
                // mTagSaveDictionary에 포함되어진 즉, 입고처리된 태그는 1씩 카운트다운해서 0까지 카운트되면 제거되도록
                else if (SharedValues.mTagSaveDictionary.ContainsKey(Key_List[i]))
                {
                    SharedValues.mTagStateDictionary[Key_List[i]].read_count -= 1;
                    Debug.WriteLine("CountDown Key : {0}, Count : {1}", Key_List[i], SharedValues.mTagStateDictionary[Key_List[i]].read_count);
                }
            }

        }

        private void allport_state_remove(int port)
        {

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
                        int RemovePort = SharedValues.mTagSaveDictionary[Key_List[i]].Port;
                        string RemoveEpc = SharedValues.mTagSaveDictionary[Key_List[i]].Epc;

                        //io_data_listview.add_listview_items("o", DateTime.Now, SharedValues.mTagSaveDictionary[Key_List[i]].Epc, "정보 없음");
                        virtualListViewOutput.AddListViewItem(DateTime.Now, null, RemovePort, RemoveEpc, "null");
                        virtualListViewOutput.UpdateListViewItem();
                        SharedValues.mTagSaveDictionary.Remove(Key_List[i]);
                        var tag_cnt = SharedValues.mTagSaveDictionary.Where(
                        x => x.Value.Port.Equals(port)).ToList();
                        tablePanel1.DataViewTagCntNum(port, tag_cnt.Count);
                        if (SharedValues.WebInterLockCheck)
                        {
                            DataFormat.AlertOutputEvent(SharedValues.DeviceId, SharedValues.WorkerId,
                                RemovePort, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), RemoveEpc, tag_cnt.Count, 0, 0);
                        }
                        Debug.WriteLine("mTagSaveDictionary Remove Key : {0}",Key_List[i]);
                    };
                }
            }
            GC.Collect();
        }

        private void allport_state_change(int port)
        {
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
                if (SharedValues.mTagStateDictionary[Key_List[i]].read_count < 1 &&
                    (SharedValues.mTagStateDictionary[Key_List[i]].other_port == -1))
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