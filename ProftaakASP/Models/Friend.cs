using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Friend
    {
        //Hier maak ik alle attributen aan voor een friend
        private int friendone;
        private int friendtwo;

        //Hier maak ik getters en setters voor de attributen
        public int FriendOne { get { return friendone; } set { friendone = value; } }
        public int FriendTwo { get { return friendtwo; } set { friendtwo = value; } }

        //Hier link ik de attributen aan een friend
        public Friend(int friendone, int friendtwo)
        {
            this.friendone = friendone;
            this.friendtwo = friendtwo;
        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return FriendOne + " " + FriendTwo;
        }
    }
}