using Newtonsoft.Json;

namespace SAR_API.Domains;

public class NewTaskRequest
{
    [JsonProperty("taskName")]
    public string TaskName { get; set; }
    
    [JsonProperty("startDate")]
    public DateTime StartDate { get; set; }
    
    [JsonProperty("endDate")]
    public DateTime EndDate { get; set; }
    
    [JsonProperty("operationalPeriod")]
    public int OperationalPeriod { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
}