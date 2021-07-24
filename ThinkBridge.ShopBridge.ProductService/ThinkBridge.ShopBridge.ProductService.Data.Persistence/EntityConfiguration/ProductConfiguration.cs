using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;

namespace ThinkBridge.ShopBridge.ProductService.Data.Persistence.EntityConfiguration
{
    /// <summary>
    /// ProductConfiguration class will hold the Entity Framework Fluent API Configuration for Product Class properties.
    /// Each property will have declarations based on DB Schema, Column Types, Indexes, Length and IsRequired etc.
    /// This class also inherits BaseEntityConfiguration.
    /// </summary>
    /// <seealso cref="BaseEntityConfiguration{Product}" />
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for Product class properties.
        /// Property will have declarations based on DB Schema, Column Types, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The role entity configuration.</param>
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            // Create Table
            builder.ToTable(ServiceConstants.DbProductsTable);

            // Entity Properties and Table Columns Mapping
            builder.Property(prop => prop.Name)
                .HasColumnName(ServiceConstants.DbNameColumn)
                .HasColumnType(ServiceConstants.DbStringMedium)
                .HasMaxLength(255);
            builder.Property(prop => prop.Description)
               .HasColumnName(ServiceConstants.DbDescriptionColumn)
               .HasColumnType(ServiceConstants.DbStringMedium)
               .HasMaxLength(255);
            builder.Property(prop => prop.Price)
               .HasColumnName(ServiceConstants.DbPriceColumn)
               .HasColumnType(ServiceConstants.DbIntegerSmall);
            builder.Property(prop => prop.IsActive)
                .HasColumnName(ServiceConstants.DbIsActiveColumn)
                .HasColumnType(ServiceConstants.DbBoolean)
                .HasDefaultValue(false);
        }

    }
}
