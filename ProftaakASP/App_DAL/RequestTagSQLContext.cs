using System;
using ProftaakASP.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProftaakASP.App_DAL
{
    public class RequestTagSQLContext : IRequestTagContext
    {
        RequestTag requesttag;

        public List<RequestTag> GetAllRequestTags()
        {
            List<RequestTag> requestTags = new List<RequestTag>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM REQUESTTAG ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requestTags.Add(CreateRequestTagFromReader(reader));
                        }
                    }
                }
            }
            return requestTags;
        }

        public RequestTag InsertRequestTag(RequestTag requesttag)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO REQUESTTAG (RequestID,TagID)" + " VALUES(@requestid, @tagid)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@requestid", requesttag.RequestId);
                    command.Parameters.AddWithValue("@tagid", requesttag.TagId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return requesttag;
            }
        }

        public bool UpdateRequestTag(RequestTag requesttag)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE REQUESTTAG" +
                    " SET RequestID=@requestid, TagID=@tagid" +
                    " WHERE RequestID = @requestid";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@requestid", requesttag.RequestId);
                    command.Parameters.AddWithValue("@tagid", requesttag.TagId);

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

        public bool DeleteRequestTag(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM REQUESTTAG WHERE RequestID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public RequestTag GetRequestTagById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM REQUESTTAG WHERE RequestID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requesttag = CreateRequestTagFromReader(reader);
                        }
                    }
                }
            }
            return requesttag;
        }

        private RequestTag CreateRequestTagFromReader(SqlDataReader reader)
        {
            return new RequestTag(
                Convert.ToInt32(reader["RequestID"]),
                Convert.ToInt32(reader["TagID"])
                );
        }
    }
}