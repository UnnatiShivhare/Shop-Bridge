using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ThinkBridge.ShopBridge.ProductService.Data.Persistence;
using ThinkBridge.ShopBridge.ProductService.Repository.Interface;


namespace ThinkBridge.ShopBridge.ProductService.Repository.Repository
{
    /// <summary>
    /// Generic Repository class for data access methods using Entity Framework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly ServiceDbContext MockContext;
        /// <summary>
        /// The database set
        /// </summary>
        protected internal DbSet<TEntity> MockDbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(ServiceDbContext context)
        {
            MockContext = context;
            MockDbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// Gets the collection of entities based on the optional filter, orderBy and includeProperties
        /// </summary>
        /// <param name="filter">lambda expression filter</param>
        /// <param name="orderBy">orderBy delegate</param>
        /// <param name="includeProperties">related objects delimited by comma</param>
        /// <returns>Entity Collection</returns>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = MockDbSet;

            if (filter != null)
                query = query.Where(filter);

            var includedProperties = includeProperties != null
                ? includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                : new string[] { };

            Parallel.ForEach(
                includedProperties, includeProperty =>
                {
                    query = query.Include(includeProperty);
                });

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        /// <summary>
        /// Get the Entity Details based on the Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>get entity by id</returns>
        public virtual TEntity GetById(object id)
        {
            return MockDbSet.Find(id);
        }

        /// <summary>
        /// Adds the entity to the context
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Add(TEntity entity)
        {
            MockDbSet.Add(entity);
        }

        /// <summary>
        /// Adds a set of entities to the context
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            MockDbSet.AddRange(entities);
        }

        /// <summary>
        /// Removes the Entity from the Context
        /// </summary>
        /// <param name="entity">entity</param>
        public virtual void Remove(TEntity entity)
        {
            if (MockContext.Entry(entity).State == EntityState.Detached)
                MockDbSet.Attach(entity);

            MockDbSet.Remove(entity);
        }

        /// <summary>
        /// Removes a set of entities from the context
        /// </summary>
        /// <param name="entities">list of entities</param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }
    }
}
