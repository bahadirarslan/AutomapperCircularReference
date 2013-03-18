using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class TestDbContext : DbContext {
        public TestDbContext()
            : base("Data Source=.;Initial Catalog=AutomapperTest;Persist Security Info=True;User ID=dev;Password=123456;MultipleActiveResultSets=True") {

        }
        public DbSet<Model> Model {
            get;
            set;
        }
        public DbSet<ModelProperty> ModelProperty {
            get;
            set;
        }
        public DbSet<PropertyDefinition> PropertyDefinition {
            get;
            set;
        } 
    }
}
