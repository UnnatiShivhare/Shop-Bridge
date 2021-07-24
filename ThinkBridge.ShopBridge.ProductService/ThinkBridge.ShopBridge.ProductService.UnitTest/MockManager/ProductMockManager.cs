using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Data.Persistence;
using ThinkBridge.ShopBridge.ProductService.Repository;
using ThinkBridge.ShopBridge.ProductService.Repository.Interface;

namespace ThinkBridge.ShopBridge.ProductService.UnitTest.MockManager
{
    /// <summary>
    /// Product Mock Manager class to into product repository functions
    /// </summary>
    public class ProductMockManager
    {
        /// <summary>
        /// Private field to initialize unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Initializes a new instance <see cref="ProductMockManager"/> class. 
        /// </summary> 
        public ProductMockManager()
        {
            var accessDbContext = new ServiceDbContext();
            _unitOfWork = new UnitOfWork(accessDbContext);
        }

        /// <summary>
        /// Create operation on Product Entity with mock data
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>
        ///     <c>True : If the mock product is created successfully in database</c>
        ///     <c>False: If any error occured while creating the product</c>
        /// </returns>
        public bool CreateProduct(Product product)
        {
            var isProductCreated = false;


            isProductCreated = _unitOfWork.ProductRepository.CreateProduct(product);


            return isProductCreated;
        }

        /// <summary>
        /// Get operation on Product Entity with mock data
        /// </summary>
        /// <param name="productIdentifiers">The product identifiers.</param>
        /// <returns>list of products</returns>
        public List<Product> GetProducts(List<Guid> productIdentifiers = null)
        {
            var products = new List<Product>();


            products = _unitOfWork.ProductRepository.GetProducts(productIdentifiers);


            return products;
        }

        /// <summary>
        /// Update operation on Product Entity with mock data
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>
        ///     <c>True : If the mock product is updated successfully in database</c>
        ///     <c>False: If any error occured while updating the product</c>
        /// </returns>
        public bool UpdateProduct(Product product)
        {
            var isProductUpdated = false;


            isProductUpdated = _unitOfWork.ProductRepository.UpdateProduct(product);


            return isProductUpdated;
        }

        /// <summary>
        /// Delete operation on Product Entity with mock data
        /// </summary>
        /// <param name="productIdentifiers">The product identifiers.</param>
        /// <param name="isSoftDelete">if set to <c>true</c> [is soft delete].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        ///     <c>True : If the mock product is deleted successfully in database</c>
        ///     <c>False: If any error occured while deleting the product</c>
        /// </returns>
        public bool DeleteProduct(List<Guid> productIdentifiers, bool isSoftDelete, bool isActive = false)
        {
            var isProductRemoved = false;


            isProductRemoved = _unitOfWork.ProductRepository.DeleteProduct(productIdentifiers, isSoftDelete, isActive);


            return isProductRemoved;
        }
    }
}
