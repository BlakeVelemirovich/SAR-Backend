using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.DTOs;

public class AgencyDTO
{
    [Column("agency_id")]
    public Guid AgencyId { get; set; }
    
    [Column("agency_name")]
    public string AgencyName { get; set; }
    
    [Column("Province")]
    public string Province { get; set; }
}