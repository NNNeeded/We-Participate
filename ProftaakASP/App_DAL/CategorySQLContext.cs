using System;
using System.Collections.Generic;
using ProftaakASP.Models;
using System.Data.SqlClient;

// Yorick

namespace ProftaakASP.App_DAL
{
    public class CategorySQLContext : ICategorySQLContext
    {
        public List<Category> getAllCategories()
        {
            List<Category> Categories = new List<Category>();

            using (SqlCommand Command = new SqlCommand("SELECT Title FROM Category", Database.Connection))
            {
                try
                {
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        Categories.Add(new Category(Reader["Title"].ToString()));
                    }
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }

            return Categories;
        }

        public void newCategory(Category C)
        {
            using (SqlCommand Command = new SqlCommand("INSERT INTO Category (Title) VALUES ('@Title')", Database.Connection))
            {
                try
                {
                    Command.Parameters.AddWithValue("@Title", C.Title);
                    Command.ExecuteNonQuery();
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }
        }

        public void alterCategory(Category C)
        {
            using (SqlCommand Command = new SqlCommand("UPDATE Category SET Title = '@Title' WHERE ID = @ID", Database.Connection))
            {
                try
                {
                    Command.Parameters.AddWithValue("@Title", C.Title);
                    Command.Parameters.AddWithValue("@ID", C.Id);
                    Command.ExecuteNonQuery();
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }

        }

        public void deleteCategory(Category C)
        {
            using (SqlCommand Command = new SqlCommand("DELETE FROM Category WHERE Title = '@Title'", Database.Connection))
            {
                try
                {
                    Command.Parameters.AddWithValue("@Title", C.Title);
                    Command.ExecuteNonQuery();
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                }
            }
        }
    }
}