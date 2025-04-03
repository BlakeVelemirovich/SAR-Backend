using SAR_API.Domains;
using SAR_API.DTOs;
using Task = System.Threading.Tasks.Task;

namespace SAR_API.IncidentService;

public interface IIncidentService
{   
    Task CreateIncident(NewIncidentRequest request);
    
    Task <List<IncidentDetailsDTO>> GetAllIncidents();
    
    Task <List<IncidentDetailsDTO>> GetAllPastIncidents();
    
    Task<ViewIncidentDetailsDTO> GetViewIncident(string incidentId);
    
    Task UpdateIncidentEndDate(UpdateIncidentEndDateRequest request); 
}