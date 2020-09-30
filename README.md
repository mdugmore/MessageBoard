# MessageBoard

A simple Message Board Web API.

# To Run

Use Visual Studio or other IDE to open the solution and build and run.
Or alternatively use the dotnet CLI to run the application.

There is a Swagger UI which you can run the endpoints available.

The data is stored using an in Memory database which is seeded with initial Messages on first call.

# To Do in future

- [ ] Add Authorisation and Authentication
- [ ] Use a persistant data storage such as SQL Server to store the data
- [ ] Add logging
- [ ] Add aplication monitoring such as App Insights to monitor usage
- [ ] Expand functionality such as having different Boards and topics that messages can be added to.
- [ ] Search functionality, maybe with added caching to something like redis or Azure Search or Elastic Search for quick retrieval of messages.
- [ ] Archiving of old Data
- [ ] Dockerise the application
- [ ] Add a front end using framework such as React or Angular, or a mobile application
