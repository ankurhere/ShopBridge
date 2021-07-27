This is a REST based API made for an E-Commerce website named "ShopBridge" which lists the Products available in the website.

This API also consists of Operations:
1. To list a particular product by id, 
2. Delete a particular Product by Id as well as 
3. Update a particular Product with it's new details.
4. Also it can list all the Products ppresent in the database.

Before Running the Application:
1. Update the connectionstring, 'ProductContextConnection' in the "appsettings.json" with the server name of your SQL Server.
2. Run the Commands, 'Add-Migration' in NUGET Package Manager Console of your Visual Studio for this Project.
3. Run the Commands, 'Update-Database' to create the 'ShopBridge' Database and 'Products' table in your SQL Server.
