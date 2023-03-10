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
        public static bool[] AntStates { get; set; }
        public static int[] AntPowerGains { get; set; }
        public static int[] AntDwellTimes { get; set; }

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
