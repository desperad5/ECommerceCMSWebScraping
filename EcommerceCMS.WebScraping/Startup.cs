using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceCMS.Data;
using ECommerceCMS.Data.Abstract;
using ECommerceCMS.Data.Repositories;
using ECommerceCMS.Service;
using ECommerceCMS.Service.Abstract;
using ECommerceCMS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EcommerceCMS.WebScraping
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
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddElasticsearch(Configuration);
            services.AddDbContext<ApplicationDbContext>(options =>
                                                                    options.UseSqlServer(Configuration.GetConnectionString("SocialAuth")));
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderCartItemRepository, OrderCartItemRepository>();
            services.AddScoped<IOrderCartRepository, OrderCartRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderCartService, OrderCartService>();
            services.AddScoped<IOrderCartItemService, OrderCartItemService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IBundleRepository, BundleRepository>();
            services.AddScoped<IBundleService, BundleService>();
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IListingRepository, ListingRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
