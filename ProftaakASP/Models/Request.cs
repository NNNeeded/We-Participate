using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class Request
    {
        //Hier maak ik alle attributen aan voor een request
        private int id;
        private int accountid;
        private string title;
        private string context;
        private DateTime dateplaced;
        private DateTime datehelpneeded;
        private DateTime requestexpiration;
        private int categoryid;

        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public int AccountId { get { return accountid; } set { accountid = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Context { get { return context; } set { context = value; } }

        [DataType(DataType.Date)]
        public DateTime DatePlaced { get { return dateplaced; } set { dateplaced = value; } }

        [DataType(DataType.Date)]
        public DateTime DateHelpNeeded { get { return datehelpneeded; } set { datehelpneeded = value; } }

        [DataType(DataType.Date)]
        public DateTime RequestExpiration { get { return requestexpiration; } set { requestexpiration = value; } }

        public int CategoryId { get { return categoryid; } set { categoryid = value; } }

        //Hier link ik de attributen aan een request
        public Request(int id, int accountid, string title, string context, DateTime dateplaced, DateTime datehelpneeded, DateTime requestexpiration, int categoryid)
        {
            this.id = id;
            this.accountid = accountid;
            this.title = title;
            this.context = context;
            this.dateplaced = dateplaced;
            this.datehelpneeded = datehelpneeded;
            this.requestexpiration = requestexpiration;
            this.categoryid = categoryid;
        }

        //Hier maak ik nog een keer een request aan zonder een id
        //Dit is omdat wanneer je een request insert in de database het id niet nodig is omdat deze auto-increment
        public Request(int accountid, string title, string context, DateTime dateplaced, DateTime datehelpneeded, DateTime requestexpiration, int categoryid):this(-1, accountid, title, context, dateplaced, datehelpneeded, requestexpiration, categoryid)
        {
  
        }



        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return Title + " " + Context + " " + DatePlaced + " " + DateHelpNeeded;
        }
    }
}