using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task  SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!storeContext.ProductBrands.Any())
                {
                    var brandData= File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands= JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach(var brand in brands)
                    {
                        storeContext.ProductBrands.Add(brand);
                    }
                    await storeContext.SaveChangesAsync();
                }

                if(!storeContext.ProductTypes.Any())
                {
                    var typeData= File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types= JsonSerializer.Deserialize<List<ProductType>>(typeData);

                    foreach(var item in types)
                    {
                        storeContext.ProductTypes.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
                if(!storeContext.Products.Any())
                {
                    var productData= File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products= JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach(var item in products)
                    {
                        storeContext.Products.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var logger= loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex,"Error caught while addind seed Data");
            }
        }
    }
}