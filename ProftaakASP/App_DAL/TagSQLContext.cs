using System;
using ProftaakASP.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProftaakASP.App_DAL
{
    public class TagSQLContext : ITagContext
    {
        Tag tag;

        public List<Tag> GetAllTags()
        {
            List<Tag> tags = new List<Tag>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM TAG ORDER BY ID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tags.Add(CreateTagFromReader(reader));
                        }
                    }
                }
            }
            return tags;
        }

        public Tag InsertTag(Tag tag)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO TAG (TagString)" + " Values(@tagstring)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tagstring", tag.TagString);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
            }
            return tag;
        }

        public bool UpdateTag(Tag tag)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE TAG" + " SET TagString=@tagstring" + " WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", tag.Id);
                    command.Parameters.AddWithValue("@tagstring", tag.TagString);

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

        public bool DeleteTag(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM TAG WHERE ID=@id";
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

        public Tag GetTagById(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM TAG WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            tag = CreateTagFromReader(reader);
                        }
                    }
                }
            }
            return tag;
        }
        private Tag CreateTagFromReader(SqlDataReader reader)
        {
            return new Tag(
                Convert.ToInt32(reader["ID"]),
                Convert.ToString(reader["Tagstring"]
                ));
        }
    }
}