   
- First, you have to create the database. Go to the directory "DataBaseScript" and run the script "CreateFullDataBase.sql". 

- To insert some data to the data base, execute the script "InsertData.sql" in the directory "CreateTables"

- After, build the solution of the project.

- Then you have to publish application to IIS. Publish part RecipeBook.Web on localhost:8001(or another adress), and part RecipeBook.Service on localhost:8002

- Change connectionStrings to your SQL-Server in file RecipeBook.Service\Web.config


*For adding/deleting/updating information about recipes, log in as the Editor (editor,123)
*For adding/deleting/updating information about users, log in as the Admin (admin, 123)

