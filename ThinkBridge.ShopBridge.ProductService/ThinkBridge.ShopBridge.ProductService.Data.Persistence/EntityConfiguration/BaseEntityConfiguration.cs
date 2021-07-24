using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;

namespace ThinkBridge.ShopBridge.ProductService.Data.Persistence.EntityConfiguration
{
    /// <summary>
    /// BaseEntityConfiguration class will hold the Entity Framework Fluent API Configuration for BaseEntity Class properties.
    /// Each property will have declarations based on DB Schema, Column Types, Indexes, Length and IsRequired etc.
    /// This class also inherits EF Core Entity Type Configuration.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{TEntity}" />
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Configures the EntityTypeBuilder for BaseEntity class properties.
        /// Property will have declarations based on DB Schema, Column Types, Indexes, Length and IsRequired etc.
        /// </summary>
        /// <param name="builder">The base configuration.</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(prop => prop.Identifier)
                .HasColumnName(ServiceConstants.DbIdentifierColumn)
                .HasColumnType(ServiceConstants.DbUniqueIdentifier)
                .HasDefaultValueSql(ServiceConstants.DbDefaultUniqueIdentifier)
                .IsRequired();

            builder.Property(prop => prop.CreatedOn)
                .HasColumnName(ServiceConstants.DbCreatedOnColumn)
                .HasColumnType(ServiceConstants.DbDateTime)
                .HasDefaultValueSql(ServiceConstants.DbDefaultDateTime)
                .IsRequired();

            builder.Property(prop => prop.CreatedBy)
                .HasColumnName(ServiceConstants.DbCreatedByColumn)
                .HasColumnType(ServiceConstants.DbStringMedium)
                .HasMaxLength(255);

            builder.Property(prop => prop.UpdatedOn)
                .HasColumnName(ServiceConstants.DbUpdatedOnColumn)
                .HasColumnType(ServiceConstants.DbDateTime)
                .HasDefaultValueSql(ServiceConstants.DbDefaultDateTime);

            builder.Property(prop => prop.UpdatedBy)
                .HasColumnName(ServiceConstants.DbUpdatedByColumn)
                .HasColumnType(ServiceConstants.DbStringMedium)
                .HasMaxLength(255);
        }
    }
}
