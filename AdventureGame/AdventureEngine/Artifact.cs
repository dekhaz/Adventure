using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdventureEngine
{
    public class Artifact : Item
    {
   
        public Artifact()
        {
            this.slot = Slot.Armor;
            this.Name = "Naked";
            this.Quantity = 0;
            this.Usable = false;
            this.Potency = new Effect();
            this.Enchantment = Spirit.Corrupted;
        }

        public Artifact(Realm realm)
        {
            this.Style = realm;
        }

        public Artifact(Slot slot)
        {
            this.slot = slot;
        }

        public Artifact(Realm realm, Slot slot)
        {
            this.slot = slot;
            this.Style = realm;
        }



        public override int Measure()
        {
            return this.Quantity;
        }

        public override void SetAmount(int amount)
        {
            this.Quantity = amount;
        }

        public override string Describe()
        {
            if (NotEmpty())
            {
                return this.Name + ", " + SlotCheck.SlotString(this.slot);
            }
            else
            {
                return "Naked";
            }
        }




    }
}



