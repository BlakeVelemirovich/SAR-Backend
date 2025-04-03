using Microsoft.EntityFrameworkCore;
using SAR_API.Database;
using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly NeonDbContext _dbContext;
    
    // Dependency Injection
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
        // Get all incidents using Methods Syntax
        var result = await (
            from i in _dbContext.incident
            join o in _dbContext.operational_period on i.IncidentId equals o.IncidentId
            join r in _dbContext.responder on o.ResponderId equals r.ResponderId
            join a in _dbContext.agency on r.AgencyId equals a.AgencyId
            where i.EndDate == null
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
    
    public async Task<List<IncidentDetailsDTO>> GetAllPastIncidents()
    {
        // Get all incidents using Methods Syntax
        var result = await (
            from i in _dbContext.incident
            join o in _dbContext.operational_period on i.IncidentId equals o.IncidentId
            join r in _dbContext.responder on o.ResponderId equals r.ResponderId
            join a in _dbContext.agency on r.AgencyId equals a.AgencyId
            where i.EndDate != null
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

    public async Task<Incident> GetIncidentDetails(string incidentId)
    {
        // Get incident details
        return await _dbContext.incident.FirstOrDefaultAsync(i => i.IncidentId == incidentId);
    }
    
    public async Task<List<OperationalPeriodDTO>> GetOperationalPeriods(string incidentId)
    {
        // Get operational periods
        var operationalPeriods = await _dbContext.operational_period
            .Where(op => op.IncidentId == incidentId)
            .Select(op => new OperationalPeriodDTO()
            {
                OperationalPeriodId = op.OperationalPeriodId,
                OperationalPeriod = op.Period,
                ResponderId = op.ResponderId,
                StartDatetime = op.StartDatetime,
                EndDatetime = op.EndDatetime,
                IncidentId = op.IncidentId,
                Tasks = _dbContext.task
                    .Where(t => t.OperationalPeriodId == op.OperationalPeriodId)
                    .Select(t => new TaskDetailsDTO
                    {
                        TaskId = t.TaskId,
                        StartDateTime = t.StartDatetime,
                        EndDateTime = t.EndDatetime ?? DateTime.MinValue
                    }).ToList()
            })
            .ToListAsync();

        return operationalPeriods;
    }
    
    public async Task<int> UpdateIncidentEndDate(UpdateIncidentEndDateRequest request)
    {
        // Get incident from database
        var incident = await _dbContext.incident.FirstOrDefaultAsync(i => i.IncidentId == request.IncidentId);
        
        // Check if incident exists
        if (incident == null)
        {
            return 0;
        }
        
        // Update incident end date
        incident.EndDate = request.EndDate;
        
        // Save changes to database
        return await _dbContext.SaveChangesAsync();
    }
}
