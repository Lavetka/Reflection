using SharedNamespace;

namespace Reflection
{
    public class ConfigurationComponentBase
    {
        public void LoadSettings()
        {
            foreach (var property in this.GetType().GetProperties())
            {
                var attribute = (ConfigurationItemAttribute)Attribute.GetCustomAttribute(property, typeof(ConfigurationItemAttribute));

                if (attribute != null)
                {
                    var value = attribute.ConfigProvider.LoadSettings(attribute.SettingName);
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
                    attribute.ConfigProvider.SaveSettings(attribute.SettingName, value);
                }
            }
        }
    }

}

