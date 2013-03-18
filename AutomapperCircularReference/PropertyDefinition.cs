using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class PropertyDefinition {
        public int PropertyDefinitionID {
            get;
            set;
        }
       
        public string DataType {
            get;
            set;
        }
      
        public string Name {
            get;
            set;
        }
      
        public ICollection<ModelProperty> ModelProperties {
            get;
            set;
        }
    }
}
