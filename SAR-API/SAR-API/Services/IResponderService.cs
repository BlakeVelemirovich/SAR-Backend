using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.IncidentService;

public interface IResponderService
{
    public Task CreateResponder(AssignUserRequest request);

    public Task<string> GetUserIdByEmail(GetUserIdRequest request);

    Task<string> GetResponderIdByEmail(GetUserIdRequest request);

    Task<List<ResponderDTO>> GetAllResponders();
}