using DrillCRUD.Models;


namespace DrillCRUD.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Host=localhost;Port=5433;Database=Drill_db;Username=postgres;Password=16ed2ad3b"
            optionsBuilder.UseNpgsql("host=localhost;port=5432;username=postgres;password=16ed2ad3b;database=Drill_db");
        }

        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoint> DrillBlockPoints { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoint> HolePoints { get; set; }
    }
}
