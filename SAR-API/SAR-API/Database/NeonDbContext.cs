using Microsoft.EntityFrameworkCore;
using SAR_API.Domains;

namespace SAR_API.Database;

public class NeonDbContext : DbContext
{
    public NeonDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Responder> Responders { get; set; }
    public DbSet<User> Users { get; set; }
    // public DbSet<Incident> Incidents { get; set; }
}