   
- First, you have to create the database.Go to the directory "DataBaseScript" and run the script "CreateFullDataBase.sql". 

- To insert some data to the data base, execute the script "InsertData.sql" in the directory "CreateTables"

- Then you have to publish application to IIS. Publish part RecipeBook.Web on localhost:8001, and part RecipeBook.Service on localhost:8002

- Change connectionStrings to your SQL-Server in file RecipeBook.Service\Web.config

