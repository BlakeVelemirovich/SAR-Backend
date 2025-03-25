namespace SAR_API.Domains;

public class AssignUserRequest
{
    public string Role { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string Phone { get; set; }
    
    public string Province { get; set; }
    
    public Guid AgencyId { get; set; }
    
    public Boolean CheckedIn { get; set; }
    
    public string Email { get; set; }
}