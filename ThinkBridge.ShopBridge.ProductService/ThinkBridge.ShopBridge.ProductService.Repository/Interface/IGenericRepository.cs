using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ThinkBridge.ShopBridge.ProductService.Repository.Interface
{
    /// <summary>
    /// Common Repository Interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Interface method to Get the collection of entities
        /// </summary>
        /// <param name="filter">filter option</param>
        /// <param name="orderBy">order by</param>
        /// <param name="includeProperties">Include Properties</param>
        /// <returns>Entity Collection</returns>
        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");
    }
}
