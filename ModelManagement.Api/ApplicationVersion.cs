using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ModelManagement.Api
{
    public class ApplicationVersion
    {
        public static string GetVersion()
        {
            var executingAssembly = Assembly.GetAssembly(typeof(ApplicationVersion));
            string fileVersion = FileVersionInfo.GetVersionInfo(executingAssembly.Location).FileVersion;
            return fileVersion;
        }
    }
}