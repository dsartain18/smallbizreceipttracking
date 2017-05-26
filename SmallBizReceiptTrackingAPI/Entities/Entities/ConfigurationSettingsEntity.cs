using System;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

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
        /// Constructs a new instance of the ConfigurationSettingsEntity class. Validates configuration settings.
        /// </summary>
        /// <param name="configurationSettings">Configuration settings to validate and set</param>
        public ConfigurationSettingsEntity(NameValueCollection configurationSettings)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException("configurationSettings");
            }

            // Validate Log4Net settings
            //Log4NetConfigurationFile = ValidateFileSetting("log4NetConfigurationFile", configurationSettings["log4NetConfigurationFile"]);
            //ShouldWatchLog4NetConfigurationFile = ValidateBooleanSetting("shouldWatchLog4NetConfigurationFile", configurationSettings["shouldWatchLog4NetConfigurationFile"]);
        }

        /// <summary>
        /// Validates a URI setting
        /// </summary>
        /// <param name="settingName">Name of the URI setting</param>
        /// <param name="settingValue">Value of the URI setting</param>
        /// <param name="uriKind">Uri kind that this setting must be</param>
        /// <returns>Returns the validate setting in URI format</returns>
        private static Uri ValidateURISetting(string settingName, string settingValue, UriKind uriKind)
        {
            if (String.IsNullOrWhiteSpace(settingValue))
            {
                throw new ConfigurationErrorsException(String.Format("The {0} URI setting cannot be null, empty or whitespace.", settingName));
            }

            Uri convertedSetting = null;

            if (!Uri.TryCreate(settingValue, uriKind, out convertedSetting))
            {
                throw new ConfigurationErrorsException(String.Format("Failed to convert the {0} URI setting to a URI object.", settingName));
            }

            return convertedSetting;
        }

        /// <summary>
        /// Validates a string setting
        /// </summary>
        /// <param name="settingName">Name of the string setting</param>
        /// <param name="settingValue">Value of the string setting</param>
        /// <returns>Validated string setting</returns>
        private static string ValidateStringSetting(string settingName, string settingValue)
        {
            if (String.IsNullOrWhiteSpace(settingValue))
            {
                throw new ConfigurationErrorsException(String.Format("The {0} setting cannot be null, empty or whitespace", settingName));
            }

            return settingValue;
        }

        /// <summary>
        /// Validates a file setting
        /// </summary>
        /// <param name="settingName">Name of the file setting</param>
        /// <param name="settingValue">Value of the file setting</param>
        /// <returns>Path to the validated file</returns>
        private static string ValidateFileSetting(string settingName, string settingValue)
        {
            if (!File.Exists(settingValue))
            {
                throw new ConfigurationErrorsException(String.Format("The file specified in the {0} setting could not be found", settingName));
            }

            return settingValue;
        }

        /// <summary>
        /// Validates a boolean setting
        /// </summary>
        /// <param name="settingName">Name of the boolean setting</param>
        /// <param name="settingValue">Value of the boolean setting</param>
        /// <returns>The validated boolean setting</returns>
        private static bool ValidateBooleanSetting(string settingName, string settingValue)
        {
            if (String.IsNullOrWhiteSpace(settingValue))
            {
                throw new ConfigurationErrorsException(String.Format("The {0} setting must be set to true or false", settingName));
            }

            bool convertedSetting = false;

            if (!Boolean.TryParse(settingValue, out convertedSetting))
            {
                throw new ConfigurationErrorsException(String.Format("The {0} setting must be set to true or false", settingName));
            }

            return convertedSetting;
        }
    }
}
