using System.Reflection;
using Reflection;
using SharedNamespace;

class Program
{
    static void Main()
    {
        // Specify the directory where DLLs are located
        string pluginsDirectory = "/Users/lavetos/Projects/NETMentoring/Reflection/Reflection/bin/Debug/net7.0";

        // Load and instantiate FileConfigurationProvider from DLL
        
        var fileConfigurationProvider = LoadProvider<IConfigurationProvider>("FileConfigurationProvider.dll", pluginsDirectory, new object[] { filePath });

        // Load and instantiate ConfigurationManagerConfigurationProvider from DLL
        IConfigurationProvider configManagerConfigurationProvider = LoadProvider<IConfigurationProvider>("ConfigurationManagerConfigurationProvider.dll", pluginsDirectory);

        // Example with FileConfigurationProvider
        var appConfigFile = new MyAppConfiguration();
        appConfigFile.LoadSettings();

        Console.WriteLine($"UserName: {appConfigFile.UserName}");
        Console.WriteLine($"ApiKey: {appConfigFile.ApiKey}");

        appConfigFile.UserName = "Hleb";
        appConfigFile.ApiKey = "12345";
        appConfigFile.SaveSettings();

        Console.WriteLine($"UserName: {appConfigFile.UserName}");
        Console.WriteLine($"ApiKey: {appConfigFile.ApiKey}");

        // Example with ConfigurationManagerConfigurationProvider
        var appConfigManager = new MyAppConfiguration();
        appConfigManager.LoadSettings();

        Console.WriteLine($"TimeoutSeconds: {appConfigManager.TimeoutSeconds}");

        appConfigManager.TimeoutSeconds = 30;
        appConfigManager.SaveSettings();

        Console.WriteLine($"TimeoutSeconds: {appConfigManager.TimeoutSeconds}");

        static T LoadProvider<T>(string dllName, string directory, object[] constructorArgs = null)
        {
            string dllPath = Path.Combine(directory, dllName);

            if (File.Exists(dllPath))
            {
                var assembly = Assembly.LoadFrom(dllPath);
                var providerType = assembly.GetTypes().FirstOrDefault(t => typeof(T).IsAssignableFrom(t));

                if (providerType != null)
                {
                    return (T)Activator.CreateInstance(providerType, constructorArgs);
                }
            }

            throw new FileNotFoundException($"Provider DLL '{dllName}' not found.");
        }
    }
}
