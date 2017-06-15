using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SmallBizReceiptTrackingAPI
{
    /// <summary>
    /// Configuration for the Web API
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers configuration, routes, and services
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{version}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
