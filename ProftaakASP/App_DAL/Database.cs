using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProftaakASP.App_DAL
{
    public class Database
    {
        //Wanneer je een database toevoegd moet je de connectie string hierin opslaan
        private static readonly string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi368111;Persist Security Info=True;User ID=dbi368111;Password=12345678";

        //Hier regel ik een sql connectie en daarvoor gebruik ik de connectiestring
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    connection.Close();
                }
                return connection;
            }
        }
    }
}