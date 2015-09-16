using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BaukCMS.DataLayer.Migrations;
using BaukCMS.Models.Models;

namespace BaukCMS.DataLayer.Context
{
    public class BaukCMSContext : DbContext
    {
        public BaukCMSContext()
        {
            Database.SetInitializer<BaukCMSContext>(null);
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<UserProperty> UserProperty { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageType> PageType { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<PageContent> PageContent { get; set; }
        public DbSet<MediaCategory> MediaCategory { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<FormCategory> FormCategory { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Error> Error { get; set; }
        public DbSet<CompanySite> CompanySite { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BaukCMSContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BaukCMSContext, Configuration>());
        }

    }
}
