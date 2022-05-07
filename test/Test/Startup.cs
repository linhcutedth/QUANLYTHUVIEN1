using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test
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
            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    // Đọc thông tin Authentication:Google từ appsettings.json
                    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                    // Thiết lập ClientID và ClientSecret để truy cập API google
                    googleOptions.ClientId = googleAuthNSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                    googleOptions.CallbackPath = "/dang-nhap-tu-google";
                });                // thêm provider Google và cấu hình
                /*.AddFacebook(facebookOptions => { ... });           // thêm provider Facebook và cấu hình*/

            services.AddDbContext<QLTVContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("DefaultConnection")));
            /*services.AddIdentity<AppUser, IdentityRole> ()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<LapTopContext>();
             */
               
            services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<QLTVContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages();

            services.AddDistributedMemoryCache();            // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
            services.AddSession((option) =>
            {                                                // Đăng ký dịch vụ Session
                    option.Cookie.Name = "LaptopStore";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
                    option.IdleTimeout = new TimeSpan(0, 30, 0);    // Thời gian tồn tại của Session
                });
            services.AddSession((option) =>
            {                                                // Đăng ký dịch vụ Session
                option.Cookie.Name = "LaptopStore";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
                option.IdleTimeout = new TimeSpan(0, 30, 0);    // Thời gian tồn tại của Session
            });


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;//yeu cau so 0-9
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;// co ki tu dac biet
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = true;
            });
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddOptions();                                         // Kích hoạt Options
            var mailsettings = Configuration.GetSection("MailSettings");  // đọc config
            services.Configure<MailSettings>(mailsettings);                // đăng ký để Inject
            services.AddSingleton<IEmailSender, SendMailService>();
        }
            
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=DauSach}/{action=Sach}/{id?}");

                endpoints.MapRazorPages();
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "Admin",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            /*app.UseEndpoints(endpoints =>
            {​​​
           *//* endpoints.MapAreaControllerRoute(
            name: "areas",
            areaName: "Admin",
            pattern: "Admin/{​​​controller=Home}​​​/{​​​action=Index}​​​/{​​​id?}​​​");*//*

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{​​​controller=Home}​​​/{​​​action=Index}​​​/{​​​id?}​​​");


            }​​​);*/
        }
    }
}
