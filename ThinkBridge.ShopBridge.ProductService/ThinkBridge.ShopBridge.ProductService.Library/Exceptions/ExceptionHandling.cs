using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Logging;

namespace ThinkBridge.ShopBridge.ProductService.Library.Exceptions
{
    /// <summary>
    /// ExceptionalHandling is a static class and contains static method which handle exceptions & invokes logger to log messages.
    /// </summary>
    public static class ExceptionalHandling
    {
        /// <summary>
        /// Handles the exception by extracting specific exception message and log message by invoking blob logger.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        public static void HandleException(Exception exception, string exceptionType)
        {            
            var message = exception.ToString();

            try
            {  
                Logger.LogMessageAsync(message, exceptionType).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Logger.LogMessageAsync(ex.Message, ServiceConstants.Error).ConfigureAwait(true);
            }
        }
    }
}
