using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface IAgencyRepository
{
    public Task<int> AddAgency(AgencyDTO request);
}