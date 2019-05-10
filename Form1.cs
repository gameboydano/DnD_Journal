using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DND_Journal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Game WotE = new Game("War of the Elements", "My first DND Campaign!");
            Player Leoldan = new Player(17, 12, 13, 18, 12, 8, "Leoldan", "Runeseeker", "Wolffolk", "Neutral Good");
            updateData(Leoldan);

        }

        private void updateData(Player player)
        {
            Textbox_Name.Text = player.Name;
            Textbox_Class.Text = player.Class;
            Textbox_Race.Text = player.Race;
            Combobox_Alignment.Text = player.Alignment;
            Combobox_STR.Text = player.STR.ToString();
            Combobox_DEX.Text = player.DEX.ToString();
            Combobox_CON.Text = player.CON.ToString();
            Combobox_INT.Text = player.INT.ToString();
            Combobox_WIS.Text = player.WIS.ToString();
            Combobox_CHA.Text = player.CHA.ToString();
            Label_Info.Text = player.getAllInfo();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            Player player = new Player(int.Parse(Combobox_STR.Text), int.Parse(Combobox_DEX.Text), int.Parse(Combobox_CON.Text), int.Parse(Combobox_INT.Text), int.Parse(Combobox_WIS.Text), int.Parse(Combobox_CHA.Text), Textbox_Name.Text, Textbox_Class.Text, Textbox_Race.Text, Combobox_Alignment.Text);
            Journal_Writer writer = new Journal_Writer(player);
        }

        private void Button_Load_Click(object sender, EventArgs e)
        {
            Journal_Reader reader = new Journal_Reader();
            Player player = reader.readFileCharacter();
            updateData(player);
        }
    }
}
