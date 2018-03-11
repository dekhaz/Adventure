using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Consumable : Item
    {
        public Consumable()
        {

        }

        public Consumable(string named,int potency, bool restorative, bool cureall, bool barrier, int money)
        {
            this.Usable = true;
            Name = named;
            Potency = new Effect(potency, restorative, cureall, barrier, money);
            

        }

        public override string Describe()
        {
            return base.Describe();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override DefensiveQualities GetDefensiveTraits()
        {
            return base.GetDefensiveTraits();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override OffensiveQualities GetOffenses()
        {
            return base.GetOffenses();
        }

        public override int Measure()
        {
            return base.Measure();
        }

        public override void SetAmount(int amount)
        {
            base.SetAmount(amount);
        }

        public override void SetDefenses(DefensiveQualities value)
        {
            base.SetDefenses(value);
        }

        public override void SetOffenses(OffensiveQualities value)
        {
            base.SetOffenses(value);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
