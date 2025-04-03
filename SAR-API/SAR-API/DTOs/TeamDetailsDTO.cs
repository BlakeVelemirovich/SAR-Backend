namespace SAR_API.DTOs;

public class TeamDetailsDTO
{
    public string TeamId { get; set; }
    public DateTime? StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public string TaskId { get; set; }
    public string Role { get; set; }
    public List<ResponderDTO> Responders { get; set; }
}