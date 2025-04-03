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
    
    [JsonProperty("operationalPeriodId")]
    public int OpId { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("role")]
    public string Role { get; set; }
    
    [JsonProperty("responderIds")]
    public List<string> ResponderIds { get; set; }
}