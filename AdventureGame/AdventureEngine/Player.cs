using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Player : Entity
    {

  

        public Player(int body, int mind, int soul, int known, int skill, Realm realm, Spirit spirit) : base(body, mind, soul, known, skill, realm, spirit)
        {
            this.Body = body;
            this.Mind = mind;
            this.Soul = soul;
            this.SetWounds(0);
            this.SetScars(0);
            this.SetKnown(known);
            this.SetSkill(skill);
            this.SetRealm(realm);
            this.SetSpirit(spirit);
            this.SetLevel();
            this.LevelledStats();
            
        }

        public Player(string named) : base (named)
        {
            this.SetName(named);
            this.Body = 3;
            this.Mind = 3;
            this.Soul = 3;
            this.SetKnown(1);
            this.SetSkill(1);
            this.SetRealm(Realm.Mortal);
            this.SetSpirit(Spirit.Resilient);
            this.SetLevel();
            this.LevelledStats();
            this.inventory = new Inventory();


        }

        public Player()
        {

        }







    }
}
