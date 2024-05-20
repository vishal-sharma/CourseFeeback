The solution consists of 4 projects: 
- An ASP.Net 8 Web API to manage Comments by different users providing input for courses they attended
- A Domain client library project to hold domain logic for the application
- A Data client library project to interact with database
- A console app to seed some test data

To seed some test data run the Console application from Visual Studio and verify from database that the tables are created and filled with some test data. 
- The connection string currently in Data client library points to database Server=(localdb)\\MSSQLLocalDB. This database comes pre-installed as part of Visual Studio and hence simplies requirements for people using this project for their self learning.

One test data is seeded, run the API and it shall open the Swagger interface, where you can test the Get, Post API calls to read / generate comments in database.

