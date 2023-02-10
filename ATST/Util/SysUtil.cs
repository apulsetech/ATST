using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATST.Util
{
    public static class SysUtil
    {
        // Retrieve Module Version
        public static string GetVersion()
        { return GetVersion(Assembly.GetCallingAssembly()); } //현재 실행중인 코드를 호출한 메서드가 포함된 어셈블리를 가져온다.
        public static string GetVersion(Assembly assembly)
        {
            // 빌드 번호 및 어셈블리 버전 정보 가져오기
            return assembly.GetName().Version.ToString();
        }

        // Retrieve Module Name
        public static string GetModuleName()
        { return GetModuleName(Assembly.GetCallingAssembly()); }
        public static string GetModuleName(Assembly assembly)
        {
            return Path.GetFileNameWithoutExtension(assembly.ManifestModule.Name);
        }

        //Retrieve Module Path
        public static string GetModulePath()
        { return GetModulePath(Assembly.GetCallingAssembly()); }
        public static string GetModulePath(Assembly assembly)
        {
            return Path.GetDirectoryName(assembly.Location);
        }
    }
}
