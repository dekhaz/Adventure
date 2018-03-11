using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Weapon : Item
    {
       
        //damage is a value that will add the ability to cause serious wounds
        //this is a very small range, from 1 - 7, with rare instances going up as high as 14
        public int Damage;
        //the more finesse and power a character has, the more this damage will do at minimum
        //the max damage is much higher, but is diminished by having more power than finesse.
            //greater finesse will allow for a much higher random range.
            //if finesse is higher than weapon damage and character power, it will allow for max damage

        public Weapon()
        {
            this.Name = "Free Hand";
            this.slot = Slot.TwoHands;
            this.Quantity = 0;
            this.Usable = false;
            this.Potency = new Effect();
            this.Enchantment = Spirit.Corrupted;
            this.Damage = 1;
            this.SetOffenses(OffensiveQualities.Strength);
        }


        public Weapon(string named, Realm styl, Spirit ench, Slot slt, OffensiveQualities off, int dam)
        {
            this.Name = named;
            this.Style = styl;
            this.Enchantment = ench;
            this.slot = slt;
            this.SetOffenses(off);
            this.SetDefenses(DefensiveQualities.Unprotected);
            this.Usable = false;
            this.Damage = dam;
        }

        public Weapon(Realm realm)
        {
            this.Style = realm;
        }

        public Weapon(Slot slot)
        {
            this.slot = slot;
        }

        public Weapon(Realm realm, Slot slot)
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
                return "Free Hand";
            }
        }

     

    }
}


