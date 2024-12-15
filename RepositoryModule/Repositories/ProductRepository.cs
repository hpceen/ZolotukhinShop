using DomainModule.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Database;
using Repositories.Extensions;

namespace Repositories.Repositories;

public class ProductRepository(DatabaseContext context) : IProductRepository
{
    public async Task<ProductModel?> GetById(int id)
    {
        return (await context.Products.FindAsync(id))?.ToModel();
    }

    public async Task<List<ProductModel>> GetByFilter(Filter filter)
    {
        var query = context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(filter.SearchString))
        {
            query = query.Where(x =>
                (x.Brand + " " + x.Name + " " + x.Description).ToLower().Contains(filter.SearchString.ToLower()));
        }

        if (filter.CategoryId != null)
        {
            query = query.Where(x => x.CategoryId == filter.CategoryId);
        }

        query = filter.SortOrder switch
        {
            "priceAsc" => query.OrderBy(x => x.Price),
            "priceDesc" => query.OrderByDescending(x => x.Price),
            "nameAsc" => query.OrderBy(x => x.Name),
            "nameDesc" => query.OrderByDescending(x => x.Name),
            _ => query
        };

        if (filter.PriceFrom != null)
        {
            query = query.Where(x => x.Price >= filter.PriceFrom);
        }

        if (filter.PriceTo != null)
        {
            query = query.Where(x => x.Price <= filter.PriceTo);
        }

        if (filter.BatteryLifeTimeFrom != null)
        {
            query = query.Where(x => x.BatteryLifeTime >= filter.BatteryLifeTimeFrom);
        }

        if (filter.BatteryLifeTimeTo != null)
        {
            query = query.Where(x => x.BatteryLifeTime <= filter.BatteryLifeTimeTo);
        }

        if (filter.CameraResolutionFrom != null)
        {
            query = query.Where(x => x.CameraResolution >= filter.CameraResolutionFrom);
        }

        if (filter.CameraResolutionTo != null)
        {
            query = query.Where(x => x.CameraResolution <= filter.CameraResolutionTo);
        }

        if (filter.OsVersion.Count != 0)
        {
            query = query.Where(x => filter.OsVersion.Contains(x.OsVersion));
        }

        if (filter.InternetConnectionType.Count != 0)
        {
            query = query.Where(x => filter.InternetConnectionType.Contains(x.InternetConnectionType));
        }

        if (filter.ScreenDiagonalFrom != null)
        {
            query = query.Where(x => x.ScreenDiagonal >= filter.ScreenDiagonalFrom);
        }

        if (filter.ScreenDiagonalTo != null)
        {
            query = query.Where(x => x.ScreenDiagonal <= filter.ScreenDiagonalTo);
        }

        if (filter.MemorySizeFrom != null)
        {
            query = query.Where(x => x.MemorySize >= filter.MemorySizeFrom);
        }

        if (filter.MemorySizeTo != null)
        {
            query = query.Where(x => x.MemorySize <= filter.MemorySizeTo);
        }

        if (filter.DisplayMatrixType.Count != 0)
        {
            query = query.Where(x => filter.DisplayMatrixType.Contains(x.DisplayMatrixType));
        }

        if (filter.WeightFrom != null)
        {
            query = query.Where(x => x.Weight >= filter.WeightFrom);
        }

        if (filter.WeightTo != null)
        {
            query = query.Where(x => x.Weight <= filter.WeightTo);
        }

        if (filter.CpuName.Count != 0)
        {
            query = query.Where(x => filter.CpuName.Contains(x.CpuName));
        }

        if (filter.RamSizeFrom != null)
        {
            query = query.Where(x => x.RamSize >= filter.RamSizeFrom);
        }

        if (filter.RamSizeTo != null)
        {
            query = query.Where(x => x.RamSize <= filter.RamSizeTo);
        }

        if (filter.GpuName.Count != 0)
        {
            query = query.Where(x => filter.GpuName.Contains(x.GpuName));
        }

        return await query.Select(x => x.ToModel()).ToListAsync();
    }
}