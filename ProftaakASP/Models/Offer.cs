using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Offer
    {
        //Hier maak ik alle attributen aan voor een offer
        private int id;
        private int accountid;
        private int requestid;
        private string title;
        private string context;


        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public int AccountId { get { return accountid; } set { accountid = value; } }
        public int RequestId { get { return requestid; } set { requestid = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Context { get { return context; } set { context = value; } }

        //Hier link ik de attributen aan een offer
        public Offer(int id, int accountid, int requestid, string title, string context)
        {
            this.id = id;
            this.accountid = accountid;
            this.requestid = requestid;
            this.title = title;
            this.context = context;
        }


        //Hier maak ik nog een keer een offer aan zonder een id
        //Dit is omdat wanneer je een offer insert in de database het id niet nodig is omdat deze auto-increment
        public Offer(int accountid, int requestid, string title, string context):this(-1, accountid, requestid, title, context)
        {
      
        }



        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return Title + " " + Context + "" + AccountId;
        }
    }
}