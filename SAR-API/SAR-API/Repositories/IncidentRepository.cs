using SAR_API.Database;
using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly NeonDbContext _dbContext;
    
    public IncidentRepository(
        NeonDbContext dbContext
        )
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> AddIncident(IncidentDTO request)
    {
        // Add incident to database
        await _dbContext.incident.AddAsync(request);
        return await _dbContext.SaveChangesAsync();
    }
}