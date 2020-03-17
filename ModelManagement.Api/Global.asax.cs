using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ModelManagement.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        ExceptionManager exManager;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //IConfigurationSource config = ConfigurationSourceFactory.Create();
            //ExceptionPolicyFactory factory = new ExceptionPolicyFactory(config);
            //LogWriterFactory logFactory = new LogWriterFactory(config);

            //Logger.SetLogWriter(logFactory.Create(), true);
            //ExceptionPolicy.SetExceptionManager(factory.CreateManager());
            //exManager = factory.CreateManager();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception error = Server.GetLastError();
            //if (error is HttpUnhandledException)
            //{
            //    error = error.InnerException;
            //}
            //string erMessage = error.Message;
            //Exception errorToThrow;
            //if (ExceptionPolicy.HandleException(error, "Policy", out errorToThrow))
            //{
            //    if (errorToThrow != null)
            //    {
            //        HttpContext.Current.Cache[""] = errorToThrow.Message;
            //        Logger.Write(errorToThrow.Message);
            //    }
            //}
            //else
            //{
            //    Server.ClearError();
            //}
        }
    }
}
