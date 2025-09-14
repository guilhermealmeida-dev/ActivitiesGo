using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActivitiesGo.Aplication.DTOs.Auth;

public class LoginDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    [EmailAddress(ErrorMessage = "Endereço de email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo é obrigatório")]
    public string Password { get; set; } = string.Empty;
}
