using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadLunatix.ConsoleApp.Configuration
{
    public class MyConfiguration : IConfiguration
    {
        public string OutputDirectory => GetConfigurationValue<string>("outputDirectory", @"C:\Generations");

        public string OutputExtenstion => GetConfigurationValue<string>("outputExtenstion", "jpg");

        public int Amount => GetConfigurationValue<int>("amount", 100);

        public List<string> ElementNames => GetConfigurationValue<string>("elementNames", String.Empty).Split(",").ToList();

        public string ElementsDirectory => GetConfigurationValue<string>("elementsDirectory", @"C:\Elements");

        public MyConfiguration() { }

        private T GetConfigurationValue<T>(string key, T defaultValue)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                var value = ConfigurationManager.AppSettings[key];
                if(value == null || converter == null) 
                    return defaultValue;

                return (T) converter.ConvertFromString(value);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}
