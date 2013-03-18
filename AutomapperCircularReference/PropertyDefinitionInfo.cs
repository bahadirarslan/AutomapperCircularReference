using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class PropertyDefinitionInfo {
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

        public ICollection<ModelPropertyInfo> ModelProperties {
            get;
            set;
        }
    }
}
