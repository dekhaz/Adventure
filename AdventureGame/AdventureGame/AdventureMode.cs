using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdventureEngine;


namespace AdventureGame
{
    public partial class AdventureMode : Form
    {

        private Player _player;
        public Dictionary<string, Consumable> ConDict;
        public Dictionary<string, Treasure> TreDict;
        public Dictionary<string, Armor> ArmDict;
        public Dictionary<string, Weapon> WeaDict;
        public Dictionary<string, Monster> MonDict;
        public Dictionary<string, Location> LocDict;
        public Dictionary<string, Feature> FeaDict;
        public Dictionary<string, Artifact> ArtDict;









        public AdventureMode()
        {
            InitializeComponent();

            _player = new Player("Nameless");

            ConDict.Add("p", new Consumable("Health Potion", ));
            TreDict.Add("g",new Treasure());
            ArmDict.Add("a", new Armor());
            WeaDict.Add("w", new Weapon());
            MonDict.Add("m", new Monster());
            LocDict.Add("l", new Location(0,0,0,"",""));
            FeaDict.Add("f", new Feature("",""));
            ArtDict.Add("t", new Artifact());
            







        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AdventureMode_Load(object sender, EventArgs e)
        {

        }
    }
}
