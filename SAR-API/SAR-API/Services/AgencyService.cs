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
        Guid agencyId = Guid.NewGuid();
        AgencyDTO agency = new AgencyDTO()
        {
            AgencyId = agencyId,
            AgencyName = request.AgencyName,
            Province = request.Province
        };
        
        // Add to Database
        await _agencyRepository.AddAgency(agency);
    }
}