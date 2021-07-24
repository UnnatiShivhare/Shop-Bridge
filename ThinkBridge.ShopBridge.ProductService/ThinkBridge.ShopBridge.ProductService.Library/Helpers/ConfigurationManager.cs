
using Microsoft.Extensions.Configuration;
using System;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Exceptions;

namespace ThinkBridge.ShopBridge.ProductService.Library.Helpers
{
    /// <summary>
    /// AzureConfigurationManager is a static class and perform operation of getting configuration info from application settings json file.
    /// </summary>
    public static class ConfigurationManager
    {
        /// <summary>
        /// The configuration field to hold configuration values from application settings json file
        /// </summary>
        private static readonly IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile(ServiceConstants.ConfigurationFileName, false, true)
            .Build();

        /// <summary>
        /// Gets the entire configuration values from application settings json file
        /// </summary>
        /// <returns>Configuration</returns>
        public static IConfiguration GetConfiguration()
        {
            return Configuration;
        }

        /// <summary>
        /// Gets the configuration value from application settings json file for a specific key
        /// </summary>
        /// <param name="configName">Name of the configuration.</param>
        /// <returns>Configuration value</returns>
        public static string GetConfigValue(string configName)
        {
            var configValue = string.Empty;

            try
            {
                configValue = Configuration.GetSection(configName).Value;
            }
            catch (Exception ex)
            {
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }

            return configValue;
        }
    }
}