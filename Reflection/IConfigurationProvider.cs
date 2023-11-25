using System;
namespace Reflection
{
	public interface IConfigurationProvider
	{
        string LoadSettings(string setting);
        void SaveSettings(string setting, string value);
    }
}

