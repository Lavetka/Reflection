namespace Reflection
{
    public class MyAppConfiguration : ConfigurationComponentBase
    {
        [ConfigurationItem("UserName", typeof(FileConfigurationProvider))]
        public string UserName { get; set; }

        [ConfigurationItem("TimeoutSeconds", typeof(ConfigurationManagerConfigurationProvider))]
        public int TimeoutSeconds { get; set; }

        [ConfigurationItem("ApiKey", typeof(FileConfigurationProvider))]
        public string ApiKey { get; set; }

        public MyAppConfiguration(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
        }
    }
}

