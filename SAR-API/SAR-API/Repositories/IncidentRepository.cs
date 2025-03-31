using Microsoft.EntityFrameworkCore;
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
    
    public async Task<int> AddIncident(Incident request)
    {
        // Add incident to database
        await _dbContext.incident.AddAsync(request);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<int> AddOperationalPeriod(OperationalPeriod request)
    {
        // Add operational period to database
        await _dbContext.operational_period.AddAsync(request);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<IncidentDetailsDTO>> GetAllIncidents()
    {
        var result = await (
            from i in _dbContext.incident
            join o in _dbContext.operational_period on i.IncidentId equals o.IncidentId
            join r in _dbContext.responder on o.ResponderId equals r.ResponderId
            join a in _dbContext.agency on r.AgencyId equals a.AgencyId
            where o.EndDatetime == null
            select new IncidentDetailsDTO {
                IncidentId = i.IncidentId,
                IncidentName = i.IncidentName,
                StartDate = o.StartDatetime,
                IncidentType = i.IncidentType,
                AgencyName = a.AgencyName
            }
        ).ToListAsync();

            return result;
    }
}
