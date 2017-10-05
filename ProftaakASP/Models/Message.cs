using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Message
    {
        //Hier maak ik alle attributen aan voor een message
        private int id;
        private int sender;
        private int receiver;
        private string context;
        private DateTime datesend;
        private bool isread;

        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public int Sender { get { return sender; } set { sender = value; } }
        public int Receiver { get { return receiver; } set { receiver = value; } }
        public string Context { get { return context; } set { context = value; } }
        public DateTime DateSend { get { return datesend; } set { datesend = value; } }
        public bool IsRead { get { return isread; } set { isread = value; } }

        //Hier link ik de attributen aan een message
        public Message(int id, int sender, int receiver, string context, DateTime datesend, bool isread)
        {
            this.id = id;
            this.sender = sender;
            this.receiver = receiver;
            this.context = context;
            this.datesend = datesend;
            this.isread = isread;
        }

        //Hier maak ik nog een keer een message aan zonder een id
        //Dit is omdat wanneer je een message insert in de database het id niet nodig is omdat deze auto-increment
        public Message(int sender, int receiver, string context, DateTime datesend, bool isread) :this(-1, sender, receiver, context, datesend, isread)
        {

        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return Sender + " " + Receiver + "" + Context + " " + DateSend;
        }
    }
}