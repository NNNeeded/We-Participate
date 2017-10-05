using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Category
    {
        //Hier maak ik alle attributen aan voor een category
        private int id;
        private string title;

        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public string Title { get { return title; } set { title = value; } }

        //Hier link ik de attributen aan een category
        public Category(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

        //Hier maak ik nog een keer een category aan zonder een id
        //Dit is omdat wanneer je een category insert in de database het id niet nodig is omdat deze auto-increment
        public Category(string title) :this(-1, title)
        {

        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return Title;
        }
    }
}