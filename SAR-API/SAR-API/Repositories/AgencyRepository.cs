using Microsoft.EntityFrameworkCore;
using SAR_API.Database;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public class AgencyRepository : IAgencyRepository
{
    private readonly NeonDbContext _dbContext;
    
    public AgencyRepository (NeonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> AddAgency(AgencyDTO request)
    {
        // Add the agency to the database
        await _dbContext.agency.AddAsync(request);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<List<AgencyDTO>> GetAgencies()
    {
        // Get all agencies from the database
        return await _dbContext.agency.ToListAsync();
    }
}