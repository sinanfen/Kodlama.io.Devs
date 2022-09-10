using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Social> Socials { get; set; }

        //---Core.Security.Entities ---
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Developer> Developers { get; set; }



        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);//Bir programlama dilinin çok teknolojisi olabilir.
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.HasOne(p => p.ProgrammingLanguage);//Bir teknolojinin 1 ProgramlamaDili vardır. ASP.NET -> C# gibi.
            });

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.FirstName).HasColumnName("FirstName");
                a.Property(a => a.LastName).HasColumnName("LastName");
                a.Property(a => a.Email).HasColumnName("Email");
                a.Property(a => a.PasswordHash).HasColumnName("PasswordHash");
                a.Property(a => a.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(a => a.Status).HasColumnName("Status").HasDefaultValue(true);
                a.Property(a => a.AuthenticatorType).HasColumnName("AuthenticatorType");
                a.HasMany(a => a.UserOperationClaims);
                a.HasMany(a => a.RefreshTokens);
            });

            modelBuilder.Entity<Developer>(a =>
            {
                a.ToTable("Developers");
                a.HasMany(a => a.Socials);
            });

            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(a => a.Id).HasColumnName("Id");
                a.Property(a => a.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(p => p.OperationClaim);
                p.HasOne(p => p.User);
            });

            modelBuilder.Entity<Social>(p =>
            {
                p.ToTable("Socials").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.DeveloperId).HasColumnName("DeveloperId");
                p.Property(p => p.SocialUrl).HasColumnName("ProfileUrl");
                p.HasOne(p => p.Developer);
            });

            ProgrammingLanguage[] programmingLanguagesEntitySeeds = { new(1, "C#"), new(2, "Java"), new(3, "JavaScript") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesEntitySeeds);

            Technology[] technologiesEntitySeeds = { new(1, 1, "ASP.NET Core"), new(2, 2, "Spring"), new(3, 3, "React") };
            modelBuilder.Entity<Technology>().HasData(technologiesEntitySeeds);

        }
    }
}
