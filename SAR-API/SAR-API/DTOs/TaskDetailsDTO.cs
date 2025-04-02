using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.DTOs;

public class TaskDetailsDTO
{
    [Column("task_id")]
    public string TaskId { get; set; }
    
    [Column("start_datetime")]
    public DateTime StartDateTime { get; set; }
    
    [Column("end_datetime")]
    public DateTime EndDateTime { get; set; }
}