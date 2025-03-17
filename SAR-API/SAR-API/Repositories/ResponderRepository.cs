using SAR_API.Domains;

namespace SAR_API.Repositories;

public class ResponderRepository : IResponderRepository
{
    public Task<int> AddResponder(Responder request)
    {
        // Add responder to database
        return Task.FromResult(1);
    }
}