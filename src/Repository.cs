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
                    }
                    else
                    {
                        throw new ApplicationException("Client profile not found.");
                    }
                }
            }
        }

        public void editClientProfile(int userId, string username, string email, string phone, string address, string companyName)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string countQuery = "SELECT COUNT(*) FROM Users WHERE username = @username AND id != @userId;";
                using (var countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@username", username);
                    countCmd.Parameters.AddWithValue("@userId", userId);
                    var count = Convert.ToInt32(countCmd.ExecuteScalar());
                    if (count != 0)
                    {
                        throw new ApplicationException("Username already exists. Please choose another username.");
                    }
                }

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updateUserQuery = @"
                            UPDATE Users
                            SET username = @Username,
                                email = @Email,
                                phone = @Phone
                            WHERE id = @UserId;";

                        using (var cmdUser = new MySqlCommand(updateUserQuery, conn, transaction))
                        {
                            cmdUser.Parameters.AddWithValue("@Username", username);
                            cmdUser.Parameters.AddWithValue("@Email", email);
                            cmdUser.Parameters.AddWithValue("@Phone", phone);
                            cmdUser.Parameters.AddWithValue("@UserId", userId);

                            int affected = cmdUser.ExecuteNonQuery();
                            if (affected == 0)
                                throw new ApplicationException("User not found or no changes applied.");
                        }

                        string updateClientQuery = @"
                            UPDATE Clients
                            SET address = @Address,
                                company_name = @CompanyName
                            WHERE user_id = @UserId;";

                        using (var cmdClient = new MySqlCommand(updateClientQuery, conn, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@Address", address);
                            cmdClient.Parameters.AddWithValue("@CompanyName", companyName);
                            cmdClient.Parameters.AddWithValue("@UserId", userId);

                            int affected = cmdClient.ExecuteNonQuery();
                            if (affected == 0)
                                throw new ApplicationException("Client profile not found or no changes applied.");
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while editing client profile: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public (string username, string email, string phone, string skills, string expertise, string portfolio, string pastwork) getFreelancerProfileData(int userId)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string query = @"
                    SELECT 
                        u.username, 
                        u.email, 
                        u.phone,
                        f.skills, 
                        f.expertise, 
                        f.portfolio, 
                        f.pastwork
                    FROM Users u
                    JOIN Freelancers f ON u.id = f.user_id
                    WHERE u.id = @userId;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString("username");
                            string email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : reader.GetString("email");
                            string phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? "" : reader.GetString("phone");
                            string skills = reader.IsDBNull(reader.GetOrdinal("skills")) ? "" : reader.GetString("skills");
                            string expertise = reader.IsDBNull(reader.GetOrdinal("expertise")) ? "" : reader.GetString("expertise");
                            string portfolio = reader.IsDBNull(reader.GetOrdinal("portfolio")) ? "" : reader.GetString("portfolio");
                            string pastwork = reader.IsDBNull(reader.GetOrdinal("pastwork")) ? "" : reader.GetString("pastwork");

                            return (username, email, phone, skills, expertise, portfolio, pastwork);
                        }
                        else
                        {
                            throw new ApplicationException("Freelancer profile not found.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while fetching freelancer profile: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public void editFreelancerProfile(int userId, string username, string email, string phone, string skills, string expertise, string portfolio, string pastwork)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string countQuery = "SELECT COUNT(*) FROM Users WHERE username = @username AND id != @userId;";
                using (var countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@username", username);
                    countCmd.Parameters.AddWithValue("@userId", userId);
                    var count = Convert.ToInt32(countCmd.ExecuteScalar());
                    if (count != 0)
                    {
                        throw new ApplicationException("Username already exists. Please choose another username.");
                    }
                }

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updateUserQuery = @"
                            UPDATE Users
                            SET username = @Username,
                                email = @Email,
                                phone = @Phone
                            WHERE id = @UserId;";

                        using (var cmdUser = new MySqlCommand(updateUserQuery, conn, transaction))
                        {
                            cmdUser.Parameters.AddWithValue("@Username", username);
                            cmdUser.Parameters.AddWithValue("@Email", email);
                            cmdUser.Parameters.AddWithValue("@Phone", phone);
                            cmdUser.Parameters.AddWithValue("@UserId", userId);

                            int affected = cmdUser.ExecuteNonQuery();
                            if (affected == 0)
                                throw new ApplicationException("User not found or no changes applied.");
                        }

                        string updateFreelancerQuery = @"
                            UPDATE Freelancers
                            SET skills = @Skills,
                                expertise = @Expertise,
                                portfolio = @Portfolio,
                                pastwork = @Pastwork
                            WHERE user_id = @UserId;";

                        using (var cmdFreelancer = new MySqlCommand(updateFreelancerQuery, conn, transaction))
                        {
                            cmdFreelancer.Parameters.AddWithValue("@Skills", skills);
                            cmdFreelancer.Parameters.AddWithValue("@Expertise", expertise);
                            cmdFreelancer.Parameters.AddWithValue("@Portfolio", portfolio);
                            cmdFreelancer.Parameters.AddWithValue("@Pastwork", pastwork);
                            cmdFreelancer.Parameters.AddWithValue("@UserId", userId);

                            int affected = cmdFreelancer.ExecuteNonQuery();
                            if (affected == 0)
                                throw new ApplicationException("Freelancer profile not found or no changes applied.");
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while editing freelancer profile: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public void postProject(int clientId, string? name, string? description, decimal? budget, DateTime? deadline, string? skills)
        {
            try
            {
                // Basic validation
                if (string.IsNullOrWhiteSpace(name))
                    throw new ApplicationException("Name cannot be empty!");
                if (string.IsNullOrWhiteSpace(description))
                    throw new ApplicationException("Description cannot be empty!");
                if (budget == null || budget <= 0)
                    throw new ApplicationException("Budget must be greater than 0!");
                if (deadline == null)
                    throw new ApplicationException("Deadline cannot be empty!");
                if (string.IsNullOrWhiteSpace(skills))
                    throw new ApplicationException("Skills cannot be empty!");

                var conn = DatabaseService.GetConnection();

                string insertQuery = @"
                        INSERT INTO Projects (client_id, name, description, budget, deadline, skills, status)
                        VALUES (@ClientId, @Name, @Description, @Budget, @Deadline, @Skills, 'posted');";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientId", clientId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Budget", budget);
                    cmd.Parameters.AddWithValue("@Deadline", deadline);
                    cmd.Parameters.AddWithValue("@Skills", skills);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new ApplicationException("Failed to post project. Please try again.");
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while posting project: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<(string clientName, string? freelancerName, string name, string description, decimal budget, DateTime deadline, string skills, string status, int projectId, bool isClient)> getProjectList(int? userId, bool isClient, string? searchQuery)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string query = @"
                        SELECT 
                            p.id AS projectId,
                            c_user.username AS clientName,
                            f_user.username AS freelancerName,
                            p.name,
                            p.description,
                            p.budget,
                            p.deadline,
                            p.skills,
                            p.status,
                            p.client_id,
                            p.freelancer_id
                        FROM Projects p
                        INNER JOIN Users c_user ON c_user.id = p.client_id
                        LEFT JOIN Users f_user ON f_user.id = p.freelancer_id
                        WHERE 1=1
                    ";

                if (userId.HasValue)
                {
                    if (isClient)
                        query += " AND p.client_id = @UserId";
                    else
                        query += " AND p.freelancer_id = @UserId";
                }
                else
                {
                    query += " AND p.status = 'posted'";
                }

                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    query += " AND p.name LIKE @SearchQuery";
                }

                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (userId.HasValue)
                        cmd.Parameters.AddWithValue("@UserId", userId.Value);

                    if (!string.IsNullOrWhiteSpace(searchQuery))
                        cmd.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");

                    var projects = new List<(string, string?, string, string, decimal, DateTime, string, string, int, bool)>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string clientName = reader.GetString("clientName");
                            string? freelancerName = reader.IsDBNull(reader.GetOrdinal("freelancerName"))
                                ? null
                                : reader.GetString("freelancerName");
                            string name = reader.GetString("name");
                            string description = reader.GetString("description");
                            decimal budget = reader.GetDecimal("budget");
                            DateTime deadline = reader.GetDateTime("deadline");
                            string skills = reader.GetString("skills");
                            string status = reader.GetString("status");
                            int projectId = reader.GetInt32("projectId");

                            projects.Add((clientName, freelancerName, name, description, budget, deadline, skills, status, projectId, isClient));
                        }
                    }
                    return projects;
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while fetching projects: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public (string clientName, string? freelancerName, string name, string description, decimal budget, DateTime deadline, string skills, string status, int projectId) getProjectDetail(int projectId)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string query = @"
                        SELECT 
                            p.id AS projectId,
                            c_user.username AS clientName,
                            f_user.username AS freelancerName,
                            p.name,
                            p.description,
                            p.budget,
                            p.deadline,
                            p.skills,
                            p.status
                        FROM Projects p
                        INNER JOIN Users c_user ON c_user.id = p.client_id
                        LEFT JOIN Users f_user ON f_user.id = p.freelancer_id
                        WHERE p.id = @ProjectId;";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string clientName = reader.GetString("clientName");
                            string? freelancerName = reader.IsDBNull(reader.GetOrdinal("freelancerName"))
                                ? null
                                : reader.GetString("freelancerName");
                            string name = reader.GetString("name");
                            string description = reader.GetString("description");
                            decimal budget = reader.GetDecimal("budget");
                            DateTime deadline = reader.GetDateTime("deadline");
                            string skills = reader.GetString("skills");
                            string status = reader.GetString("status");
                            int projId = reader.GetInt32("projectId");

                            return (clientName, freelancerName, name, description, budget, deadline, skills, status, projId);
                        }
                        else
                        {
                            throw new ApplicationException("Project not found.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while fetching project detail: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
