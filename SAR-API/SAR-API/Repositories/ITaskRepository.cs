using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface ITaskRepository
{
    Task<int> CreateTask(TaskIncident task);

    Task<int> CreateTeam(Team team);

    Task<TaskIncident> GetTaskView(string taskId);

    Task<TeamDetailsDTO> GetTeam(string taskId);
    
    Task<int> CreateTeamResponder(TeamResponder teamResponder);
}