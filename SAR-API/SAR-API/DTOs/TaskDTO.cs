using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.DTOs;

public class TaskDTO
{
    [Key]
    [Column("task_id")]
    public string TaskId { get; set; }
    
    [Column("task_name")]
    public string TaskName { get; set; }
    
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Column("end_date")]
    public DateTime? EndDate { get; set; }
    
    [Column("op_id")]
    public int OperationalPeriod { get; set; }
    
    [Column("description")]
    public string Description { get; set; }
}