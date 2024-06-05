using System.ComponentModel.DataAnnotations;

namespace JWT.Models.Request;
public class RefreshRequest
{
    [Required]
    public required string RefreshToken { get; set; }

}
