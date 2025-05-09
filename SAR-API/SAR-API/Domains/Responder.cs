using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class Responder
{
    [Column("responder_id")]
    public string ResponderId { get; set; }
    
    [Column("responder_name")]
    public string ResponderName { get; set; }
    
    [Column("birth_date")]
    public DateTime BirthDate { get; set; }
    
    [Column("phone")]
    public string Phone { get; set; }
    
    [Column("province")]
    public string Province { get; set; }
    
    [Column("agency_id")]
    public string AgencyId { get; set; }
    
    [Column("checked_in")]
    public Boolean CheckedIn { get; set; }
    
    [Column("user_id")]
    public string UserId { get; set; }
}