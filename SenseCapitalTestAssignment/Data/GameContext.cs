namespace SenseCapitalTestAssignment.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }

        public virtual void SetModified(Game entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}