using System.ComponentModel.DataAnnotations;

namespace Tracing.DataAccess.Dtos;

public class OwnerRegistrationDetails
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    [EmailAddress]
    public string email { get; set; } = string.Empty;
    
}