using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface ITaskRepository
{
    Task<int> CreateTask(TaskDTO task);

    Task<int> CreateTeam(TeamDTO team);

    Task<TaskIncident> GetTaskView(string taskId);

    Task<TeamDetailsDTO> GetTeam(string taskId);
}