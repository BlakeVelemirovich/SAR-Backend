using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class TaskIncident
{
    [Key]
    [Column("task_id")]
    public string TaskId { get; set; }
    
    [Column("task_name")]
    public string TaskName { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
    
    [Column("start_datetime")]
    public DateTime StartDatetime { get; set; }
    
    [Column("end_datetime")]
    public DateTime? EndDatetime { get; set; }
    
    [Column("op_id")]
    public string OperationalPeriodId { get; set; }
    
}