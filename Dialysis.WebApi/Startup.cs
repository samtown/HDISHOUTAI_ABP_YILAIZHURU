using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Repository;
using Dialysis.Service;
using Dialysis.Service.AutoMapperConfig;
using Dialysis.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Dialysis.WebApi
{
    /// <summary>
    /// 启动
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            LogHelper.SetConfig("log4net.config");
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            DtoMapping.WebApiConfigure();

            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));

            // Add framework services.
            services.AddDbContext<DialysisContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidateModelAttribute());
                options.Filters.Add(new CustomExceptionFilterAttribute());
            }).AddJsonOptions(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Add application services.
            services.AddScoped<ShiftService>();
            services.AddScoped<ShiftRepository>();
            services.AddScoped<PatientService>();
            services.AddScoped<PatientRepository>();
            services.AddScoped<PatientContactService>();
            services.AddScoped<PatientContactRepository>();
            services.AddScoped<DoctorService>();
            services.AddScoped<DoctorRepository>();
            services.AddScoped<BloodPressureService>();
            services.AddScoped<BloodPressureRepository>();
            services.AddScoped<WeightService>();
            services.AddScoped<WeightRepository>();
            services.AddScoped<DialysisService>();
            services.AddScoped<DialysisRepository>();
            services.AddScoped<PatientEduService>();
            services.AddScoped<PatientEduRepository>();
            services.AddScoped<CourseRepository>();
            services.AddScoped<FoodNutritionService>();
            services.AddScoped<FoodNutritionRepository>();
            services.AddScoped<HandRingService>();
            services.AddScoped<HandRingRepository>();
            services.AddScoped<HospitalRepository>();
            services.AddScoped<InfomationService>();
            services.AddScoped<InfomationRepository>();
            services.AddScoped<MessageService>();
            services.AddScoped<MessageRepository>();
            services.AddScoped<SystemService>();
            services.AddScoped<SystemRepository>();
            services.AddScoped<AlarmService>();
            services.AddScoped<AlarmRepository>();
            services.AddScoped<WaterService>();
            services.AddScoped<WaterRepository>();
            services.AddScoped<BloodSugarService>();
            services.AddScoped<BloodSugarRepository>();
            services.AddScoped<OssRepository, OssRepository>();
            services.AddScoped<IUnitWork, UnitWork>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "血透标准版 API", Version = "v1" });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var webapiXmlPath = Path.Combine(basePath, "Dialysis.WebApi.xml");
                c.IncludeXmlComments(webapiXmlPath);
                var domainXmlPath = Path.Combine(basePath, "Dialysis.Dto.xml");
                c.IncludeXmlComments(domainXmlPath);
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRequestLogger();

            app.UseMvcWithDefaultRoute();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "标准版 API V1");
            });
        }
    }
}
