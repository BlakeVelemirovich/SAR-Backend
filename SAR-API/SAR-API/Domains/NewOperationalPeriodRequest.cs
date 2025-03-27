namespace SAR_API.DTOs;

public class NewOperationalPeriodRequest
{
    public long OperationalPeriod { get; set; }
    
    public string ResponderId { get; set; }
    
    public DateTime StartDatetime { get; set; }
    
    public string IncidentId { get; set; }
}