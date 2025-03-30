using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.IncidentService;

public interface IIncidentService
{   
    Task CreateIncident(NewIncidentRequest request);
    
    Task <List<IncidentDetailsDTO>> GetAllIncidents();
}