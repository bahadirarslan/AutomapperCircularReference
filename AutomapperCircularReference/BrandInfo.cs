using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class BrandInfo {
        public int BrandID {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public virtual IEnumerable<ModelInfo> Models {
            get;
            set;
        }
    }
}
