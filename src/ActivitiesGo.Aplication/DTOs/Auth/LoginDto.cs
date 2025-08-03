using System;
using System.ComponentModel.DataAnnotations;

namespace ActivitiesGo.Aplication.DTOs.Auth;

public class LoginDto
{
    [Required]
    public required string Email { get; set; }
    
    [Required]
    public required string Password { get; set; }
}
