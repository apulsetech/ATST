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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATST.Forms
{
    public partial class MainForm
    {
        private int first_port = 0; // 첫번째 포트 저장 변수
        private int Last_port = 127; // 마지막 포트 저장 변수
        private bool first_Inv = true;  // 첫번째 인벤토리 판단
        private int previous_port = 0; // 이전 포트 저장 변수

        private void first_port_set(string port)
        {
            // 처음 인벤토리가 시작될때만 검사
            // 현재 포트가 첫번째 포트인지 검사
            if (first_Inv)
            {
                first_port = Convert.ToInt32(port);
                Last_port_set();
            }
        }

        private void Last_port_set()
        {
            // 안테나 활성 여부 체크
            for (int i = 0; i < SharedValues.NumberOfAntennaPorts; i++)
            {
                bool state = SharedValues.Reader.GetAntennaPortState(i) == RFID.ON;
                if (state)
                    Last_port = i;
            }
        }

        private void allport_inputstate_change(string port)
        {
            try
            {
                // 딕셔너리에 데이터가 있는지 확인하고 
                if (SharedValues.mTagSaveDictionary.Count > 0)
                {
                    int current_port = Int32.Parse(port);
                    previous_port_search(current_port);

                    // Value에 Check가 true인 키들을 리스트로 모아서 
                    var KeyList = SharedValues.mTagSaveDictionary.Where(x => x.Value.Check.Equals(true) && x.Value.Port.Equals(previous_port)).Select(x => x.Key);

                    // 일치하는 키들의 Check값을 false로 변경
                    foreach (var key in KeyList)
                    {
                        if (SharedValues.mTagSaveDictionary.ContainsKey((string)key))
                        {
                            SharedValues.mTagSaveDictionary[(string)key].Check = false;
                        }
                    }
                }
            }
            catch
            {
                Log.WriteLine("ERROR. Failed allport_inputstate_change()");
            }
        }

        private void previous_port_search(int current_port)
        {
            // 현재 포트의 이전 포트 (현재 포트의 이전  포트가[활성화 되었던 안되었던] 마지막 포트일때를 고려)
            previous_port = current_port - 1;
            if (current_port == first_port)
                previous_port = Last_port;

            // 이전 포트가 어디였는지 확인
            // 현재 포트 전부터 탐색
            for (int i = previous_port; i < first_port; i--)
            {
                // 식별 태그가 포트마다 하나씩 존재하므로 활성 태그라면 if문 처리가 수행됨.
                if (SharedValues.mTagSaveDictionary.Where(x => x.Value.Port.Equals(i)).Select(x => x.Key).Any())
                {
                    // 들어오면 i값이 이전 포트 값으로 판단
                    previous_port = i;
                    break;
                }
            }
        }

        private void output_proccess(string epc, string port, string rssi)
        {
            int current_port = Int32.Parse(port);
            // 첫번째 인벤토리 시작하면서 첫번째 포트의 라운지 타임일때 출고 처리 방지를 위함. 
            if (current_port == first_port && first_Inv)
            {
                first_Inv = false;
                return;
            }

            previous_port_search(current_port);

            // 딕셔너리에서 port 값이 이전 포트인 데이터들을 검색함.
            var previous_port_value = SharedValues.mTagSaveDictionary.Where(x => x.Value.Port.Equals(previous_port)).Select(x => x.Key);

            foreach (var Key in previous_port_value)
            {
                // check 상태가 false이면
                // 저번 사이클에서 읽혔던 태그가 현재 사이클에서는 안읽혔다는 뜻이므로 제거함.
                if (SharedValues.mTagSaveDictionary[Key].Check == false)
                {
                    Log.WriteLine("INFO. Output Data -> EPC : {0}, Port : {1}, Rssi : {2}, Check : {3}",
                       SharedValues.mTagSaveDictionary[Key].Epc, SharedValues.mTagSaveDictionary[Key].Port, SharedValues.mTagSaveDictionary[Key].Rssi, SharedValues.mTagSaveDictionary[Key].Check);
                    SharedValues.mTagSaveDictionary.Remove(Key);

                    // 출고 사운드 추가
                    // 태그 카운트 다운
                }
            }
        }

        private void input_proccess(string epc, string port, string rssi)
        {
            try
            {
                // 중복된 태그가 메모리에 있는지 검사
                if (!SharedValues.mTagSaveDictionary.ContainsKey(epc))
                {
                    // 없으면 추가
                    SharedValues.mTagSaveDictionary.Add(epc, new TagInfo(epc, Int32.Parse(port) - 1, double.Parse(rssi), true));
                    Log.WriteLine("INFO. Input Data -> EPC : {0}, Port : {1}, Rssi : {2}, Check : {3}",
                        SharedValues.mTagSaveDictionary[epc].Epc, SharedValues.mTagSaveDictionary[epc].Port, SharedValues.mTagSaveDictionary[epc].Rssi, SharedValues.mTagSaveDictionary[epc].Check);

                    // 입고 사운드 출력
                    // 태그 카운트 
                }
                else
                {
                    // 중복된 태그가 메모리에 존재하면
                    // 제거해줌.
                    Log.WriteLine("INFO. Output Data -> EPC : {0}, Port : {1}, Rssi : {2}, Check : {3}",
                       SharedValues.mTagSaveDictionary[epc].Epc, SharedValues.mTagSaveDictionary[epc].Port, SharedValues.mTagSaveDictionary[epc].Rssi, SharedValues.mTagSaveDictionary[epc].Check);
                    SharedValues.mTagSaveDictionary.Remove(epc);

                    // 출고 사운드 출력
                    // 태그 카운트 다운

                    // 기존에 있던 데이터를 지워줬으니 새롭게 저장
                    input_proccess(epc, port, rssi);
                }
            }
            catch
            {
                Log.WriteLine("ERROR. Failed input_proccess()");
            }
        }
    }
}
