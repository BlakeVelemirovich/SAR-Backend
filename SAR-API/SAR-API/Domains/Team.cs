using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class Team
{
    [Key]
    [Column("team_id")]
    public string TeamId { get; set; }
    
    [Column("start_datetime")]
    public DateTime StartDateTime { get; set; }
    
    [Column("end_datetime")]
    public DateTime? EndDateTime { get; set; }
    
    [Column("task_id")]
    public string TaskId { get; set; }
    
    [Column("role")]
    public string Role { get; set; }
}