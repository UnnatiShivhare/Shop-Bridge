using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ThinkBridge.ShopBridge.ProductService.Data.Entity
{
    /// <summary>
    /// Product class will hold the properties of Name, IsActive.
    /// This class also inherits all properties like Identifier, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn from BaseEntity.
    /// </summary>
    /// <seealso cref="BaseEntity" />
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Name of Product.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Description of the Product.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the Price of the Product.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        public int Price { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        public bool IsActive { get; set; }

    }
}
