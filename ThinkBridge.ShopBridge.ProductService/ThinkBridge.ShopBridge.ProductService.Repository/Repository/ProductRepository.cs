using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Data.Persistence;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Library.Exceptions;
using ThinkBridge.ShopBridge.ProductService.Repository.Interface;

namespace ThinkBridge.ShopBridge.ProductService.Repository.Repository
{
    /// <summary>
    /// Product Repository class will be having database context to perform CRUD Operations for a Product Entity.
    /// </summary>
    /// <seealso cref="GenericRepository{Product}" />
    /// <seealso cref="IProductRepository" />
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        /// <summary>
        /// The service database context
        /// </summary>
        private readonly ServiceDbContext _serviceDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="serviceDbContext">The service database context.</param>
        public ProductRepository(ServiceDbContext serviceDbContext) : base(serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>
        ///  <c>true</c> if product is created; otherwise <c>false</c>
        /// </returns>
        public bool CreateProduct(Product product)
        {
            var isProductCreated = false;

            try
            {
                Add(product);
                _serviceDbContext.SaveChanges();
                isProductCreated = true;
            }
            catch (Exception ex)
            {
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }

            return isProductCreated;
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="productIdentifiers">The product identifiers.</param>
        /// <returns>list of product</returns>
        public List<Product> GetProducts(List<Guid> productIdentifiers = null)
        {
            var product = new List<Product>();

            try
            {
                if (productIdentifiers != null && productIdentifiers.Any())
                    product = Get(q => productIdentifiers.Contains(q.Identifier),
                        o => o.OrderBy(prop => prop.CreatedOn),
                        string.Empty).ToList();
                else
                    product = Get(null,
                       o => o.OrderBy(prop => prop.CreatedOn),
                       string.Empty).ToList();
            }
            catch (Exception ex)
            {
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }

            return product;
        }

        /// <summary>
        /// Updates the Product.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <returns>
        ///  <c>true</c> if Product is updated; otherwise <c>false</c>
        /// </returns>
        public bool UpdateProduct(Product product)
        {
            var isProductUpdated = false;

            try
            {
                var productDetails = GetById(product.Identifier);
                if (productDetails == null) return false;

                if (!string.IsNullOrEmpty(product.Name))
                    productDetails.Name = product.Name;
                if (!string.IsNullOrEmpty(product.Description))
                    productDetails.Description = product.Description;
                if (product.Price >= 0)
                    productDetails.Price = product.Price;
                productDetails.IsActive = product.IsActive;
                if (!string.IsNullOrEmpty(product.UpdatedBy))
                    productDetails.UpdatedBy = product.UpdatedBy;
                productDetails.UpdatedOn = DateTime.UtcNow;
                _serviceDbContext.SaveChanges();
                isProductUpdated = true;
            }
            catch (Exception ex)
            {
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }

            return isProductUpdated;
        }

        /// <summary>
        /// Deletes the Products.
        /// </summary>
        /// <param name="productIdentifiers">The product identifiers.</param>       
        /// <returns>
        ///  <c>true</c> if Product is deleted; otherwise <c>false</c>
        /// </returns>
        public bool DeleteProduct(List<Guid> productIdentifiers, bool isSoftDelete, bool isActive)
        {
            var isProductsDeleted = false;

            try
            {
                foreach (var productDetails in productIdentifiers.Select(productIdentifier => GetById(productIdentifier)))
                {
                    if (isSoftDelete)
                        productDetails.IsActive = isActive;
                    else
                        Remove(productDetails);
                }

                _serviceDbContext.SaveChanges();
                isProductsDeleted = true;
            }
            catch (Exception ex)
            {
                ExceptionalHandling.HandleException(ex, ServiceConstants.Error);
            }

            return isProductsDeleted;
        }

    }
}
