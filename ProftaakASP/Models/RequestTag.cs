using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    public class RequestTag
    {
        //Hier maak ik alle attributen aan voor een requesttag
        private int requestid;
        private int tagid;

        //Hier maak ik getters en setters voor de attributen
        public int RequestId { get { return requestid; } set { requestid = value; } }
        public int TagId { get { return tagid; } set { tagid = value; } }

        //Hier link ik de attributen aan een requesttag
        public RequestTag(int requestid, int tagid)
        {
            this.requestid = requestid;
            this.tagid = tagid;
        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return RequestId + " " + TagId;
        }

    }
}