using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.DTOs;

public class OperationalPeriodDTO
{
    [Key]
    [Column("op_id")]
    public string OperationalPeriodId { get; set; }
    
    [Column("period")]
    public long OperationalPeriod { get; set; }
    
    [Column("responder_id")]
    public string ResponderId { get; set; }
    
    [Column("start_datetime")]
    public DateTime StartDatetime { get; set; }
    
    [Column("end_datetime")]
    public DateTime? EndDatetime { get; set; }
    
    [Column("incident_id")]
    public string IncidentId { get; set; }
    
    [Column("comms_id")]
    public long? CommsId { get; set; }
}