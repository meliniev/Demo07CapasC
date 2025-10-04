using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entity;

namespace Data
{
    public class DCustomer
    {
        private string _connectionString = "Server=LAB411-024\\SQLEXPRESS;Database=labniev;Trusted_Connection=True;TrustServerCertificate=True";

        // CREATE
        public void Create(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO customers (name, address, phone, active) VALUES (@name, @address, @phone, 1)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Customer> Read()
        {
            List<Customer> list = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM customers WHERE active = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Customer
                    {
                        CustomerId = Convert.ToInt32(dr["customer_id"]),
                        Name = dr["name"].ToString(),
                        Address = dr["address"].ToString(),
                        Phone = dr["phone"].ToString(),
                        Active = Convert.ToBoolean(dr["active"])
                    });
                }
            }
            return list;
        }

        // UPDATE
        public void Update(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE customers SET name=@name, address=@address, phone=@phone WHERE customer_id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", customer.CustomerId);
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@phone", customer.Phone);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE lógico
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE customers SET active = 0 WHERE customer_id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
