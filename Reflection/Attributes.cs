namespace Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigurationItemAttribute : Attribute
    {
        public string SettingName { get; }

        public ConfigurationItemAttribute(string settingName)
        {
            SettingName = settingName;
        }
    }

    public class FileConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public FileConfigurationItemAttribute(string settingName)
            : base(settingName)
        {
        }
    }

    public class ConfigurationManagerConfigurationItemAttribute : ConfigurationItemAttribute
    {
        public ConfigurationManagerConfigurationItemAttribute(string settingName)
            : base(settingName)
        {
        }
    }
}

