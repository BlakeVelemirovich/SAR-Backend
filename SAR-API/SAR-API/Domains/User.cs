namespace SAR_API.Domains;

public class User
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public string Role { get; set; }
}