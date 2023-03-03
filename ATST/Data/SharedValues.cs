using Apulsetech.Rfid.Vendor.Tag.Sensor;
using Apulsetech.Rfid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Data
{
    public static class SharedValues
    {
        public enum InterfaceType
        {
            SERIAL,
            TCP
        }

        private static string mEthernet = string.Empty;
        private static InterfaceType mConnectionType = InterfaceType.SERIAL;
        private static Reader mReader = null;
        private static SensorReader mSensorReader = null;
        private static bool mReaderConnected = false;
        private static int mNumberOfAntennaPorts = 1;
        public static Dictionary<string, TagInfo> mTagSaveDictionary = new Dictionary<string, TagInfo>();
        public static Dictionary<string, ReadInfo> mTagStateDictionary = new Dictionary<string, ReadInfo>();


        public static string Ethernet
        {
            get => mEthernet;
            set => mEthernet = value;
        }

        public static InterfaceType ConnectionType
        {
            get => mConnectionType;
            set => mConnectionType = value;
        }

        public static bool ReaderConnected
        {
            get => mReaderConnected;
            set => mReaderConnected = value;
        }

        public static int NumberOfAntennaPorts
        {
            get => mNumberOfAntennaPorts;
            set
            {
                if (value > 0)
                    mNumberOfAntennaPorts = value;
            }
        }

        public static Reader Reader
        {
            get => mReader;
            set
            {
                mReader = value;
                if (value != null)
                {
                    mSensorReader = new SensorReader(value);
                }
                else
                {
                    mSensorReader = null;
                }
            }
        }

        

    }
}
