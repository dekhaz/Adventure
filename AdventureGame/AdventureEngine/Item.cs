using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Item
    {
        //properties
        public Slot slot;
        public string Name;
        public int Quantity;
        public bool Usable;
        public Effect Potency;
        public Spirit Enchantment;
        public Realm Style;
        public DefensiveQualities defenses;
        public OffensiveQualities offenses;

        public virtual OffensiveQualities GetOffenses()
        {
            return offenses;
        }

        public virtual void SetOffenses(OffensiveQualities value)
        {
            offenses = value;
        }

        public virtual DefensiveQualities GetDefensiveTraits()
        {
            return defenses;
        }

        public virtual void SetDefenses(DefensiveQualities value)
        {
            defenses = value;
        }


        //constructors

            //the first constructor is used to create a blank object
            //this object is used to determine to NOT copy it over to inventory when overwritten by equipment
            //this uses the notEmpty() function to check.
        public Item()
        {
            this.slot = Slot.NotEquippable;
            this.Name = "Nothing";
            this.Quantity = 0;
            this.Usable = false;
            this.Potency = new Effect();
            this.Enchantment = Spirit.Corrupted;
        }




        //functions
        public Spirit GetEnchantment()
        {
            return Enchantment;
        }

        public Effect GetEffect()
        {
            return Potency;
        }


        public bool Consumable()
        {
            return this.Usable;
        }

        //refers to quantity in most instances, but in weapons and armor will measure offense and defense
        public virtual int Measure()
        {
            return this.Quantity;
        }

        //sets quantity, different methods based on item types
        public virtual void SetAmount(int amount)
        {
            this.Quantity = amount;
        }

        //how we describe it
        public virtual string Describe()
        {
            if (NotEmpty())
            {
                return this.Name + ", " + SlotCheck.SlotString(this.slot);
            }
            else
            {
                return "Nothing";
            }
        }

        //this checks for empty slot items
        public bool NotEmpty()
        {
            if ((Name != "Nothing") && (Name != null) && (Name != "Free Hand") && (Name != "Naked"))
            {
                return true;
            }
            return false;
        }









    }



}
