using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AutomapperCircularReference {
    public static class AutomapperRegistry {
        public static void Configure() {
            Mapper.Reset();
            Mapper.Initialize(x => {
                x.AddProfile<TestProfile>();              
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
