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

            modelBuilder.Entity<League>().HasData(new League { Id = "1", Name = "Bronz", Icon = "https://i.ibb.co/x2XhmKb/Badge-Bronze-Blank.png", MinPoints = 0, MaxPoints = 35 });
            modelBuilder.Entity<League>().HasData(new League { Id = "2", Name = "Argint", Icon = "https://i.ibb.co/N1WvGS7/Badge-Silver-Blank.png", MinPoints = 36, MaxPoints = 70 });
            modelBuilder.Entity<League>().HasData(new League { Id = "3", Name = "Aur", Icon = "https://i.ibb.co/ZKkccn9/Badge-Gold-Blank.png", MinPoints = 71, MaxPoints = 120 });
            modelBuilder.Entity<League>().HasData(new League { Id = "4", Name = "Safir", Icon = "https://i.ibb.co/vYB15Vr/Badge-Sapphire-Blank.png", MinPoints = 121, MaxPoints = 160 });
            modelBuilder.Entity<League>().HasData(new League { Id = "5", Name = "Rubin", Icon = "https://i.ibb.co/h1LK5dT/Badge-Ruby-Blank.png", MinPoints = 161, MaxPoints = 200 });
            modelBuilder.Entity<League>().HasData(new League { Id = "6", Name = "Ametist", Icon = "https://i.ibb.co/cLtG5RC/Badge-Amethyst-Blank.png", MinPoints = 201, MaxPoints = 250 });
            modelBuilder.Entity<League>().HasData(new League { Id = "7", Name = "Perla", Icon = "https://i.ibb.co/jMRMtRV/Badge-Pearl-Blank.png", MinPoints = 251, MaxPoints = 290 });
            modelBuilder.Entity<League>().HasData(new League { Id = "8", Name = "Obsidian", Icon = "https://i.ibb.co/kBdQq6p/Badge-Obsidian-Blank.png", MinPoints = 291, MaxPoints = 400 });
            modelBuilder.Entity<League>().HasData(new League { Id = "9", Name = "Diamant", Icon = "https://i.ibb.co/DMRB8k9/Badge-Diamond-Blank.png", MinPoints = 401, MaxPoints = 10000 });

            modelBuilder.Entity<DonationInfo>().HasData(new DonationInfo { DonationType = "DONARE_NORMALĂ", NrOfPoints = 20, NrOfPeopleHelped = 3 });
            modelBuilder.Entity<DonationInfo>().HasData(new DonationInfo { DonationType = "DONARE_SPECIALĂ", NrOfPoints = 25, NrOfPeopleHelped = 1 });
            modelBuilder.Entity<DonationInfo>().HasData(new DonationInfo { DonationType = "PLASMA_COVID", NrOfPoints = 35, NrOfPeopleHelped = 3 });

            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "1", Name = "PRIMA_DONARE", NrOfPoints = 20, Icon = "https://i.ibb.co/sR1DLrn/first-donation.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "2", Name = "DONARE_DUPĂ_MULT_TIMP", NrOfPoints = 10, Icon = "https://i.ibb.co/n0g1vd6/donation-long-time.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "3", Name = "DONARE_DUPĂ_3_LUNI", NrOfPoints = 40, Icon = "https://i.ibb.co/CzCdhfC/three-months.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "4", Name = "DONARE_DE_SĂRBĂTORI", NrOfPoints = 50, Icon = "https://i.ibb.co/qWNvzRx/holiday-donation1.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "5", Name = "DONARE_DE_PLASMĂ_COVID", NrOfPoints = 30, Icon = "https://i.ibb.co/QkPq2R9/covid-donation.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "6", Name = "PRIMA_DONARE_SPECIALĂ", NrOfPoints = 35, Icon = "https://i.ibb.co/5hrRy80/special-badge.png" });
            modelBuilder.Entity<Badge>().HasData(new Badge { Id = "7", Name = "3_DONĂRI_ÎN_9_LUNI", NrOfPoints = 60, Icon = "https://i.ibb.co/SJW0h2j/three-nine.png" });
        }
    }
}
