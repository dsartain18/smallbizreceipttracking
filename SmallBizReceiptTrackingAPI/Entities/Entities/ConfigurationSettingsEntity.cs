using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

using SartainSoftware.Common.Validators;

namespace SmallBizReceiptTrackingAPI.Entities.Entities
{
    /// <summary>
    /// Contains the configuration settings
    /// </summary>
    public class ConfigurationSettingsEntity
    {
        /// <summary>
        /// The path to the Log4Net configuration file
        /// </summary>
        public string Log4NetConfigurationFile { get; protected set; }

        /// <summary>
        /// Should the Log4Net configuration be reloaded in real time upon changes
        /// </summary>
        public bool ShouldWatchLog4NetConfigurationFile { get; protected set; }

        /// <summary>
        /// The key used to validate traffic to the API
        /// </summary>
        public string APIKey { get; protected set; }

        /// <summary>
        /// Constructs a new instance of the ConfigurationSettingsEntity class. Validates configuration settings.
        /// </summary>
        /// <param name="configurationSettings">Configuration settings to validate and set</param>
        public ConfigurationSettingsEntity(NameValueCollection configurationSettings)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException("configurationSettings");
            }

            APIKey = ConfigurationEntityValidator.ValidateStringSetting("APIKey", configurationSettings["APIKey"]);

            // Validate Log4Net settings
            Log4NetConfigurationFile = ConfigurationEntityValidator.ValidateFileSetting("log4NetConfigurationFile", configurationSettings["log4NetConfigurationFile"]);
            ShouldWatchLog4NetConfigurationFile = ConfigurationEntityValidator.ValidateBooleanSetting("shouldWatchLog4NetConfigurationFile", configurationSettings["shouldWatchLog4NetConfigurationFile"]);
        }
    }
}
