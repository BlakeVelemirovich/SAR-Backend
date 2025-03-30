using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.IncidentService;

public interface IAgencyService
{
    public Task CreateAgency(AgencyRequest request);
    
    public Task<List<Agency>> GetAgencies();
}