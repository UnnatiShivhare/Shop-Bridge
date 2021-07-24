using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ThinkBridge.ShopBridge.ProductService.Library.ClassObjects
{
    /// <summary>
    /// DeleteInfo class will hold required properties for Delete Operation Input Object.
    /// </summary>
    public class DeleteInfo
    {
        /// <summary>
        /// Gets or sets the identifiers.
        /// </summary>
        /// <value>
        /// The identifiers.
        /// </value>
        public List<Guid> Identifiers { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is soft delete.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is soft delete; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool IsSoftDelete { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}