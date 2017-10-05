using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Gender
    {
        //Hier maak ik alle attributen aan voor een gender
        private int id;
        private string genderstring;

        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public string GenderString { get { return genderstring; } set { genderstring = value; } }

        //Hier link ik de attributen aan een gender
        public Gender(int id , string genderstring)
        {
            this.id = id;
            this.genderstring = genderstring;
        }

        //Hier maak ik nog een keer een gender aan zonder een id
        //Dit is omdat wanneer je een gender insert in de database het id niet nodig is omdat deze auto-increment
        public Gender(string genderstring) :this(-1, genderstring)
        {
         
        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return GenderString;
        }
    }
}