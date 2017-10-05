using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.Models
{
    //De account class is de enige uitgewerkte class in deze demo
    public class Account
    {
        //Hier maak ik alle attributen aan voor een account
        private int id;
        private string phonenumber;
        private string email;
        private string username;
        private string password;
        private string rank;
        private string firstname;
        private string lastname;
        private DateTime birthyear;
        private string city;
        private string street;
        private string housenumber;
        private string zipcode;
        private string gender;
        private string profiledescription;
        private int preferredcategory;

        //Hier maak ik getters en setters voor de attributen
        public int Id { get { return id; } set { id = value; } }
        public string PhoneNumber { get { return phonenumber; } set { phonenumber = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Rank { get { return rank; } set { rank = value; } }
        public string FirstName { get { return firstname; } set { firstname = value; } }
        public string LastName { get { return lastname; } set { lastname = value; } }
        public DateTime BirthYear { get { return birthyear; } set { birthyear = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Street { get { return street; } set { street = value; } }
        public string HouseNumber { get { return housenumber; } set { housenumber = value; } }
        public string Zipcode { get { return zipcode; } set { zipcode = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string ProfileDescription { get { return profiledescription; } set { profiledescription = value; } }
        public int PreferredCategory { get { return preferredcategory; } set { preferredcategory = value; } }


        //Hier link ik de attributen aan een account
        public Account(int id, string phonenumber, string email, string username, string password, string rank, string firstname, string lastname, DateTime birthyear, string city, string street, string housenumber, string zipcode, string gender, string profiledescription, int preferredcategory)
        {
            this.id = id;
            this.phonenumber = phonenumber;
            this.email = email;
            this.username = username;
            this.password = password;
            this.rank = rank;
            this.firstname = firstname;
            this.lastname = lastname;
            this.birthyear = birthyear;
            this.city = city;
            this.street = street;
            this.housenumber = housenumber;
            this.zipcode = zipcode;
            this.gender = gender;
            this.profiledescription = profiledescription;
            this.preferredcategory = preferredcategory;
        }

        //Hier maak ik nog een keer een account aan zonder een id
        //Dit is omdat wanneer je een account insert in de database het id niet nodig is omdat deze auto-increment
        public Account(string phonenumber, string email, string username, string password, string rank, string firstname, string lastname, DateTime birthyear, string city, string street, string housenumber, string zipcode, string gender, string profiledescription, int preferredcategory) :this(-1, phonenumber, email, username, password, rank, firstname, lastname, birthyear, city, street, housenumber, zipcode, gender, profiledescription, preferredcategory)
        {

        }

        //Hier maak ik een ToString methode 
        public override string ToString()
        {
            return PhoneNumber + " " + Email + " " + Username + " " + Password + " " + Rank + " " + FirstName + " " + LastName + " " + City + " " + Street + " " + HouseNumber + " " + Zipcode + " " + Gender + " " + ProfileDescription;
        }
    }
}