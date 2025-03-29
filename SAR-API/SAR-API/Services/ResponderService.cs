using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.Repositories;

namespace SAR_API.IncidentService;

public class ResponderService : IResponderService
{
    private readonly IUserRepository _userRepository;
    private readonly IResponderRepository _responderRepository;
    
    public ResponderService(
        IUserRepository userRepository,
        IResponderRepository responderRepository
        )
    {
        _userRepository = userRepository;
        _responderRepository = responderRepository;
    }
    
    public async Task CreateResponder(AssignUserRequest request)
    {
        // Create full name for responder
        string responderName = request.FirstName + " " + request.LastName;
        
        // Grab User Id using email
        var userId = await _userRepository.FindUserIdByEmail(request.Email);
        
        // Convert string to Guid
        Guid userIdGuid = Guid.Parse(userId);
        
        Responder responder = new Responder
        {
            ResponderId = Guid.NewGuid(),
            ResponderName = responderName,
            BirthDate = request.BirthDate,
            Phone = request.Phone,
            Province = request.Province,
            AgencyId = request.AgencyId,
            CheckedIn = false,
            UserId = userIdGuid
        };
        
        // Add responder to database
        int dbResponse = await _responderRepository.AddResponder(responder);
        
        if (dbResponse != 0)
        {
            throw new Exception("Failed to add responder to database.");
        }
    }
    
    public async Task<string> GetUserIdByEmail(GetUserIdRequest request)
    {
        var userId = await _userRepository.FindUserIdByEmail(request.Email);
        
        if (userId == null)
        {
            throw new Exception("User not found.");
        }
        
        return userId;
    }
}