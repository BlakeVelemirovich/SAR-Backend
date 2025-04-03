using Microsoft.EntityFrameworkCore;
using SAR_API.Database;
using SAR_API.Domains;
using SAR_API.DTOs;

namespace SAR_API.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly NeonDbContext _dbContext;
    
    public TaskRepository(NeonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateTask(TaskDTO task)
    {
        // Save Task to DB
        await _dbContext.AddAsync(task);
        int result = await _dbContext.SaveChangesAsync();

        return result;
    }

    public async Task<int> CreateTeam(TeamDTO team)
    {
        // Save Team to DB
        await _dbContext.AddAsync(team);
        int result = await _dbContext.SaveChangesAsync();

        return result;
    }
    
    public async Task<TaskIncident> GetTaskView(string taskId)
    {
        // Query database for the task
        return await _dbContext.task.FirstOrDefaultAsync(t => t.TaskId == taskId);
    }

    public async Task<TeamDetailsDTO> GetTeam(string taskId)
    {
        var team = await _dbContext.team
            .Where(t => t.TaskId == taskId)
            .Select(t => new TeamDetailsDTO
            {
                TeamId = t.TeamId,
                StartDateTime = t.StartDateTime,
                EndDateTime = t.EndDateTime,
                TaskId = t.TaskId,
                Role = t.Role,
                Responders = _dbContext.Set<TeamResponder>()
                    .Where(tr => tr.TeamId == t.TeamId)
                    .Select(tr => new ResponderDTO
                    {
                        ResponderId = tr.ResponderId
                    }).ToList()
            }).FirstOrDefaultAsync();

        return team;
    }
}