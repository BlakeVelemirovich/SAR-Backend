using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAR_API.Domains;

public class User
{
    [Key]
    [Column("Id")]
    public string Id { get; set; }
    
    [Column("UserName")]
    public string UserName { get; set; }
    
    [Column("NormalizedUserName")]
    public string NormalizedUserName { get; set; }
    
    [Column("Email")]
    public string Email { get; set; }
    
    [Column("NormalizedEmail")]
    public DateTime BirthDate { get; set; }
    
    [Column("EmailConfirmed")]
    public Boolean EmailedConfirmed { get; set; }
    
    [Column("SecurityStamp")]
    public string SecurityStamp { get; set; }
    
    [Column("ConcurrencyStamp")]
    public string ConcurrencyStamp { get; set; }
    
    [Column("PhoneNumber")]
    public string PhoneNumber { get; set; }
}