using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.IncidentService;

public class IncidentService : IIncidentService
{
    public async Task CreateIncident(NewIncidentRequest request)
    {
        // Create a new incident
        string incidentId = Guid.NewGuid().ToString();
        
        IncidentDTO incidentDto = new IncidentDTO
        {
            IncidentId = incidentId,
            IncidentName = request.IncidentName,
            IncidentType = request.IncidentType,
            Province = request.Province,
            City = request.City,
            Postal = request.Postal,
            Address = request.Address,
            Summary = request.Summary,
            Objectives = request.Objectives
        };
    }
}