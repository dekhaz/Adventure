using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Monster : Entity
    {
        public Monster()
        {
        }

        public Monster(string named) : base(named)
        {
        }

        public Monster(int body, int mind, int soul, int known, int skill, Realm realm, Spirit spirit) : base(body, mind, soul, known, skill, realm, spirit)
        {
        }

        public override Choice AggressivePlan()
        {
            return base.AggressivePlan();
        }

        public override Choice ConservativePlan()
        {
            return base.ConservativePlan();
        }

        public override Choice DefensivePlan()
        {
            return base.DefensivePlan();
        }

        public override void Die()
        {
            base.Die();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void LevelledStats()
        {
            base.LevelledStats();
        }

        public override void MakePlans(ref Entity foe)
        {
            base.MakePlans(ref foe);
        }

        public override Choice RiskyPlan()
        {
            return base.RiskyPlan();
        }

        public override void SetLevel()
        {
            base.SetLevel();
        }

        public override Choice SpecialPlan()
        {
            return base.SpecialPlan();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void WoundMe(int wounds)
        {
            base.WoundMe(wounds);
        }
    }
}
