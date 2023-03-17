using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
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
        // 1. XML 형식 구성
        public static void MainConfig()
        {
            var data = new Data
            {
                AntCount = 1
            };

            var design = new Design
            {
                panel_column = 0,
                panel_row = 0,
            };

            var uri = new Uri
            {
                ApiServerPort = 0,
                GatheringServerPort = 0,
                ApiServerUri = new List<string>(),
                GatheringServerUri = new List<string>()
            };

            var setting = new Setting
            {
                data = data,
                design = design,
                uri = uri
            };

            var Configuration = new Configuration()
            {
                setting = setting
            };

            XML_Serialize(Configuration);
        }

        // 2. 파일 생성하고 XML 타입 지정 후 데이터 직렬화해서 파일에 쓰기 
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
        public Uri uri { get; set; }

        public Setting()
        {
            data = new Data();
            design = new Design();
            uri = new Uri();
        }
    }

    public class Uri
    {
        public int ApiServerPort { get; set; }
        public int GatheringServerPort { get; set; }
        public List<string> ApiServerUri { get; set; }
        public List<string> GatheringServerUri { get; set; }
    }

    public class Design
    {
        public int panel_row { get; set; }
        public int panel_column { get; set; }
    }

    public class Data
    {
        public string CultureName { get; set; }
        public int AntCount { get; set; }
        public bool[] States { get; set; }
        public int[] PowerGains { get; set; }
        public int[] DwellTiems { get; set; }

        public Data()
        {
            CultureName = "Ko-KR";
            States = Enumerable.Repeat<bool>(false, 128).ToArray<bool>();
            PowerGains = Enumerable.Repeat<int>(1, 128).ToArray<int>();
            DwellTiems = Enumerable.Repeat<int>(50, 128).ToArray<int>();
        }           
    }

}
