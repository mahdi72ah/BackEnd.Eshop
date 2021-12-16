using Angular.Eshop.Core.Services.Implementations;
using Angular.Eshop.Core.Services.Interfaces;
using Angular.Eshop.Core.Utilities.Extentions.Conection;
using Angular.Eshop.DataLayer.Entities.site.Product;
using Angular.Eshop.DataLayer.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace Angular.Eshop.webApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IHostingEnvironment hostingEnvironment { get; }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            #region Authentication

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44381",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AngularEshopJwtBearer"))
                    };
                });

            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .Build();
                });
            });

            #endregion








            services.AddSingleton<IConfiguration>( // معرفی کلاس اپ ستینگ به برنامه

                     new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile($"appsettings.json")
                     .Build()
                     );
            services.AddApplicationDbContext(Configuration);



            #region Add DbContext

            // معرفی جنریک ریپوزیتوری  در پایین منظور همون ریپوزیتوزی اصلی هستش
            #region Add DbContext 

            services.AddApplicationDbContext(Configuration);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));// معرفی جنریک ریپوزیتوری

            #endregion


            #region Application Services

            services.AddScoped<IUserService, UserService>();// حالا من توی هر کنترلری که بیام و ای یوزر سرویس رو صداش بزنم میاد و یوزر سرویس رو که در پروژه کور ایجادش کردم رو میاره برام

            #endregion

            services.AddApplicationDbContext(Configuration);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //AddScoped => اد اسکوپ به معنی این هستش که سی کانتکس برای هر یوزری که وارد سایت میشه میاد و یک کانتکس جدید که یک شمای کلی از دیتابیس من هستش رو میسازه و اینطور نیست که همه ی کاربران بیادو از یک کانتکس استفاده کنن که این اصلا عقلانی نیست

            services.AddScoped<ISliderService, SliderService>();// این میگه هر جا ای اسلایدر سرویس دیدی یه دونه اسلایدر سرویس بهش بده
            services.AddScoped<IProductService, ProductService>();
            #endregion



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Angular.Eshop.webApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("EnableCors");
            app.UseAuthentication();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Angular.Eshop.webApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });




        }
    }
}
