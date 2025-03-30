using Microsoft.EntityFrameworkCore;
using SAR_API.Domains;

namespace SAR_API.Database;

public class NeonDbContext : DbContext
{
    public NeonDbContext(DbContextOptions<NeonDbContext> options) : base(options)
    {
    }
    
    public DbSet<Agency> agency { get; set; }
    
    public DbSet<Responder> responder { get; set; }
    
    public DbSet<User> user { get; set; }
    
    public DbSet<Incident> incident { get; set; }
    
    public DbSet<OperationalPeriod> operational_period { get; set; }
    
    public DbSet<TaskIncident> task { get; set; }
}