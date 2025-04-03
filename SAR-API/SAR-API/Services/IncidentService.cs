using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.Repositories;
using Task = System.Threading.Tasks.Task;

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
    
    public async Task<ViewIncidentDetailsDTO> GetViewIncident(string incidentId)
    {
        // Get the incident details
        var incident = await _incidentRepository.GetIncidentDetails(incidentId);
        
        if (incident == null)
        {
            throw new Exception("Failed to get view incident");
        }

        var incidentDto = new IncidentDTO
        {
            IncidentId = incident.IncidentId,
            IncidentName = incident.IncidentName,
            IncidentType = incident.IncidentType,
            Province = incident.Province,
            City = incident.City,
            Postal = incident.Postal,
            Address = incident.Address,
            Summary = incident.Summary,
            Objectives = incident.Objectives
        };
        
        // Get the operational periods associated with the Incident
        var operationalPeriods = await _incidentRepository.GetOperationalPeriods(incidentId);
        
        if (operationalPeriods == null)
        {
            throw new Exception("Failed to get operational periods");
        }
        
        // Combine the two into a single DTO
        ViewIncidentDetailsDTO viewIncident = new ViewIncidentDetailsDTO
        {
            Incident = incidentDto,
            OperationalPeriods = operationalPeriods
        };
        
        return viewIncident;
    }
    
    public async Task UpdateIncidentEndDate(UpdateIncidentEndDateRequest request)
    {
        // Update the incident end date
        int result = await _incidentRepository.UpdateIncidentEndDate(request);
        
        if (result == 0)
        {
            throw new Exception("Failed to update incident end date");
        }
    }
}