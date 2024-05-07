> Hey there, VIPs!
>
> From time to time we may be asked to demonstrate our skills and on occasion it is appropriate to oblige. This is one of those times!
> 
> The functionality tested here was originally going to be a console app within a C# MonoGame project.
> The overall solution is instead a bells-and-whistles version for the purpose of providing an API demo project, as requested!
>
> The API/MVC layer was the least time consuming portion clocking in under an hour and includes a simple Middleware implementation, GameCache Service, Extension method, and dependency injection.
>
> The DropGrid.Logic portion and unit tests was just over an hour and a half, though some of that was spent on the white board and time spent imagining it was not clocked.
> As it is destined for inclusion in a busy 60 fps game loop, the design favors memory usage over CPU intensity with aggressive one-time boolean checks and short circuiting.
>
> Naturally, the most time consuming part was the dynamic jQuery driven front-end interface, styling, and related testing, coming through in a little over 2 hours.
>
> Whenever 'New Game' is clicked a new Guid will appear, you can jump between games by clicking those Guids.
> Within a game you can drop 3 different demo 'tiles' into the column chosen by radio button.
> To test the removal handling click as many "non-zero" tiles as you like and click "Hit!" to remove them and settle the board.
>
> Feel free to request additional features for the sake of the demo!
>
> Thanks,
> Ryan

# DropGrid

DropGrid is a sample application demonstrating various .NET features, including MVC, API, middleware for API key authentication, unit testing, dependency injection, extension methods, jQuery, HTML/CSS, and Docker.

## Features

- **MVC**: The HomeController serves up an initial landing page which subsequently makes authorized AJAX calls to the API GridController.
- **Rest API**: A sample API for interacting with a DropGrid via GET/POST/PUT allows creating new sessions, loading existing ones, and testing DropGrid.Logic operations.
- **Middleware Auth Sample**: Implements middleware for API key authentication.
- **C# and LINQ**: Demonstrates use of extension methods, method chaining, property attributes, and LINQ expressions.
- **Unit Testing**: Provides unit tests for testing proper DropGrid tile manipulation behaviors.
- **Singleton Dependency Injection**: Utilizes singleton dependency injection to provide a runtime persistent GameCache with unique Guids for each game.
- **jQuery and HTML/CSS Demonstration**: Includes jQuery and HTML/CSS for front-end data display, user interactions, and AJAX calls.
- **Docker Demonstration**: Has a basic ASP.NET Dockerfile as requested.

## Basic DropGridApp Functionality

- **GameCache Singleton**: Maintains game sessions keyed by unique identifier.
- **DropGrid Model**: A view model is provided and extension methods implemented for transforming a DropGrid into a JSON friendly front-end model.

DropGrid.Logic functionality itself is specific game development logic designed for use in another project. In the test interface you can interact with the following features:

- **Drop Tiles**: Users can drop tiles of 3 types (R, G, B) into grid columns chosen by radio button.
- **Remove Tiles**: "Tiles" (1, 2, or 3) can be removed from the grid by clicking to mark them for removal and then clicking the "Hit!" button that appears.
- **Fall Tiles**: Tiles should appropriately cascade downward after removal.

## DropGrid.Logic Code Design

- **Partial Classes**: Code organization is facilitated by partial classes as all logic resides in the Grid class.
- **Method Chaining**: Many operations can be performed on a given Grid by chaining the operation calls, each operation returns the Grid itself for this purpose.
- **Change History**: A Save() method is implemented to allow the option of saving Grid states between operations.

## DropGrid.Logic Copyright

The DropGrid.Logic library is copyrighted by me as part of a larger development project and usage is subject to applicable licenses and terms.

