using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace quanlykhachsan12345
{
    internal class KetNoiData
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        private string connectionString = @"Data Source=LAPTOP-LJ7MLEU5\MSSQLSERVER1;Initial Catalog=csdlks1245;Integrated Security=True;Encrypt=False";

        // Phương thức thực thi truy vấn SELECT và trả về một DataTable chứa kết quả
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm các tham số nếu được cung cấp
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }

                return dataTable;
            }
        }

        // Phương thức thực thi truy vấn INSERT, UPDATE hoặc DELETE và trả về số dòng ảnh hưởng
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm các tham số nếu được cung cấp
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }

                    return command.ExecuteNonQuery();// 
                }
            }
        }

        // Phương thức thực thi truy vấn SELECT và trả về giá trị của ô đầu tiên trong kết quả
        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm các tham số nếu được cung cấp
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }
    }
}
