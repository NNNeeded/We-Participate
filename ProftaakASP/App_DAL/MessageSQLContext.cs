using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProftaakASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProftaakASP.App_DAL
{
    public class MessageSQLContext:IMessageContext
    {
        Message message;

        //Get all messages
        public List<Message> GetAllMessages()
        {
            List<Message> messages = new List<Message>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Message ORDER BY ID";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(CreateMessageFromReader(reader));
                        }
                    }
                }
            }
            return messages;
        }

        //Insert a message object
        public Message InsertMessage(Message message)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "INSERT INTO MESSAGE (Sender, Receiver, Context, DateSend, IsRead)" +
                    "VALUES (@sender, @receiver, @context, @datesend, @isread)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sender", message.Sender);
                    command.Parameters.AddWithValue("@receiver", message.Receiver);
                    command.Parameters.AddWithValue("@context", message.Context);
                    command.Parameters.AddWithValue("@datesend", message.DateSend);
                    command.Parameters.AddWithValue("@isread", message.IsRead);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return message;
            }
        }

        //Update message object
        public bool UpdateMessage(Message message)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE MESSAGE" +
                    " SET Sender=@sender, Receiver=@receiver, Context=@context, DateSend=@datesend, IsRead=@isread" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", message.Id);
                    command.Parameters.AddWithValue("@sender", message.Sender);
                    command.Parameters.AddWithValue("@receiver", message.Receiver);
                    command.Parameters.AddWithValue("@context", message.Context);
                    command.Parameters.AddWithValue("@datesend", message.DateSend);
                    command.Parameters.AddWithValue("@isread", message.IsRead);


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


        //Update message object
        public bool UpdateIsReadStatus(Message message)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "UPDATE MESSAGE" +
                    " SET IsRead=@isread" +
                    " WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", message.Id);
                    command.Parameters.AddWithValue("@isread", message.IsRead);


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

        //Delete a message object
        public bool DeleteMessage(int id)
        {
            using (SqlConnection connection = Database.Connection)
            {
                string query = "DELETE FROM MESSAGE WHERE ID=@id";
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

        //Get a message object by id
        public Message GetMessageById(int id)
        {

            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM MESSAGE WHERE ID=@id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            message = CreateMessageFromReader(reader);
                        }
                    }
                }
            }
            return message;
        }

        //Get a messages object by receiver
        public List<Message> GetAllMessagesByReceiver(int receiver)
        {
            List<Message> messages = new List<Message>();
            using (SqlConnection connection = Database.Connection)
            {
                string query = "SELECT * FROM Message WHERE Receiver=@receiver";

                //commit
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@receiver", receiver);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(CreateMessageFromReader(reader));
                        }
                    }
                }
            }
            return messages;
        }



        //Geef aan waar een message uit bestaat
        private Message CreateMessageFromReader(SqlDataReader reader)
        {
            return new Message(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToInt32(reader["Sender"]),
                 Convert.ToInt32(reader["Receiver"]),
                 Convert.ToString(reader["Context"]),
                 Convert.ToDateTime(reader["DateSend"]), 
                 Convert.ToBoolean(reader["IsRead"]));
        }
    }
}