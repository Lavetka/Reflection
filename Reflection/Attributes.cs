using ConfigurationManagerConfigurationProvider;
using FileConfigurationProvider;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; }
        public Type ProviderType { get; }

        public ConfigurationItemAttribute(string settingName, Type providerType)
        {
            SettingName = settingName;
            ProviderType = providerType;
        }
    }

    public class FileConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public FileConfigurationItemAttribute(string settingName)
            : base(settingName, typeof(FileConfigurationProvider.FileConfigurationProvider))
        {
        }
    }

    public class ConfigurationManagerConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public ConfigurationManagerConfigurationItemAttribute(string settingName)
            : base(settingName, typeof(ConfigurationManagerConfigurationProvider.ConfigurationManagerConfigurationProvider))
        {
        }
    }
}
