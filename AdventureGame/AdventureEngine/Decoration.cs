using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Decoration : Item
    {

        public Decoration()
        {
            Name = "Free Hand";
            slot = Slot.Misc;
            Quantity = 0;
            Usable = false;
            Potency = new Effect();
            Enchantment = Spirit.Corrupted;

        }

        public Decoration(Realm realm)
        {
            Style = realm;
        }

        public Decoration(Slot slot)
        {
            this.slot = slot;
        }

        public Decoration(Realm realm, Slot slott)
        {
            this.slot = slott;
            Style = realm;
        }


        public override int Measure()
        {
            return Quantity;
        }

        public override void SetAmount(int amount)
        {
            Quantity = amount;
        }

        public override string Describe()
        {
            if (NotEmpty())
            {
                return Name + ", " + SlotCheck.SlotString(slot);
            }
            else
            {
                return "Free Hand";
            }
        }
    }
}
