using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Helpers
{
    public static class ExceptionHandler
    {
        public static LogWriter logWriter;
        public static readonly ExceptionPolicyFactory _exceptionPolicyFactory;
        public static readonly ExceptionManager _exceptionManager;

        static ExceptionHandler()
        {
            logWriter = new LogWriterFactory().Create();
            Logger.SetLogWriter(logWriter);
        }
    }
}
