using DomainModule.Models;
using Repositories.Database.Entities;

namespace Repositories.Extensions;

public static class ProductEntityExtension
{
    public static ProductModel ToModel(this ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Brand = entity.Brand,
            Price = entity.Price,
            Description = entity.Description,
            ImagePath = entity.ImagePath,
            Category = entity.Category.ToModel(),
            BatteryLifeTime = entity.BatteryLifeTime,
            CameraResolution = entity.CameraResolution,
            OsVersion = entity.OsVersion,
            InternetConnectionType = entity.InternetConnectionType,
            ScreenDiagonal = entity.ScreenDiagonal,
            RamSize = entity.RamSize,
            DisplayMatrixType = entity.DisplayMatrixType,
            Weight = entity.Weight,
            CpuName = entity.CpuName,
            GpuName = entity.GpuName,
            MemorySize = entity.MemorySize
        };
    }
}