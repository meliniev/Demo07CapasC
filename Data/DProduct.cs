using System;
using System.Collections.Generic;
using System.Data;
using Entity;
using Microsoft.Data.SqlClient;

namespace Data
{
    public class DProduct
    {
        // Cadena de conexión a la BD
        public string _connectionString = "Server=LAB411-024\\SQLEXPRESS;Database=labniev;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=true";

        public List<Product> Read()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("sp_ListarProductos", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // abrir conexión
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductId = Convert.ToInt32(reader["product_id"]),
                            Name = reader["name"].ToString(),
                            Price = Convert.ToDecimal(reader["price"]),
                            Stock = Convert.ToInt32(reader["stock"]),
                            Active = Convert.ToBoolean(reader["active"])
                        };
                        products.Add(product);
                    }
                }
            }

            return products;
        }
    }
}
