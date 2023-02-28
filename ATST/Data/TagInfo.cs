using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Data
{
    public class TagInfo
    {
        public string Epc { get; set; }
        public int Port { get; set; }
        public double Rssi { get; set; }
        public bool Check { get; set; }

        public TagInfo(string epc, int port, double rssi, bool check)
        {
            Epc = epc;
            Port = port;
            Rssi = rssi;
            Check = check;
        }
    }
}
