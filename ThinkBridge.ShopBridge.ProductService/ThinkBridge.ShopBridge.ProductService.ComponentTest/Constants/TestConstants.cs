using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;

namespace ThinkBridge.ShopBridge.ProductService.ComponentTest.Constants
{
    /// <summary>
    /// TestConstants class contains all constants which can be used in component test project.
    /// </summary>
    public static class TestConstants
    {
        // Sample Identifier
        public static Guid MockIdentifier = Guid.NewGuid();
        public static Guid MockGetIdentifier = Guid.Parse("CAEB411B-5298-48FB-B6A9-2D47A86E2289");


        // API End Points
        public static string EndpointToProducts = "api/Products";
        
        // Parameters
        public static string ProductIdentifiers = "productIdentifiers";

        // Sample Product
        public static Product MockInsertProductObject = new Product
        {
            Identifier = MockIdentifier,
            Name = "Wall Watch from Titan ",
            Description = "Elegant Wall Watch",
            Price = 2000,
            IsActive = true,
            CreatedBy = "DevOps",
            CreatedOn = DateTime.UtcNow
        };
        public static Product MockInsertDuplicateProductObject = new Product
        {
            Identifier = MockGetIdentifier,
            Name = "Wall Watch ",
            Description = "Elegant Wall Watch",
            Price = 2000,
            IsActive = true,
            CreatedBy = "DevOps",
            CreatedOn = DateTime.UtcNow
        };
        public static Product MockUpdateProductObject = new Product
        {
            Identifier = MockGetIdentifier,
            Name = "Fast Track Watch Updated",
            Description = "Stylish Fastrack Watch Updated",
            Price = 3000,
            IsActive = true,
            UpdatedBy = "DevOps",
            UpdatedOn = DateTime.UtcNow
        };
        public static Product MockUpdateInvalidProductObject = new Product
        {
            Identifier = new Guid(),
            Name = "DevOpsTestInvalidProductUpdated",
            Description = "Stylish Fastrack Watch",
            Price = 2000,
            IsActive = true,
            UpdatedBy = "DevOps",
            UpdatedOn = DateTime.UtcNow
        };

    }
}
