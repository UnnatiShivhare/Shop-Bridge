using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;

namespace ThinkBridge.ShopBridge.ProductService.Repository.Interface
{
    /// <summary>
    /// Product Repository Interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Creates the Product.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <returns>
        ///  <c>true</c> if Product is created; otherwise <c>false</c>
        /// </returns>
        bool CreateProduct(Product product);

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="productIdentifiers">The product identifiers.</param>
        /// <returns>list of products</returns>
        List<Product> GetProducts(List<Guid> productIdentifiers = null);

        /// <summary>
        /// Updates the Product.
        /// </summary>
        /// <param name="product">The Product.</param>
        /// <returns>
        ///  <c>true</c> if Product is updated; otherwise <c>false</c>
        /// </returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// Deletes the Product.
        /// </summary>
        /// <param name="productIdentifier">The product identifier.</param>
        /// <returns>
        ///  <c>true</c> if Product is deleted; otherwise <c>false</c>
        /// </returns>
        bool DeleteProduct(List<Guid> productIdentifiers, bool isSoftDelete, bool isActive);
    }
}
