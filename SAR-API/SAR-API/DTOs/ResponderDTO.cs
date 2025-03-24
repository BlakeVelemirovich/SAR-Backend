namespace SAR_API.DTOs;

public class ResponderDTO
{
    public Guid ResponderId { get; set; }
    
    public string ResponderName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string Phone { get; set; }
    
    public string Province { get; set; }
    
    public Guid AgencyId { get; set; }
    
    public Boolean CheckedIn { get; set; }
    
    public Guid UserId { get; set; }
}