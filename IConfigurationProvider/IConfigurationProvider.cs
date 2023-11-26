namespace SharedNamespace
{
    public interface IConfigurationProvider
    {
        string LoadSettings(string settingName);
        void SaveSettings(string settingName, string value);
    }
}