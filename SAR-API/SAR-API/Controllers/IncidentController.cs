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
            return BadRequest("There was an error in creating a new Incident: " + e.Message);
        }

        // Return a success message
        return Ok("Incident added successfully");
    }
    
    [HttpGet("get-allIncidents")]
    public async Task<IActionResult> GetAllIncidents()
    {
        try
        {
            // Get all Incidents
            var incidents = await _incidentService.GetAllIncidents();
            return Ok(incidents);
        }
        catch (Exception e)
        {
            return BadRequest("There was an error in getting all Incidents: " + e.Message);
        }
    }
    
    [HttpGet("get-allPastIncidents")]
    public async Task<IActionResult> GetAllPastIncidents()
    {
        try
        {
            // Get all Past Incidents
            var incidents = await _incidentService.GetAllPastIncidents();
            return Ok(incidents);
        }
        catch (Exception e)
        {
            return BadRequest("There was an error in getting all Past Incidents: " + e.Message);
        }
    }
    
    [HttpGet("get-viewIncident/{incidentId}")]
    public async Task<IActionResult> GetViewIncident(
        [FromRoute] string incidentId
    )
    {
        try
        {
            // Get view Incident
            var incident = await _incidentService.GetViewIncident(incidentId);
            return Ok(incident);
        }
        catch (Exception e)
        {
            return BadRequest("There was an error in getting view Incident: " + e.Message);
        }
    }
    
    [HttpPost("update-incidentEndDate")]
    public async Task<IActionResult> UpdateIncidentEndDate(
        [FromBody] UpdateIncidentEndDateRequest request
    )
    {
        // Check if the model state is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);

        try
        {
            // Update Incident End Date
            await _incidentService.UpdateIncidentEndDate(request);
        }
        catch (Exception e)
        {
            return BadRequest("There was an error in updating Incident End Date: " + e.Message);
        }

        // Return a success message
        return Ok("Incident End Date updated successfully");
    }
}