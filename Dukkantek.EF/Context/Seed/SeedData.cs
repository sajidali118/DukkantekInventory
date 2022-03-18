using Dukkantek.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dukkantek.Domain.Utilities.EnumsData;

namespace Dukkantek.EF.Context.Seed
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Categories
            modelBuilder.Entity<Category>().HasData(

            new Category
             {
                 Id = 1,
                 Name = "Electronic Devices",
                 ShortName = "Electronic Devices",
             },
             new Category
             {
                 Id = 2,
                 Name = "Health & Beauty",
                 ShortName = "Health & Beauty",
             },
             new Category
             {
                 Id = 3,
                 Name = "Sports & Outdoor",
                 ShortName = "Sports & Outdoor",
             }
            );

            // Products
            modelBuilder.Entity<Product>().HasData(

            new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "IPhone 13 Pro",
                Barcode = "xxxxxxxxxxxxxxx",
                Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                Weight = 90,
                Status = ProductStatus.INSTOCK,
            },
            new Product
            {
                Id = 2,
                CategoryId = 1,
                Name = "IPhone 12 Pro",
                Barcode = "xxxxxxxxxxxxxxx123",
                Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                Weight = 85,
                Status = ProductStatus.INSTOCK,
            },
            new Product
             {
                 Id = 3,
                 CategoryId = 1,
                 Name = "IPhone 13 Pro MAX",
                 Barcode = "xxxxxxxxxxxxxxx234",
                 Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                 Weight = 95,
                 Status = ProductStatus.SOLD,
            },
            new Product
             {
                 Id = 4,
                 CategoryId = 1,
                 Name = "IPhone 12 Pro MAX",
                 Barcode = "xxxxxxxxxxxxxxx3333",
                 Description = "BuildOSIOS 15 DimensionsN/A WeightN/A SIMDual Sim, Dual Standby (Nano-SIM) ColorsVarious Frequency2G BandSIM1: GSM 850 / 900 / 1800 / 1900",
                 Weight = 95,
                 Status = ProductStatus.DAMAGED,
             }
            );
        }
    }
}
