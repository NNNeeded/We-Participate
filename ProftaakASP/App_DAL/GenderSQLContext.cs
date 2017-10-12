using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using ProftaakASP.Models;

namespace ProftaakASP.App_DAL
{
    public class GenderSQLContext : IGenderSQLContext
    {
        //autoclosed de connection? moeten we genders met id hebben
        public List<Gender> getAllGenders()
        {
            List<Gender> genders = new List<Gender>();

            using (SqlCommand cmd = new SqlCommand("Select GenderString FROM Gender;", Database.Connection))
            {
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        genders.Add(new Gender(Convert.ToInt32(reader["ID"]), reader["Genderstring"].ToString()));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            return genders;
        }

        public void newGender(Gender g)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Gender (GenderString) VALUES ('@Gender');", Database.Connection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Gender", g.GenderString);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        public void alterGender(Gender g)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Gender SET GenderString = '@Gender' WHERE ID = @ID;", Database.Connection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Gender", g.GenderString);
                    cmd.Parameters.AddWithValue("@ID", g.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }

        public void deleteGender(Gender g)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Gender WHERE Genderstring = '@Gender';", Database.Connection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Gender", g.GenderString);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}