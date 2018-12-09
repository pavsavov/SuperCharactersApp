namespace SuperCharacters.Web.Middlewares
{
    using Microsoft.AspNetCore.Builder;

    public static class PowerUsersAndRolesSeedExtension
    {
        public static IApplicationBuilder UsePowerUsersAndRolesSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PowerUsersAndRolesSeedMiddleware>();
        }
    }
}
