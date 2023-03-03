using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Data
{
    public class ReadInfo
    {
        public int read_count { get; set; }
        public bool state_switch { get; set; }
        public int Port { get; set; }
        public int other_port { get; set; }
        public int other_count { get; set; }

        public ReadInfo(int Count, bool Switch, int port, int o_port, int o_count)
        {
            read_count = Count;
            state_switch = Switch;
            Port = port;
            other_port = o_port;
            other_count = o_count;
        }
    }
}
