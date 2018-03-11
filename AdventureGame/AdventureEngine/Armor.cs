using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Armor : Item
    {
      
        public Armor()
        {
            this.slot = Slot.Armor;
            this.Name = "Naked";
            this.Quantity = 0;
            this.Usable = false;
            this.Potency = new Effect();
            this.Enchantment = Spirit.Corrupted;
            this.SetDefenses(DefensiveQualities.Unprotected);
            this.SetOffenses(OffensiveQualities.Feeble);
            this.Style = Realm.Unaligned;
        }


        public Armor(string named, Realm styl, Spirit ench, Slot slt, DefensiveQualities def)
        {
            this.Name = named;
            this.Style = styl;
            this.Enchantment = ench;
            this.slot = slt;
            this.SetDefenses(def);
            this.SetOffenses(OffensiveQualities.Feeble);

        }



        public override DefensiveQualities GetDefensiveTraits()
        {
            return base.GetDefensiveTraits();
        }

        public override OffensiveQualities GetOffenses()
        {
            return OffensiveQualities.Feeble;
        }

        public override void SetOffenses(OffensiveQualities value)
        {
            base.SetOffenses(OffensiveQualities.Feeble);
        }



        public Armor(Realm realm)
        {
            this.Style = realm;
        }

        public Armor(Slot slot)
        {
            this.slot = slot;
        }

        public Armor (Realm realm, Slot slot)
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


