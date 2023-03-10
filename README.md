# Sense-Capital - Tic-Tac-Toe Game REST API

This is a REST API for playing Tic-Tac-Toe game. The API allows two players to play the game on a 3x3 board by making moves until there is a winner or the board is full.

The API is built using C# and .NET 7.0, and it uses Entity Framework Core to access the database. The API supports JSON message format and provides endpoints to create a new game, retrieve all games, retrieve a game by id, and make a move in the game.

The API is designed to be used by a web application and a mobile application to play Tic-Tac-Toe game. The web application and the mobile application can be built separately and can use this API to communicate with the server.

## Getting Started

To get started with this API, you need to have the following installed on your system:

- [.NET 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQL Express](https://www.microsoft.com/en-US/download/details.aspx?id=101064)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

Once you have these installed, you can clone the repository and open the project in Visual Studio 2022.

## Running the API

To run the API, follow these steps:

1. Open the project in Visual Studio 2022.
2. Set the **SenseCapitalTestAssignment** project as the startup project.
3. Build the solution to restore the packages and build the project.
4. Open the Package Manager Console and run the following command to create the database:

``` PowerShell
Update-Database
```

or

```.NET CLI
dotnet ef database update
```

Make sure you're in the project directory.

5. Run the project by pressing F5 or clicking the Start button.

The API should now be running on `http://localhost:<port>/`, where `<port>` is the port number assigned by Visual Studio. The default port is `7062`, you can find it in the file `launchSettings.json`.

## Using the API

The API provides the following endpoints:

- `POST /api/games`: Creates a new game.
- `GET /api/games`: Retrieves all games.
- `GET /api/games/{id}`: Retrieves a game by id.
- `POST /api/moves/{id}`: Makes a move in the game with the specified id.

### Creating a new game

To create a new game, send a POST request to `/api/games` with an empty body. The API will return the newly created game in the response body.

Example request:

```Insomnia
POST http://localhost:<port>/api/game
```

Example response:

```json
{
  "id": "d1df60c6-708c-4b87-bdb6-a2efb19b10d8",
  "board": "         ",
  "nextPlayer": "X",
  "winner": null,
  "isDraw": false,
  "isGameOver": false
}
```

### Retrieving all games

To retrieve all games, send a GET request to `/api/games`. The API will return a list of all games in the response body.

Example request:

```Insomnia
GET http://localhost:<port>/api/games
```

Example response:

```json
[
  {
    "id": "81e5e620-8c9a-4804-a119-03c40072f2eb",
    "board": "OOOXOX XX",
    "nextPlayer": "O",
    "winner": "O",
    "isDraw": false,
    "isGameOver": true
  },
  {
    "id": "d1df60c6-708c-4b87-bdb6-a2efb19b10d8",
    "board": "         ",
    "nextPlayer": "X",
    "winner": null,
    "isDraw": false,
    "isGameOver": false
  },
  {
    "id": "e4040aa0-9671-4a93-8bd7-3c7ac010aa42",
    "board": "XO  O   X",
    "nextPlayer": "X",
    "winner": null,
    "isDraw": false,
    "isGameOver": false
  }
]
```

### Retrieving a game by id

To retrieve a game by id, send a GET request to `/api/game/{id}`, where `{id}` is the id of the game. The API will return the game in the response body.

Example request:

```Insomnia
GET http://localhost:<port>/api/games/81e5e620-8c9a-4804-a119-03c40072f2eb
```

Example response:

```json
{
  "id": "81e5e620-8c9a-4804-a119-03c40072f2eb",
  "board": "OOOXOX XX",
  "nextPlayer": "O",
  "winner": "O",
  "isDraw": false,
  "isGameOver": true
}
```

### Making a move in the game

To make a move in the game, send a POST request to `/api/move/{id}`, where `{id}` is the id of the game. The request body should contain the coordinates of the move and the player who made the move.

Example request:

```Insomnia
POST http://localhost:<port>/api/move/81e5e620-8c9a-4804-a119-03c40072f2eb
Content-Type: application/json
Body:
{
  "row": 0,
  "column": 1
}
```

Example response:

```json
{
  "id": "81e5e620-8c9a-4804-a119-03c40072f2eb",
  "board": "OOOXOX XX",
  "nextPlayer": "O",
  "winner": "O",
  "isDraw": false,
  "isGameOver": true
}
```

## Conclusion

This REST API provides endpoints for creating a new Tic-Tac-Toe game, retrieving all games, retrieving a game by id, and making a move in the game. It uses C# and .NET 7.0, and it is designed to be used by a web application and a mobile application.

## Future Improvements

Here are some ideas for improving the Tic-Tac-Toe API:

- Add a feature to delete a game by id
- Add a feature to resume a game that was previously interrupted
- Add a feature to check if a game has ended due to a draw
- Add authentication and authorization to restrict access to certain endpoints
- Add unit tests and integration tests to ensure the API is functioning correctly
- Add logging to help with debugging and error tracking
- Improve error handling and provide more informative error messages to the client
