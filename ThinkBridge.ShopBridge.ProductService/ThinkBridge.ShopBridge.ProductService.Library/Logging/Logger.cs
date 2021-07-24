using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Helpers;

namespace ThinkBridge.ShopBridge.ProductService.Library.Logging
{
    public static class Logger
    {
        public static async Task LogMessageAsync(string message, string filePath = null)
        {
            try
            {
                string fileLogTemplate;
                string defaultDateFormat;

                filePath ??= ConfigurationManager.GetConfigValue(ServiceConstants.FileStoragePath);
                fileLogTemplate = ConfigurationManager.GetConfigValue(ServiceConstants.DefaultFileLogTemplate);
                defaultDateFormat = ConfigurationManager.GetConfigValue(ServiceConstants.DefaultDateFormat);

                var currentDateTime = DateTime.UtcNow;
                var logDate = currentDateTime.ToString(defaultDateFormat);
                var messageContent = string.Format(fileLogTemplate, logDate, message, Environment.NewLine);

                File.AppendAllText(filePath, messageContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
