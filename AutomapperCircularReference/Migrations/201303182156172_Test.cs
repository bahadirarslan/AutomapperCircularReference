namespace AutomapperCircularReference.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Models", "BrandID", "dbo.Brands");
            DropForeignKey("dbo.ModelProperties", "ModelID", "dbo.Models");
            DropForeignKey("dbo.ModelProperties", "PropertyDefinitionID", "dbo.PropertyDefinitions");
            DropIndex("dbo.Models", new[] { "BrandID" });
            DropIndex("dbo.ModelProperties", new[] { "ModelID" });
            DropIndex("dbo.ModelProperties", new[] { "PropertyDefinitionID" });
            AddForeignKey("dbo.Models", "BrandID", "dbo.Brands", "BrandID");
            AddForeignKey("dbo.ModelProperties", "PropertyDefinitionID", "dbo.PropertyDefinitions", "PropertyDefinitionID");
            AddForeignKey("dbo.ModelProperties", "ModelID", "dbo.Models", "ModelID");
            CreateIndex("dbo.Models", "BrandID");
            CreateIndex("dbo.ModelProperties", "PropertyDefinitionID");
            CreateIndex("dbo.ModelProperties", "ModelID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ModelProperties", new[] { "ModelID" });
            DropIndex("dbo.ModelProperties", new[] { "PropertyDefinitionID" });
            DropIndex("dbo.Models", new[] { "BrandID" });
            DropForeignKey("dbo.ModelProperties", "ModelID", "dbo.Models");
            DropForeignKey("dbo.ModelProperties", "PropertyDefinitionID", "dbo.PropertyDefinitions");
            DropForeignKey("dbo.Models", "BrandID", "dbo.Brands");
            CreateIndex("dbo.ModelProperties", "PropertyDefinitionID");
            CreateIndex("dbo.ModelProperties", "ModelID");
            CreateIndex("dbo.Models", "BrandID");
            AddForeignKey("dbo.ModelProperties", "PropertyDefinitionID", "dbo.PropertyDefinitions", "PropertyDefinitionID", cascadeDelete: true);
            AddForeignKey("dbo.ModelProperties", "ModelID", "dbo.Models", "ModelID", cascadeDelete: true);
            AddForeignKey("dbo.Models", "BrandID", "dbo.Brands", "BrandID", cascadeDelete: true);
        }
    }
}
