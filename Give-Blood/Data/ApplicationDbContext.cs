using Give_Blood.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Give_Blood.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<UserBadges> UserBadges { get; set; }
        public DbSet<DonationInfo> DonationInfo { get; set; }
    }
}
