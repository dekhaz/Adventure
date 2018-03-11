using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Location
    {
        public string Name { get; set; }
        public Dictionary<string, Feature> dictFeat;
        //x,y,z coordinates
        public int CoX, CoY, CoZ;
        public string Description;
        public List<Entity> residents;


        public Location(int x,int y,int z,string named,string described)
        {
            CoX = x;
            CoY = y;
            CoZ = z;
            Name = named;
            Description = described;
        }


        public void AddResident(Entity resident)
        {
            residents.Add(resident);

        }

 


        public override string ToString()
        {
            StringBuilder descriptor = new StringBuilder(""+ Name + ".");
            foreach (KeyValuePair<string, Feature> feat in dictFeat)
            {
                descriptor.AppendLine("There is a " + feat.Value.ToString());
            }

            return descriptor.ToString();
        }



        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
