using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Api.CommonUtilities;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Exceptions;

namespace ThinkBridge.ShopBridge.ProductService.Library.Helpers
{
    /// <summary>
    /// ResponseManager class which will provide functionality of generating standard API Response Object based on few input parameters.
    /// Based on Input details it will extract required info and creates API Response Object.
    /// </summary>
    public class ResponseManager
    {       
        /// <summary>
        /// Standard API Response Object will be created for any API based on input parameters information.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="httpStatus">The HTTP status.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="response">The response.</param>
        /// <returns>API Response Object</returns>
        public static ApiResponse ApiResponse(string status, string message, int httpStatusCode = 500, string httpStatus = null, Exception exception = null, dynamic response = null)
        {
            string error = null;
            var apiResponse = new ApiResponse
            {
                Status = status,
                HttpStatusCode = httpStatusCode,
                HttpStatus = httpStatus,
                Message = message,
                Error = error,
                Response = response
            };
            return apiResponse;
        }

    }
}
