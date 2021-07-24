using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ThinkBridge.ShopBridge.ProductService.Api.CommonUtilities;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Library.ClassObjects;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Exceptions;
using ThinkBridge.ShopBridge.ProductService.Library.Helpers;
using ThinkBridge.ShopBridge.ProductService.Repository.Interface;

namespace ThinkBridge.ShopBridge.ProductService.Api.Controllers
{
    [Route(ServiceConstants.ApiRoutePrefix)]
    [Produces(ServiceConstants.ApiResponseContentType)]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Private field of The unit of work with repository properties
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// API End point to create a new product by accepting product entity which contains name and created by.
        /// Once Product is created respective response will be returned.
        /// </summary>
        /// <param name="product">The product details.</param>
        /// <returns>response Json with status of product creation operation</returns>
        [HttpPost("Products")]
        public ActionResult<ApiResponse> CreateProduct([FromBody] Product product)
        {
            ApiResponse apiResponse;
            const int httpStatusCode = (int)HttpStatusCode.BadRequest;
            const string httpStatus = ServiceConstants.BadRequest;

            try
            {
                if (ModelState.IsValid)
                {
                    product.CreatedOn = DateTime.UtcNow;
                    var isProductCreated = _unitOfWork.ProductRepository.CreateProduct(product);
                    apiResponse = isProductCreated
                        ? ResponseManager.ApiResponse(ServiceConstants.Success, ServiceConstants.CreateMessage,
                            (int)HttpStatusCode.OK, ServiceConstants.Ok, null, product.Identifier)
                        : ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.CreateFailMessage,
                            (int)HttpStatusCode.OK, ServiceConstants.Ok, null, false);
                }
                else
                {
                    apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.CreateFailMessage,
                        httpStatusCode, httpStatus, null, ServiceConstants.InvalidInput);
                }
            }
            catch (Exception ex)
            {
                apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.InternalServerError,
                    (int)HttpStatusCode.InternalServerError, ServiceConstants.InternalServerError, ex);
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }
            return Ok(apiResponse);
        }
        /// <summary>
        /// API End Point to get all products which present in Product Service System.
        /// </summary>
        /// <param name="productIdentifiers">list of product identifiers.</param>
        /// <returns>response Json with status of getting all products</returns>
        [HttpGet("Products")]
        public ActionResult<ApiResponse> GetProducts([FromQuery] List<Guid> productIdentifiers = null)
        {
            ApiResponse apiResponse;
            try
            {
                var products = _unitOfWork.ProductRepository.GetProducts(productIdentifiers);

                apiResponse = ResponseManager.ApiResponse(ServiceConstants.Success, ServiceConstants.FetchMessage,
                    (int)HttpStatusCode.OK, ServiceConstants.Ok, null, products);
            }
            catch (Exception ex)
            {
                apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.InternalServerError,
                    (int)HttpStatusCode.InternalServerError, ServiceConstants.InternalServerError, ex);
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }
            return Ok(apiResponse);
        }
        /// <summary>
        /// API End point to update an existing product by accepting product entity which contains name, is active, modified by.
        /// Once Product is updated respective response will be returned.
        /// </summary>
        /// <param name="product">The product details to be updated.</param>
        /// <returns>response Json with status of product update</returns>
        [HttpPut("Products")]
        public ActionResult<ApiResponse> UpdateProduct([FromBody] Product product)
        {
            ApiResponse apiResponse;
            const int httpStatusCode = (int)HttpStatusCode.BadRequest;
            const string httpStatus = ServiceConstants.BadRequest;

            try
            {
                if (ModelState.IsValid)
                {
                    var isProductUpdated = _unitOfWork.ProductRepository.UpdateProduct(product);

                    apiResponse = isProductUpdated
                        ? ResponseManager.ApiResponse(ServiceConstants.Success, ServiceConstants.UpdateMessage,
                            (int)HttpStatusCode.OK, ServiceConstants.Ok, null, true)
                        : ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.UpdateFailMessage,
                            (int)HttpStatusCode.OK, ServiceConstants.Ok, null, false);
                }
                else
                {
                    apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.UpdateFailMessage,
                        httpStatusCode, httpStatus, null, ServiceConstants.InvalidInput);
                }
            }
            catch (Exception ex)
            {
                apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.InternalServerError,
                    (int)HttpStatusCode.InternalServerError, ServiceConstants.InternalServerError, ex);
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }
            return Ok(apiResponse);
        }
        /// <summary>
        /// API End point to delete an existing product by accepting product entity which contains identifier and type of delete.
        /// Once Product is deleted respective response will be returned.
        /// </summary>
        /// <param name="deleteInfo">the delete information.</param>
        /// <returns>response Json with status of product delete operation</returns>
        [HttpDelete("Products")]
        public ActionResult<ApiResponse> DeleteProduct([FromBody] DeleteInfo deleteInfo)
        {
            ApiResponse apiResponse;
            const int httpStatusCode = (int)HttpStatusCode.BadRequest;
            const string httpStatus = ServiceConstants.BadRequest;
            var successMessage = deleteInfo.IsSoftDelete ? ServiceConstants.SoftDeleteMessage : ServiceConstants.DeleteMessage;
            var failureMessage = deleteInfo.IsSoftDelete ? ServiceConstants.SoftDeleteFailMessage : ServiceConstants.DeleteFailMessage;

            try
            {
                if (ModelState.IsValid)
                {
                    var isProductDeleted = _unitOfWork.ProductRepository
                        .DeleteProduct(deleteInfo.Identifiers, deleteInfo.IsSoftDelete, deleteInfo.IsActive);

                    apiResponse = isProductDeleted
                       ? ResponseManager.ApiResponse(ServiceConstants.Success, successMessage,
                           (int)HttpStatusCode.OK, ServiceConstants.Ok, null, true)
                       : ResponseManager.ApiResponse(ServiceConstants.Failure, failureMessage,
                           (int)HttpStatusCode.OK, ServiceConstants.Ok, null, false);
                }
                else
                {
                    apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.DeleteFailMessage,
                        httpStatusCode, httpStatus, null, ServiceConstants.InvalidInput);
                }
            }
            catch (Exception ex)
            {
                apiResponse = ResponseManager.ApiResponse(ServiceConstants.Failure, ServiceConstants.InternalServerError,
                    (int)HttpStatusCode.InternalServerError, ServiceConstants.InternalServerError, ex);
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }
            return Ok(apiResponse);
        }
    }
}
