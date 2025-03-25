using SAR_API.Domains;

namespace SAR_API.IncidentService;

public interface IAgencyService
{
    public Task CreateAgency(AgencyRequest request);
}