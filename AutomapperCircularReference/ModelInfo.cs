using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class ModelInfo {

        public int ModelID {
            get;
            set;
        }

        public string Logo {
            get;
            set;
        }


        public string Name {
            get;
            set;
        }

        public virtual ICollection<ModelPropertyInfo> ModelProperties {
            get;
            set;
        }

        public int BrandID {
            get;
            set;
        }

        public virtual BrandInfo Brand {
            get;
            set;
        }

        public override int GetHashCode() {
            return this.Logo.GetHashCode() ^ this.Name.GetHashCode() ^ this.ModelID.GetHashCode();
        }

        public override bool Equals(object obj) {
            if(obj == null || !(obj is ModelInfo)) return false;

            ModelInfo mi = (ModelInfo)obj;
            return (this.Name == mi.Name && this.Logo == mi.Logo && this.ModelID == mi.ModelID && this.ModelProperties == mi.ModelProperties);
        }
    }
}
