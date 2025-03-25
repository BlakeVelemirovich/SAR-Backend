using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.Repositories;

namespace SAR_API.IncidentService;

public class ResponderService : IResponderService
{
    private readonly IUserRepository _userRepository;
    
    public ResponderService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task CreateResponder(AssignUserRequest request)
    {
        // Create full name for responder
        string responderName = request.FirstName + " " + request.LastName;
        
        // Grab User Id using email
        var userId = await _userRepository.FindUserIdByEmail(request.Email);
        
        // Convert string to Guid
        Guid userIdGuid = Guid.Parse(userId);
        
        ResponderDTO responder = new ResponderDTO
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
        
    }
}