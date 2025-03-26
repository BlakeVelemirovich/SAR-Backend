using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.IncidentService;

namespace SAR_API.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IResponderService _responderService;

    public UserController(
        IResponderService responderService
        )
    {
        _responderService = responderService;
    }

    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        [FromBody] AssignUserRequest request
        )
    {
        // Check if the model state is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        // Get the user by email
        var user = await userManager.FindByEmailAsync(request.Email);
        // Check to see if a user is found
        if (user == null)
            return NotFound("User not found");
        
        // Check if the role exists, if not create it
        if (!await roleManager.RoleExistsAsync(request.Role))
            await roleManager.CreateAsync(new IdentityRole(request.Role));
        
        try
        {
            // Assign the role to the user
            await userManager.AddToRoleAsync(user, request.Role);
            
            // Create new Responder
            await _responderService.CreateResponder(request);

        }
        catch (Exception e)
        {
            return BadRequest("There was an error in creating a new responder: " + e.Message);
        }
        
        // Return a success message
        return Ok("Role assigned successfully");
    }

    [HttpPost("create-responder")]
    public async Task<IActionResult> CreateResponder(NewIncidentRequest request)
    {
        return Ok();
    }
}