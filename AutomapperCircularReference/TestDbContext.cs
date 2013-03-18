using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class TestDbContext : DbContext {
        public TestDbContext()
            : base("Data Source=dev-sql;Initial Catalog=AutomapperTest;Persist Security Info=True;User ID=dev;Password=devPass;MultipleActiveResultSets=True") {

        }
        public DbSet<Brand> Brand {
            get;
            set;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Model>().HasMany(p => p.ModelProperties).WithRequired(s => s.Model).HasForeignKey(s => s.ModelID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Brand>().HasMany(p => p.Models).WithRequired(s => s.Brand).HasForeignKey(s => s.BrandID).WillCascadeOnDelete(false);
            modelBuilder.Entity<ModelProperty>().HasRequired(p => p.PropertyDefinition).WithMany(s => s.ModelProperties).HasForeignKey(s => s.PropertyDefinitionID).WillCascadeOnDelete(false);
            modelBuilder.Entity<ModelProperty>().HasRequired(p => p.Model).WithMany(s => s.ModelProperties).HasForeignKey(s => s.ModelID).WillCascadeOnDelete(false);
        }
    }
}
