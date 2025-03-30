using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class TaskIncident
{
    [Key]
    [Column("team_id")]
    public string TeamId { get; set; }
    
    [Column("responder_id")]
    public string ResponderId { get; set; }
    
    [Column("role_id")]
    public string RoleId { get; set; }
    
    [Column("start_datetime")]
    public DateTime StartDate { get; set; }
    
    [Column("end_datetime")]
    public DateTime? EndDate { get; set; }
    
    [Column("task_id")]
    public string TaskId { get; set; }
}