using SAR_API.Domains;

namespace SAR_API.IncidentService;

public interface IIncidentService
{   
    Task CreateIncident(NewIncidentRequest request);
}