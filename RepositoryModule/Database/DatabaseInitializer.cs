using Repositories.Database.Entities;

namespace Repositories.Database;

public static class DatabaseInitializer
{
    public static void Initialize(DatabaseContext context)
    {
        var categoryList = new List<CategoryEntity>
        {
            new()
            {
                Id = 1,
                Name = "Smartphone",
            },
            new()
            {
                Id = 2,
                Name = "Tablet",
            },
            new()
            {
                Id = 3,
                Name = "Laptop",
            }
        };

        var productList = new List<ProductEntity>
        {
            new()
            {
                Id = 1,
                Brand = "Apple",
                Name = "iPhone 14",
                Description = "Последняя модель с чипом A16 Bionic",
                Price = 1099.99,
                ImagePath = "image1.webp",
                Category = categoryList[0],
                BatteryLifeTime = 24,
                CameraResolution = 50,
                OsVersion = "iOS 16",
                InternetConnectionType = "5G",
            },
            new()
            {
                Id = 2,
                Brand = "Samsung",
                Name = "Galaxy S23",
                Description = "Флагманская модель с Snapdragon 8 Gen 2",
                Price = 899.99,
                ImagePath = "image2.webp",
                Category = categoryList[0],
                BatteryLifeTime = 26,
                CameraResolution = 108,
                OsVersion = "Android 13",
                InternetConnectionType = "5G",
            },
            new()
            {
                Id = 3,
                Brand = "Google",
                Name = "Pixel 7",
                Description = "Высокопроизводительный смартфон с Google Tensor",
                Price = 599.99,
                ImagePath = "image3.webp",
                Category = categoryList[0],
                BatteryLifeTime = 30,
                CameraResolution = 50,
                OsVersion = "Android 13",
                InternetConnectionType = "5G",
            },
            new()
            {
                Id = 4,
                Brand = "OnePlus",
                Name = "11 Pro",
                Description = "Премиальный смартфон с камерой Hasselblad",
                Price = 799.99,
                ImagePath = "image4.webp",
                Category = categoryList[0],
                BatteryLifeTime = 28,
                CameraResolution = 108,
                OsVersion = "Android 12",
                InternetConnectionType = "5G",
            },
            new()
            {
                Id = 5,
                Brand = "Xiaomi",
                Name = "Mi 12",
                Description = "Доступный флагман с Snapdragon 8",
                Price = 699.99,
                ImagePath = "image5.webp",
                Category = categoryList[0],
                BatteryLifeTime = 32,
                CameraResolution = 50,
                OsVersion = "MIUI 13",
                InternetConnectionType = "5G",
            },
            new()
            {
                Id = 6,
                Brand = "Apple",
                Name = "iPad Air",
                Description = "Мощный планшет с чипом M1",
                Price = 599.99,
                ImagePath = "image6.webp",
                Category = categoryList[1],
                ScreenDiagonal = 10.9,
                MemorySize = 64,
                DisplayMatrixType = "Liquid Retina",
                InternetConnectionType = "WiFi",
                Weight = 0.458,
            },
            new()
            {
                Id = 7,
                Brand = "Samsung",
                Name = "Galaxy Tab S8",
                Description = "Универсальный планшет с S Pen",
                Price = 749.99,
                ImagePath = "image7.webp",
                Category = categoryList[1],
                ScreenDiagonal = 11,
                MemorySize = 128,
                DisplayMatrixType = "Super AMOLED",
                InternetConnectionType = "WiFi",
                Weight = 0.502,
            },
            new()
            {
                Id = 8,
                Brand = "Microsoft",
                Name = "Surface Go 3",
                Description = "Компактный планшет с Windows 11",
                Price = 399.99,
                ImagePath = "image8.webp",
                Category = categoryList[1],
                ScreenDiagonal = 10.5,
                MemorySize = 64,
                DisplayMatrixType = "PixelSense",
                InternetConnectionType = "WiFi",
                Weight = 0.544,
            },
            new()
            {
                Id = 9,
                Brand = "Lenovo",
                Name = "Tab P11 Plus",
                Description = "Высокопроизводительный планшет для развлечений",
                Price = 299.99,
                ImagePath = "image9.webp",
                Category = categoryList[1],
                ScreenDiagonal = 11,
                MemorySize = 128,
                DisplayMatrixType = "IPS",
                InternetConnectionType = "WiFi",
                Weight = 0.490,
            },
            new()
            {
                Id = 10,
                Brand = "Huawei",
                Name = "MatePad 11",
                Description = "Премиальный планшет с высокой частотой обновления",
                Price = 499.99,
                ImagePath = "image10.webp",
                Category = categoryList[1],
                ScreenDiagonal = 10.95,
                MemorySize = 64,
                DisplayMatrixType = "IPS",
                InternetConnectionType = "WiFi",
                Weight = 0.485,
            },
            new()
            {
                Id = 11,
                Brand = "Apple",
                Name = "MacBook Air M2",
                Description = "Тонкий и легкий ноутбук с чипом M2",
                Price = 1199.99,
                ImagePath = "image11.webp",
                Category = categoryList[2],
                CpuName = "Apple M2",
                RamSize = 16,
                GpuName = "Apple GPU",
                Weight = 1.29,
            },
            new()
            {
                Id = 12,
                Brand = "Dell",
                Name = "XPS 13",
                Description = "Ультратонкий ноутбук с дисплеем InfinityEdge",
                Price = 999.99,
                ImagePath = "image12.webp",
                Category = categoryList[2],
                CpuName = "Intel Core i5",
                RamSize = 8,
                GpuName = "Intel Iris Xe",
                Weight = 1.2
            },
            new()
            {
                Id = 13,
                Brand = "HP",
                Name = "Spectre x360",
                Description = "Трансформируемый ноутбук с 4K дисплеем",
                Price = 1399.99,
                ImagePath = "image13.webp",
                Category = categoryList[2],
                CpuName = "Intel Core i7",
                RamSize = 16,
                GpuName = "Nvidia GeForce",
                Weight = 1.34
            },
            new()
            {
                Id = 14,
                Brand = "Asus",
                Name = "ZenBook 14",
                Description = "Компактный ноутбук с высокой производительностью",
                Price = 899.99,
                ImagePath = "image14.webp",
                Category = categoryList[2],
                CpuName = "AMD Ryzen 7",
                RamSize = 16,
                GpuName = "Nvidia GeForce",
                Weight = 1.13
            },
            new()
            {
                Id = 15,
                Brand = "Lenovo",
                Name = "ThinkPad X1 Carbon",
                Description = "Бизнес-ноутбук с исключительным качеством сборки",
                Price = 1399.99,
                ImagePath = "image15.webp",
                Category = categoryList[2],
                CpuName = "Intel Core i7",
                RamSize = 16,
                GpuName = "Intel Iris Xe",
                Weight = 1.13
            }
        };

        if (context.Products.Any()) return;
        context.Products.AddRange(productList);
        context.SaveChanges();
    }
}