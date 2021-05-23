using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchedulerWebApi.Models;
using SchedulerWebApi.Models.Interfaces;
using SchedulerWebApi.Services;
using Microsoft.OpenApi.Models;

namespace SchedulerWebApi
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
            services.AddDbContextPool<SchedulerContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MysqlDatabaseConnection"))); ;

            services.AddTransient<IAccount, AccountService>();
            services.AddTransient<IDivision, DivisionService>();
            services.AddTransient<IHealtFacility, HealthFacilityService>();
            services.AddTransient<IShift, ShiftService>();
            services.AddTransient<IHistoryShift, HistoryShiftService>();
            services.AddTransient<IUser, UserService>();
            services.AddTransient<IWard, WardService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Scheduler API v1",
                    Version = "v1"
                });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Scheduler API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
