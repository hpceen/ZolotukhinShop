namespace DomainModule.Models;

public class Filter
{
    public string? SearchString { get; set; } = null;
    public int? CategoryId { get; set; } = null;
    public string? SortOrder { get; set; } = "none";
    public double? PriceFrom { get; set; } = null;
    public double? PriceTo { get; set; } = null;
    public int? BatteryLifeTimeFrom { get; set; } = null;
    public int? BatteryLifeTimeTo { get; set; } = null;
    public int? CameraResolutionFrom { get; set; } = null;
    public int? CameraResolutionTo { get; set; } = null;
    public List<string?> OsVersion { get; set; } = [];
    public List<string?> InternetConnectionType { get; set; } = [];
    public int? ScreenDiagonalFrom { get; set; } = null;
    public int? ScreenDiagonalTo { get; set; } = null;
    public int? MemorySizeFrom { get; set; } = null;
    public int? MemorySizeTo { get; set; } = null;
    public List<string?> DisplayMatrixType { get; set; } = [];
    public double? WeightFrom { get; set; } = null;
    public double? WeightTo { get; set; } = null;
    public List<string?> CpuName { get; set; } = [];
    public int? RamSizeFrom { get; set; } = null;
    public int? RamSizeTo { get; set; } = null;
    public List<string?> GpuName { get; set; } = [];
}