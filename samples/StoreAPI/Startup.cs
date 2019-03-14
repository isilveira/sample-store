using ChanceNET;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreAPI.Core.Application.Interfaces;
using StoreAPI.Core.Domain.Entities;
using StoreAPI.Core.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("StoreAPI");

            services.AddMediatR(assembly);

            services.AddDbContext<IStoreContext, StoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IStoreContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            SeedStoreContextAsync(context).Wait();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private async Task SeedStoreContextAsync(IStoreContext context)
        {
            await SeedCategoryAsync(context, 50);
            await SeedProductsAsync(context, 1_000);
        }

        private async Task SeedCategoryAsync(IStoreContext context, int inserts)
        {
            Chance chance = new Chance();

            while (context.Categories.Count() < inserts)
            {
                for (int i = context.Categories.Count(); i < inserts; i++)
                {
                    var category = new Category
                    {
                        Name = chance.Word(0, 0, true),
                        Description = chance.Paragraph(3),
                        RootCategoryID = chance.Bool() && i > 0 ? chance.Integer(1, i) : default(int?)
                    };

                    await context.Categories.AddAsync(category);

                    chance = chance.New();
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedProductsAsync(IStoreContext context, int inserts)
        {
            Chance chance = new Chance();

            while (context.Products.Count() < inserts)
            {
                for (int i = context.Products.Count(); i < inserts; i++)
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
                        CategoryID = chance.Integer(1, 50)
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

                    chance = chance.New();
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
