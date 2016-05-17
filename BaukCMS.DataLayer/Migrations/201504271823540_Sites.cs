namespace BaukCMS.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        SiteId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Domain = c.String(),
                    })
                .PrimaryKey(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sites");
        }
    }
}
