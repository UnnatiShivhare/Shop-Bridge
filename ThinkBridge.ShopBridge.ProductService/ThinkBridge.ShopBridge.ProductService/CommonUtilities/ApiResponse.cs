using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridge.ShopBridge.ProductService.Api.CommonUtilities
{
    /// <summary>
    /// ApiResponse class which holds properties of standard API Response object
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the status with string return type to Status Property.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the HTTP status code with int return type to HttpStatusCode Property.
        /// </summary>
        /// <value>
        /// The HTTP status code.
        /// </value>
        public int HttpStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the HTTP status with string return type to HttpStatus Property.
        /// </summary>
        /// <value>
        /// The HTTP status.
        /// </value>
        public string HttpStatus { get; set; }
        /// <summary>
        /// Gets or sets the message with string return type to Message Property.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the error with string return type to Error Property.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public string Error { get; set; }
        /// <summary>
        /// Gets or sets the response with dynamic return type to Response Property.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        public dynamic Response { get; set; }
    }
}
