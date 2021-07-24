using ThinkBridge.ShopBridge.ProductService.Data.Persistence;
using ThinkBridge.ShopBridge.ProductService.Repository.Interface;
using ThinkBridge.ShopBridge.ProductService.Repository.Repository;

namespace ThinkBridge.ShopBridge.ProductService.Repository
{
    /// <summary>
    /// UnitOfWork class which holds all repository classes as properties
    /// When UnitOfWork class is dependency injected to service controller, any repository can be accessed.
    /// </summary>
    /// <seealso cref="IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {

        /// <summary>
        /// The service database context
        /// </summary>
        private readonly ServiceDbContext _serviceDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="serviceDbContext">The service database context.</param>
        public UnitOfWork(ServiceDbContext serviceDbContext)
        {
            _serviceDbContext = serviceDbContext;
        }

        /// <summary>
        /// Gets the product repository.
        /// </summary>
        /// <value>
        /// The product repository.
        /// </value>
        public IProductRepository ProductRepository => new ProductRepository(_serviceDbContext);
    }

}
