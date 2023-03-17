using ATST.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Data
{
    internal class Config
    {
        public static string CultureName { get; set; }
        public static int Panel_Row { get; set; }
        public static int Panel_Column { get; set; }

        public static bool[] AntStates = new bool[128];
        public static int[] AntPowerGains = new int[128];
        public static int[] AntDwellTimes = new int[128];

        public static int mAntCount = 1;
        public static int mApiServerPort = 0;
        public static int mGatheringServerPort = 0;

        public static List<string> APiServerUri = new List<string>();
        public static List<string> GatheringServerUri = new List<string>();

        public static void Load()
        { Load(Assembly.GetExecutingAssembly()); }
        public static void Load(Assembly assembly)
        {
            string filePath = GetFilePath(assembly);
            Configuration config = XmlConfigManager.Load<Configuration>(filePath);
            if (config == null)
            {
                config = new Configuration();
                XmlConfigManager.Save(filePath, config);
            }

            CultureName = config.setting.data.CultureName;
            AntStates = config.setting.data.States;
            AntPowerGains = config.setting.data.PowerGains;
            AntDwellTimes = config.setting.data.DwellTiems;
            Panel_Row = config.setting.design.panel_row;
            Panel_Column = config.setting.design.panel_column;
            mAntCount = config.setting.data.AntCount;
            mApiServerPort = config.setting.uri.ApiServerPort;
            mGatheringServerPort = config.setting.uri.GatheringServerPort;

            if (config.setting.uri.ApiServerUri != null)
            {
                foreach (var u in config.setting.uri.ApiServerUri)
                {
                    APiServerUri.Add(u);
                }
            }
            if (config.setting.uri.GatheringServerUri != null)
            {
                foreach (var u in config.setting.uri.GatheringServerUri)
                {
                    GatheringServerUri.Add(u);
                }
            }
        }

        public static void Save()
        { Save(Assembly.GetExecutingAssembly()); }
        public static void Save(Assembly assembly)
        {
            string filePath = GetFilePath(assembly);

            Configuration config = new Configuration();

            config.setting.data.CultureName = CultureName;
            config.setting.design.panel_row = Panel_Row;
            config.setting.design.panel_column = Panel_Column;
            config.setting.data.States = AntStates;
            config.setting.data.PowerGains = AntPowerGains;
            config.setting.data.DwellTiems = AntDwellTimes;
            config.setting.uri.ApiServerPort = mApiServerPort;
            config.setting.uri.GatheringServerPort = mGatheringServerPort;
            config.setting.uri.ApiServerUri = APiServerUri;
            config.setting.uri.GatheringServerUri = GatheringServerUri;
            config.setting.data.AntCount = mAntCount;

            XmlConfigManager.Save(filePath, config);
        }

        private static string GetFilePath(Assembly assembly)
        {
            string filePath = Path.Combine(SysUtil.GetModulePath(assembly),
                String.Format("{0}.config", SysUtil.GetModuleName(assembly)));
            return filePath;
        }
    }
}
