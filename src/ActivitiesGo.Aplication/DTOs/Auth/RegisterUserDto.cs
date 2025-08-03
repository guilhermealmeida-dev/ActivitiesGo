using System;
using System.ComponentModel.DataAnnotations;

namespace ActivitiesGo.Aplication.DTOs.User;

public class RegisterUserDto
{
    [Required(ErrorMessage = "O campo name é obrigatório")]
    public required string Name { get; set; }
    [Required(ErrorMessage = "O campo email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public required string Email { get; set; }
    [Length(11, 11, ErrorMessage = "O campo deve ter 11 caracteres")]
    [Required(ErrorMessage = "O campo cpf é obrigatório")]
    public required string CPF { get; set; }
    [MinLength(6, ErrorMessage = "Numero de caracteres insuficiente")]
    [Required(ErrorMessage = "O campo password é obrigatório")]
    public required string Password { get; set; }
}
