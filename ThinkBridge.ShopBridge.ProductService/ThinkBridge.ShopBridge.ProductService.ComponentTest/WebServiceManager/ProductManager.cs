using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThinkBridge.ShopBridge.ProductService.Api.CommonUtilities;
using ThinkBridge.ShopBridge.ProductService.ComponentTest.Constants;
using ThinkBridge.ShopBridge.ProductService.ComponentTest.Helpers;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Library.ClassObjects;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Helpers;

namespace ThinkBridge.ShopBridge.ProductService.ComponentTest.WebServiceManager
{
    /// <summary>
    /// ProductManager to invoke CRUD operations on Product Entity using HTTP Client.
    /// </summary>
    public class ProductManager
    {
        /// <summary>
        /// Create Operation HTTP Client Call on Product Entity Create API Endpoint.
        /// </summary>
        /// <param name="webManager">web manager object</param>
        /// <param name="product">product entity</param>
        /// <returns>status of creation of product</returns>
        public ApiResponse CreateProduct(WebManager webManager, Product product)
        {
            var apiResponse = new ApiResponse();

            var response = webManager.HttpClientRequest(ServiceConstants.Post,
                TestConstants.EndpointToProducts, product);
            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
            return apiResponse;
        }

        /// <summary>
        /// Get Operation HTTP Client Call on Product Entity Get API Endpoint.
        /// </summary>
        /// <param name="webManager">web manager object</param>
        /// <param name="productIdentifiers">list of product identifiers</param>
        /// <returns>list of products</returns>
        public ApiResponse GetProducts(WebManager webManager, List<Guid> productIdentifiers = null)
        {
            var apiResponse = new ApiResponse();

            var apiUrl = TestConstants.EndpointToProducts;

            if (productIdentifiers != null && productIdentifiers.Count > 0)
            {
                var queryParameters = ParamManager.GetQueryParameters(TestConstants.ProductIdentifiers,
                    productIdentifiers);

                if (!string.IsNullOrEmpty(queryParameters))
                    apiUrl += ServiceConstants.QuestionMark + queryParameters;
            }

            var response = webManager.HttpClientRequest(ServiceConstants.Get, apiUrl);
            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

            return apiResponse;
        }

        /// <summary>
        /// Update Operation HTTP Client Call on Product Entity Update API Endpoint.
        /// </summary>
        /// <param name="webManager">web manager object</param>
        /// <param name="product">product entity</param>
        /// <returns>status of update operation of product details</returns>
        public ApiResponse UpdateProduct(WebManager webManager, Product product)
        {
            var apiResponse = new ApiResponse();

            var response = webManager.HttpClientRequest(ServiceConstants.Put,
                TestConstants.EndpointToProducts, product);
            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

            return apiResponse;
        }

        /// <summary>
        /// Delete Operation HTTP Client Call on Product Entity Delete API Endpoint.
        /// </summary>
        /// <param name="webManager">web manager object</param>
        /// <param name="deleteInfo">The delete information.</param>
        /// <returns>status of delete operation of product details</returns>
        public ApiResponse DeleteProduct(WebManager webManager, DeleteInfo deleteInfo)
        {
            var apiResponse = new ApiResponse();

            var response = webManager.HttpClientRequest(ServiceConstants.Delete,
                TestConstants.EndpointToProducts, deleteInfo);
            apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

            return apiResponse;
        }
    }
}
