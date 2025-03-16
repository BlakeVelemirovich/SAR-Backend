using SAR_API.Domains;

namespace SAR_API.Repositories;

public interface IIncidentRepository
{
    Task<int> AddIncident(NewIncidentRequest request);
}