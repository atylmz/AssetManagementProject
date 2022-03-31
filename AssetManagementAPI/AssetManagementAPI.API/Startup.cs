using AssetManagementAPI.Bussiness.Abstract;
using AssetManagementAPI.Bussiness.Concrete;
using AssetManagementAPI.DataAccess.Abstract;
using AssetManagementAPI.DataAccess.Concrete;
using AssetManagementAPI.DataAccess.Repository.Repository;
using AssetManagementAPI.DataAccess.UnitOfWork;
using AssetManagementAPI.DtoModel.Mapping;
using AssetManagementAPI.Entity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementAPI.API
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
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AssetManagementAPI.API", Version = "v1" });
            });

           // services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(IMapProfile));


            services.AddDbContext<AssetManagementContext>(options => options.UseSqlServer("Server=DESKTOP-LN7BH6H\\SQLExpress;Database=AssetManagement;Trusted_Connection=True;"));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IBrandService), typeof(BrandManager));
            //services.AddTransient<Repository<Brand>>();
            services.AddTransient(typeof(IModelService), typeof(ModelManager));
            services.AddTransient(typeof(ITypeService), typeof(TypeManager));
            services.AddTransient(typeof(IGroupService), typeof(GroupManager));
            services.AddTransient(typeof(ICurrencyService), typeof(CurrencyManager));
            services.AddTransient(typeof(IUnitService), typeof(UnitManager));
            services.AddTransient(typeof(INewAssetService), typeof(NewAssetManager));
            services.AddTransient(typeof(IAssetService), typeof(AssetManager));
            services.AddTransient(typeof(IAssetStatusService), typeof(AssetStatusManager));
            services.AddTransient(typeof(IAssetBarcodeService), typeof(AssetBarcodeManager));
            services.AddTransient(typeof(IAssetWithoutBarcodeService), typeof(AssetWithoutBarcodeManager));
            services.AddTransient(typeof(IPriceService), typeof(PriceManager));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssetManagementAPI.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => {
                options.WithOrigins("https://localhost:44358/").AllowAnyHeader();
            });
        

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
