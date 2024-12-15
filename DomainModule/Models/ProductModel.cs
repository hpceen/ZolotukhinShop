namespace DomainModule.Models;

[Serializable]
public class ProductModel
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? ImagePath { get; set; }
    public required CategoryModel Category { get; set; }
    public int? BatteryLifeTime { get; set; }
    public int? CameraResolution { get; set; }
    public string? OsVersion { get; set; }
    public string? InternetConnectionType { get; set; }
    public double? ScreenDiagonal { get; set; }
    public int? MemorySize { get; set; }
    public string? DisplayMatrixType { get; set; }
    public double? Weight { get; set; }
    public string? CpuName { get; set; }
    public int? RamSize { get; set; }
    public string? GpuName { get; set; }
}