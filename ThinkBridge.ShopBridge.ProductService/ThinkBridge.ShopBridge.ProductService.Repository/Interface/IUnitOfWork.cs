using System;
using System.Collections.Generic;
using System.Text;

namespace ThinkBridge.ShopBridge.ProductService.Repository.Interface
{
    /// <summary>
    /// UnitOfWork Interface
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the product repository.
        /// </summary>
        /// <value>
        /// The product repository.
        /// </value>
        IProductRepository ProductRepository { get; }
    }
}
