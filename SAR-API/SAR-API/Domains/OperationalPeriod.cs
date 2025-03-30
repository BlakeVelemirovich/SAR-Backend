using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class OperationalPeriod
{
    [Key]
    [Column("op_id")]
    public string OperationalPeriodId { get; set; }
    
    [Column("period")]
    public long Period { get; set; }
    
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