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
        TaskIncident task = new TaskIncident
        {
            TaskId = taskId,
            TaskName = request.TaskName,
            StartDatetime = request.StartDate,
            EndDatetime = request.EndDate,
            OperationalPeriodId = request.OpId,
            Description = request.Description
        };
        
        // Save task to database
        int result = await _taskRepository.CreateTask(task);
        
        // Check if task was created successfully (result == 0 if failed)
        if (result == 0)
        {
            throw new Exception("Failed to create task");
        }
        
        // Create a new team and return the team id
        string teamId = Guid.NewGuid().ToString();
        
        // Create new team object
        Team team = new Team
        {
            TeamId = teamId,
            TaskId = taskId,
            Role = request.Role
        };
        
        // Save team to database
        int teamResult = await _taskRepository.CreateTeam(team);
        
        // Check if team was created successfully (teamResult == 0 if failed)
        if (teamResult == 0)
        {
            throw new Exception("Failed to create team");
        }
        
        // Create new team responders
        foreach (var responder in request.ResponderIds)
        {
            // Generate new Team Responder Id
            string teamResponderId = Guid.NewGuid().ToString();
            
            // Create new team responder object
            TeamResponder teamResponder = new TeamResponder
            {
                TeamResponderId = teamResponderId,
                TeamId = teamId,
                ResponderId = responder
            };
            
            // Save team responder to database
            int teamResponderResult = await _taskRepository.CreateTeamResponder(teamResponder);
            
            // Check if team responder was created successfully (teamResponderResult == 0 if failed)
            if (teamResponderResult == 0)
            {
                throw new Exception("Failed to create team responder");
            }
        }
        
    }
    
    public async Task<ViewTaskDTO> GetTaskView(string taskId)
    {
        // Get task from database
        TaskIncident task = await _taskRepository.GetTaskView(taskId);
        
        // Check if task exists
        if (task == null)
        {
            throw new Exception("Task not found");
        }
        
        // Get team assigned to task
        TeamDetailsDTO team = await _taskRepository.GetTeam(taskId);
        
        // Create view task object
        ViewTaskDTO viewTask = new ViewTaskDTO
        {
            TaskId = task.TaskId,
            TaskName = task.TaskName,
            StartDateTime = task.StartDatetime,
            EndDateTime = task.EndDatetime,
            OpId = task.OperationalPeriodId,
            Description = task.Description,
            Teams = team
        };
        
        return viewTask;
    }
}