using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{


    public enum Choice
    {
        OptionAttack,
        OptionDefend,
        PowerAlpha,
        PowerBeta,
        PowerDelta,
        OptionAlpha,
        OptionBeta

    }

    public static class ActionEngine
    {
        public static void SetPlayerAction(Choice ch, ref Entity play,ref Entity foe)
        {
            play.plan = ch;
            Combat.ConductRound(ref play, ref foe);
        }
    }


    public delegate void Result(ref Entity target);



}
