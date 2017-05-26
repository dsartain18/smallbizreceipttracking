using System;
using System.Web.Http;

namespace SmallBizReceiptTrackingAPI
{
    /// <summary>
    /// The main Web API application
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Starts the Web API Application
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
