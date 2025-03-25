using System.Text.Json.Serialization;

namespace SAR_API.Domains;

public class AgencyRequest
{
    [JsonPropertyName("agencyName")]
    public string AgencyName { get; set; }
    
    [JsonPropertyName("province")]
    public string Province { get; set; }
}