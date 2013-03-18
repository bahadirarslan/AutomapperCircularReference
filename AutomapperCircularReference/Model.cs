using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class Model {

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
        public int BrandID {
            get;
            set;
        }

        public virtual Brand Brand {
            get;
            set;
        }

        public virtual ICollection<ModelProperty> ModelProperties {
            get;
            set;
        }

        public override int GetHashCode() {
            return this.Logo.GetHashCode() ^ this.Name.GetHashCode() ^ this.ModelID.GetHashCode();
        }

        public override bool Equals(object obj) {

            if(obj == null || !(obj is Model)) return false;

            Model mi = (Model)obj;
            return (this.Name == mi.Name && this.Logo == mi.Logo && this.ModelID == mi.ModelID && this.ModelProperties == mi.ModelProperties);


        }
    }
}
