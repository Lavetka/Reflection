using ConfigurationManagerConfigurationProvider;
using FileConfigurationProvider;

namespace Reflection
{
    public class MyAppConfiguration : Reflection.ConfigurationComponentBase
    {
        [ConfigurationManagerConfigurationItem("UserName")]
        public string UserName { get; set; }

        [ConfigurationManagerConfigurationItem("TimeoutSeconds")]
        public int TimeoutSeconds { get; set; }

        [ConfigurationManagerConfigurationItem("ApiKey")]
        public string ApiKey { get; set; }

        [FileConfigurationItem("StartDate", "config.json")]
        public DateTime StartDate { get; set; }
    }
}