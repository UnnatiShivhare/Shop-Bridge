using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ThinkBridge.ShopBridge.ProductService.Data.Entity
{
    /// <summary>
    /// BaseEntity class will hold properties of Identifier, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier value with GUID return type to Identifier Property.
        /// Also this property is primary key. This property won't allow null values.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public Guid Identifier { get; set; }
        /// <summary>
        /// Gets or sets the created date-time value with DateTime return type to CreatedOn Property.
        /// This property allow null values as it is optional property while updating data.
        /// <value>
        /// The created on.
        /// </value>
        /// </summary>
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets the created by value with string return type to CreatedBy Property.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the updated date-time value with DateTime return type to UpdatedOn Property.
        /// This property allow null values as it is optional property while creating an entry.
        /// </summary>
        /// <value>
        /// The updated on.
        /// </value>
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Gets or sets the modified by value with string return type to UpdatedBy Property.
        /// This property allow null values as it is optional property while creating an entry.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        public string UpdatedBy { get; set; }
    }
}
