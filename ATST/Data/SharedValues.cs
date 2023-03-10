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
        private static string mSelectedPort = string.Empty; 
        public static Dictionary<string, TagInfo> mTagSaveDictionary = new Dictionary<string, TagInfo>();
        public static Dictionary<string, ReadInfo> mTagStateDictionary = new Dictionary<string, ReadInfo>();

        public static readonly string[] RfidMemTypesArray =
            { "Reserved", "EPC", "TID", "User" };
        public static readonly string[] RfidSelctionMemTypesArray =
            { "FileType", "EPC", "TID", "User" };
        public static readonly string[] RfidSecurityMemTypesArray =
            { "EPC", "TID", "User" };
        public static readonly string[] RfidSelectionTargetsArray =
            { "Inventoried(S0)", "Inventoried(S1)", "Inventoried(S2)", "Inventoried(S3)", "SL" };
        public static readonly string[] RfidSelectionTargetsShortArray =
            { "S0", "S1", "S2", "S3", "SL" };
        public static readonly string[] RfidSelectionActionsArray = {
            "Assert SL or inventoried → A, Deassert SL or inventoried → B",
            "Assert SL or inventoried → A, Do nothing",
            "Do nothing, Deassert SL or inventoried → B",
            "Negate SL or (A → B, B → A), Do nothing",
            "Deassert SL or inventoried → B, Assert SL or inventoried → A",
            "Deassert SL or inventoried → B, Do nothing",
            "Do nothing, Assert SL or inventoried → A",
            "Do nothing, Negate SL or (A → B, B → A)"
        };
        public static readonly string[] RfidInventorySessionArray = { "S0", "S1", "S2", "S3" };
        public static readonly string[] RfidInventoryTargetsArray = { "A", "B" };
        public static readonly string[] RfidInventorySelectionsArray = { "ALL", "~SL", "SL" };

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

        public static string SelectedPort
        {
            get => mSelectedPort;
            set => mSelectedPort = value;
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
