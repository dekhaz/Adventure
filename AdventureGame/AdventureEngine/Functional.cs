using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{


    public static class SlotCheck
    {
        public static string SlotString(Slot slot)
        {
            switch (slot)
            {
                case Slot.NotEquippable:
                    return "Not Equippable";
                case Slot.TwoHands:
                    return "Two-Handed";
                case Slot.MainHand:
                    return "Main Hand";
                case Slot.OffHand:
                    return "Off Hand";
                case Slot.Headgear:
                    return "Headgear";
                case Slot.Arms:
                    return "Arms";
                case Slot.Feet:
                    return "Feet";
                case Slot.Torso:
                    return "Torso";
                case Slot.Cloak:
                    return "Cloak";
                case Slot.Belt:
                    return "Belt";
                case Slot.Misc:
                    return "Decoration";
                case Slot.Talisman:
                    return "Talisman";
                case Slot.Charm:
                    return "Charm";
                case Slot.Trinket:
                    return "Trinket";
                default:
                    return "Not Equippable";
            }
        }
     }



    
}
