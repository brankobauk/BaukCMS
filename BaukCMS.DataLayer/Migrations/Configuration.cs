using System.Data.Entity.Migrations;
using BaukCMS.DataLayer.Context;

namespace BaukCMS.DataLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BaukCMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BaukCMSContext context)
        {

        }

    }
}