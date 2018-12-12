namespace SuperCharacters.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.DataAccess;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SuperCharacters.Models;
    using SuperCharacters.Web.Middlewares;
    using SuperCharactersApp.Repository;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.ViewModels.DTO.CharacterViewModels;
    using SuperCharactersApp.Repository.Account.Contracts;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using SuperCharactersApp.ViewModels.DTO.SuperPowerViewModels;
    using SuperCharactersApp.Services.CRUD.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SuperCharactersAppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<SuperCharactersUser, IdentityRole>(options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequiredLength = 3;
                   options.Password.RequiredUniqueChars = 0;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
               })
                .AddDefaultTokenProviders()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<SuperCharactersAppDbContext>();

            //// Data repository
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            ////Services
            services.AddScoped<CharacterServices>();
            services.AddScoped<TeamServices>();
            services.AddScoped<SuperpowerServices>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Registration of type's assemblies in order to be mapped automatically by convention.
            AutoMapperConfig.RegisterMappings(
                typeof(CharacterViewModel).Assembly,
                typeof(CharacterCreateViewModel).Assembly,
                typeof(ListAllCharacters).Assembly,
                typeof(CreateTeamViewModel).Assembly,
                typeof(CreateSuperPowerViewModel).Assembly,
                typeof(SuperPowersListingViewModel).Assembly
                );


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // PowerUsers e.g. "Admin" and "Creator" seeded to database with their respective role.
            app.UsePowerUsersAndRolesSeeder();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
