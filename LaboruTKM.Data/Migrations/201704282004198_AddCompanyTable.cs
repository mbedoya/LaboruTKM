namespace LaboruTKM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(nullable: false, unicode: false),
                        ContactName = c.String(unicode: false),
                        ContactEmail = c.String(nullable: false, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.company");
        }
    }
}
