using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProftaakASP.App_DAL
{
    //De SQLContext is gelinked aan een interface 
    public class AccountSQLContext:IAccountContext
    {
        //Maak een account object aan genaamd account
        Account account;

        //Get all accounts
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM ACCOUNT ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(CreateAccountFromReader(reader));
                        }
                    }
                }
            }
            return accounts;
        }

        //Insert a account object
        public Account InsertAccount(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO ACCOUNT (PhoneNumber, Email, Username, Password, Rank, FirstName, LastName, City, Street, HouseNumber, Zipcode, Gender, ProfileDescription)" +
                    "VALUES (@phonenumber, @email, @username, @password, @rank, @firstname, @lastname, @city, @street, @housenumber, @zipcode, @gender, @profiledescription)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@phonenumber", account.PhoneNumber);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@username", account.Username);
                    command.Parameters.AddWithValue("@password", account.Password);
                    command.Parameters.AddWithValue("@rank", account.Rank);
                    command.Parameters.AddWithValue("@firstname", account.FirstName);
                    command.Parameters.AddWithValue("@lastname", account.LastName);
                    command.Parameters.AddWithValue("@city", account.City);
                    command.Parameters.AddWithValue("@street", account.Street);
                    command.Parameters.AddWithValue("@housenumber", account.HouseNumber);
                    command.Parameters.AddWithValue("@zipcode", account.Zipcode);
                    command.Parameters.AddWithValue("@gender", account.Gender);
                    command.Parameters.AddWithValue("@profiledescription", account.ProfileDescription);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return account;
            }
        }

        //Update account object
        public bool UpdateAccount(Account account)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE ACCOUNT" +
                    " SET PhoneNumber=@phonenumber, Email=@email, Username=@username, Password=@password, Rank=@rank, FirstName=@firstname, LastName=@lastname, BirthYear=@birthyear, City=@city, Street=@street, HouseNumber=@housenumber, Zipcode=@zipcode, Gender=@gender, ProfileDescription=@profiledescription, PreferredCategory=@preferredcategory" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", account.Id);
                    command.Parameters.AddWithValue("@phonenumber", account.PhoneNumber);
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@username", account.Username);
                    command.Parameters.AddWithValue("@password", account.Password);
                    command.Parameters.AddWithValue("@rank", account.Rank);
                    command.Parameters.AddWithValue("@firstname", account.FirstName);
                    command.Parameters.AddWithValue("@lastname", account.LastName);
                    command.Parameters.AddWithValue("@birthyear", account.BirthYear);
                    command.Parameters.AddWithValue("@city", account.City);
                    command.Parameters.AddWithValue("@street", account.Street);
                    command.Parameters.AddWithValue("@housenumber", account.HouseNumber);
                    command.Parameters.AddWithValue("@zipcode", account.Zipcode);
                    command.Parameters.AddWithValue("@gender", account.Gender);
                    command.Parameters.AddWithValue("@profiledescription", account.ProfileDescription);
                    command.Parameters.AddWithValue("@preferredcategory", account.PreferredCategory);

                    try
                    {
                        if (Convert.ToInt32(command.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (SqlException e)
                    {

                    }

                }
            }

            return false;
        }

        //Delete a account object
        public bool DeleteAccount(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM ACCOUNT WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //Get a account object by id
        public Account GetAccountById(int id)
        {

            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM ACCOUNT WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            account = CreateAccountFromReader(reader);
                        }
                    }
                }
            }
            return account;
        }

        //Get username and passwords
        public Account Login(string username, string password)
        {
            SqlConnection connection = Database.Connection;

            //Check the state of the connection
            ConnectionState conState = connection.State;

            if (conState == ConnectionState.Open)
            {
                string query = "SELECT * FROM ACCOUNT WHERE Username=@username and Password=@password";
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteScalar();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Account account = CreateAccountFromReader(reader);
                            return account;
                        }
                    }
                }
            }
            return null;
        }

        //Geef aan waar een account uit bestaat
        private Account CreateAccountFromReader(SqlDataReader reader)
        {
            return new Account(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["PhoneNumber"]),
                 Convert.ToString(reader["Email"]),
                 Convert.ToString(reader["Username"]),
                 Convert.ToString(reader["Password"]),
                 Convert.ToString(reader["Rank"]),
                 Convert.ToString(reader["FirstName"]),
                 Convert.ToString(reader["LastName"]),
                 Convert.ToDateTime(reader["BirthYear"]),
                 Convert.ToString(reader["City"]),
                 Convert.ToString(reader["Street"]),
                 Convert.ToString(reader["HouseNumber"]),
                 Convert.ToString(reader["Zipcode"]),
                 Convert.ToString(reader["Gender"]),
                 Convert.ToString(reader["ProfileDescription"]),
                 Convert.ToInt32(reader["PreferredCategory"]));
        }
    }
}