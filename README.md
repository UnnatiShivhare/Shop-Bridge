# Introduction 
ShopBridge is an e-commerse application
ShopBridge Product Service will provide the API Endpoints required to perform the CRUD operations.

# Getting Started
1.	Required Installation 
    We need to install Microsoft Visual Studio Enterprise 2019 : Version 16.6.2 and SSMS 18.6    
    Microsoft .Net Framework : Version 3.1.401

# Build and Test
Please refer the document attached ThinkBridgeDocument.docx in the repository. It contains the DB table Script, time tracking and the Steps with screenshots of testing.

Step 1  : Create the table Products using SSMS 18.6 . Add the Connection string of the DB in the appsettings.json file with Data Source, Initial Catalog, User Id and Password values in the below format: 

  "ConnectionStrings": {
    "DefaultConnection": "Data Source=;Initial Catalog=;User Id=;Password=;Connection Timeout=60;" 
    }

Step 2  : After successful build, run the Application and Swagger UI will be displayed with POST, GET, PUT and DELETE Operations  

Step 3 : New Products can be created by executing the POST Method. We need to pass a Product Object in order to insert it in the Database.
 
Step 4 : On Click of Execute –Details Saved successfully.
 
Step 5 : We can fetch the existing Product Details by executing the GET Method. 
 
Step 6 : On Click of Execute all the Products present in Database will be returned as an output.
 
Step 7 : In order to update an existing Product we can execute the PUT method with required modifications by passing the Product object.
 
Step 8 : On click of Execute the Product detailed will be updated successfully 

Step 9 : In order to delete the existing Product we can execute the DELETE method by passing the DeleteInfo Object 

Step 10 : On Click of Execute the product details will be deleted from the Database.
 
