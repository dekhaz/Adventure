using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Feature
    {
        public string Name;
        public string Description;

        //public flags for feature effects
            //need to add


        public Feature(string named, string describe)
        {
            Name = named;
            Description = describe;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Name + ", " + Description;

        }
    }
}
