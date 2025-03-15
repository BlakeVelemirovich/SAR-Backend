namespace SAR_API.Domains;

public class NewIncidentRequest
{
    public string IncidentName { get; set; }
    public string IncidentCommander { get; set; }
    public string Agency { get; set; }
    public string IncidentType { get; set; }
    public long OperationPeriod { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Postal { get; set; }
    public string Province { get; set; }
    public DateTime Date { get; set; }
    public string Summary { get; set; }
    public string Objectives { get; set; }
}