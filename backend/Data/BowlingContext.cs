using Microsoft.EntityFrameworkCore;

namespace BowlingAPI.Data;

public class BowlingContext : DbContext
{
    public BowlingContext(DbContextOptions<BowlingContext> options) : base(options)
    {
    }

    // Table for bowlers
    public DbSet<Bowler> Bowlers { get; set; }
    
    // Table for teams
    public DbSet<Team> Teams { get; set; }
}