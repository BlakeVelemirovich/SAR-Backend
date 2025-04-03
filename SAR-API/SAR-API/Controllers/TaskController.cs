using Microsoft.AspNetCore.Mvc;
using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.IncidentService;

namespace SAR_API.Controllers;

[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpPost("create-task")]
    public async Task<IActionResult> CreateTask(
        [FromBody] NewTaskRequest request
    )
    {
        // Check if the model state is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            // Create new Task
            await _taskService.CreateTask(request);
        }
        catch (Exception e)
        {
            return BadRequest("There was an error in creating a new task: " + e.Message);
        }
        
        // Return a success message
        return Ok("Task added successfully");
    }
    
    [HttpGet("get-viewTask/{taskId}")]
    public async Task<IActionResult> GetTaskView(string taskId)
    {
        // Check if the model state is valid
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        try
        {
            // Get the task view
            ViewTaskDTO task = await _taskService.GetTaskView(taskId);
            
            // Return the task view
            return Ok(task);
        }
        catch (Exception e)
        {
            return BadRequest("There was an error in getting the task view: " + e.Message);
        }
    }
    
}