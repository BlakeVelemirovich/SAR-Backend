using SAR_API.Domains;

namespace SAR_API.IncidentService;

public interface ITaskService
{
    public Task CreateTask(NewTaskRequest request);
}