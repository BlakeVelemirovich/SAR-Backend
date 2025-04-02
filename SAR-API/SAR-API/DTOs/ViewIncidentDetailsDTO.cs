namespace SAR_API.DTOs;

public class ViewIncidentDetailsDTO
{
    public IncidentDTO Incident { get; set; }
    
    public List<OperationalPeriodDTO> OperationalPeriods { get; set; }
}