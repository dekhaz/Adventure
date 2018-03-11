using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Effect
    {
        int Strength;
        bool restorative;
        bool cureall;
        bool barrier;
        int Cost;

        public Effect()
        {

        }


        public Effect(int val, bool r, bool c, bool b, int money)
        {
            Strength = val;
            restorative = r;
            cureall = c;
            barrier = b;
            Cost = money;

        }

        public void ConsumeMe(ref Entity consumer)
        {
            if (restorative)
            {
                consumer.SetWounds(consumer.GetWounds() - Strength);
                if (consumer.GetWounds() < 0)
                {
                    consumer.SetWounds(0);
                    consumer.SetScars(consumer.GetScars() - Strength);
                    if (consumer.GetScars() < 0)
                    {
                        consumer.SetScars(0);
                    }
                }
                if (cureall)
                {
                    consumer.SetStatus(Status.Normal);
                }
                if (barrier)
                {
                    consumer.SetTactic(Tactical.Barrier);
                }
            }


        }
    }

}



