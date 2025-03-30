using SAR_API.Domains;
using SAR_API.DTOs;
using SAR_API.Repositories;

namespace SAR_API.IncidentService;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    
    public async Task CreateTask(NewTaskRequest request)
    {
        // Add task to database
        string taskId = Guid.NewGuid().ToString();
        
        // Create new task object
        TaskDTO task = new TaskDTO
        {
            TaskId = taskId,
            TaskName = request.TaskName,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            OperationalPeriod = request.OperationalPeriod,
            Description = request.Description
        };
        
        // Save task to database
        int result = await _taskRepository.CreateTask(task);
        
        // Check if task was created successfully (result == 0 if failed)
        if (result == 0)
        {
            throw new Exception("Failed to create task");
        }
    }
}