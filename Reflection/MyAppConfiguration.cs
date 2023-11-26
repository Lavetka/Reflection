using SharedNamespace;

namespace Reflection
{
    public class MyAppConfiguration : ConfigurationComponentBase
    {
        public MyAppConfiguration(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }

        [ConfigurationItem("UserName")]
        public string UserName { get; set; }

        [ConfigurationItem("TimeoutSeconds")]
        public int TimeoutSeconds { get; set; }

        [ConfigurationItem("ApiKey")]
        public string ApiKey { get; set; }
    }
}

