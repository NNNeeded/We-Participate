using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProftaakASP.Models;
using System.Data.SqlClient;

namespace ProftaakASP.App_DAL
{
    public class OfferSQLContext:IOfferContext
    {
        Offer offer;

        public List<Offer> GetAllOffers()
        {
            string query = "SELECT * From Offer;";
            List<Offer> OfferList = new List<Offer>();
            using (SqlConnection conn = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        OfferList.Add(CreateOfferFromReader(dr));
                    }
                }
                Database.Connection.Close();
            }
            return OfferList;
        }

        public Offer GetOfferInfo(int id)
        {
            string query = "SELECT * FROM Offer WHERE id = @id;";
            using (SqlConnection conn = Database.Connection)
            {
                
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        offer = CreateOfferFromReader(dr);
                    }
                }
            }
            return offer;
        }

        public bool InsertOffer(Offer o)
        {
            string query = "INSERT INTO Offer(AccountID, RequestID, Title, Context) VALUES (@accountID, @requestid, @title, @context);";
            using (SqlConnection conn = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@accountID", o.AccountId);
                cmd.Parameters.AddWithValue("@requestID", o.RequestId);
                cmd.Parameters.AddWithValue("@title", o.Title);
                cmd.Parameters.AddWithValue("@context", o.Context);

                try
                {
                    if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                    {
                        return true;
                    }
                }
                catch (SqlException e)
                {

                }
            }            
            return false;
        }



        public bool DeleteOffer(int id)
        {
            string query = "DELETE FROM Offer WHERE Id = @id;";
            using (SqlConnection conn = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return false;
        }

        public Offer CreateOfferFromReader(SqlDataReader dr)
        {
            Offer o = new Offer(
                Convert.ToInt32(dr["ID"]),
                Convert.ToInt32(dr["AccountID"]),
                Convert.ToInt32(dr["RequestID"]),
                Convert.ToString(dr["Title"]),
                Convert.ToString(dr["Context"]));
            return o;
        }
    }
}