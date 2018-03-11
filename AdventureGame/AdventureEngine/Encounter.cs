using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Encounter
    {
        private Entity foe;

        public Entity GetFoe()
        {
            return foe;
        }

        public void SetFoe(Entity value)
        {
            foe = value;
        }

        private bool victory;



        public bool CheckVictory(bool value)
        {
            if (!(GetFoe().Alive))
            {
                victory = true;
            } else
            {
                victory = false;
            }
            return victory;
        }
    }
}
