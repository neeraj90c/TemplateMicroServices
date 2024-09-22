using AuthenticationService.Extentions;
using AuthenticationService.Interface;
using AuthenticationService.Service;
using Microsoft.Extensions.FileProviders;
using Common.Interface;
using Common.Service;
using IJwtToken = Common.Interface.IJwtToken;
using JwtAuthenticationManager;

namespace AuthenticationService
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
                    builder.WithOrigins("http://localhost:53135",
                                        "http://localhost:4200",
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
            services.AddTransient<IUserContract, UserService>();
            services.AddTransient<IUserMaster, UserService>();
            services.AddTransient<IEncryptDecrypt, EncryptDecryptService>();
            services.AddTransient<IJwtToken, JWTToken>();

            services.AddSingleton<JwtTokenHandler>();

            //For Directory Browsing, comment out for Prod Release
            services.AddDirectoryBrowser();
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
