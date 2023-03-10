namespace SenseCapitalTestAssignment.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Board { get; set; }
        public string NextPlayer { get; set; }
        public string? Winner { get; set; }
        public bool IsDraw { get; set; }
        public bool IsGameOver { get; set; }
    }
}