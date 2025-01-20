using System.ComponentModel.DataAnnotations;

namespace Repositories.Database.Entities;

public class UserEntity
{
    [Key] public int Id { get; set; }
    [MaxLength(100)] public required string LastName { get; set; }
    [MaxLength(100)] public required string FirstName { get; set; }
    [MaxLength(100)] public required string Patronymic { get; set; }
    [MaxLength(100)] public required string PhoneNumber { get; set; }
    [MaxLength(100)] public required string Password { get; set; }
}