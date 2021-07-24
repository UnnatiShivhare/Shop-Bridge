using System;
using System.Collections.Generic;
using System.Text;

namespace ThinkBridge.ShopBridge.ProductService.Library.Constants
{
    public class ServiceConstants
    {
        public const string ProjectName = "ThinkBridge ShopBridge Product Service";
        public const string SwaggerVersion = "v1";
        public const string SwaggerDescription = "API Endpoints";
        public const string CorsPolicyName = "PRODUCT_SERVICE_CORS";
        public const string SwaggerJson = "/swagger/v1/swagger.json";

        public const string DbProductsTable = "Products";
        public const string DbNameColumn = "Name";
        public const string DbDescriptionColumn = "Description";
        public const string DbPriceColumn = "Price";
        public const string DbIsActiveColumn = "IsActive";
        public const string DbUniqueIdentifier = "uniqueidentifier";
        public const string DbStringTiny = "nvarchar(10)";
        public const string DbStringSmall = "nvarchar(50)";
        public const string DbStringMedium = "nvarchar(255)";
        public const string DbStringLarge = "nvarchar(4000)";
        public const string DbStringMax = "nvarchar(max)";
        public const string DbIntegerSmall = "int";
        public const string DbIntegerMedium = "int";
        public const string DbIntegerLarge = "bigint";
        public const string DbFloatSmall = "real";
        public const string DbFloatMedium = "float";
        public const string DbNumericSmall = "numeric(18,1)";
        public const string DbNumericMedium = "numeric(22,3)";
        public const string DbNumericLarge = "numeric(25,5)";
        public const string DbBoolean = "bit";
        public const string ConfigurationFileName = "appsettings.json";
        public const string DefaultConnectionName = "DefaultConnection";
        public const string ConnectionString = "ConnectionString";
        public const string Error = "Error";
        public const string FileStoragePath = "FileStoragePath";
        public const string DefaultFileLogTemplate = "FileStorageLogTemplate";
        public const string DefaultDateFormat = "DefaultDateFormat";
        public const string BadRequest = "Bad Request";
        public const string Success = "Success";
        public const string Ok = "OK";
        public const string Failure = "Failure";
        public const string CreateMessage = "Created details successfully";
        public const string FetchMessage = "Fetched details successfully";
        public const string UpdateMessage = "Updated details successfully";
        public const string DeleteMessage = "Deleted details successfully";
        public const string SoftDeleteMessage = "Soft Deleted details successfully";
        public const string CreateFailMessage = "Failed creating details";
        public const string FetchFailMessage = "Failed fetching details";
        public const string UpdateFailMessage = "Failed updating details";
        public const string DeleteFailMessage = "Failed deleting details";
        public const string SoftDeleteFailMessage = "Failed soft deleting details";
        public const string InvalidInput = "Please provide valid input.";
        public const string InternalServerError = "Internal Server Error";
        public const string DbIdentifierColumn = "Identifier";
        public const string DbCreatedOnColumn = "CreatedOn";
        public const string DbCreatedByColumn = "CreatedBy";
        public const string DbUpdatedOnColumn = "UpdatedOn";
        public const string DbUpdatedByColumn = "UpdatedBy";
        public const string DbDefaultUniqueIdentifier = "NEWID()";
        public const string DbDateTime = "datetime2(7)";
        public const string DbDefaultDateTime = "GETDATE()";
        public const string ApiRoutePrefix = "api";
        public const string ApiResponseContentType = "application/json";
        public const string ProductServiceSchema = "dbo";
        public const string Test = "Test";
        public const string Put = "Put";
        public const string Get = "Get";
        public const string Post = "Post";
        public const string Delete = "Delete";
        public const string Ampersand = "&";
        public const string EqualTo = "=";
        public const string QuestionMark = "?";

    }
}
