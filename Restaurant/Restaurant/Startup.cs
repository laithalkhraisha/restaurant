using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using RESTAURANT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(x => x.EnableEndpointRouting = false);
            services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepositories>();
            services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
            services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
            services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
            services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
            services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
            services.AddScoped<IRepository<MasterServices>, MasterServicesRepository>();
            services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
            services.AddScoped<IRepository<MasterSocialMedia>, MasterSocialMediaRepository>();
            services.AddScoped<IRepository<MasterWorkingHours>, MasterWorkingHoursRepository>();
            services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
            services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
            services.AddScoped<IRepository<TransactionContactUs>, TransactionContactUsRepository>();
            services.AddScoped<IRepository<TransactionNewsletter>, TransactionNewsletterRepository>();
            services.AddScoped<IRepository<MasterPeople>, MasterPeopleRepository>();
            services.AddDbContext<AppDbContext>(x =>
            {

                x.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(x =>
            {
                x.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Accounts}/{action=Login}/{id?}"
                  );

                x.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
