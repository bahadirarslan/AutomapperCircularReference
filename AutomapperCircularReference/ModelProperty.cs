using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomapperCircularReference {
    public class ModelProperty {
        public int ModelPropertyID {
            get;
            set;
        }
       
        public virtual int ModelID {
            get;
            set;
        }
     
        public virtual Model Model {
            get;
            set;
        }
      
        public bool IsContainable {
            get;
            set;
        }
       
        public bool HasFilterDefinition {
            get;
            set;
        }
        public int PropertyDefinitionID {
            get;
            set;
        }
        public PropertyDefinition PropertyDefinition {
            get;
            set;
        }
        public override int GetHashCode() {
            return this.ModelPropertyID.GetHashCode() + this.ModelID.GetHashCode() ^ this.IsContainable.GetHashCode() ^ this.HasFilterDefinition.GetHashCode();
        }
        public override bool Equals(object obj) {
            if(obj == null || !(obj is ModelProperty)) return false;
            ModelProperty mpi = (ModelProperty)obj;
            return (this.ModelPropertyID == mpi.ModelPropertyID && this.ModelID == mpi.ModelID && this.IsContainable == mpi.IsContainable && this.HasFilterDefinition == mpi.HasFilterDefinition);
        }
    }
}
