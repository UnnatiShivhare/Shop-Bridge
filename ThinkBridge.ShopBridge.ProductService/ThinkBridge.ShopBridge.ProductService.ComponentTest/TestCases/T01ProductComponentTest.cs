using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.ComponentTest.Constants;
using ThinkBridge.ShopBridge.ProductService.ComponentTest.Helpers;
using ThinkBridge.ShopBridge.ProductService.ComponentTest.WebServiceManager;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Library.ClassObjects;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;

namespace ThinkBridge.ShopBridge.ProductService.ComponentTest.TestCases
{/// <summary>
 /// Test cases for the api end points of the Product Entity
 /// </summary>
    [TestClass]
    public class T01ProductComponentTest
    {
        /// <summary>
        /// private field to initialize ProductManager
        /// </summary>
        private readonly ProductManager _productManager;
        /// <summary>
        /// Private webManager used to issue all type of HTTP request
        /// </summary>
        private readonly WebManager _webManager;
        /// <summary>
        /// private constant string ExpectedStatus used for Assert
        /// </summary>
        private const string ExpectedStatus = ServiceConstants.Success;

        /// <summary>
        /// Constructor to initialize ServiceManager
        /// </summary>
        public T01ProductComponentTest()
        {
            _productManager = new ProductManager();
            _webManager = new WebManager();
        }

        /// <summary>
        /// Component Test case to create Product
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void TestMethod01CreateProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var apiResponse = _productManager.CreateProduct(_webManager, TestConstants.MockInsertProductObject);

            if (apiResponse?.Response != null && Guid.TryParse(apiResponse.Response.ToString(), out Guid _)
                && apiResponse?.Status.Equals(ServiceConstants.Success, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Get the products based on list of product identifiers
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void TestMethod02GetProductsByIdentifiers()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { TestConstants.MockGetIdentifier };

            var apiResponse = _productManager.GetProducts(_webManager, productIdentifiers);

            if (apiResponse?.Response != null
                && apiResponse.Status.Equals(ServiceConstants.Success, StringComparison.InvariantCultureIgnoreCase))
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(apiResponse.Response.ToString());

                if (products.Count > 0)
                    actualStatus = ServiceConstants.Success;
            }

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Get the list of all products
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestMethod03GetProducts()
        {
            var actualStatus = ServiceConstants.Failure;

            var apiResponse = _productManager.GetProducts(_webManager, new List<Guid>());

            if (apiResponse?.Response != null
                && apiResponse.Status.Equals(ServiceConstants.Success, StringComparison.InvariantCultureIgnoreCase))
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(apiResponse.Response.ToString());

                if (products.Count > 0)
                    actualStatus = ServiceConstants.Success;
            }

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Component Test case to create duplicate Product
        /// </summary>
        [TestMethod]
        [Priority(3)]
        public void TestMethod04CreateDuplicateProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var apiResponse = _productManager.CreateProduct(_webManager, TestConstants.MockInsertProductObject);

            if (apiResponse.Status.Equals(ServiceConstants.Failure, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Component Test case to update Product
        /// </summary>
        [TestMethod]
        [Priority(4)]
        public void TestMethod05UpdateProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var apiResponse = _productManager.UpdateProduct(_webManager, TestConstants.MockUpdateProductObject);

            if (apiResponse?.Response != null && apiResponse.Status.Equals(ServiceConstants.Success, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Component Test case to update invalid Product
        /// </summary>
        [TestMethod]
        [Priority(5)]
        public void TestMethod06UpdateInvalidProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var apiResponse = _productManager.UpdateProduct(_webManager, TestConstants.MockUpdateInvalidProductObject);

            if (apiResponse.Status.Equals(ServiceConstants.Failure, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Component Test case to soft delete Product
        /// </summary>
        [TestMethod]
        [Priority(6)]
        public void TestMethod07SoftDeleteProduct()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { TestConstants.MockGetIdentifier };
            var productDetail = new DeleteInfo { Identifiers = productIdentifiers, IsSoftDelete = true, IsActive = false };

            var apiResponse = _productManager.DeleteProduct(_webManager, productDetail);

            if (apiResponse?.Response != null && apiResponse.Status.Equals(ServiceConstants.Success, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Component Test case to hard delete Product
        /// </summary>
        [TestMethod]
        [Priority(7)]
        public void TestMethod08HardDeleteProduct()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { TestConstants.MockGetIdentifier };
            var productDetail = new DeleteInfo { Identifiers = productIdentifiers, IsSoftDelete = false };

            var apiResponse = _productManager.DeleteProduct(_webManager, productDetail);

            if (apiResponse?.Response != null && apiResponse.Status.Equals(ServiceConstants.Success, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Component Test case to delete Invalid Product
        /// </summary>
        [TestMethod]
        [Priority(8)]
        public void TestMethod09DeleteInvalidProduct()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { Guid.NewGuid() };
            var productDetail = new DeleteInfo { Identifiers = productIdentifiers, IsSoftDelete = false };

            var apiResponse = _productManager.DeleteProduct(_webManager, productDetail);

            if (apiResponse.Status.Equals(ServiceConstants.Failure, StringComparison.InvariantCultureIgnoreCase))
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }
    }
}
