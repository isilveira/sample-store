using ChanceNET;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Store.Core.Application.Interfaces.Infrastructures.Data;
using Store.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructures.Data.Seeds
{
    public static class IStoreContextSeedExtensions
    {
        public static async Task SeedContext(this IStoreContext context, IConfiguration configuration)
        {
            var seedsMultiplier = configuration.GetSection("AppSettings").GetValue<int>("SeedsMultiplier");
            if (seedsMultiplier == 0)
            {
                Log.Debug("Seed multiplier set 0, no seed.");
                return;
            }

            await SeedCategoryAsync(context, Convert.ToInt32(0.5M * seedsMultiplier));
            await SeedProductsAsync(context, 100 * seedsMultiplier);
            await SeedConstumersAsync(context, 10 * seedsMultiplier);
            await SeedOrders(context);
        }

        private static async Task SeedOrders(IStoreContext context)
        {
            Chance chance = new Chance();

            var totalCustomers = await context.Customers.CountAsync();
            var totalCustomersWithOrders = await context.Customers.Where(x=>x.Orders.Any()).CountAsync();
            var totalCustomersWithoutOrders = await context.Customers.Where(x => !x.Orders.Any()).CountAsync();

            if (totalCustomers / 4 < totalCustomersWithOrders)
            {
                return;
            }

            var custumerIds = await context.Customers.Select(x => x.CustomerID).ToListAsync();

            int saveCounter = 0;
            foreach (var customerID in custumerIds)
            {
                var customer = await context.Customers.Where(x => x.CustomerID == customerID).SingleOrDefaultAsync();

                if (chance.Bool())
                {
                    int productCount = chance.Integer(1, 4);
                    var date = chance.Date(0, 0, 0, customer.RegistrationDate.Year + 1, 2019);
                    var confirmed = chance.Bool();
                    var order = new Order
                    {
                        RegistrationDate = date,
                        ConfirmationDate = confirmed ? date : default(DateTime?),
                        CancellationDate = !confirmed ? date : default(DateTime?),
                        OrderedProducts = new List<OrderedProduct>()
                    };
                    for (int i = 0; i < productCount; i++)
                    {
                        var productMaxID = context.Products.Max(x => x.ProductID);
                        var productID = chance.Integer(1, productMaxID);
                        var product = await context.Products.SingleOrDefaultAsync(x => x.ProductID == productID);

                        while (product == null)
                        {
                            productID = chance.Integer(1, productMaxID);
                            product = await context.Products.SingleOrDefaultAsync(x => x.ProductID == productID);
                        }

                        var orderedProduct = new OrderedProduct
                        {
                            Amount = chance.Integer(1, 4),
                            Value = product.Value,
                            ProductID = product.ProductID,
                            RegistrationDate = date
                        };

                        order.OrderedProducts.Add(orderedProduct);
                    }
                    if (customer.Orders == null)
                    {
                        customer.Orders = new List<Order>();
                    }
                    customer.Orders.Add(order);
                    saveCounter++;
                }

                if (saveCounter >= 100)
                {
                    Log.Debug($"Saving {saveCounter.ToString()} orders.");
                    await context.SaveChangesAsync();
                    saveCounter = 0;
                }

                chance = chance.New();
            }

            await context.SaveChangesAsync();
        }

        private static async Task SeedCategoryAsync(IStoreContext context, int inserts)
        {
            Log.Debug($"Seed {inserts.ToString()} categories.");

            Chance chance = new Chance();
            int categoriesCount = context.Categories.Count();
            while (categoriesCount < inserts)
            {
                int saveCounter = 0;
                for (int i = categoriesCount; i < inserts; i++)
                {
                    var category = new Category
                    {
                        Name = chance.Word(0, 0, true),
                        Description = chance.Paragraph(3),
                        RootCategoryID = chance.Bool() && i > 0 ? chance.Integer(1, i) : default(int?)
                    };

                    await context.Categories.AddAsync(category);
                    saveCounter++;

                    if (saveCounter == 100)
                    {
                        Log.Debug($"Saving {saveCounter.ToString()} categories.");
                        await context.SaveChangesAsync();
                        saveCounter = 0;
                    }

                    await context.SaveChangesAsync();

                    chance = chance.New();
                }
                if (saveCounter > 0)
                {
                    Log.Debug($"Saving {saveCounter.ToString()} categories.");
                    await context.SaveChangesAsync();
                }

                categoriesCount = context.Categories.Count();

                Log.Debug($"{categoriesCount.ToString()} categories already saved.");
            }

            Log.Debug("Done seed categories.");
        }

        private static async Task SeedProductsAsync(IStoreContext context, int inserts)
        {
            Log.Debug($"Seed {inserts.ToString()} products.");

            Chance chance = new Chance();
            int categoriesCount = context.Categories.Count();
            int productsCount = context.Products.Count();
            while (productsCount < inserts)
            {
                int saveCounter = 0;
                for (int i = productsCount; i < inserts; i++)
                {
                    var product = new Product
                    {
                        Name = chance.Sentence(6, 0, true, true, '.'),
                        Description = chance.Paragraph(3),
                        Specifications = chance.Paragraph(6),
                        Amount = chance.Integer(0, 500),
                        Value = Convert.ToDecimal(chance.Double(0, 250)),
                        RegistrationDate = chance.Date(0, 0, 0, 2010, 2018),
                        IsVisible = chance.Bool(),
                        CategoryID = chance.Integer(1, categoriesCount)
                    };

                    if (product.Images == null)
                    {
                        product.Images = new List<Image>();
                    }

                    for (int x = 0; x <= chance.Integer(1, 5); x++)
                    {
                        product.Images.Add(new Image { MimeType = "image/jpg", Url = "https://picsum.photos/500/500?image=" + chance.Integer(0, 1000).ToString() });
                    }

                    await context.Products.AddAsync(product);
                    saveCounter++;

                    if (saveCounter == 1000)
                    {
                        Log.Debug($"Saving {saveCounter.ToString()} products.");
                        await context.SaveChangesAsync();
                        productsCount = context.Products.Count();
                        Log.Debug($"{productsCount.ToString()} products already saved.");
                        saveCounter = 0;
                    }


                    chance = chance.New();
                }
                if (saveCounter > 0)
                {
                    Log.Debug($"Saving {saveCounter.ToString()} products.");
                    await context.SaveChangesAsync();
                }

                productsCount = context.Products.Count();
                Log.Debug($"{productsCount.ToString()} products already saved.");
            }

            Log.Debug("Done seed products.");
        }

        private static async Task SeedConstumersAsync(IStoreContext context, int inserts)
        {
            Log.Debug($"Seed {inserts.ToString()} customers.");

            Chance chance = new Chance();
            int customersCount = context.Customers.Count();
            while (customersCount < inserts)
            {
                int saveCounter = 0;
                for (int i = customersCount; i < inserts; i++)
                {
                    var customer = new Customer
                    {
                        Name = chance.FullName(),
                        Email = chance.Email(),
                        RegistrationDate = chance.Date(0, 0, 0, 2010, 2018)
                    };

                    await context.Customers.AddAsync(customer);
                    saveCounter++;
                    if (saveCounter == 100)
                    {
                        Log.Debug($"Saving {saveCounter.ToString()} customers.");
                        await context.SaveChangesAsync();
                        saveCounter = 0;
                    }

                    chance = chance.New();
                }

                if (saveCounter > 0)
                {
                    Log.Debug($"Saving {saveCounter.ToString()} customers.");
                    await context.SaveChangesAsync();
                }

                customersCount = context.Customers.Count();
                Log.Debug($"{customersCount.ToString()} customers already saved.");
            }

            Log.Debug("Done seed customers.");
        }
    }
}
