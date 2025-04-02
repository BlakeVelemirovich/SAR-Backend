namespace SAR_API.DTOs;

public class TaskViewDTO
{
    public string TaskId { get; set; }
    
    public string TaskName { get; set; }
    
    public string Description { get; set; }
    
    public string StartDateTime { get; set; }
    
    public string EndDateTime { get; set; }
    
    public string OpId { get; set; }
    
    public List<TeamViewDTO> Teams { get; set; }
}