using System.ComponentModel.DataAnnotations;

namespace Repositories.Database.Entities;

public class UserEntity
{
    [MaxLength(100)] public required string LastName { get; set; }
    [MaxLength(100)] public required string FirstName { get; set; }
    [MaxLength(100)] public required string Patronymic { get; set; }
    [Key] [MaxLength(100)] public required string Phone { get; set; }
    [MaxLength(100)] public required string Password { get; set; }
}