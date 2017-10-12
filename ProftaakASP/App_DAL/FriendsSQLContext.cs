using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProftaakASP.App_DAL;
using ProftaakASP.Models;
using System.Data.SqlClient;

namespace ProftaakASP.App_DAL
{
    public class FriendsSQLContext : IFriendsContext
    {
        public bool CheckFriends(int x, int y)
        {
            string query = "SELECT * FROM Friends WHERE FriendOne = @friendone OR FriendOne = @friendtwo AND FriendTwo = @friendone OR FriendTwo = @friendtwo;";
            using (SqlConnection conn = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@friendone", x);
                cmd.Parameters.AddWithValue("@friendtwo", y);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        conn.Close();
                        return true;
                    }
                }
            }
            Database.Connection.Close();
            return false;
        }

        public void MakeFriends(Account x, Account y)
        {
            string query = "INSERT INTO Friends(FriendOne, FriendTwo) VALUES (@idone, @idtwo);";
            using (SqlConnection conn = Database.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idone", x.Id);
                cmd.Parameters.AddWithValue("@idtwo", y.Id);
                cmd.ExecuteNonQuery();
                conn.Close;
            }
        }
    }
}