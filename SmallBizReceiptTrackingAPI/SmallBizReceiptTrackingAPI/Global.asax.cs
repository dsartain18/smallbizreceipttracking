using System;
using System.IO;
using System.Configuration;
using System.Web.Http;

using log4net;
using log4net.Config;

using SmallBizReceiptTrackingAPI.Entities.Entities;

namespace SmallBizReceiptTrackingAPI
{
    /// <summary>
    /// The main Web API application
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static ILog _log = LogManager.GetLogger(typeof(WebApiApplication));

        /// <summary>
        /// Starts the Web API Application
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigurationSettingsEntity configurationSettings = new ConfigurationSettingsEntity(ConfigurationManager.AppSettings);

            // Configure Log4Net
            ConfigureLog4Net(configurationSettings.Log4NetConfigurationFile, configurationSettings.ShouldWatchLog4NetConfigurationFile);
        }

        /// <summary>
        /// Configures the Log4Net infrastructure
        /// </summary>
        /// <param name="log4NetConfigurationFilePath">Path to the Log4Net configuration file</param>
        /// <param name="activelyWatchLog4NetConfigurationFile">Should the log4net configuration file be watched during runtime</param>
        private void ConfigureLog4Net(string log4NetConfigurationFilePath, bool activelyWatchLog4NetConfigurationFile)
        {
            // Logger Config
            if (activelyWatchLog4NetConfigurationFile)
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigurationFilePath));
            }
            else
            {
                XmlConfigurator.Configure(new FileInfo(log4NetConfigurationFilePath));
            }

            _log.Debug("Logging services successfully configured");
        }
    }
}
