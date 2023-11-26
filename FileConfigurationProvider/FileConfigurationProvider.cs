/*using Newtonsoft.Json;
using SharedNamespace;

namespace FileConfigurationProvider;

public class FileConfigurationProvider : IConfigurationProvider
{
    private readonly string filePath;

    public FileConfigurationProvider(string filePath)
    {
        this.filePath = filePath;
    }

    public string LoadSettings(string settingName)
    {
        if (File.Exists(filePath))
        {
            var settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(filePath));

            if (settings != null && settings.ContainsKey(settingName))
            {
                var settingValue = settings[settingName];
                return settingValue?.ToString();
            }
        }
        Console.WriteLine("No such parameter in File");
        return null;
    }

    public void SaveSettings(string settingName, string value)
    {
        var settings = new Dictionary<string, object>();

        if (File.Exists(filePath))
        {
            settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(filePath));
        }

        settings[settingName] = value;

        File.WriteAllText(filePath, JsonConvert.SerializeObject(settings));
    }
}

*/