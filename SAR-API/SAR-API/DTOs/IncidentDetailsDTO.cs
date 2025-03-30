namespace SAR_API.DTOs;

public class IncidentDetailsDTO
{
    public string IncidentId { get; set; }
    
    public string IncidentName { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public string IncidentType { get; set; }
    
    public string AgencyName { get; set; }
}