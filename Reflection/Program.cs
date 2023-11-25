using Reflection;

class Program
{
    static void Main()
    {
        IConfigurationProvider fileConfigurationProvider = new FileConfigurationProvider("config.json");
        IConfigurationProvider configManagerConfigurationProvider = new ConfigurationManagerConfigurationProvider();

        // Example with FileConfigurationProvider
        var appConfigFile = new MyAppConfiguration(fileConfigurationProvider);
        appConfigFile.LoadSettings();

        Console.WriteLine($"UserName: {appConfigFile.UserName}");
        Console.WriteLine($"ApiKey: {appConfigFile.ApiKey}");

          appConfigFile.UserName = "Hleb";
          appConfigFile.ApiKey = "12345";
          appConfigFile.SaveSettings();

        Console.WriteLine($"UserName: {appConfigFile.UserName}");
        Console.WriteLine($"ApiKey: {appConfigFile.ApiKey}");
     

        // Example with ConfigurationManagerConfigurationProvider
        var appConfigManager = new MyAppConfiguration(configManagerConfigurationProvider);
        appConfigManager.LoadSettings();

        Console.WriteLine($"TimeoutSeconds: {appConfigManager.TimeoutSeconds}");

        appConfigManager.TimeoutSeconds = 30;
        appConfigManager.SaveSettings();

        Console.WriteLine($"TimeoutSeconds: {appConfigManager.TimeoutSeconds}");
    }
}