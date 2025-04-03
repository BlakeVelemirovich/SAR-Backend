using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SAR_API.DTOs;

namespace SAR_API.Domains;

public class Incident
{
    [Key]
    [Column("incident_id")]
    public string IncidentId { get; set; }
    
    [Column("incident_name")]
    public string IncidentName { get; set; }
    
    [Column("type")]
    public string IncidentType { get; set; }
    
    [Column("province")]
    public string Province { get; set; }
    
    [Column("city")]
    public string City { get; set; }
    
    [Column("postal_code")]
    public string Postal { get; set; }
    
    [Column("address")]
    public string Address { get; set; }
    
    [Column("summary")]
    public string Summary { get; set; }
    
    [Column("objectives")]
    public string Objectives { get; set; }
    
    [Column("end_datetime")]
    public DateTime? EndDate { get; set; }
}