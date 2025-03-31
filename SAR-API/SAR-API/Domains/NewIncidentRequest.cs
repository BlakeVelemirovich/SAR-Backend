using System.Text.Json.Serialization;

namespace SAR_API.Domains;

using System;
using System.ComponentModel.DataAnnotations;

public class NewIncidentRequest
{
    [Required(ErrorMessage = "IncidentName is required.")]
    [StringLength(100, ErrorMessage = "IncidentName cannot exceed 100 characters.")]
    [JsonPropertyName("incidentName")]
    public string IncidentName { get; set; }

    [Required(ErrorMessage = "IncidentCommander is required.")]
    [StringLength(500, ErrorMessage = "IncidentCommander cannot exceed 500 characters.")]
    [JsonPropertyName("incidentCommander")]
    public string IncidentCommander { get; set; }

    [Required(ErrorMessage = "Agency is required.")]
    [StringLength(50, ErrorMessage = "Agency cannot exceed 50 characters.")]
    [JsonPropertyName("agency")]
    public string Agency { get; set; }

    [Required(ErrorMessage = "IncidentType is required.")]
    [StringLength(50, ErrorMessage = "IncidentType cannot exceed 50 characters.")]
    [JsonPropertyName("incidentType")]
    public string IncidentType { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "OperationPeriod must be a positive number.")]
    [JsonPropertyName("operationPeriod")]
    public long OperationPeriod { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
    [JsonPropertyName("city")]
    public string City { get; set; }

    [Required(ErrorMessage = "Postal is required.")]
    [StringLength(10, ErrorMessage = "Postal cannot exceed 10 characters.")]
    [JsonPropertyName("postal")]
    public string Postal { get; set; }

    [Required(ErrorMessage = "Province is required.")]
    [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
    [JsonPropertyName("province")]
    public string Province { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    [JsonPropertyName("startDate")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Summary is required.")]
    [StringLength(1000, ErrorMessage = "Summary cannot exceed 1000 characters.")]
    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [Required(ErrorMessage = "Objectives is required.")]
    [StringLength(1000, ErrorMessage = "Objectives cannot exceed 1000 characters.")]
    [JsonPropertyName("objectives")]
    public string Objectives { get; set; }
}