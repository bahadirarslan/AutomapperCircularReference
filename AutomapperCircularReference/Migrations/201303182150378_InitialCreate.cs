namespace AutomapperCircularReference.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        Name = c.String(),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.ModelProperties",
                c => new
                    {
                        ModelPropertyID = c.Int(nullable: false, identity: true),
                        ModelID = c.Int(nullable: false),
                        IsContainable = c.Boolean(nullable: false),
                        HasFilterDefinition = c.Boolean(nullable: false),
                        PropertyDefinitionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelPropertyID)
                .ForeignKey("dbo.Models", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("dbo.PropertyDefinitions", t => t.PropertyDefinitionID, cascadeDelete: true)
                .Index(t => t.ModelID)
                .Index(t => t.PropertyDefinitionID);
            
            CreateTable(
                "dbo.PropertyDefinitions",
                c => new
                    {
                        PropertyDefinitionID = c.Int(nullable: false, identity: true),
                        DataType = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.PropertyDefinitionID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ModelProperties", new[] { "PropertyDefinitionID" });
            DropIndex("dbo.ModelProperties", new[] { "ModelID" });
            DropIndex("dbo.Models", new[] { "BrandID" });
            DropForeignKey("dbo.ModelProperties", "PropertyDefinitionID", "dbo.PropertyDefinitions");
            DropForeignKey("dbo.ModelProperties", "ModelID", "dbo.Models");
            DropForeignKey("dbo.Models", "BrandID", "dbo.Brands");
            DropTable("dbo.PropertyDefinitions");
            DropTable("dbo.ModelProperties");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
