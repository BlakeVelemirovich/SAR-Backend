namespace SAR_API.Domains;

using System;
using System.ComponentModel.DataAnnotations;

public class NewIncidentRequest
{
    [Required(ErrorMessage = "IncidentName is required.")]
    [StringLength(100, ErrorMessage = "IncidentName cannot exceed 100 characters.")]
    public string IncidentName { get; set; }

    [Required(ErrorMessage = "IncidentCommander is required.")]
    [StringLength(50, ErrorMessage = "IncidentCommander cannot exceed 50 characters.")]
    public string IncidentCommander { get; set; }

    [Required(ErrorMessage = "Agency is required.")]
    [StringLength(50, ErrorMessage = "Agency cannot exceed 50 characters.")]
    public string Agency { get; set; }

    [Required(ErrorMessage = "IncidentType is required.")]
    [StringLength(50, ErrorMessage = "IncidentType cannot exceed 50 characters.")]
    public string IncidentType { get; set; }

    [Range(1, long.MaxValue, ErrorMessage = "OperationPeriod must be a positive number.")]
    public long OperationPeriod { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Postal is required.")]
    [StringLength(10, ErrorMessage = "Postal cannot exceed 10 characters.")]
    public string Postal { get; set; }

    [Required(ErrorMessage = "Province is required.")]
    [StringLength(50, ErrorMessage = "Province cannot exceed 50 characters.")]
    public string Province { get; set; }

    [Required(ErrorMessage = "Date is required.")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Summary is required.")]
    [StringLength(1000, ErrorMessage = "Summary cannot exceed 1000 characters.")]
    public string Summary { get; set; }

    [Required(ErrorMessage = "Objectives is required.")]
    [StringLength(1000, ErrorMessage = "Objectives cannot exceed 1000 characters.")]
    public string Objectives { get; set; }
}