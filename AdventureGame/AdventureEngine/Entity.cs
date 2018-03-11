using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{

    public abstract class Entity
    {
        public Random chaos = new Random();
        private string name;
        private string title;

        public int Body;
        public int Mind;
        public int Soul;
        public int Damage;
        //ongoing holds a list of effects that will continue to happen,
        /*
         * functions added must contain 2 arguments, the effect object
         * which will hold data about the effect
         * 
         * and a reference to self provided by the bearer of the delegate.
         * 
         */

    

        //power is equal to double (body and level) + soul
        public int Power;
        
        //finesse is equal to body + mind + skill experience
        public int Finesse;
        
        //courage is body+spirit plus double level
        public int Courage;
        
        //guile is double mind, plus all experiences
        public int Guile;
        
        //perception is mind, body, and soul, plus all experiences
        public int Perception;
        
        //magic or empathy is double (soul and level) + half of (mind + body)
        public int Magic;


        public Inventory inventory = new Inventory();



        /*
          this.Courage = (this.Body + this.Soul) + this.GetLevel()*2;
            this.Finesse = (this.Body + this.Mind) + this.GetSkill();
            this.Power = (this.Body * 2) + this.GetLevel()*2 + (this.Soul);
            this.Guile = (this.Mind * 2) + this.GetKnown() + this.GetSkill();
            this.Magic = (this.Soul * 2) + this.GetLevel()*2 + ((this.Mind + this.Body)/2);
            this.Perception = (this.Body + this.Mind + this.Soul) + (this.GetKnown() + this.GetSkill());
        */


        public DefensiveQualities Defense;
        public OffensiveQualities Offense;

        public void SetDefenses()
        {
            //recheck defense
            inventory.SetDefenses();
            //apply defense
            Defense = inventory.GetDefenses();
        }


        private int level;
        private int known;
        private int skill;

        private int health;
        private int wounds;
        public int GetWounds() { return wounds; }
        public void SetWounds(int value) => wounds = value;

        private int scars;
        public int GetScars() { return scars; }
        public void SetScars(int value) => scars = value;
        

        private Realm realm;
        private Status status;
        private Spirit spirit;
        private Tactical tactic;
        public Choice plan;

        public bool Alive = true;

        public string GetName()
        {
            return name;
        }

        public void SetName(string named)
        {
            name = named;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int value) => health = value;

        public int GetLevel()
        {
            return level;
        }

        public int GetKnown()
        {
            return known;
        }

        public void SetKnown(int value) => known = value;

        public int GetSkill()
        {
            return skill;
        }

        public void SetSkill(int value) => skill = value;

        

        public Realm GetRealm()
        {
            return realm;
        }

        public void SetRealm(Realm value) => realm = value;

        

        public Status GetStatus()
        {
            return status;
        }

        public void SetStatus(Status value) => status = value;

        

        public Spirit GetSpirit()
        {
            return spirit;
        }

        public void SetSpirit(Spirit value) => spirit = value;

        public Tactical GetTactic()
        {
            return tactic;
        }

        public void SetTactic(Tactical value) => tactic = value;

        public string Alias
        {
            get
            {
                return name + ", " + title;
            }
        }



        public virtual Choice AggressivePlan()
        {
            return Choice.OptionAttack;
        }






        public virtual Choice RiskyPlan()
        {
            int decide = chaos.Next(1, 5);
            switch (decide)
            {
                case 1:
                    return Choice.OptionAttack;
                  
                case 2:
                    return Choice.OptionAttack;
                   
                case 3:
                    return Choice.OptionDefend;
                    
                default:
                    break;

            }
            return Choice.OptionAttack;
        }
        public virtual Choice ConservativePlan()
        {
            int decide = chaos.Next(1, 5);
            switch (decide)
            {
                case 1:
                    return Choice.OptionDefend;
                case 2:
                    return Choice.OptionAttack;
                case 3:
                    return Choice.OptionDefend;
                default:
                    break;
            }
            return Choice.OptionDefend;
        }



        public virtual Choice DefensivePlan()
        {
            return Choice.OptionDefend;
        }
        public virtual Choice SpecialPlan()
        {
            int decide = chaos.Next(1, 5);
            switch (decide)
            {
                case 1:
                    return Choice.PowerAlpha;
                case 2:
                    return Choice.PowerBeta;
                case 3:
                    return Choice.PowerDelta;
                default:
                    break;
            }


            return Choice.OptionDefend;
        }


        public virtual void MakePlans(ref Entity foe)
        {
            //my foe's defenses are weakened or i have an advantage
            if ((foe.GetTactic().HasFlag(Tactical.Pressed)) || (foe.GetTactic().HasFlag(Tactical.Harried)))
            {
                //i have a combo
                if ((this.GetTactic().HasFlag(Tactical.Combo)) || (this.GetTactic().HasFlag(Tactical.Onslaught)))
                {
                    //and they are immune!
                    if (foe.GetTactic().HasFlag(Tactical.Barrier))
                    {
                        //i'm going to choose a special action
                        this.plan = this.SpecialPlan();
                    }
                    //and i parried!
                    else if (this.GetTactic().HasFlag(Tactical.Parry))
                    {
                        //i'm going to choose to counterattack!
                        this.plan = this.AggressivePlan();
                    }
                    //but i am now stumbling
                    else if (this.GetTactic().HasFlag(Tactical.Stumble))
                    {
                        //i'm going to choose a risky action!
                        this.plan = this.RiskyPlan();
                    }
                    //and that's it
                    else
                    {
                        //i'm going to try to attack again!
                        this.plan = this.AggressivePlan();
                    }
                }
                //my foe is weakened, but so am I
                else if ((this.GetTactic().HasFlag(Tactical.Stumble)) || (this.GetTactic().HasFlag(Tactical.Harried)))
                {
                    //I am going to choose a risky action if i am at risk, otherwise conservative
                    if (this.GetStatus().HasFlag(Status.Wound))
                    {
                        this.plan = this.RiskyPlan();
                    } else
                    {
                        this.plan = this.ConservativePlan();
                    }
                }
                //my foe is weakened and I am normal
                else
                {
                    //i'm going to choose an aggressive action or a risky one!
                    this.plan = this.RiskyPlan();
                } 
            }
            //my foe was immune to my last attack!
            else if (foe.GetTactic().HasFlag(Tactical.Barrier))
            {
                //i'm going to choose a special action or back off
                this.plan = this.SpecialPlan();
            }
            //my foe has made a mistake!
            else if ((foe.GetTactic().HasFlag(Tactical.Stumble)) || (foe.GetTactic().HasFlag(Tactical.Whiff)))
            {
                //i'm going to choose an aggressive action
                this.plan = this.AggressivePlan();
            }

            else if ((foe.GetTactic().HasFlag(Tactical.Onslaught)) || (foe.GetTactic().HasFlag(Tactical.Combo)) || (foe.GetTactic().HasFlag(Tactical.Parry)))
            {
                //i'm going to choose a defensive action 
                this.plan = this.DefensivePlan();
            }
            else
            {
                //i'm going to choose a conservative action to gain the upper hand!
                this.plan = this.ConservativePlan();
            }

        }



      public void SetTitle()
        {
            //is body higher than mind or soul?
            if ((Body > Mind) || (Body > Soul))
            {
                // is body higher than soul but not mind?
                if (Body < Mind)
                {
                    //mind > body > soul
                    switch (level)
                    {
                        case 0:
                            //shouldn't happen
                            title = "Politician";
                            break;
                        case 1: case 2:
                            title = "Scoundrel";
                            break;
                        case 3: case 4:
                            title = "Rogue";
                            break;
                        case 5: case 6:
                            title = "Thief";
                            break;
                        case 7: case 8:
                            title = "Smuggler";
                            break;
                        case 9: case 10:
                            title = "Infiltrator";
                            break;
                        case 11: case 12:
                            title = "Shadow";
                            break;
                        default:
                            title = "Darklord";
                            break;
                    }
                }
                //is body higher than mind but not soul?
                else if (Body < Soul)
                {
                    //soul > body > mind
                    switch (level)
                    {
                        case 0:
                            //shouldn't happen
                            title = "Cultist";
                            break;
                        case 1:
                        case 2:
                            title = "Faithful";
                            break;
                        case 3:
                        case 4:
                            title = "Seeker";
                            break;
                        case 5:
                        case 6:
                            title = "Questioner";
                            break;
                        case 7:
                        case 8:
                            title = "Inquisitor";
                            break;
                        case 9:
                        case 10:
                            title = "Crusader";
                            break;
                        case 11:
                        case 12:
                            title = "Paladin";
                            break;
                        default:
                            title = "Demigod";
                            break;
                    }
                }
                //body must be the highest.
                else
                {
                    //body > mind & soul
                    switch (level)
                    {
                        case 0:
                            //shouldn't happen
                            title = "Undead Warrior";
                            break;
                        case 1:
                        case 2:
                            title = "Warrior";
                            break;
                        case 3:
                        case 4:
                            title = "Mercenary";
                            break;
                        case 5:
                        case 6:
                            title = "Skirmisher";
                            break;
                        case 7:
                        case 8:
                            title = "Berserker";
                            break;
                        case 9:
                        case 10:
                            title = "Berserker";
                            break;
                        case 11:
                        case 12:
                            title = "Berserker";
                            break;
                        default:
                            title = "Demigod";
                            break;
                    }
                }
            }
            //body is not higher than mind or soul, is mind higher than soul?
            
            else if (Mind > Soul)
            {
                //mind > soul > body
                switch (level)
                {
                    case 0:
                        //shouldn't happen
                        title = "Undead";
                        break;
                    case 1:
                    case 2:
                        title = "Scholar";
                        break;
                    case 3:
                    case 4:
                        title = "Scholar";
                        break;
                    case 5:
                    case 6:
                        title = "Scholar";
                        break;
                    case 7:
                    case 8:
                        title = "Scholar";
                        break;
                    case 9:
                    case 10:
                        title = "Scholar";
                        break;
                    case 11:
                    case 12:
                        title = "Scholar";
                        break;
                    default:
                        title = "Scholar";
                        break;
                }
            }
            else if (Soul > Mind)
            {
                //soul > mind > body
                switch (level)
                {
                    case 0:
                        //shouldn't happen
                        title = "Undead";
                        break;
                    case 1:
                    case 2:
                        title = "Ritualist";
                        break;
                    case 3:
                    case 4:
                        title = "Ritualist";
                        break;
                    case 5:
                    case 6:
                        title = "Ritualist";
                        break;
                    case 7:
                    case 8:
                        title = "Ritualist";
                        break;
                    case 9:
                    case 10:
                        title = "Ritualist";
                        break;
                    case 11:
                    case 12:
                        title = "Ritualist";
                        break;
                    default:
                        title = "Ritualist";
                        break;
                }
            }
            else
            {
                //soul = body = mind
                switch (level)
                {
                    case 0:
                        //shouldn't happen
                        title = "Undead";
                        break;
                    case 1:
                    case 2:
                        title = "Initiate";
                        break;
                    case 3:
                    case 4:
                        title = "Adept";
                        break;
                    case 5:
                    case 6:
                        title = "Professional";
                        break;
                    case 7:
                    case 8:
                        title = "Veteran";
                        break;
                    case 9:
                    case 10:
                        title = "Expert";
                        break;
                    case 11:
                    case 12:
                        title = "Lord";
                        break;
                    default:
                        title = "Demigod";
                        break;
                }
            }
        }
   

        protected Entity(int body, int mind, int soul, int known, int skill, Realm realm, Spirit spirit)
        {
            Body = body;
            Mind = mind;
            Soul = soul;
            this.SetWounds(0);
            this.SetScars(0);
            this.SetKnown(known);
            this.SetSkill(skill);
            this.SetRealm(realm);
            this.SetSpirit(spirit);
            this.SetLevel();
            this.LevelledStats();
        }

        protected Entity(string named)
        {
            this.name = named;
        }

        protected Entity()
        {

        }

        public virtual void WoundMe(int wounds)
        {
            //you have recieved a wound!

            //you are already bleeding, and you bleed a little more
            if (this.GetStatus().HasFlag(Status.Bleed))
            {
                this.SetWounds(this.GetWounds() + 1);
            }

            //now apply the wounds
            this.SetWounds(this.GetWounds() + wounds);

            if (this.GetHealth() <= this.GetWounds())
            {
                //you are bleeding, it will not scar yet
                //bloodloss intensifies the wounding (giving an extra wound)
                if (this.GetStatus().HasFlag(Status.Bleed))
                {
                    //this means that once bleeding stops, we will have several turns
                    //where we get scars (lethal wounds)
                    
                    this.SetWounds(this.GetWounds() + 1);
                } else
                {
                    //scars are not really scars.. we just are using that for fun.
                    //later we will use scars carried after a successful fight
                        //these will turn into an actual scar on a list of scars
                        //its severity will depend on the number of scars from that fight.
                        //this will just be for fluff at first
                    //we will add excess wounds over health as scars, and close a wound
                    this.SetScars(this.GetScars() + (this.GetWounds() - this.GetHealth()));
                    this.SetWounds(this.GetWounds() - 1);
                }
                if (this.GetScars() > this.GetHealth())
                {
                    //death time, you can't support this many lethal wounds
                    this.Die();
                }
            }
        }

        public virtual void Die()
        {
            this.Alive = false;   
        }


 
        public virtual void LevelledStats()
        {
            this.Courage = (this.Body + this.Soul) + this.GetLevel()*2;
            this.Finesse = (this.Body + this.Mind) + this.GetSkill();
            this.Power = (this.Body * 2) + this.GetLevel()*2 + (this.Soul);
            this.Guile = (this.Mind * 2) + this.GetKnown() + this.GetSkill();
            this.Magic = (this.Soul * 2) + this.GetLevel()*2 + ((this.Mind + this.Body)/2);
            this.Perception = (this.Body + this.Mind + this.Soul) + (this.GetKnown() + this.GetSkill());
            
            this.SetHealth((this.Body / 2) * (this.level + this.Courage));
        }
        public virtual void SetLevel()
        {
            //every six points in each knowledge and skill add a level for specialization.
            //every six points of knowledge and skill together adds a level from experience.
            //every entity gains their first level for free.

            level = ((GetKnown() / 6) + (GetSkill() / 6) + (GetKnown() + GetSkill()) / 6) + 1;

        }


    }
}
