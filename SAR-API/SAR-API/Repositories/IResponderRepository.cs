using SAR_API.Domains;

namespace SAR_API.Repositories;

public interface IResponderRepository
{
    public Task<int> AddResponder(Responder request);
}