using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{
    public class Inventory
    {
        public Dictionary<string, Item> Equipment;
        public List<Item> Stowed;
        public int FreeHands;
        public Spirit Enchantments;
        public Realm Resistances;
        public DefensiveQualities Defenses;
        public OffensiveQualities Offense;
        


        public void SetDefenses()
        {
            DefensiveQualities tempor = 0x0;
            //go through each equipped item, check enchantment flags, or them to tempor to add it together.
            foreach (KeyValuePair<string, Item> worn in Equipment)
            {
                tempor = tempor | worn.Value.GetDefensiveTraits();
            }
            //set enchantments to combined values.
            Defenses = tempor;
        }

        public void SetOffense()
        {
            OffensiveQualities tempor = 0x0;
            //go through each equipped item, check enchantment flags, or them to tempor to add it together.
            foreach (KeyValuePair<string, Item> worn in Equipment)
            {
                tempor = tempor | worn.Value.GetOffenses();
            }
            //set enchantments to combined values.
            Offense = tempor;
        }


        public DefensiveQualities GetDefenses()
        {
            return Defenses;
        }

        public void AddItem(Item added)
        {
            if ((Stowed.IndexOf(added)) >= 0)
            {
                Stowed[Stowed.IndexOf(added)].SetAmount(Stowed[Stowed.IndexOf(added)].Measure() + 1);
            }
            else
            {
                Stowed.Add(added);
            }
            
        }

        public void RemoveItem(Item remov)
        {
            Stowed.Remove(remov);
        }


        public void UseItem(ref Entity consumer, ref Consumable food)
        {
            if (RemoveQuantity(food))
            {
                food.GetEffect().ConsumeMe(ref consumer);
            }
            
        }


        public void SetEnchantments()
        {
            Spirit tempor = 0x0;
            //go through each equipped item, check enchantment flags, or them to tempor to add it together.
            foreach(KeyValuePair<string,Item> worn in Equipment)
            {
                tempor = tempor | worn.Value.GetEnchantment();
            }
            //set enchantments to combined values.
            Enchantments = tempor;
        }

        public Spirit GetEnchantments()
        {
            return Enchantments;
        }

        //generic constructor initializes empty slots
        public Inventory()
        {
            Equipment["Headgear"] = new Armor();
            Equipment["Torso"] = new Armor(); 
            Equipment["Arms"] = new Armor(); 
            Equipment["Feet"] = new Armor(); 
            Equipment["Cloak"] = new Armor(); 
            Equipment["Belt"] = new Armor(); 

            Equipment["MainHand"] = new Weapon();
            Equipment["OffHand"] = new Weapon();
            Equipment["BothHands"] = new Weapon();


            //these three are interchangeable but have different effects in how they are worn

            Equipment["Talisman"] = new Decoration();
            Equipment["Charm"] = new Decoration();
            Equipment["Trinket"] = new Decoration();



            Equipment["Artifact1"] = new Artifact();
            Equipment["Artifact2"] = new Artifact();
            Equipment["Artifact3"] = new Artifact();
            Equipment["Artifact4"] = new Artifact();
            Equipment["Artifact5"] = new Artifact();
            Equipment["Artifact6"] = new Artifact();
            Equipment["Artifact7"] = new Artifact();
            Equipment["Artifact8"] = new Artifact();


            //eight artifact slots, each for one of the defined 8
            /*  the eight artifacts
                Warrior's Harness (sets free hands to max always)

             */
        }

 

        //this will take a slot argument, and return what is there.
        //if it fails, then it returns an 'empty' item that is not equippable.
        //this uses slotcheck.slotstring to create a string for our key index list from the slot types on the item.
        public Item GetEquipped(Slot slot)
        {
            //creating our empty space object in case we need it.
            Item empty = new Item();
            //let's see if something is there, first.

            if (CheckEquipped(slot)){
                //something was there, let's try to return it.
                try
                {
                    return Equipment[SlotCheck.SlotString(slot)];
                }
                catch
                {
                    //i checked for what was equipped, and it was something, and something went wrong.
                    return empty;
                }
            }
            //this failed, so let's return our empty item.
            return empty;

        }


        //this will consume a measure of an item if it is consumable.
        public bool RemoveQuantity(Item consumed)
        {
          
                int selection = 0;
                if (Stowed.Contains<Item>(consumed))
                {
                    selection = Stowed.IndexOf(consumed);
                    Stowed[selection].SetAmount(Stowed[selection].Measure() - 1);

                    if (Stowed[selection].Measure() <= 0)
                    {
                        Stowed.RemoveAt(selection);
                    }
                    return true;
                }
                return false;
   
        
        }


        //this checks slots to see if something is equipped.
        //it will return true if the item in that slot exists and is not an empty space item. ("Nothing")
        //this is used to determine if there is something to strip before equipping
        public bool CheckEquipped(Slot slot)
        {
            try
            {
                if ((Equipment[SlotCheck.SlotString(slot)] != null) && (Equipment[SlotCheck.SlotString(slot)].NotEmpty()))
                {
                    //something is worn
                    return true;
                }
                //slot is null or 'nothing'
                return false;
            }
            catch
            {
                //this messed up. let's return false!
                return false;
            }
        }

        public bool StripGear(Slot slot)
        {
            try
            {
                Item stripped;
                if (CheckEquipped(slot))
                {
                    stripped = Equipment[SlotCheck.SlotString(slot)];
                    Stowed.Add(stripped);
                    Equipment[SlotCheck.SlotString(slot)] = new Item();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
  

        //this is how we equip things.
        //this will check to see if there is an item in a slot, and will place it in storage, and then update the equipped item.
        public bool GearSwap(Slot slot, Item newItem)
        {
            //first off, let's check to see if we need to mess with other slots, if it is a weapon.
            //we are trying to equip a two handed weapon, so remove all weapons.

            try
            {
                if (slot == Slot.TwoHands)
                {
                    if (CheckEquipped(Slot.MainHand))
                    {
                        Stowed.Add(GetEquipped(Slot.MainHand));
                        Equipment["MainHand"] = new Weapon();

                    }
                    if (CheckEquipped(Slot.OffHand))
                    {
                        Stowed.Add(GetEquipped(Slot.OffHand));
                        Equipment["OffHand"] = new Weapon();

                    }
                    if (CheckEquipped(Slot.TwoHands))
                    {
                        Stowed.Add(GetEquipped(Slot.TwoHands));
                        Equipment["BothHands"] = new Weapon();
                    }
                }
                //we are trying to equip a mainhand weapon, so replace that and remove twohanders
                else if (slot == Slot.MainHand)
                {
                    if (CheckEquipped(Slot.MainHand))
                    {
                        Stowed.Add(GetEquipped(Slot.MainHand));
                        Equipment["MainHand"] = new Weapon();

                    }
                    if (CheckEquipped(Slot.TwoHands))
                    {
                        Stowed.Add(GetEquipped(Slot.TwoHands));
                        Equipment["BothHands"] = new Weapon();
                    }
                }

                //we are trying to replace an offhand weapon, so replace that and remove twohanders
                else if (slot == Slot.OffHand)
                {
                    if (CheckEquipped(Slot.TwoHands))
                    {
                        Stowed.Add(GetEquipped(Slot.TwoHands));
                        Equipment["BothHands"] = new Weapon();
                    }
                    if (CheckEquipped(Slot.OffHand))
                    {
                        Stowed.Add(GetEquipped(Slot.OffHand));
                        Equipment["OffHand"] = new Weapon();

                    }
                }


                //check if there is something equipped still,, in case it wasn't a weapon.
                if (CheckEquipped(slot))
                {
                    //add it to storage; this only needs to happen if something is equipped and it isn't nothing.
                    Stowed.Add(GetEquipped(slot));
                    Slot checktype = (slot & Slot.Armor);
                    if (checktype > 0)
                    {
                        Equipment[SlotCheck.SlotString(slot)] = new Armor();
                    }
                    checktype = (slot & Slot.Misc);
                    if (checktype > 0)
                    {
                        Equipment[SlotCheck.SlotString(slot)] = new Decoration();
                    }
                    checktype = (slot & Slot.TwoHands);
                    if (checktype > 0)
                    {
                        Equipment[SlotCheck.SlotString(slot)] = new Weapon();
                    }

                }
                //if both hands are equipped, dual wielding or otherwise, this will be true
                if (CheckEquipped(Slot.TwoHands)) { FreeHands = 0; }
                //if only one hand is equipped, this will be true (if both were, it would be caught before)
                else if ((CheckEquipped(Slot.MainHand)) || (CheckEquipped(Slot.OffHand))) { FreeHands = 1; }
                //otherwise, hands are free.
                else { FreeHands = 2; }
                //the rest always needs to happen upon equipping to prevent duplication
                //remove new object from storage
                Stowed.Remove(newItem);
                //put new object into inventory
                Equipment[SlotCheck.SlotString(slot)] = newItem;
                //we succeeded, so yay!
                return true;
            }
            catch
            {
                //disaster! the action failed.
                return false;
            }

        }
    }






}
