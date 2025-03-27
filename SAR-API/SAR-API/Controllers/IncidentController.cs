using Microsoft.AspNetCore.Mvc;
using SAR_API.Domains;
using SAR_API.IncidentService;

namespace SAR_API.Controllers;

[ApiController]
public class IncidentController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentController(
        IIncidentService incidentService
    )
    {
        _incidentService = incidentService;
    }

    [HttpPost("create-incident")]
    public async Task<IActionResult> AddAgency(
        [FromBody] NewIncidentRequest request
    )
    {
        // Check if the model state is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            // Create new Agency
            await _incidentService.CreateIncident(request);

        }
        catch (Exception e)
        {
            return BadRequest("There was an error in creating a new agency: " + e.Message);
        }

        // Return a success message
        return Ok("Incident added successfully");
    }
}