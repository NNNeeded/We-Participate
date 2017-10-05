using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Tag
    {
        //Hier maak ik alle attributen aan voor een tag
        private int id;
        private string tagstring;

        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public string TagString { get { return tagstring; } set { tagstring = value; } }

        //Hier link ik de attributen aan een tag
        public Tag(int id, string tagstring)
        {
            this.id = id;
            this.tagstring = tagstring;
        }

        //Hier maak ik nog een keer een tag aan zonder een id
        //Dit is omdat wanneer je een tag insert in de database het id niet nodig is omdat deze auto-increment
        public Tag(string tagstring):this(-1, tagstring)
        {

        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return TagString;
        }
    }
}