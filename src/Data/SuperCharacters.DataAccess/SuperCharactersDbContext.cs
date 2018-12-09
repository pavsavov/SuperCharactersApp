namespace SuperCharacters.Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.Models;

    public class SuperCharactersDbContext : IdentityDbContext<SuperCharacterUser>
    {
        //public DbSet<Score> Scores { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        public DbSet<SuperCharacterUser> AppUsers { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<Team> Teams { get; set; }


        public SuperCharactersDbContext(DbContextOptions<SuperCharactersDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<TeamsCharacters>().HasKey(tc => new { tc.CharacterId, tc.TeamId });


        }
    }
}
