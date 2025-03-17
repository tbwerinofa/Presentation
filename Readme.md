Task Management Application
A task management application created using ASP.NET Core minimal APIs and React Application. Manages tasks life time of task that have been created for a user.

Dependencies
Code in this repo depends on following
 - VS Code Editor
 - Visual Studio 2022(optional)
 - .NET 9 SDK installer.
 - React 9.0.0

Please note the above may require more dependencies for them to work


Task React App
This is the React Application that has been used for the front end.
-- Bootsrap 5 has been used to style the HTML and give it a responsive design
-- Axios with React has been used as an HttpClient and for all REST calls
-- TanStack Query (FKA React Query) has been used for State management

Minimal Web API
DataAccess
 - Make use of Microsoft Nuget package EntityframeworkCore as an Object Relation Mapping (ORM) tool to persist data to a SQLite database.

Business Object
 - Creates Business objects that are used by the Service layer and Presentation layer. 

Command Service
 - Contains the business logic to Create, Update and Delete object. This architecture follows the Command Query Responsibility Segregation pattern
 - Communicates with request from the Presentation layer, passes them on to the Data Access Layer and return results

Query Service
 - Contains the business logic to Read objects. This architecture follows the Command Query Responsibility Segregation pattern
 - Read data from the DataAccess layer and pass it on to the Presentation layer for use in API
 
Presentation
This contains our Task Management Entry Point API. 
   - Makes use OpenAPI (Swagger) documentation and UI, to interact with external users
   - Receice requests from external users and passes them on to the Service Layer

While the Program.cs file in the Presentation project is where the APIs are registered and implemented, much of the code is in the different projects described above.


PresentationTests
	- This layer contains the Unit test for the solution. Unfortunately due to time constraints only a bare minimum have been implemented
	
Constraints Authentication
	- Due to time constraint the Authentication functionality using JWT Tokens is yet to be implemented
