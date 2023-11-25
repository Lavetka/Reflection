using System;
using System.Configuration;


namespace Reflection
{
    public class ConfigurationManagerConfigurationProvider : IConfigurationProvider
    {
        public string LoadSettings(string settingName)
        {
            // Implementation for reading setting from ConfigurationManager
            return ConfigurationManager.AppSettings[settingName];
        }

        public void SaveSettings(string settingName, string value)
        {
            // Implementation for writing setting to ConfigurationManager
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[settingName].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

