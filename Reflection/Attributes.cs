using SharedNamespace;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; }
        public IConfigurationProvider ConfigProvider { get; protected init; }

        public ConfigurationItemAttribute(string settingName, IConfigurationProvider configProvider)
        {
            SettingName = settingName;
            ConfigProvider = configProvider;
        }
    }

    public class FileConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public FileConfigurationItemAttribute(string settingName, string path)
            : base(settingName, new FileConfigurationProvider.FileConfigurationProvider(path))
        {
        }
    }

    public class ConfigurationManagerConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public ConfigurationManagerConfigurationItemAttribute(string settingName)
            : base(settingName, new ConfigurationManagerConfigurationProvider.ConfigurationManagerConfigurationProvider())
        {
        }
    }
}
