using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DND_Journal
{
    class Game
    {
        public string GameName;
        public string Description { get; set; }

        public Game()
        {
        }

        public Game (string GN, string Desc)
        {
            this.GameName = GN;
            this.Description = Desc;
        }

        public string GetDisplayText()
        {
            return GameName + ": " + Description;
        }


    }

    class Journal_Writer
    {
        public string path;

        public Journal_Writer(Player character)
        {
            path = @"..\..\Journal.xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "   ";

            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Characters");
            xmlOut.WriteStartElement("Character");
            xmlOut.WriteAttributeString("Name", character.Name);
            xmlOut.WriteElementString("Class", character.Class);
            xmlOut.WriteElementString("Race", character.Race);
            xmlOut.WriteElementString("Alignment", character.Alignment);
            xmlOut.WriteElementString("Strength", character.STR.ToString());
            xmlOut.WriteElementString("Dexterity", character.DEX.ToString());
            xmlOut.WriteElementString("Constitution", character.CON.ToString());
            xmlOut.WriteElementString("Intelligence", character.INT.ToString());
            xmlOut.WriteElementString("Wisdom", character.WIS.ToString());
            xmlOut.WriteElementString("Charisma", character.CHA.ToString());
            xmlOut.WriteEndElement();
            xmlOut.WriteEndElement();
            xmlOut.Close();

        }



        public Journal_Writer(string p, Player character)
        {
            path = p;
        }


    }

    class Journal_Reader
    {
        public string path;

        public Journal_Reader()
        {
        }

        public Player readFileCharacter()
        {
            path = @"..\..\Journal.xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            XmlReader xmlIn = XmlReader.Create(path, settings);
            xmlIn.ReadToDescendant("Character");
            Player player = new Player();
            player.Name = xmlIn["Name"];
            xmlIn.ReadStartElement("Character");
            player.Class = xmlIn.ReadElementContentAsString();
            player.Race = xmlIn.ReadElementContentAsString();
            player.Alignment = xmlIn.ReadElementContentAsString();
            player.STR = xmlIn.ReadElementContentAsInt();
            player.DEX = xmlIn.ReadElementContentAsInt();
            player.CON = xmlIn.ReadElementContentAsInt();
            player.INT = xmlIn.ReadElementContentAsInt();
            player.WIS = xmlIn.ReadElementContentAsInt();
            player.CHA = xmlIn.ReadElementContentAsInt();
            xmlIn.Close();
            return player;
        }
    }


    class Player
    {
        public int STR;
        public int DEX;
        public int CON;
        public int INT;
        public int WIS;
        public int CHA;
        public int Max_HP;
        public int Current_HP;
        public int Temp_HP;
        public int AC;
        public int AC_No_Armour;
        public int SPD;
        public int LVL;
        public string Name;
        public string Class;
        public string Race;
        public string Alignment;
        public Boolean Pro_STR;
        public Boolean Pro_DEX;
        public Boolean Pro_CON;
        public Boolean Pro_INT;
        public Boolean Pro_WIS;
        public Boolean Pro_CHA;
        public Boolean Pro_Acrobatics;
        public Boolean Pro_Animal_Handling;
        public Boolean Pro_Arcana;
        public Boolean Pro_Athletics;
        public Boolean Pro_Deception;
        public Boolean Pro_History;
        public Boolean Pro_Insight;
        public Boolean Pro_Intimidation;
        public Boolean Pro_Investigation;
        public Boolean Pro_Medicine;
        public Boolean Pro_Nature;
        public Boolean Pro_Perception;
        public Boolean Pro_Performance;
        public Boolean Pro_Persuasion;
        public Boolean Pro_Religion;
        public Boolean Pro_Sleight_of_Hand;
        public Boolean Pro_Stealth;
        public Boolean Pro_Survival;

        public Player()
        {

        }

        public Player(int str, int dex, int con, int intel, int wis, int cha, string name, string job, string race, string alignment)
        {
            this.LVL = 1;
            this.STR = str;
            this.DEX = dex;
            this.CON = con;
            this.INT = intel;
            this.WIS = wis;
            this.CHA = cha;
            this.Name = name;
            this.Class = job;
            this.Race = race;
            this.Alignment = alignment;
            /*
            this.Max_HP = hp;
            this.Current_HP = hp;
            this.SPD = spd;
            this.AC_No_Armour = ac;
            this.AC = ac;
            */
        }

        public int getModSTR()
        {
            int mod = (this.STR - 10) / 2;
            return mod;
        }

        public int getModDEX()
        {
            int mod = (DEX - 10) / 2;
            return mod;
        }

        public int getModCON()
        {
            int mod = (CON - 10) / 2;
            return mod;
        }

        public int getModINT()
        {
            int mod = (INT-10) / 2;
            return mod;
        }

        public int getModWIS()
        {
            int mod = (WIS - 10) / 2;
            return mod;
        }

        public int getModCHA()
        {
            int mod = (CHA - 10) / 2;
            return mod;
        }

        public string getAllInfo()
        {
            string info = Name + "\n" + Class + "\n" + Alignment + "\n" + STR + " Mod: " + getModSTR() + "\n" + DEX + " Mod: " + getModDEX() + "\n" + CON + " Mod: " + getModCON() + "\n" + INT + " Mod: " + getModINT() + "\n" + WIS + " Mod: " + getModWIS() + "\n" + CHA + " Mod: " + getModCHA();
            return info;
        }

    }


}
