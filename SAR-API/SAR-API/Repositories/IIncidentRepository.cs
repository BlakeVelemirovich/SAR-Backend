using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface IIncidentRepository
{
    Task<int> AddIncident(Incident request);
    
    Task<int> AddOperationalPeriod(OperationalPeriod request);
    
    Task<List<IncidentDetailsDTO>> GetAllIncidents();
}