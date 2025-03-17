namespace SAR_API.Domains;

public class Responder
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string Phone { get; set; }
    
    public string Province { get; set; }
    
    public string Email { get; set; }
    
    public Boolean CheckedIn { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid AgencyId { get; set; }
}