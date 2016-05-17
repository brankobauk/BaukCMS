using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;
using WebMatrix.WebData;

namespace BaukCMS.DataLayer.Filters
{
    public class InitializeDatabaseConnection
    {
        private readonly BaukCMSContext _baukCMSContext = new BaukCMSContext();

        public void SimpleMembershipInitializer()
        {
            Database.SetInitializer<BaukCMSContext>(null);

            try
            {
                if (!_baukCMSContext.Database.Exists())
                {
                    // Create the SimpleMembership database without Entity Framework migration schema
                    ((IObjectContextAdapter)_baukCMSContext).ObjectContext.CreateDatabase();
                    
                }

                WebSecurity.InitializeDatabaseConnection("BaukCMSContext", "UserProfiles", "UserId", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
