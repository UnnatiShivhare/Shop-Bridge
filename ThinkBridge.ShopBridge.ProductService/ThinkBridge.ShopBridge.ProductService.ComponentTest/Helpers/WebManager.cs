using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Api;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;

namespace ThinkBridge.ShopBridge.ProductService.ComponentTest.Helpers
{
    /// <summary>
    /// WebManager to perform HTTP Client for Service API End Points.
    /// </summary>
    public class WebManager
    {
        /// <summary>
        /// HttpClient object to issue HTTP request
        /// </summary>
        public HttpClient Client { get; }

        /// <summary>
        /// Constructor to initialize the WebHostBuilder for in memory TestServer 
        /// </summary>
        public WebManager()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>().UseEnvironment(ServiceConstants.Test);
            var testServer = new TestServer(webHostBuilder);

            Client = testServer.CreateClient();
        }

        /// <summary>
        /// Common method to handle all HTTP type request
        /// </summary>
        /// <param name="requestType">type of request</param>
        /// <param name="apiUrl">api URL</param>
        /// <param name="dataObject">data object</param>
        /// <returns>api response for End Points</returns>
        public string HttpClientRequest(string requestType, string apiUrl, dynamic dataObject = null)
        {
            string apiResponse = null;


            var serializedJsonContent = dataObject != null ? JsonConvert.SerializeObject(dataObject) : string.Empty;

            var httpRequestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(Client.BaseAddress + apiUrl),
                Method = requestType switch
                {
                    ServiceConstants.Post => HttpMethod.Post,
                    ServiceConstants.Put => HttpMethod.Put,
                    ServiceConstants.Delete => HttpMethod.Delete,
                    _ => HttpMethod.Get
                },
                Content = requestType != ServiceConstants.Get
                ? new StringContent(serializedJsonContent, Encoding.UTF8, ServiceConstants.ApiResponseContentType)
                : null
            };

            using var response = Client.SendAsync(httpRequestMessage).Result;
            if (response.IsSuccessStatusCode)
                apiResponse = response.Content.ReadAsStringAsync().Result;


            return apiResponse;
        }
    }
}
