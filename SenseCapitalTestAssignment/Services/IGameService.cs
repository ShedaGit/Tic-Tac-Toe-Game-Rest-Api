namespace SenseCapitalTestAssignment.Services
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetGamesAsync();
        Task<Game> CreateGameAsync();
        Task<Game> GetGameAsync(string id);
        Task<Game> MakeMoveAsync(Game game, MoveRequest moveRequest);
    }
}
