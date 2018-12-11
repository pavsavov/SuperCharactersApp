namespace SuperCharacters.DataAccess
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.Models;

    public class SuperCharactersAppDbContext : IdentityDbContext<SuperCharactersUser>
    {
        //public DbSet<Score> Scores { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        public DbSet<SuperCharactersUser> AppUsers { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<Team> Teams { get; set; }

        public SuperCharactersAppDbContext()
        {

        }

        public SuperCharactersAppDbContext(DbContextOptions<SuperCharactersAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Configuring Discriminator using Fluent API
            builder.Entity<Character>()
                .HasDiscriminator<string>("CharacterType")
                .HasValue<Character>("character_base")
                .HasValue<SuperHero>("Superhero")
                .HasValue<SuperVillain>("Supervillain");


            //builder.Entity<TeamsCharacters>().HasKey(tc => new { tc.CharacterId, tc.TeamId });


        }
    }
}
