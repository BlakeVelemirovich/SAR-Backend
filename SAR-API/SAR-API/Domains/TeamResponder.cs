using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class TeamResponder
{
    [Key]
    [Column("id")]
    public string TeamResponderId { get; set; }
    
    [Column("team_id")]
    public string TeamId { get; set; }
    
    [Column("responder_id")]
    public string ResponderId { get; set; }
    
    [Column("start_datetime")]
    public DateTime? StartDateTime { get; set; }
    
    [Column("end_datetime")]
    public DateTime? EndDateTime { get; set; }
}