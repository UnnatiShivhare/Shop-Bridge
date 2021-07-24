using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.UnitTest.MockManager;
using ThinkBridge.ShopBridge.ProductService.UnitTest.Constants;

namespace ThinkBridge.ShopBridge.ProductService.UnitTest
{
    /// <summary>
    /// T01ProductUnitTest class contains all the test cases which is required for the Product entity
    /// </summary>
    [TestClass]
    public class T01ProductUnitTest
    {
        /// <summary>
        /// Private field to initialize ProductMockManager
        /// </summary>
        private readonly ProductMockManager _productMockManager;
        /// <summary>
        /// Private const string ExpectedStatus used for Assert
        /// </summary>
        private const string ExpectedStatus = ServiceConstants.Success;

        /// <summary>
        /// Constructor to initialize ProductMockManager
        /// </summary>
        public T01ProductUnitTest()
        {
            _productMockManager = new ProductMockManager();
        }

        /// <summary>
        /// Test case to create the Product
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void TestMethod01CreateProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var isProductCreated = _productMockManager.CreateProduct(TestConstants.MockInsertProductObject);

            if (isProductCreated)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Test case to get all the Products based on list of product identifiers
        /// </summary>
        [TestMethod]
        [Priority(1)]
        public void TestMethod02GetProductsByIdentifiers()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { TestConstants.MockGetIdentifier };

            var products = _productMockManager.GetProducts(productIdentifiers);

            if (products.Count > 0)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Test case to get all the Products
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestMethod03GetProducts()
        {
            var actualStatus = ServiceConstants.Failure;

            var products = _productMockManager.GetProducts();

            if (products.Count > 0)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Negative Test case to create duplicate record for Product
        /// </summary>
        [TestMethod]
        [Priority(3)]
        public void TestMethod04CreateDuplicateProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var isProductCreated = _productMockManager.CreateProduct(TestConstants.MockInsertDuplicateProductObject);

            if (!isProductCreated)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Test case to update an Product based on identifier 
        /// </summary>
        [TestMethod]
        [Priority(4)]
        public void TestMethod05UpdateProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var isProductUpdated = _productMockManager.UpdateProduct(TestConstants.MockUpdateProductObject);

            if (isProductUpdated)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Negative Test case to update an Product which doesn't exist
        /// </summary>
        [TestMethod]
        [Priority(5)]
        public void TestMethod06UpdateInvalidProduct()
        {
            var actualStatus = ServiceConstants.Failure;

            var isProductUpdated = _productMockManager.UpdateProduct(TestConstants.MockUpdateInvalidProductObject);

            if (!isProductUpdated)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Test case to delete a product with soft delete action
        /// </summary>
        [TestMethod]
        [Priority(6)]
        public void TestMethod07SoftDeleteProduct()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { TestConstants.MockGetIdentifier };

            var isProductDeleted = _productMockManager.DeleteProduct(productIdentifiers, true);

            if (isProductDeleted)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Test case to delete a product with hard delete action
        /// </summary>
        [TestMethod]
        [Priority(7)]
        public void TestMethod08HardDeleteProduct()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { TestConstants.MockGetIdentifier };

            var isProductDeleted = _productMockManager.DeleteProduct(productIdentifiers, false);

            if (isProductDeleted)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }

        /// <summary>
        /// Negative Test case to delete a product whose identifier doesn't exist
        /// </summary>
        [TestMethod]
        [Priority(8)]
        public void TestMethod09DeleteInvalidProduct()
        {
            var actualStatus = ServiceConstants.Failure;
            var productIdentifiers = new List<Guid> { Guid.NewGuid() };

            var isProductDeleted = _productMockManager.DeleteProduct(productIdentifiers, false);

            if (!isProductDeleted)
                actualStatus = ServiceConstants.Success;

            Assert.AreEqual(ExpectedStatus, actualStatus);
        }
    }
}
