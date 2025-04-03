namespace SAR_API.DTOs;

public class ViewTaskDTO
{
    public string TaskId { get; set; }
    
    public string TaskName { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public DateTime? EndDateTime { get; set; }
    
    public string OpId { get; set; }
    
    public TeamDetailsDTO? Teams { get; set; }
}