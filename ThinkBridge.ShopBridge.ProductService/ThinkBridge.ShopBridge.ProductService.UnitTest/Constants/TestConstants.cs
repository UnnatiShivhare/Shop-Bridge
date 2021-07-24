using System;
using System.Collections.Generic;
using System.Text;
using ThinkBridge.ShopBridge.ProductService.Data.Entity;

namespace ThinkBridge.ShopBridge.ProductService.UnitTest.Constants
{
    /// <summary>
    /// TestConstants class contains all constants which can be used in unit test project.
    /// </summary>
    public static class TestConstants
    {
        // Sample Identifier
        public static Guid MockIdentifier = Guid.NewGuid();
        public static Guid MockGetIdentifier = Guid.Parse("C9A387BE-A432-437C-B160-E09D7348E3D9");

        // Sample Product
        public static Product MockInsertProductObject = new Product
        {
            Identifier = MockIdentifier,
            Name = "Fast Track Watch",
            Description = "Stylish Fastrack Watch",
            Price = 2000,
            IsActive = true,
            CreatedBy = "DevOps",
            CreatedOn = DateTime.UtcNow
        };
        public static Product MockInsertDuplicateProductObject = new Product
        {
            Identifier = MockGetIdentifier,
            Name = "Fast Track Watch",
            Description = "Stylish Fastrack Watch",
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