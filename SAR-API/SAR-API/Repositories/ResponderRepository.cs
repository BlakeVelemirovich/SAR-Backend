using Microsoft.EntityFrameworkCore;
using SAR_API.Database;
using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public class ResponderRepository : IResponderRepository
{
    private readonly NeonDbContext _neonDbContext;
    private readonly ApplicationDbContext _dbContext;
    
    public ResponderRepository(
        NeonDbContext neonDbContext,
        ApplicationDbContext dbContext
        )
    {
        _neonDbContext = neonDbContext;
        _dbContext = dbContext;
    }
    
    public async Task<int> AddResponder(Responder request)
    {
        // Add the responder to the database
        await _neonDbContext.responder.AddAsync(request);
        return await _dbContext.SaveChangesAsync();
    }
    
    public async Task<string> FindUserIdByEmail(string userEmail)
    {
        // Get user by email
        var result = await (
            from r in _neonDbContext.responder
            join u in _neonDbContext.AspNetUsers on r.UserId equals u.Id
            where r.UserId == u.Id
            select r.ResponderId

        ).FirstOrDefaultAsync();

        return result;
    }
    
    public async Task<List<Responder>> GetAllResponders()
    {
        // Get all responders from the database
        return await _neonDbContext.responder.ToListAsync();
    }
}