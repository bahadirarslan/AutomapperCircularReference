using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class TestProfile : Profile {
        public override string ProfileName {
            get {
                return "TestProfile";
            }
        }
        protected override void Configure() {
            Mapper.CreateMap<Model, ModelInfo>();
            Mapper.CreateMap<ModelProperty, ModelPropertyInfo>();
            Mapper.CreateMap<PropertyDefinition, PropertyDefinitionInfo>();
            Mapper.CreateMap<Brand, BrandInfo>();

            Mapper.CreateMap<ModelInfo, Model>();
            Mapper.CreateMap<PropertyDefinitionInfo, PropertyDefinition>();
            Mapper.CreateMap<ModelPropertyInfo, ModelProperty>();
            Mapper.CreateMap<BrandInfo, Brand>();
        }
    }
}
