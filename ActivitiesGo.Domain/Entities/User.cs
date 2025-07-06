namespace ActivitiesGo.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string CPF { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
    public int XP { get; set; }
    public int Level { get; set; }
    public DateTime? DeleteAt { get; set; }

}
