// <auto-generated />
namespace AutomapperCircularReference.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class Test : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Test));
        
        string IMigrationMetadata.Id
        {
            get { return "201303182156172_Test"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
