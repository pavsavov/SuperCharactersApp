namespace SuperCharacters.DataAccess
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SuperCharacters.Models;

    public class SuperCharactersAppDbContext : IdentityDbContext<SuperCharactersUser>
    {
        public DbSet<Score> Scores { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        public DbSet<SuperCharactersUser> AppUsers { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Battle> Battles { get; set; }

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

            //Configure Discriminator using Fluent API
            builder.Entity<Character>()
                .HasDiscriminator<string>("CharacterType")
                .HasValue<SuperHero>("Superhero")
                .HasValue<SuperVillain>("Supervillain");

            builder.Entity<Team>()
                .HasMany(tm => tm.TeamMembers)
                .WithOne(t => t.Team)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Character>()
                .HasOne(si => si.SecretIdentity)
                .WithOne(c => c.Character)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Character>()
                .HasMany(sp => sp.SuperPowers)
                .WithOne(c => c.Character)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<SecretIdentity>()
                .HasOne(si => si.Character)
                .WithOne(c => c.SecretIdentity)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
