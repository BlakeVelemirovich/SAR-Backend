using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface IAgencyRepository
{
    public Task<int> AddAgency(Agency request);
    
    public Task<List<Agency>> GetAgencies();
}