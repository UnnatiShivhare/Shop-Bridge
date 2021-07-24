using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Exceptions;

namespace ThinkBridge.ShopBridge.ProductService.Library.Helpers
{
    /// <summary>
    /// ParamManager to perform query parameters for GET Operations.
    /// </summary>
    public static class ParamManager
    {
        /// <summary>
        /// Gets the query parameters.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="paramerterValues">The paramerter values.</param>
        /// <returns>query parameter string</returns>
        public static string GetQueryParameters(string parameterName, dynamic paramerterValues)
        {
            string queryParameters = string.Empty;

            try
            {
                if (paramerterValues != null && paramerterValues.Count > 0)
                {
                    foreach (var parameterValue in paramerterValues)
                    {
                        var index = paramerterValues.IndexOf(parameterValue);

                        if (index != 0)
                            queryParameters += ServiceConstants.Ampersand;

                        queryParameters += parameterName + ServiceConstants.EqualTo + parameterValue;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }

            return queryParameters;
        }
    }
}
