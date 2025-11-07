using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancePlatform.src
{
    internal class Repository
    {
        public void register(string username, string password, string userType)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string countQuery = "SELECT COUNT(*) FROM Users WHERE username = @username;";
                using (var countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@username", username);
                    var count = Convert.ToInt32(countCmd.ExecuteScalar());
                    if (count != 0)
                    {
                        throw new ApplicationException("Username already exists. Please choose another username.");
                    }
                }

                string insertUserQuery = @"
                    INSERT INTO Users (username, password, type)
                    VALUES (@username, @password, @type);";

                long userId;
                using (var cmd = new MySqlCommand(insertUserQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@type", userType);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new ApplicationException("Failed to insert user. Please try again.");

                    userId = cmd.LastInsertedId;
                }
                if (userType == "client")
                {
                    string insertClientQuery = @"
                        INSERT INTO Clients (user_id, address, company_name)
                        VALUES (@userId, '', '');";
                    using (var cmd = new MySqlCommand(insertClientQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (userType == "freelancer")
                {
                    string insertFreelancerQuery = @"
                        INSERT INTO Freelancers (user_id, skills, expertise, portfolio, pastwork)
                        VALUES (@userId, '', '', '', '');";
                    using (var cmd = new MySqlCommand(insertFreelancerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public (int userId, string userType) login(string username, string password)
        {
            var conn = DatabaseService.GetConnection();
            string query = @"
                    SELECT id, type FROM Users 
                    WHERE username = @username AND password = @password;";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("id");
                        string userType = reader.GetString("type");
                        return (userId, userType);
                    }
                    else
                    {
                        throw new ApplicationException("Invalid Credentials. Please check your username and password.");
                    }
                }
            }
        }

        public (string username, string email, string phone, string address, string companyName) getClientProfileData(int userId)
        {
            var conn = DatabaseService.GetConnection();

            string query = @"
                SELECT u.id, u.username, u.email, u.phone,
                       c.address, c.company_name
                FROM Users u
                INNER JOIN Clients c ON u.id = c.user_id
                WHERE u.id = @userId;";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string username = reader.GetString("username");
                        string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email");
                        string phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? "" : reader.GetString("phone");
                        string address = reader.IsDBNull(reader.GetOrdinal("address")) ? "" : reader.GetString("address");
                        string companyName = reader.IsDBNull(reader.GetOrdinal("company_name")) ? "" : reader.GetString("company_name");
                        return (username, email, phone, address, companyName);
                    } else
                    {
                        throw new ApplicationException("Client profile not found.");
                    }
                }
            }
        }
    }
}
