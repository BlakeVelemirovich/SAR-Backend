using SAR_API.Database;
using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public class ResponderRepository : IResponderRepository
{
    private readonly NeonDbContext _dbContext;
    
    public ResponderRepository(NeonDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> AddResponder(Responder request)
    {
        // Add the responder to the database
        await _dbContext.responder.AddAsync(request);
        return await _dbContext.SaveChangesAsync();
    }
}