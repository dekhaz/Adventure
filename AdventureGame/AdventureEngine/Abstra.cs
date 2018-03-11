using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureEngine
{

   


    [Flags]
    public enum Slot
    {
        NotEquippable = 0x0,

        MainHand = 0x1,
        OffHand = 0x2,
            TwoHands = 0x3,
            //this uses two hands
            //also allows checks for weapon slots

        Arms = 0x4,
        Feet = 0x8,
        Headgear = 0x10,
        Cloak = 0x20,
        Belt = 0x40,
        Torso = 0x80,
            Armor = 0xFC,
            //allows checks for armor slots
        
        Trinket = 0x100,
        Talisman = 0x200,
        Charm = 0x400,
            Misc = 0x700
            //allows to be equipped in trinket, talisman, and charm,
            //allows checks for misc slots
    }



   


    //flags realm and spirit and damage line up by bit power;
    /*
        x80     x40     x20     x10     x8      x4      x2      x1      
        nemesis stellar occult  primal  anachro industr esotery mortal
        ether   pelagic boreal  blood   turbul  geotic  kindled resilient
        astral  crush   freeze  sever   force   impact  burn    melee

    as do gestures, components, and implements
        emote   relax   point   snarl   rise    squat   lift    punch
        f.dream f.ocean f.frost p.teeth f.cloud p.rock  f.oil   p.ashes
        skull   shell   cowl    blade   rod     hammer  torch   staff

    statuses line up with the damage types that are closest in association
        terror  bound   drowsy  bleed   shock   shatter burn wound


    

    these are kept separate (even though the bits line up and therefore could be used)
    solely for the interest of convenience in abstraction and in working with the variables

        i'd rather someone be able to understand the code at this point, haha

    */
    [Flags]
    public enum Realm
    {
        //this is the realm of nothing, for all shall be bound to their mortality at the least
        //that which is nothing is truly powerful and has no weakness
        Unaligned = 0x0,

        //this is the standard realm, for man and common beast
        Mortal = 0x1,

        //this is the realm of the mind, and of arcane secret, and of magical existence
        Esoteric = 0x2,

        //this is the realm of machine, detonation, gear and golem
        Industrial = 0x4,

        //this is the realm of the eldritch sciences that built the world before
        Anachronistic = 0x8,

        //this is the realm of the mightiest beast, of berserker and ancient dragon
        Primal = 0x10,

        //this is the realm of the alien and the maddened sorcerous travesties that corrupt
        Occult = 0x20,

        //this is the realm of the stars and the heavens, of space and of planets
        Stellar = 0x40,

        //this is the realm of fate, of the gods, of destiny and damnation
        Nemesis = 0x80
    }


    [Flags]
    public enum Spirit
    {
        //this is representative of the total loss of spirit
        //this is the static we are consumed by when self nullifies
        Corrupted = 0x0,

        //this is the will to survive that keeps us going
        //this is the spirit of life, and the continuation of the endless cycles
        //this is the hope that there is meaning in the face of entropy
            //this is awareness of the totality of self
            //this is the strength to own consequence
            //this is the power to actualize self
        Resilient = 0x1,

        //this is the spirit of hope and the light that wards the darkness
        //this is the reason that we band together at hearth and home
        //this is the spirit that will hold itself up to the darkness
            //to find truth, and to defy fate
            //this is the awareness of the other and the effect of choice
            //this is the power to offer sanctuary and the power to destroy
            //this is the quest to learn, the drive to see other as self
        Kindled = 0x2,

        //this is the mountain, the world, the spirit of majesty and awe of creation
        //this is the spirit of sisyphus at the top of the hill, overcoming pettiness
        //this is the spirit of sisyphus at the bottom of the hill, setting himself to his rock
            //this is the mountain shattered, stone by stone
            //this is the empire built, brick by brick
            //this is the act of controlling our world through creation and construction
            //this is the chain, and the steel that breaks it
        Geotic = 0x4,

        //this is the shifting winds, the sky, the desire for change that upheaves empires
        //this is the light of the dawn, and the light of the stars
            //this is the dream that we may fly
            //this is the power to shatter our limitations
            //this is the power to believe that we can rise above what we know
            //this is the hope for change
            //this is the feeling of being watched when we are alone under stars
        Turbulent = 0x8,

        //this is the need to feed, the hunger that keeps us striving for more,
        //this is the spirit of emotion, rage, fear, love
            //this is the courage that lets us face our fears
            //this is the need to face them, or flee them
            //this is greed and empathy for those who suffer without
            //this is the pangs of hunger that keep us hunting
            //this is the curse of mortality, of blood, of hunger and disease
        Sanguine = 0x10,

        //this is the spirit of logic without empathy, process without reason
        //this is the cold void of emptiness, and the power of glacial indifference
            //this is the other, misunderstood, with motives unknown
            //these are the lies we tell ourselves to distance ourselves from blood's curse
            //this is justice, and injustice, but always the power of consequence and strength
            //this is knowledge that distance exists, and of the indifference of the void
        Boreal = 0x20,

        //this is the sea, the life it grants, the life it takes
        //this is the spirit of dreams of elsewhere, of new worlds and different situations
            //this is the hope that an other may exist, that the self may grow
            //this is the power to find life in the crushing depths
            //this is the abberant form we fear in ourselves
            //this is the always unseen, and quickly forgotten
            //this is the hope for light when we surround ourselves in shadows
        Pelagic = 0x40,

        //this is the spirit of the unknown but felt, the spark that causes self to exist
        //this is the divinity we all hold but lose sight of while bound to the mortal realm
            //this is the shadow of ourselves that we forget
            //this is our divinity that we deny
            //this is the dream that we may remember
        Ethereal = 0x80
    }






    [Flags]
    public enum Damage
    {
        //typeless damage is to be avoided
        Death = 0x0,

        //the realm of mortal effort and of resilient spirit
        //this encompasses any unmodified melee
        //this damage type holds the least threat in terms of applied statuses
        //however, this damage type is the least resistable
        //none are immune to the struggle for survival
        Melee = 0x1,

        //the realm of esoteric secret and of the kindled spirit of warded flames
        //burn damage causes severe damage but sears closed severed wounds
        //attacks that favor burn damage will apply the ignited status
        //attacks that have secondary burn damage will increase their continual effect
        Burn = 0x2,

        //the realm of industrial armament and of the geotic spirit of the 
        //impact pierces through armor to make lethal strikes
        //attacks that favor impact damage will ignore defenses, and stumble defenders
        //attacks that have secondary impact damage will increase their ability to ovecome defense
        Impact = 0x4,

        //the realm of anachronistic tech and of the turbulent spirit of the endless storm
        //force overwhelms molecularly, bashing and disintegrating the target
        //attacks that favor force damage will inflict multiplied wounds when not resisted
        //attacks that include secondary force damage will have their wounds increased
        Force = 0x8,

        //the realm of primal rage and of the sanguine spirit of the sealed self
        //sever damage is dealt both by monster's claw and by augmented blade, and causes bloodloss
        //attacks that favor sever damage will cause death checks when they apply wounds
        //attacks that include sever damage will cause severe pain
        Sever = 0x10,

        //the realm of occult voids and of the boreal spirit of the frozen wastes
        //freeze damage causes massive damage to organics, and includes chilling necrosis
        //attacks that favor freeze damage will harry foes and drowse them as the chill passes through
        //attacks that include freeze damage will also harm energy levels
        Freeze = 0x20,

        //the realm of stellar might and of the pelagic spirits of the depths
        //crushing damage is done with gravitic field and with pressure blasts, and stuns foes
        //attacks that favor crush damage will stumble foes and add wounds equal to damage taken
        //attacks that include crush damage will gain a bonus wound against the wounded
        Crush = 0x40,

        //the realm of fated nemesis and of the ethereal spirits that surround
        //astral damage encompasses psychic assault as well as dimensional and existential energies
        //attacks that favor astral damage will annihilate the mind, draining energy as they wound
        //astral damage taken without energy to lose will slay the foe
        //attacks that include astral damage will inflict fear and pain but deal less wounds.
        Astral = 0x80
    }


    [Flags]
    public enum Gestu
    {
        //this implies no gesture 
        Still = 0x0,

        //the gesture of defiance
        //mortal resilience in the face of foes
        //strike out in melee with a fist
        HandFist = 0x1,

        //lift your implement high
        //esoteric warmth casting kindled light
        //burn away the shadows
        HandLift = 0x2,

        //lower yourself to channel power
        //find the strength of geotic power and industry
        //every impact chips away the mountain and builds an empire, piece by piece
        BodySquat = 0x4,

        //embrace the skies and leave the ground
        //hover with anachronistic tech and turbulent powers
        //lash out with energetic forces
        BodyRiser = 0x8,

        //bear your fangs and growl at your foes with a mighty roar
        //channel your primal and sanguine fury
        //sever the bonds of your foes, and the bonds of their flesh
        FaceSnarl = 0x10,

        //point at your foe
        //single them out with ice cold impunity and occult significance
        //let the occult difference between self and other be known
        HandPoint = 0x20,

        //be moved by the forces that surround
        //succumb to and be filled with crushing pelagic forces
        //let the stellar bodies guide you and know the celestial
        BodyRelax = 0x40,

        //reveal the inner self in expression
        //channel the ethereal and fated powers that are unseen beyond the physical
        //allow yourself to feel your fate and know nemesis
        FaceEmote = 0x80

    }


    //spell components are inventory items that allow spells to be performed.
    //a component is required for each step in the spell sequence;
    //pouches of ash, dream dust, teeth, and rocks are all reusable; the pouch is not consumed upon usage
    //the number of times they may be used in a single spell is limited to the number of relevant pouches.
    //pouches are rarer, and each acquired allows greater magic at all times/
    //flasks of oil, storms, frost, and ocean water are all consumable; 
    //they may be used in a single spell as many times as the size of their flask allows;
    //attained flasks will refill upon visiting an alchemy bench
    //flasks are enchanted to be used as spell components, and thus finding an enchanted flask is a serious boon.

    [Flags]
    public enum Compo
    {
        //this implies no component was available and your own spirit is being burnt off to empower the magic
        //this may not be selected as a step in a spell sequence.
        SpiritBurn = 0x0,

        //the ashes of the revered dead
        //empowers resilient magic
        //empowers melee and mortality
        PouchAsh = 0x1,

        //a flask of the finest oils
        //empowers kindled magic
        //empowers burn and knowledge
        FlaskOil = 0x2,

        //a pouch of shards from the heart of a mountain
        //empowers geotic magic
        //empowers industry and impact
        PouchRocks = 0x4,

        //a flask filled with clouds from the storm
        //empowers turbulent magic
        //powers anachronistic device and the forces of energies
        FlaskCloud = 0x8,


        //a bag of the teeth of predators
        //empowers primal magic
        //sever foes and feast on sanguine power
        PouchTeeth = 0x10,

        //a flask of superchill fluid
        //empowers boreal magic
        //freeze foes, show them the alien coldness of the occult
        FlaskFrost = 0x20,

        //a flask of saltwater from the seas
        //empowers pelagic magic
        //crush foes with stellar gravity and oceanic pressure
        FlaskOcean = 0x40,

        //a pouch of dream dust
        //empowers ethereal magic and reveals destiny and nemesis
        //rend the mind apart from psychic assault of astral energies
        PouchDream = 0x80
    }



    //implements are either inventory items, or wielded items.
    //having one equipped will allows its combination into spell rituals if it is equippable
    //non equippable implements (i.e., artifacts) always provide their bonus.
    //multiple present implements will all add their effects

    //staff, torch, hammer, rod, and blade all may be gained from currently equipped items
    //a staff is the lone 2handed focus, and forgoes the inclusion of any hand gestures, 
    //but may also be used as a rod even if it is not a metal staff

    //torches, hammer, rods, and blades are all implements provided from weapons
    //these may also be gained from certain artifact tools.


    //using gestures that are blocked or components that are missing will cause spells to change in various ways
    //they may cause a new spell effect, or fail spectacularly.
    //in the case of blocked gestures
    /*
        blocked hand gestures all become lift, as it is an arm motion and does not require fingers
        blocked body gestures all become relax, as that is the only action left that empowers magic
        blocked face gestures have their own rules, 
            face emote becomes body relax,
            face snarl becomes hand lift.

    */

    [Flags]
    public enum Imple
    {
        //you are wielding no spellcasting implement nor fetish for occult ritual
        None = 0x0,

        //a tool to grasp to remember the focus of self upon the other
        //you have a tool, and this allows you to extend effort past self
        Staff = 0x1,

        //provide light and warmth and guide the way to progress
        //you have a beacon, that may be used to shelter and to destroy
        Torch = 0x2,

        //you are wielding the implement of a builder and worker
        //wield the powers of industry and of the mountain
        Hammer = 0x4,

        //you are wielding a metallic rod that focuses the energies of turbulent anachronism
        //channel the storm and align flows of energies
        Rod = 0x8,

        //you are wielding a blade that lets you free the power of primal blood
        //spill blood to empower sanguine magic
        Blade = 0x10,

        //you have a cowl to disguise your alien presence and to control the cold
        //empowers your ability to wield boreal forces and mask oneself amongst the alien
        Cowl = 0x20,

        //this shell is still reverberant with the powers of the ocean and the stars
        //sound it as a horn and listen to its song to channel the tides
        Shell = 0x40,

        //the skull of an alien beast still harbors the ethereal powers of nemesis
        //all are fated to return to dust and ether
        Skull = 0x80
    }


}
