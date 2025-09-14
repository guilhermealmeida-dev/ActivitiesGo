using System;
using System.ComponentModel.DataAnnotations;

namespace ActivitiesGo.Aplication.DTOs.User;

public class RegisterUserDto
{
    [Required(ErrorMessage = "O campo é obrigatório")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Length(11, 11, ErrorMessage = "O campo deve ter 11 caracteres")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public string CPF { get; set; } = string.Empty;

    [MinLength(6, ErrorMessage = "Numero de caracteres insuficiente")]
    [Required(ErrorMessage = "O campo é obrigatório")]
    public string Password { get; set; } = string.Empty;
}
