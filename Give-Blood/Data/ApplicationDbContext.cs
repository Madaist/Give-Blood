using Give_Blood.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Give_Blood.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {

        private readonly PasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        public ApplicationDbContext(DbContextOptions options,
                                    IOptions<OperationalStoreOptions> operationalStoreOptions
                                    ) : base(options, operationalStoreOptions)
        {
            
        }


        public DbSet<Donation> Donations { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<UserBadges> UserBadges { get; set; }
        public DbSet<DonationInfo> DonationInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<League>().ToTable("Leagues");
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<Donation>().ToTable("Donations");
            modelBuilder.Entity<Badge>().ToTable("Badges");
            modelBuilder.Entity<UserBadges>().ToTable("UserBadges");
            modelBuilder.Entity<DonationInfo>().ToTable("DonationInfo");

            modelBuilder.Entity<League>().HasData(new League { Id = "1", Name = "Bronze", Icon = "https://i.ibb.co/x2XhmKb/Badge-Bronze-Blank.png", MinPoints = 0, MaxPoints = 35 });
            modelBuilder.Entity<League>().HasData(new League { Id = "2", Name = "Silver", Icon = "https://i.ibb.co/N1WvGS7/Badge-Silver-Blank.png", MinPoints = 36, MaxPoints = 70 });
            modelBuilder.Entity<League>().HasData(new League { Id = "3", Name = "Gold", Icon = "https://i.ibb.co/ZKkccn9/Badge-Gold-Blank.png", MinPoints = 71, MaxPoints = 120 });
            modelBuilder.Entity<League>().HasData(new League { Id = "4", Name = "Sapphire", Icon = "https://i.ibb.co/vYB15Vr/Badge-Sapphire-Blank.png", MinPoints = 121, MaxPoints = 160 });
            modelBuilder.Entity<League>().HasData(new League { Id = "5", Name = "Ruby", Icon = "https://i.ibb.co/h1LK5dT/Badge-Ruby-Blank.png", MinPoints = 161, MaxPoints = 200 });
            modelBuilder.Entity<League>().HasData(new League { Id = "6", Name = "Amethyst", Icon = "https://i.ibb.co/cLtG5RC/Badge-Amethyst-Blank.png", MinPoints = 201, MaxPoints = 250 });
            modelBuilder.Entity<League>().HasData(new League { Id = "7", Name = "Pearl", Icon = "https://i.ibb.co/jMRMtRV/Badge-Pearl-Blank.png", MinPoints = 251, MaxPoints = 290 });
            modelBuilder.Entity<League>().HasData(new League { Id = "8", Name = "Obsidian", Icon = "https://i.ibb.co/kBdQq6p/Badge-Obsidian-Blank.png", MinPoints = 291, MaxPoints = 400 });
            modelBuilder.Entity<League>().HasData(new League { Id = "9", Name = "Diamond", Icon = "https://i.ibb.co/DMRB8k9/Badge-Diamond-Blank.png", MinPoints = 401, MaxPoints = 10000 });

            modelBuilder.Entity<DonationInfo>().HasData(new DonationInfo { DonationType = "ORDINARY_DONATION", NrOfPoints = 20, NrOfPeopleHelped = 3 });
            modelBuilder.Entity<DonationInfo>().HasData(new DonationInfo { DonationType = "SPECIAL_DONATION", NrOfPoints = 25, NrOfPeopleHelped = 1 });
            modelBuilder.Entity<DonationInfo>().HasData(new DonationInfo { DonationType = "COVID_PLASMA", NrOfPoints = 35, NrOfPeopleHelped = 3 });

            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "1", Name = "FIRST_DONATION", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "2", Name = "DONATION_AFTER_LONG_TIME", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "3", Name = "DONATION_AFTER_3_MONTHS", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "4", Name = "HOLIDAY_DONATION", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "5", Name = "COVID_PLASMA_DONATION", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "6", Name = "FIRST_SPECIAL_DONATION", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "7", Name = "FIRST_SPECIAL_DONATION", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "8", Name = "3_DONATIONS_IN_9_MONTHS", Icon = "https://i.ibb.co/3rzcKMM/first-donation-badge.png" });
        }
    }
}
