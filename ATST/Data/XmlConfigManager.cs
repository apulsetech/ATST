using ATST.Diagnotics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ATST.Data
{
    public class XmlConfigManager
    {
        private static readonly string TAG = typeof(XmlConfigManager).FullName;
        private const bool E = true;
        private const bool I = true;

        // 설정 파일 로드
        public static T Load<T>(string fileName) where T : class
        {
            T config = null;

            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open,
                    FileAccess.Read, FileShare.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    config = (T)serializer.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLine("ERROR. Load([{0}]) - Failed to load xml configuration file [{1}]",
                    fileName, ex.Message);
                return null;
            }
            Log.WriteLine("INFO. Load([{0}]) - [{1}]", fileName, config.ToString());
            return config;
        }

        // 설정 파일 저장
        public static bool Save<T>(string fileName, T config)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(config.GetType());
                    serializer.Serialize(stream, config);
                    stream.Close();
                }
            }
            catch(Exception ex)
            {
                Log.WriteLine("ERROR. Save([{0}], [{1}]) - Failed to save xml configuration file [{2}]",
                    fileName, config.ToString(), ex.Message);
                return false;
            }
            Log.WriteLine("INFO. Save([{0}], [{1}])", fileName, config.ToString());
            return true;
        }
    }
}
