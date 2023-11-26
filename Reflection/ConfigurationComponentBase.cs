using SharedNamespace;

namespace Reflection
{
    public class ConfigurationComponentBase
    {
        protected IConfigurationProvider configurationProvider;

        public ConfigurationComponentBase(IConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public void LoadSettings()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                var attribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute));

                if (attribute != null)
                {
                    var value = configurationProvider.LoadSettings(attribute.SettingName);
                    if (value != null)
                    {
                        Type propertyType = property.PropertyType;
                        property.SetValue(this, Convert.ChangeType(value, propertyType));
                    }
                }
            }
        }

        public void SaveSettings()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                var attribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute));

                if (attribute != null)
                {
                    var value = property.GetValue(this)?.ToString();
                    configurationProvider.SaveSettings(attribute.SettingName, value);
                }
            }
        }
    }
}

