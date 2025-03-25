using Microsoft.EntityFrameworkCore;

namespace SAR_API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContent;
    
    // Dependency injection
    public UserRepository(ApplicationDbContext dbContent)
    {
        _dbContent = dbContent;
    }
    
    public async Task<string> FindUserIdByEmail(string userEmail)
    {
        // Get user by email
        var user =  await _dbContent.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

        if (user == null)
        {
            throw new Exception("User not found.");
        }
        
        // Extract user Id from Identity User object
        return user.Id;
    }
}