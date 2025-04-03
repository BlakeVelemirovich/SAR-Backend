using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.IncidentService;

public interface ITaskService
{
    public Task CreateTask(NewTaskRequest request);
    
    public Task<ViewTaskDTO> GetTaskView(string taskId);
}