using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface IResponderRepository
{
    public Task<int> AddResponder(Responder request);

    Task<string> FindUserIdByEmail(string userEmail);
}