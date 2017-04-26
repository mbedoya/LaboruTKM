namespace LaboruTKM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvalutionAndTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.evaluation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Description = c.String(unicode: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.section",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false, storeType: "nvarchar"),
                        Description = c.String(unicode: false),
                        DateCreated = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SectionDTOEvaluationDTOes",
                c => new
                    {
                        SectionDTO_Id = c.Int(nullable: false),
                        EvaluationDTO_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SectionDTO_Id, t.EvaluationDTO_Id })
                .ForeignKey("dbo.section", t => t.SectionDTO_Id, cascadeDelete: true)
                .ForeignKey("dbo.evaluation", t => t.EvaluationDTO_Id, cascadeDelete: true)
                .Index(t => t.SectionDTO_Id)
                .Index(t => t.EvaluationDTO_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SectionDTOEvaluationDTOes", "EvaluationDTO_Id", "dbo.evaluation");
            DropForeignKey("dbo.SectionDTOEvaluationDTOes", "SectionDTO_Id", "dbo.section");
            DropIndex("dbo.SectionDTOEvaluationDTOes", new[] { "EvaluationDTO_Id" });
            DropIndex("dbo.SectionDTOEvaluationDTOes", new[] { "SectionDTO_Id" });
            DropTable("dbo.SectionDTOEvaluationDTOes");
            DropTable("dbo.section");
            DropTable("dbo.evaluation");
        }
    }
}
