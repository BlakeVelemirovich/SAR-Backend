using Microsoft.EntityFrameworkCore;
using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Database;

public class NeonDbContext : DbContext
{
    public NeonDbContext(DbContextOptions<NeonDbContext> options) : base(options)
    {
    }
    
    public DbSet<AgencyDTO> agency { get; set; }
    public DbSet<Responder> responder { get; set; }
    public DbSet<User> user { get; set; }
    public DbSet<IncidentDTO> incident { get; set; }
}