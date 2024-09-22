using CompanyMaster.Extentions;
using CompanyMaster.Interface;
using CompanyMaster.Service;

namespace CompanyMaster
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "systel";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(
                                        "*.systelusa.com",
                                        "*.systelindia.com"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            services.AddServices(Configuration);
            //For Authorization
            services.AddHttpContextAccessor();

            //Common Services
            services.AddTransient<ICompanyMaster, CompanyMasterService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleWareBefore();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseRequestLogging();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseCustomExceptionHandler();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
