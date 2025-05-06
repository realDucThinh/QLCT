using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExpenseApp.DAL
{
    public class ExpenseDAL
    {
        private string connectionString = "Data Source=DTHINH;Initial Catalog=ExpenseDB;Integrated Security=True;";

        public List<Expense> GetExpenses()
        {
            List<Expense> expenses = new List<Expense>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, Amount, Category, DateAdded FROM Expenses ORDER BY DateAdded DESC";  // Lấy tất cả các khoản chi
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    expenses.Add(new Expense
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        Category = reader["Category"].ToString(),
                        DateAdded = Convert.ToDateTime(reader["DateAdded"])
                    });
                }
            }
            return expenses;
        }


        public bool AddExpense(decimal amount, string category)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Expenses (Amount, Category) VALUES (@Amount, @Category)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@Category", category);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;  // Trả về true nếu thêm thành công
            }
        }


        public bool RemoveExpense(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Expenses WHERE ID = @ID"; 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public class Expense
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
