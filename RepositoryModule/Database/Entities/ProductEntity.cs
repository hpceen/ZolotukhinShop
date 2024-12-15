using System.ComponentModel.DataAnnotations;

namespace Repositories.Database.Entities;

public class ProductEntity
{
    [Key] public int Id { get; set; }
    [MaxLength(100)] public string? Brand { get; set; }
    [MaxLength(100)] public string? Name { get; set; }
    [MaxLength(500)] public string? Description { get; set; }
    public double Price { get; set; }
    [MaxLength(255)] public string? ImagePath { get; set; }
    public virtual CategoryEntity Category { get; set; } = new();
    public int CategoryId { get; set; }
    public int? BatteryLifeTime { get; set; }
    public int? CameraResolution { get; set; }
    [MaxLength(255)] public string? OsVersion { get; set; }
    [MaxLength(255)] public string? InternetConnectionType { get; set; }
    public double? ScreenDiagonal { get; set; }
    public int? MemorySize { get; set; }
    [MaxLength(255)] public string? DisplayMatrixType { get; set; }
    public double? Weight { get; set; }
    [MaxLength(255)] public string? CpuName { get; set; }
    public int? RamSize { get; set; }
    [MaxLength(255)] public string? GpuName { get; set; }
}