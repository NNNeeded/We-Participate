using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProftaakASP.App_DAL
{
    public class RequestSQLContext:IRequestContext
    {
        Request request;

        //Get all requests
        public List<Request> GetAllRequests()
        {
            List<Request> requests = new List<Request>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "Select * From Request R Where R.RequestExpiration >= Convert(Date, GetDate(), 101)";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requests.Add(CreateRequestFromReader(reader));
                        }
                    }
                }
            }
            return requests;
        }

        //Insert a request object
        public Request InsertRequest(Request request)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO REQUEST (AccountID, Title, Context, DatePlaced, DateHelpNeeded, RequestExpiration, CategoryID)" +
                    "VALUES (@accountid, @title, @context, @dateplaced, @datehelpneeded, @requestexpiration, @categoryid)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountid", request.AccountId);
                    command.Parameters.AddWithValue("@title", request.Title);
                    command.Parameters.AddWithValue("@context", request.Context);
                    command.Parameters.AddWithValue("@dateplaced", request.DatePlaced);
                    command.Parameters.AddWithValue("@datehelpneeded", request.DateHelpNeeded);
                    command.Parameters.AddWithValue("@requestexpiration", request.RequestExpiration);
                    command.Parameters.AddWithValue("@categoryid", request.CategoryId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return request;
            }
        }

        //Update request object
        public bool UpdateRequest(Request request)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE REQUEST" +
                    " SET AccountID=@accountid, Title=@title, Context=@context, DatePlaced=@dateplaced, DateHelpNeeded=@datehelpneeded, RequestExpiration=@requestexpiration, CategoryID=@categoryid" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", request.Id);
                    command.Parameters.AddWithValue("@accountid", request.AccountId);
                    command.Parameters.AddWithValue("@title", request.Title);
                    command.Parameters.AddWithValue("@context", request.Context);
                    command.Parameters.AddWithValue("@dateplaced", request.DatePlaced);
                    command.Parameters.AddWithValue("@datehelpneeded", request.DateHelpNeeded);
                    command.Parameters.AddWithValue("@requestexpiration", request.RequestExpiration);
                    command.Parameters.AddWithValue("@categoryid", request.CategoryId);


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

        //Delete a request object
        public bool DeleteRequest(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM REQUEST WHERE ID=@id";
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

        //Get a request object by id
        public Request GetRequestById(int id)
        {

            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM REQUEST WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            request = CreateRequestFromReader(reader);
                        }
                    }
                }
            }
            return request;
        }



        //Geef aan waar een request uit bestaat
        private Request CreateRequestFromReader(SqlDataReader reader)
        {
            return new Request(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["AccountId"]),
                 Convert.ToString(reader["Title"]),
                 Convert.ToString(reader["Context"]),
                 Convert.ToDateTime(reader["DatePlaced"]),
                 Convert.ToDateTime(reader["DateHelpNeeded"]),
                 Convert.ToDateTime(reader["RequestExpiration"]),
                 Convert.ToInt32(reader["CategoryId"]));
        }
    }
}