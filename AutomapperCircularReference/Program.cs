using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    class Program {
        static void Main(string[] args) {
            AutomapperRegistry.Configure();
            Database.SetInitializer(new DropCreateDatabaseAlways<TestDbContext>());
            using(TestDbContext db = new TestDbContext()) {
                db.Model.Add(new Model() {
                    ModelID = 1,
                    Name = "Test 1",
                    Logo = "logo.png"
                });

                db.Model.Add(new Model() {
                    ModelID = 2,
                    Name = "Test 2",
                    Logo = "logo.png"
                });

                db.PropertyDefinition.Add(new PropertyDefinition() {
                    PropertyDefinitionID = 1,
                    Name = "Test Definition 1"
                });

                db.PropertyDefinition.Add(new PropertyDefinition() {
                    PropertyDefinitionID = 2,
                    Name = "Test Definition 2"
                });

                db.PropertyDefinition.Add(new PropertyDefinition() {
                    PropertyDefinitionID = 3,
                    Name = "Test Definition 3"
                });

                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 1,
                    ModelID = 1,
                    PropertyDefinitionID = 1,
                    IsContainable = true,
                    HasFilterDefinition = true
                });
                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 2,
                    ModelID = 1,
                    PropertyDefinitionID = 1,
                    IsContainable = false,
                    HasFilterDefinition = true
                });
                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 3,
                    ModelID = 1,
                    PropertyDefinitionID = 2,
                    IsContainable = true,
                    HasFilterDefinition = false
                });
                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 4,
                    ModelID = 1,
                    PropertyDefinitionID = 2,
                    IsContainable = false,
                    HasFilterDefinition = false
                });

                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 5,
                    ModelID = 2,
                    PropertyDefinitionID = 3,
                    IsContainable = true,
                    HasFilterDefinition = true
                });
                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 6,
                    ModelID =2,
                    PropertyDefinitionID = 3,
                    IsContainable = false,
                    HasFilterDefinition = true
                });
                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 7,
                    ModelID = 2,
                    PropertyDefinitionID = 1,
                    IsContainable = true,
                    HasFilterDefinition = false
                });
                db.ModelProperty.Add(new ModelProperty() {
                    ModelPropertyID = 7,
                    ModelID = 2,
                    PropertyDefinitionID = 3,
                    IsContainable = false,
                    HasFilterDefinition = false
                });
                db.SaveChanges();

                IEnumerable<ModelProperty> models = db.Set<ModelProperty>().ToList();
                Console.WriteLine("{0} ModelProperties fetched from Db", models.Count());

                IEnumerable<ModelPropertyInfo> modedlInfos = Mapper.Map<IEnumerable<ModelProperty>, IEnumerable<ModelPropertyInfo>>(models);
                Console.WriteLine("{0} ModelPropertyInfo fetched from Db", modedlInfos.Count());
                Console.ReadLine();
            }
        }
    }
}
