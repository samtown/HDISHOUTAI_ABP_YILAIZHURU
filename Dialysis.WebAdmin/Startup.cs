using Dialysis.Common;
using Dialysis.Domain;
using Dialysis.Repository;
using Dialysis.Service;
using Dialysis.Service.AutoMapperConfig;
using Dialysis.WebAdmin.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace Dialysis.WebAdmin
{
    public class Startup
    {
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

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DtoMapping.WebAdminConfigure();

            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));

            // Add framework services.
            services.AddDbContext<DialysisContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Dialysis.WebAdmin")));

            services.AddMvc(options => options.Filters.Add(new CustomExceptionFilterAttribute()))
                .AddJsonOptions(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;

            services.AddSession(options =>
            {
                options.CookieName = "Dialysis";
            });

            // Add application services.
            //Service
            services.AddScoped<AlarmService>();
            services.AddScoped<BloodPressureService>();
            services.AddScoped<BloodSugarService>();
            services.AddScoped<CourseCategoryService>();
            services.AddScoped<CourseService>();
            services.AddScoped<DialysisService>();
            services.AddScoped<DoctorService>();
            services.AddScoped<FoodNutritionService>();
            services.AddScoped<HandRingService>();
            services.AddScoped<HospitalService>();
            services.AddScoped<InfomationService>();
            services.AddScoped<MessageService>();
            services.AddScoped<PatientContactService>();
            services.AddScoped<PatientEduService>();
            services.AddScoped<PatientService>();
            services.AddScoped<ShiftService>();
            services.AddScoped<SystemService>();
            services.AddScoped<WaterService>();
            services.AddScoped<WeightService>();
            //Repository
            services.AddScoped<AlarmRepository>();
            services.AddScoped<BloodPressureRepository>();
            services.AddScoped<BloodSugarRepository>();
            services.AddScoped<CourseRepository>();
            services.AddScoped<DialysisRepository>();
            services.AddScoped<DoctorRepository>();
            services.AddScoped<FoodNutritionRepository>();
            services.AddScoped<HandRingRepository>();
            services.AddScoped<HospitalRepository>();
            services.AddScoped<InfomationRepository>();
            services.AddScoped<MessageRepository>();
            services.AddScoped<OssRepository>();
            services.AddScoped<PatientContactRepository>();
            services.AddScoped<PatientEduRepository>();
            services.AddScoped<PatientRepository>();
            services.AddScoped<ShiftRepository>();
            services.AddScoped<SystemRepository>();
            services.AddScoped<WaterRepository>();
            services.AddScoped<WeightRepository>();

            services.AddScoped<IUnitWork, UnitWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
