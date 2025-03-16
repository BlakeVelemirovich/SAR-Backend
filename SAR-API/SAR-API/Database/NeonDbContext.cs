using Microsoft.EntityFrameworkCore;

namespace SAR_API.Database;

public class NeonDbContext : DbContext
{
    public NeonDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
}