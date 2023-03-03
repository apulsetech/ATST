using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATST.Util
{
    public class CreateConfig
    {
        public static void MainConfig()
        {
            var data = new Data
            {
                CultureName = ""
            };

            var design = new Design
            {
                panel_column = 0,
                panel_row = 0
            };

            var setting = new Setting
            {
                data = data,
                design = design
            };

            var Configuration = new Configuration()
            {
                setting = setting
            };

            XML_Serialize(Configuration);
        }

        private static void XML_Serialize(Configuration configuration)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string FilePath = Path.Combine(SysUtil.GetModulePath(assembly),
                String.Format("{0}.config", SysUtil.GetModuleName(assembly)));

            if (!File.Exists(FilePath))
            {
                using (var SettingData = File.Create(FilePath))
                {
                    var xmlSerializer = new XmlSerializer(typeof(Configuration));
                    xmlSerializer.Serialize(SettingData, configuration);
                }
            }
        }
    }

    public class Configuration
    {
        public Setting setting { get; set; }

        public Configuration()
        {
            setting = new Setting();    
        }
    }

    public class Setting
    {
        public Data data { get; set; }
        public Design design { get; set; }

        public Setting()
        {
            data = new Data();
            design = new Design();
        }
    }

    public class Design
    {
        public int panel_row { get; set; }
        public int panel_column { get; set; }
    }

    public class Data
    {
        public string CultureName { get; set; }
    }

}
