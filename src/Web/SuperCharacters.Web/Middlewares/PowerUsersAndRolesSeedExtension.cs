namespace SuperCharacters.Web.Middlewares
{
    using Microsoft.AspNetCore.Builder;

    /// <summary>
    /// Extension method which provides acces to Seed Middleware.
    /// </summary>
    public static class PowerUsersAndRolesSeedExtension
    {
        public static IApplicationBuilder UsePowerUsersAndRolesSeeder(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PowerUsersAndRolesSeedMiddleware>();
        }
    }
}
