using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.Repositories;

namespace SAR_API.IncidentService;

public class AgencyService : IAgencyService
{
    private readonly IAgencyRepository _agencyRepository;

    public AgencyService(IAgencyRepository agencyRepository)
    {
        _agencyRepository = agencyRepository;
    }

    public async Task CreateAgency(AgencyRequest request)
    {
        // Create New Agency DTO
        Guid newGuid = Guid.NewGuid();
        // Convert Guid to string
        string agencyId = newGuid.ToString();
        AgencyDTO agency = new AgencyDTO()
        {
            AgencyId = agencyId,
            AgencyName = request.AgencyName,
            Province = request.Province
        };
        
        // Add to Database
        await _agencyRepository.AddAgency(agency);
    }
    
    public async Task<List<AgencyDTO>> GetAgencies()
    {
        // Get all agencies
        var agencies = await _agencyRepository.GetAgencies();
        
        // Verify if there are any agencies
        if (agencies.Count == 0)
        {
            throw new Exception("No agencies found");
        }
        
        return agencies;
    }
}