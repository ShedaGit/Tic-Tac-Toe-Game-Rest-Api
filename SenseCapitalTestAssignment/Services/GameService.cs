namespace SenseCapitalTestAssignment.Services
{
    public class GameService : IGameService
    {
        private readonly GameContext _context;

        public GameService(GameContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> CreateGameAsync()
        {
            var game = new Game
            {
                Id = Guid.NewGuid().ToString(),
                Board = "         ",
                NextPlayer = "X",
                Winner = null,
                IsDraw = false,
                IsGameOver = false
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }

        public async Task<Game?> GetGameAsync(string id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<Game?> MakeMoveAsync(Game game, MoveRequest moveRequest)
        {
            if (game.IsGameOver)
            {
                return null;
            }

            int index = moveRequest.Row * 3 + moveRequest.Column;
            if (game.Board[index] != ' ')
            {
                return null;
            }

            char player = game.NextPlayer[0];
            game.Board = game.Board.Substring(0, index) + player + game.Board.Substring(index + 1);

            if (CheckForWinner(game, moveRequest))
            {
                game.Winner = game.NextPlayer;
                game.IsGameOver = true;
                game.IsDraw = false;
            }
            else if (CheckForDraw(game))
            {
                game.IsDraw = true;
                game.IsGameOver = true;
            }
            else
            {
                game.NextPlayer = game.NextPlayer == "X" ? "O" : "X";
            }

            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return game;
        }

        private bool CheckForWinner(Game game, MoveRequest moveRequest)
        {
            int row = moveRequest.Row;
            int col = moveRequest.Column;
            char player = game.NextPlayer[0];
            string board = game.Board;

            // Check for horizontal win
            if (board[row * 3] == player && board[row * 3 + 1] == player && board[row * 3 + 2] == player)
            {
                return true;
            }

            // Check for vertical win
            if (board[col] == player && board[col + 3] == player && board[col + 6] == player)
            {
                return true;
            }

            // Check for diagonal win
            if ((row == col && board[0] == player && board[4] == player && board[8] == player) ||
                (row + col == 2 && board[2] == player && board[4] == player && board[6] == player))
            {
                return true;
            }

            return false;
        }

        private bool CheckForDraw(Game game)
        {
            return !game.Board.Contains(' ');
        }
    }
}
