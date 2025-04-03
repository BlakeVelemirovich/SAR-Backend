namespace SAR_API.Domains;

public class UpdateIncidentEndDateRequest
{
    public string IncidentId { get; set; }
    
    public DateTime EndDate { get; set; }
}