using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{

    [Flags]
    public enum DefensiveQualities
    {
        //unprotected defense and the pressed status work similarly
        Unprotected = 0x0,

        //generic armors
        //light armor = padded
        //      occultist cowl = padded,blessed,warded
        //      adventurer's armor = padded,scaled,evasion
        //

        //medium armor = padded,braced
        //      cauldron battle regalia = padded,braced,insulated,warded,scaled
        //      mercenary scrapmail = padded,braced,evasion
        
        //heavy armor = padded,braced,plated
        //      steam knight armor = padded,braced,plated,insulated,blessed
        //      ancient machine = padded,braced,plated,insulated,warded,evasion
        
        //beast hide = padded,insulated,evasion
        //      abberant hide = padded,braced,insulated,warded
        //      dragon's scales = padded,braced,plated,scaled


        //player armor is replaced twice and alsoupgraded throughout, so does not have the light,medium,heavy option
        //this is because the investment in heavier would become a pointless loss upon upgrades
        
        //starting armor
        //Worn Leathers = padded,evasion
        
        //secondary replacement (may be skipped)
        //Ornate Plate = padded,braced,plated

        //final replacement
        //Ancient Chainmail = padded,braced,blessed,evasion

        //+alloyplating = +plated
        //+dragonscale  = +scaled
        //+dire fur     = +insulated
        //+eldersigil   = +warded
        //the hero's final armor adds all defensive types.


        //provided by light armor and heavier, thick garb, and heavy robes 
        //this lets a save occur for finesse to reduce damage by a wound
        //this lets a save occur for body to reduce damage by a wound
        Padded = 0x1,

        //provided by hides, medium armor and heavier, and reinforcement of lighter armors
        //this reduces damage by a wound, always
        //this is representative of armor absorbing the force of attacks
        Braced = 0x2,


        //provided by heavy armors, and patchwork armor trophies added to any garb
        //this reduces damage by a wound, unless shattered or pressed
        Plated = 0x4,

        //provided by armors that include the scales of dragonkind
        //this negates the sever and burn effects of damage
        Scaled = 0x8,

        //provided by armors that include heavy furs and thermal plastics
        //this negates the freeze effects of damage
        Insulated = 0x10,

        //provided by enchantment and by advanced alloys that are super resistant to energies
        //this negates force and crush effects of damage
        //the magic of this warding will absorb some wounds
        Warded = 0x20,

        //provided by the grace of the spirits or the divinity of the world and the self
        //this lets a save occur for courage and empathy to avoid wounds
        Blessed = 0x40,

        //this is the graceful art of not needing armor by method of not being struck
        //this lets a save occur for perception and finesse to avoid wounds
        Evasion = 0x80

        
    }


    /*          stats!
       this.Courage = (this.Body + this.Soul) + this.GetLevel()*2;
         this.Finesse = (this.Body + this.Mind) + this.GetSkill();
         this.Power = (this.Body * 2) + this.GetLevel()*2 + (this.Soul);
         this.Guile = (this.Mind * 2) + this.GetKnown() + this.GetSkill();
         this.Magic = (this.Soul * 2) + this.GetLevel()*2 + ((this.Mind + this.Body)/2);
         this.Perception = (this.Body + this.Mind + this.Soul) + (this.GetKnown() + this.GetSkill());
     */


    //an example with 1 body, 7 mind, 7 soul, 12 known, and 9 skill
    //they are level 7 (1 + 3 (21/6 for total) + 3(double specialized knowledge, specialized skill)
    // this is a wise sorcerous graybeard or something

    //         1bo/7mi/7so, 9sk/12kn
    /*
     *
     *  Body = 1
     *  Mind = 7
     *  Soul = 7
     * 
     * Courage = 1 + 7 + 14             = 22 Courage
     * Finesse = 1 + 7 + 9              = 17 Finesse
     * Power = 2 + 14 + 7               = 23 Power
     * Guile = 14 + 12 + 9              = 35 Guile
     * Magic = 14 + 14 + 4              = 32 Magic
     * Perception = 1 + 7 + 7 + 12 + 9  = 36 Perception
    */

    //next we have an upstart young hero, strong yet untested
    //and with 5 body, 4 mind, and 3 soul, and 3 known and 6 skill
    // they are level 3, 1 from 6 skill, 1 from default, 1 from total exp

    //         5bo/4mi/3so, 6sk/3kn
    /*
     *
     * Body = 5
     * Mind = 4
     * Soul = 3
     * 
     * Courage = 5 + 3 + 6      = 14 courage
     * Finesse = 5 + 4 + 6      = 15 finesse
     * Power = 10 + 6 + 3       = 19 power
     * Guile = 8 + 9            = 17 guile
     * Magic = 6 + 6 + 4        = 16 magic
     * Perception = 12 + 9      = 21 perception
     * 
     * 
    */

    //and here we have the decrepit soul at the bottom of all rankings.
    //example with 1/1/1 for stats, 1/1 experience (level 1)
    /*
     * Body = 1 
     * Mind = 1
     * Soul = 1
     * 
     * Courage = 1 + 1 + 2          = 4 courage
     * Finesse = 1 + 1 + 1          = 3 finesse
     * Power = 2 + 2 + 1            = 5 power
     * Guile = 2 + 1 + 1            = 4 guile
     * Magic = 2 + 2 + 1            = 5 magic
     * Perception = 3 + 2           = 5 perception
     * 
     * 
    */

    //even with the elder's diminished body, his experience and force of will overcome both foes
    //the upstart hero would think himself invincible after facing the decrepit.

    //and even this standard level 2 would have a chance against any, though at disadvantage


    // at 3/3/3 for stats, and 3/3 experience (level 2), and 3 damage weapon
    //power         =3*2 (body*2) + 2*2 (level*2) + 3 (soul)        = 13 power
    //finesse       =3 (body) + 3 (mind) + 3 (skill experience)     = 9 finesse
    //perception    =3+3+3 (body+mind+soul) + 3 (skill) + 3 (known) = 15 perception
    //courage       =3 + 3 (body+soul) + 2*2 (level*2)              = 10 courage
    //guile         =3*2 (mind*2) + 3 + 3 (both exp)                = 12 guile
    //magic         =3*2 (soul*2) + 2*2 (level*2) + 3 ((b+m)/2)     = 13 magic

    //with a 3 damage weapon and the strength of their arm:
    //      strength:   3-13 damage (0-1 wounds)
    //      iron:       25 - 75 damage (3 - 10 wounds)

    //our 1/1/1/1/1 friend with 1 damage weapon would deal
    //      strength:   1-5 damage (0 wounds)
    //      iron:       9-14 damage (1-2 wounds)


    //our wise old fool in this fray, with his mighty 7 damage weapon,
    //strength:     1-23 damage
    //iron:         47 - 81 damage
    //  (7+23+17)
    //      (7+23+17)*2 = 94  
    //              his power is higher than finesse, so
    //          94 * (17/46) = 34 + 47 = 81 damage
    // 
    // 
    //


    [Flags]
    public enum OffensiveQualities
    {
        //this is the offensive quality of those who have broken or are meek
        Feeble = 0x0,

        //you have the force of your might to deal wounds
        //this allows a damage roll of min(body),max(power)
        Strength = 0x1,

        //this allows a damage roll for the strength of your weapon,
        //with a min(weapon damage+power+finesse),

        //with finesse < power:
        // max  ((weapon damage)+(power)+(finesse))*2)*(finesse/(power*2)) + min
        //with finesse >= power:
        // max  ((weapon damage)+(power)+(finesse))*2)*((finesse*2)/power) + min


        Iron = 0x2,

        //this quality infers severring damage, and will add a bonus wound and cause bleeding
        //in addition, they add damage equal to the average of power and finesse
        Edged = 0x4,

        //this quality infers crushing damage, and may shatter or stumble the foe
        //in addition, they add damage equal to power.
        Blunt = 0x8,

        //this quality infers high kinetic force piercing impacts, and will shatter the foe
        //in addition, they add damage equal to perception.
        Ballistic = 0x10,

        //this quality is the realm of beasts and berserker,
        //brutal will lessen the amount of damage required for a wound (i.e., from 7 to 6)
        //in addition, it will add damage equal to courage.
        Brutal = 0x20,
        
        //this attack has qualities of the heatless void
        //this will add a damage roll of min(mind)max(mind+magic)
        Stellar = 0x40,

        //chaotic attacks will overwhelm a foe with energy
        //this will add a damage roll of mind(soul)max(soul+courage)
        Chaotic = 0x80,
        //flamebrand attacks will burn a foe
            FlameBrand = OffensiveQualities.Chaotic | OffensiveQualities.Edged,
        //frostbrand attacks will freeze a foe
            FrostBrand = OffensiveQualities.Stellar | OffensiveQualities.Brutal,
        //stormbrand attacks will shock a foe
            StormBrand = OffensiveQualities.Brutal | OffensiveQualities.Chaotic,
        //enchanted attacks will have force and edge, regardless of weapon.        
            Enchanted = OffensiveQualities. Edged | OffensiveQualities.Blunt

    }




    [Flags]
    public enum Status
    {
        Normal = 0x0,

        //i have been wounded. this escalates threat and diminishes effect
        Wound = 0x1,

        //i have been set aflame, or doused with caustic action
        //this wounds me as long as it persists
        Burn = 0x2,

        //my defenses or my form have been damaged
        //my ability to ward myself from harm has been greatly reduced
        Shatter = 0x4,

        //i am filled with damaging energies and searing potential
        //this causes me wounds when I take actions, but is also a tremendous source of magic
        Shock = 0x8,

        //my wounds continue to harm as my essence is spilt
        //this lessens my ability to bear my wounds
        Bleed = 0x10,

        //i am exhausted, ensorcelled, chilled, or befuddled
        //this lessens my potency in all manners and leaves me easily harmed
        Drowsy = 0x20,

        //i have been bound by a foe, be it by rope, tendril, or maw
        //this restricts my actions to struggling lest I be consumed
        Bound = 0x40,

        //i have been filled with horror, doubt, and sadness
        //hope leaves me and my spirit diminishes
        //without fear there may not be courage
        Terror = 0x80
    }

    // the tactical flag enum is used to determine how the battle is going
    //this will modify all available actions, every turn
    [Flags] public enum Tactical
    {
        Normal = 0x0,

        //this flag activates when my attack is successful
        //if this flag is active, it will upgrade into onslaught
        //if i am parried, it will end the combo instead of stumbling me
        //if my combo upgrades into an onslaught, my foe will become harried by my relentless assault
        Combo = 0x1,

        //this flag activates when I defended successfully
        //when I parry, my foe will stumble unless they are on an onslaught or midcombo
        //foe gains whiff, and potentially stumble (if they have no combo)
        //If i parry a foe that is stumbled, I will counter their attack
        Parry = 0x2,

        //I stumbled, am off balance, overextended, knocked down, or tossed about.
        //stumbling limits my ability to successfully strike out, and to parry
        //if I manage to turn this momentum around, I can carry the effort to make a power strike
        Stumble = 0x4,

        //my last action failed. I need to reassess the situation and adapt.
        //actions become careless if I press on after a whiff.
        //some advanced weapons suffer less disadvantages after a miss,
        //and some suffer this disadvantage even after success (high-recoil)
        Whiff = 0x8,

        //I am pressing my advantage, pushing forward, and have the upperhand
        //this happens when my combo continues in its success,
        //or when I take an advantage left by a foe's careless mistakes
        Onslaught = 0x10,

        //my foe attempted to harm me and I was immune to their efforts.
        //this represents the quick advantage that follows a foe's complete failure
        //some magics will grant me this advantage
        Barrier = 0x20,

        //I am harried when my foe is pressing their advantage.
        //this represents losing ground, losing morale, and the momentum building against me
        //when harried, actions take on desperation.
        //desperate actions may be risky, but may change the flow of the moment.
        //astral damage will harry my foes with illusion
        Harried = 0x40,

        //I am pressed when I have repeatedly defended and a foe keeps pressing the attack.
        //this represents my defensive abilities being worn down to fatigue and pressure
        //even a foe with nearly invulnerable defenses may be pressed into a disadvantage
        //crushing damage will easier press my foes.
        Pressed = 0x80


        


    }



    public static class Combat
    {


        public static void ConductRound(ref Entity play, ref Entity foe)
        {
            if (foe.Guile <= play.Guile)
            {
                foe.MakePlans(ref play);
                //announce their decision

                //execute player's plan
                if (play.plan.HasFlag(Choice.OptionAttack))
                {
                    Combat.ConductAttack(ref play, ref foe);
                }
                else if (play.plan.HasFlag(Choice.OptionDefend))
                {
                    //they don't need to do anything here yet, the flags are set
                }
                //just using attack for the rest for now, no other systems are up yet 
                else if (play.plan.HasFlag(Choice.PowerAlpha))
                {
                    Combat.ConductAttack(ref play, ref foe);
                }
                else if (play.plan.HasFlag(Choice.PowerBeta))
                {
                    Combat.ConductAttack(ref play, ref foe);
                }
                else if (play.plan.HasFlag(Choice.PowerDelta))
                {
                    Combat.ConductAttack(ref play, ref foe);
                }
                else if (play.plan.HasFlag(Choice.OptionAlpha))
                {
                    Combat.ConductAttack(ref play, ref foe);
                }
                else if (play.plan.HasFlag(Choice.OptionBeta))
                {
                    Combat.ConductAttack(ref play, ref foe);
                }
                else
                {
                    //they didn't decide to do anything...
                }


                //execute foe's plan
                if (foe.plan.HasFlag(Choice.OptionAttack))
                {
                    Combat.ConductAttack(ref foe, ref play);
                }
                else if (foe.plan.HasFlag(Choice.OptionDefend))
                {
                    //they don't need to do anything here yet, the flags are set
                }
                //just using attack for the rest for now, no other systems are up yet 
                else if (foe.plan.HasFlag(Choice.PowerAlpha))
                {
                    Combat.ConductAttack(ref foe, ref play);
                }
                else if (foe.plan.HasFlag(Choice.PowerBeta))
                {
                    Combat.ConductAttack(ref foe, ref play);
                }
                else if (foe.plan.HasFlag(Choice.PowerDelta))
                {
                    Combat.ConductAttack(ref foe, ref play);
                }
                else if (foe.plan.HasFlag(Choice.OptionAlpha))
                {
                    Combat.ConductAttack(ref foe, ref play);
                }
                else if (foe.plan.HasFlag(Choice.OptionBeta))
                {
                    Combat.ConductAttack(ref foe, ref play);
                } else
                {
                    //they didn't decide to do anything...
                }
            }
               



            if (foe.Guile > play.Guile)
            {

                foe.MakePlans(ref play);
                //do not announce their decision
            }

        }

        /*
        public static void AddTactic(ref Entity target, Tactical flg)
        {
            target.SetTactic(target.GetTactic() | flg);
        }

        public static void RemoveTactic(ref Entity target, Tactical flg)
        {
            target.SetTactic((target.GetTactic() & ~ flg));
        }

        public static void AddStatus(ref Entity target, Status flg)
        {
            target.SetStatus(target.GetStatus() | flg);
        }

        public static void RemoveStatus(ref Entity target, Status flg)
        {
            target.SetStatus(target.GetStatus() & ~ flg);
        }
        */

       public static void BurnThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Burn);
        }

        public static void WoundThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Wound);
        }

        public static void BindThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Bind);
        }

        public static void TireThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Drowsy);
        }

        public static void BleedThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Bleed);
        }

        public static void ScareThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Terror);
        }

        public static void ShockThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Shock);
        }

        public static void ShatterThem(ref Entity target)
        {
            target.SetStatus(target.GetStatus() | Status.Shatter);
        }


        public static void BreakDefense(ref Entity target)
        {
            //add pressed and remove barrier
            target.SetTactic((target.GetTactic() | Tactical.Pressed) & ~Tactical.Barrier);
        }

        public static void OverExtended(ref Entity target)
        {
            //downgrades advantages
            
            //if they parried and then overextended, remove the parry's benefit
            //and then be done, this is sparring!
            if (target.GetTactic().HasFlag(Tactical.Onslaught))
            {
                target.SetTactic(target.GetTactic() & ~(Tactical.Parry));
            }

            //if they are at a serious disadvantage and overextend then expose their weaknesses
            else if (target.GetTactic().HasFlag(Tactical.Stumble))
            {
                //remove barrier, add pressed, do not modify stumble.
                target.SetTactic(target.GetTactic() | Tactical.Pressed & ~ Tactical.Barrier);
            }

            //if they have an advantage, strip it and be done
            else if ((target.GetTactic().HasFlag(Tactical.Onslaught) || target.GetTactic().HasFlag(Tactical.Combo)))
            {
                target.SetTactic(target.GetTactic() & ~(Tactical.Onslaught | Tactical.Combo));
            }

            //if they already missed, make them stumble
            else if (target.GetTactic().HasFlag(Tactical.Whiff))
            {
                target.SetTactic(target.GetTactic() | Tactical.Stumble);
            }
            //otherwise just set them as having whiffed it
            else
            {
                target.SetTactic(target.GetTactic() | Tactical.Whiff);
            }
        }


 
        public static int DamageRoll(ref Entity attacker)
        {
            int damage = 0;
            int woundat = 7;
            //woundat controls how much damage is translated into a point of wounding.
            //lowering this value will greatly increase wounds occurred
            //currently brutal attacks will lower it to 6.
            //in addition flame attacks will lower it 1 further, to a low 5.
            //on the defensive roll, wounds will be multiplied out by 7
            //this would turn 60 points with woundat 6 into 70 points of woundat 7.
            //defensive rolls may change the woundat from there; 
            //heavy defenses increase it to 8 currently
            //in addition enchantment and blessings will increase it further, up to a max of 10

            //brutal vs heavy (60 damage)
            // this means 60d/w6 (10 wounds) = (10 wounds) 70d/w7 = 70d/w8 = <<8 wounds>> 

            //normal vs heavy (60 damage)
            // this would be 60d/w7 (8 wounds) = (8 wounds) 56d/w7 = 56d/w8 =  <<7 wounds>>

            //brutal vs normal (60 damage) 
            // this is 60d/w6 (10 wounds) = (10 wounds) 70d/w7 = 70d/w7 <<10 wounds>>

            //normal vs normal (60 damage)
            // this is 60d/w7 (8 wounds) = (8 wounds) 56d/w7 = 56d/w7 <<8 wounds>>

            //burning brutal strike vs normal defense (60 damage)
            // this is 60d/w5 (12 wounds) = (12 wounds) 84d/w7 = 84d/w7 <<12 wounds>>

            //burning brutal strike vs ultimate armor (60 damage)
            //this is 60d/w5 (12 wounds) = (12 wounds) 84d/w7 = 84d/w10 <<8 wounds>>

            //normal strike vs ultimate armor (60 damage)
            //this is 60d/w7 (8 wounds) = (8 wounds) 56d/w7 = 56d/w10 <<5 wounds>>

            //thus we can see shifting this has potent effect



            //do they have no way to damage?
            if (attacker.Offense.HasFlag(OffensiveQualities.Feeble))
            {
                damage += attacker.Courage;
            }
            //if not, they have a way to damage.
            else 
            {
                //do they make a strength roll?
                if (attacker.Offense.HasFlag(OffensiveQualities.Strength))
                {
                    damage += attacker.chaos.Next(attacker.Body, attacker.Power);
                }

                //do they make a weapon roll?
                if (attacker.Offense.HasFlag(OffensiveQualities.Iron))
                {
                    if (attacker.Finesse >= attacker.Power)
                    {
                        //this will result in an amplified max
                        damage += attacker.chaos.Next((attacker.Finesse + attacker.Power + attacker.Damage), (((attacker.Finesse + attacker.Power + attacker.Damage)*2) * ((attacker.Finesse*2) / attacker.Power) + (attacker.Finesse+attacker.Power+attacker.Damage)));
                    } else
                    {
                        //this will  result in a diminished max
                        damage += attacker.chaos.Next((attacker.Finesse + attacker.Power + attacker.Damage), (((attacker.Finesse + attacker.Power + attacker.Damage)*2) * (attacker.Finesse / (attacker.Power*2)) + (attacker.Finesse + attacker.Power + attacker.Damage)));
                    }
                }

                //do they have a flaming weapon?
                if (attacker.Offense.HasFlag(OffensiveQualities.FlameBrand))
                {
                    //is it also enchanted? (need blunt, edged, flame rolls)
                    if (attacker.Offense.HasFlag(OffensiveQualities.Enchanted))
                    {
                        woundat = woundat - 1;
                        damage += (attacker.Magic) + ((attacker.Power + attacker.Finesse) / 2) + attacker.Power;
                    }
                    else //otherwise, just need flame and edged rolls
                    {
                        damage += (attacker.Magic) + ((attacker.Power + attacker.Finesse) / 2);
                        woundat = woundat - 1;
                    }           
 
                } else //it isn't burning
                {
                    //is it enchanted? (blunt+edged)
                    if (attacker.Offense.HasFlag(OffensiveQualities.Enchanted))
                    {
                        //add bonus damage for magic, and bonuses from edged and blunt
                        damage += (attacker.Magic) + ((attacker.Power + attacker.Finesse) / 2) + attacker.Power;
                    }
                    //if it isn't, is it edged?
                    else if (attacker.Offense.HasFlag(OffensiveQualities.Edged))
                    {
                        damage+= (attacker.Power+attacker.Finesse)/2;
                    }
                    //if it isn't, is it blunt?
                    else if (attacker.Offense.HasFlag(OffensiveQualities.Blunt))
                    {
                        damage += (attacker.Power);
                    }
                }
                //we've now made our rolls for blunt,edged,burning,iron,strength

 

                //does the weapon have ballistic force?
                if (attacker.Offense.HasFlag(OffensiveQualities.Ballistic))
                {
                    //our perception allows us to hit harder
                    damage += attacker.Perception;
        
                }


                //is the weapon storming or frosty? (chaotic+brutal) or (stellar+brutal)?
                if ((attacker.Offense.HasFlag(OffensiveQualities.StormBrand)) || (attacker.Offense.HasFlag(OffensiveQualities.FrostBrand)))
                {
                    //add our bonuses for brutal
                    woundat = woundat - 1;
                    damage += attacker.Courage;
                    //if it is chaotic, we know it is also stormy (and brutal!)
                    if (attacker.Offense.HasFlag(OffensiveQualities.Chaotic))
                    {
                        //add our ability to control chaos as damage
                        damage += attacker.Guile;
                    }
                    //if it is stellar, we know it is also frozen (and brutal!)
                    if (attacker.Offense.HasFlag(OffensiveQualities.Stellar))
                    {
                        //add the force of our spirit to the damage
                        damage += attacker.Soul * attacker.GetLevel();
                    }
                }
                //is it not stormy or frozen, but still brutal?
                else if (attacker.Offense.HasFlag(OffensiveQualities.Brutal))
                {
                    woundat = woundat - 1;
                    damage += attacker.Courage;
                }
                //or is it not brutal, but still chaotic?
                else if (attacker.Offense.HasFlag(OffensiveQualities.Chaotic))
                {
                    damage += attacker.Guile;
                }
                //or is it none of those, but still stellar?
                else if (attacker.Offense.HasFlag(OffensiveQualities.Stellar))
                {
                    damage += attacker.Soul * attacker.GetLevel();
                }
               
            }
            return (damage / woundat);
        }


        public static int DefenseRoll(int wdealt, ref Entity defender)
        {
            //here we return wounds to damage, translated by multiplying out by 7.
            //this willhave increased the damage value if damage was dealt with a lower woundat.
            int woundedat = 7;
            int ddealt = wdealt * woundedat;
            
            //is the defender defending??
            if (defender.plan.HasFlag(Choice.OptionDefend))
            {
                //you are parrying an attack!
                defender.SetTactic(defender.GetTactic() | Tactical.Parry);
                woundedat = woundedat + 3;
                //if you are being worn down
                if (defender.GetTactic().HasFlag(Tactical.Pressed))
                {
                    //you gain no bonus to wound reduction for defending
                    woundedat = woundedat - 3;
                }
                if (defender.GetTactic().HasFlag(Tactical.Harried)) 
                {
                    //your defenses are now pressed.
                    //this will undo your bonus from defending, next time 
                    defender.SetTactic(defender.GetTactic() | Tactical.Pressed);
                    
                }

                //you defended, and have the evasion quality, you will most likely dodge
                //unless that is, you have stumbled.
                if ((defender.Defense.HasFlag(DefensiveQualities.Evasion)) && !(defender.GetTactic().HasFlag(Tactical.Stumble)))
                {
                    //make a dodge roll, finesse is higher, you have dodged!
                    //you were anticipating this attack, and have a much higher chance to dodge.
                    if (defender.chaos.Next(0, 100) <= (defender.Finesse + defender.Perception) + (defender.Body * defender.GetLevel()))
                    {
                        //they whiffed it.
                        return 0;
                    }
                    //if your dodge failed, maybe you still lessened the blow, saw it coming
                    if (defender.chaos.Next(0, 100) <= defender.Perception)
                    {
                        ddealt = ddealt - (defender.Perception + defender.Finesse);
                    }
                }
            }
            else //you were not defending.
            {
                //it is slightly easier to harm you.
                woundedat = woundedat - 1;
                //if you made a mistake previously, now your defenses are faltering
                //if you have been wounded, you are now being harried, which will open you up to being knocked about
                
                //if you were defended and pressed you gain a further penalty to your defenses
                //but you are no longer going to be pressed, as you have stopped defending
                //will the risk be worth it?
                if (defender.GetTactic().HasFlag(Tactical.Pressed))
                {
                    //you gain a penalty for the desperation of this moment, 
                    //you have opened up after being beaten down
                    woundedat = woundedat - 3;
                    //this now removes the pressed disadvantage
                    defender.SetTactic(defender.GetTactic() & ~Tactical.Pressed);
                }

                //this was a serious mistake, you missed and overextended, and now have stumbled.
                //if you have been harried by attacks, this will also make you stumble
                if ((defender.GetTactic().HasFlag(Tactical.Whiff)) || (defender.GetTactic().HasFlag(Tactical.Harried)))
                {
                    //this adds stumble for you have been knocked about
                    defender.SetTactic(defender.GetTactic() | Tactical.Stumble);
                    woundedat = woundedat - 2;
                }

                //you were not defending, but do have the evasion quality.
                //this will give you a small chance to still have dodged.
                //unless you have been stumbling about.
                if ((defender.Defense.HasFlag(DefensiveQualities.Evasion)) && !(defender.GetTactic().HasFlag(Tactical.Stumble)))
                {
                    //make a dodge roll, finesse is higher, you have dodged!
                    if (defender.chaos.Next(0, 100) <= defender.Finesse)
                    {
                        //they whiffed it.
                        return 0;
                    }
                    //if your dodge failed, maybe you still lessened the blow, saw it coming
                    if (defender.chaos.Next(0, 100) <= defender.Perception)
                    {
                        ddealt = ddealt - (defender.Perception + defender.Finesse);
                        if (ddealt <= 0) { return 0; }
                    }
                }

            }
            //end of defend/nodefend block

            //if you are stumbling, we are going to remove your parry bonus now.
            if (defender.GetTactic().HasFlag(Tactical.Stumble))
            {
                defender.SetTactic(defender.GetTactic() &~ Tactical.Parry);
            }
            
            //armor check time
            //padding? if you know how to use it...
            if (defender.Defense.HasFlag(DefensiveQualities.Padded))
            {
                ddealt = ddealt - (defender.Body + defender.GetSkill());
                if (ddealt <= 0) { return 0; }
            }
            //braced? you can stand against impact!
            if (defender.Defense.HasFlag(DefensiveQualities.Braced))
            {
                ddealt = ddealt - defender.Power;
                if (ddealt <= 0) { return 0; }
            }
            //plated? this will make it much harder to wound you
            if (defender.Defense.HasFlag(DefensiveQualities.Plated))
            {
                //impenetrable! (not really)
                woundedat = woundedat + 3;
            }
            //scaled?
            if (defender.Defense.HasFlag(DefensiveQualities.Scaled))
            {
                
            }


            //insulated?
            if (defender.Defense.HasFlag(DefensiveQualities.Insulated))
            {
                //diminishes some of the force
                woundedat = woundedat + 1;

            }

            //warded? lessens damage by magic stat
            if (defender.Defense.HasFlag(DefensiveQualities.Warded))
            {
                //protects you from wounds
                ddealt = ddealt - defender.Magic;
                if (ddealt <= 0) { return 0; }
            }

            //blessed? lessens damage by courage stat, increases woundedat
            if (defender.Defense.HasFlag(DefensiveQualities.Blessed))
            {
                //protects you from wounds
                woundedat = woundedat + 1;
                ddealt = ddealt - defender.Courage;
                if (ddealt <= 0) { return 0; }
            }

            //now we math it back, before checking for wards
            int lesswounds = ddealt / woundedat;
            //warded - second bonus?
            if (defender.Defense.HasFlag(DefensiveQualities.Warded))
            {
                //we take 2/3 as many wounds from the magic of the warding
                lesswounds = lesswounds * (2 / 3);
            }
            //blessed - second bonus?
            if (defender.Defense.HasFlag(DefensiveQualities.Blessed))
            {
                //we take 2/3 as many wounds from the magic of the blesing
                lesswounds = lesswounds * (2 / 3);
            }
            if (lesswounds > 0)
            {
                //you have been wounded previously, and now have been harmed. you are being harried.
                if (defender.GetStatus().HasFlag(Status.Wound))
                {
                    defender.SetTactic(defender.GetTactic() | Tactical.Harried);
                } else { defender.SetStatus(defender.GetStatus() | Status.Wound);}
            }
            defender.WoundMe(lesswounds);

            return lesswounds;

        }




        public static void ConductAttack(ref Entity attacker, ref Entity defender)
        {
            int attackdamage = DefenseRoll(DamageRoll(ref attacker),ref defender);
            if (attackdamage <= 0)
            {
                OverExtended(ref attacker);
            }
            if (attacker.Offense.HasFlag(OffensiveQualities.FlameBrand))
            {
                if (!(defender.Defense.HasFlag(DefensiveQualities.Scaled))){
                    BurnThem(ref defender);
                }
                else
                {
                    //they were immune to an effect
                    defender.SetTactic(Tactical.Barrier);
                }
            }
            if (attacker.Offense.HasFlag(OffensiveQualities.FrostBrand))
            {
                if (!(defender.Defense.HasFlag(DefensiveQualities.Insulated)))
                {
                    TireThem(ref defender);
                }
                else
                {
                    //they were immune to an effect
                    defender.SetTactic(Tactical.Barrier);
                }
            }
            if (attacker.Offense.HasFlag(OffensiveQualities.StormBrand))
            {
                if (!(defender.Defense.HasFlag(DefensiveQualities.Warded)))
                {
                    ShockThem(ref defender);
                } else
                {
                    //they were immune to an effect
                    defender.SetTactic(Tactical.Barrier);
                }
            }
            if (((attacker.Offense.HasFlag(OffensiveQualities.Blunt)) || (attacker.Offense.HasFlag(OffensiveQualities.Ballistic))) && (defender.GetTactic().HasFlag(Tactical.Pressed)))
            {
                ShatterThem(ref defender);
            }




        }



    }
}
