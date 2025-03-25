using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.DTOs;

public class AgencyDTO
{
    // Primary Key
    [Key]
    [Column("agency_id")]
    public string AgencyId { get; set; }
    
    [Column("agency_name")]
    public string AgencyName { get; set; }
    
    [Column("province")]
    public string Province { get; set; }
}