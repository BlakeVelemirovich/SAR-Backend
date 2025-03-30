using SAR_API.DTOs;

namespace SAR_API.Repositories;

public interface ITaskRepository
{
    Task<int> CreateTask(TaskDTO task);
}