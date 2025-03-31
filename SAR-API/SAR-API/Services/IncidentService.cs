using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.Repositories;

namespace SAR_API.IncidentService;

public class IncidentService : IIncidentService
{
    private readonly IIncidentRepository _incidentRepository;
    
    public IncidentService(IIncidentRepository incidentRepository)
    {
        _incidentRepository = incidentRepository;
    }
    public async Task CreateIncident(NewIncidentRequest request)
    {
        // Create a new incident
        string incidentId = Guid.NewGuid().ToString();
        
        Incident incident = new Incident
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
        
        // Add incident to database
        int result = await _incidentRepository.AddIncident(incident);

        // Check if anything went wrong
        if (result == 0)
        {
            throw new Exception("Failed to create incident");
        }
        
        // Add Operation Period to database
        await CreateOperationalPeriod(new NewOperationalPeriodRequest
        {
            OperationalPeriod = request.OperationPeriod,
            ResponderId = request.IncidentCommander,
            StartDatetime = request.StartDate,
            IncidentId = incidentId
        });
    }
    
    private async Task CreateOperationalPeriod(NewOperationalPeriodRequest request)
    {
        // Create a guid operational id
        string operationalPeriodId = Guid.NewGuid().ToString();

        OperationalPeriod operationalPeriod = new OperationalPeriod
        {
            OperationalPeriodId = operationalPeriodId,
            Period = request.OperationalPeriod,
            ResponderId = request.ResponderId,
            StartDatetime = request.StartDatetime,
            IncidentId = request.IncidentId,
            CommsId = null
        };
        
        // Add operational period to database
        int result = await _incidentRepository.AddOperationalPeriod(operationalPeriod);
        
        if (result == 0)
        {
            throw new Exception("Failed to create operational period");
        }
    }
    
    public async Task<List<IncidentDetailsDTO>> GetAllIncidents()
    {
        var incidentList = await _incidentRepository.GetAllIncidents();
        
        if (incidentList == null)
        {
            throw new Exception("Failed to get all incidents");
        }
        
        return incidentList;
    }
    
    public async Task<List<IncidentDetailsDTO>> GetAllPastIncidents()
    {
        var incidentList = await _incidentRepository.GetAllPastIncidents();
        
        if (incidentList == null)
        {
            throw new Exception("Failed to get all past incidents");
        }
        
        return incidentList;
    }
}