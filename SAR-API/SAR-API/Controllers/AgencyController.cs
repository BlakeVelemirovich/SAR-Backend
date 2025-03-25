using Microsoft.AspNetCore.Mvc;
using SAR_API.Domains;
using SAR_API.IncidentService;

namespace SAR_API.Controllers;

[ApiController]
public class AgencyController : ControllerBase
{
    private readonly IAgencyService _agencyService;

    public AgencyController(
        IAgencyService agencyService
    )
    {
        _agencyService = agencyService;
    }

    [HttpPost("add-agency")]
    public async Task<IActionResult> AddAgency(
        [FromBody] AgencyRequest request
    )
    {
        // Check if the model state is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            // Create new Agency
            await _agencyService.CreateAgency(request);

        }
        catch (Exception e)
        {
            return BadRequest("There was an error in creating a new agency: " + e.Message);
        }
        
        // Return a success message
        return Ok("Role assigned successfully");
    } 
}