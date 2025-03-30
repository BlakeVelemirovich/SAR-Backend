using SAR_API.Database;
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
}