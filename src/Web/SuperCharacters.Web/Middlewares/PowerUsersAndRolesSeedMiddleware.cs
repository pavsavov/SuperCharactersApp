namespace SuperCharacters.Web.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using SuperCharacters.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    public class PowerUsersAndRolesSeedMiddleware
    {
        private readonly RequestDelegate next;
        private readonly Dictionary<string, SuperCharactersUser> powerUsers = new Dictionary<string, SuperCharactersUser>()
        {
            {"Admin",new SuperCharactersUser{Email = "admin@admin.ad",PasswordHash="admin123",UserName ="Admin" } },
            {"Creator",new SuperCharactersUser{ Email="creator@creator.cr",PasswordHash="creator123",UserName = "Creator"} },
        };

        public PowerUsersAndRolesSeedMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<SuperCharactersUser>>();

            await SeedRoles(roleManager);
            await SeedUsers(userManager);

            await next(context);
        }
        private async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {

            foreach (var roleName in powerUsers.Keys)
            {
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(roleName));

                    if (!result.Succeeded)
                    {
                        ExceptionCatcher(result);
                    }
                }
            }
        }

        private async Task SeedUsers(UserManager<SuperCharactersUser> userManager)
        {

            foreach (var user in powerUsers)
            {
                if (await userManager.FindByNameAsync(user.Key) == null)
                {
                    var result = await userManager.CreateAsync(user.Value, user.Value.PasswordHash);

                    if (!result.Succeeded)
                    {
                        ExceptionCatcher(result);
                    }

                    var isAdded = await userManager.AddToRoleAsync(user.Value, user.Key);
                    if (!isAdded.Succeeded)
                    {
                        ExceptionCatcher(isAdded);
                    }
                }
            }
        }
        private void ExceptionCatcher(IdentityResult result)
        {
            throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
        }
    }
}
