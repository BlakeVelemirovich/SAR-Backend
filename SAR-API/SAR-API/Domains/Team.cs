namespace SAR_API.Domains;

public class Team
{
    public string ResponderId { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    public string ResponderRole { get; set; }
}