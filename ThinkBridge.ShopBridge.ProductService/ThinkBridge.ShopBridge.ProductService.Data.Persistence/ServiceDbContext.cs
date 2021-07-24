using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Data.Persistence.EntityConfiguration;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;

namespace ThinkBridge.ShopBridge.ProductService.Data.Persistence
{
    /// <summary>
    /// ServiceDbContext class inherits the DBContext class and provides the functionality to get the connection string from app setting.json and what type of database, initializes the model-builder whose functionality is provided in the entity configuration folder and also initializes the DBSet
    /// </summary>
    public class ServiceDbContext : DbContext
    {
        /// <summary>
        /// Get the connection string from application settings json and check what type of database is being called
        /// </summary>
        /// <param name="optionsBuilder">options builder</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(ServiceConstants.ConfigurationFileName, false, true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString(ServiceConstants.DefaultConnectionName);
            optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
        }
        /// <summary>
        /// Initializes the schema and apply configuration for entity
        /// </summary>
        /// <param name="modelBuilder">builds the model</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set Default Schema
            modelBuilder.HasDefaultSchema(ServiceConstants.ProductServiceSchema);

            // Apply Entity configuration
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

        }
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The Products.
        /// </value>
        public DbSet<Product> Products { get; set; }
    }
}
