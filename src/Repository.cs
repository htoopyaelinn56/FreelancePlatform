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

        public void createBidForProject(int projectId, int freelancerId, decimal? bidAmount)
        {
            try
            {
                if (bidAmount == null || bidAmount <= 0)
                    throw new ApplicationException("Bid Amount must be greater than 0!");

                var conn = DatabaseService.GetConnection();

                // Check if freelancer already has an active bid (status != 'rejected' to allow re-bid)
                string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM Bids 
                        WHERE project_id = @ProjectId 
                        AND freelancer_id = @FreelancerId 
                        AND status != 'rejected';";

                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ProjectId", projectId);
                    checkCmd.Parameters.AddWithValue("@FreelancerId", freelancerId);

                    int existingBidCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingBidCount > 0)
                        throw new ApplicationException("You already have an active bid on this project.");
                }

                string insertQuery = @"
                        INSERT INTO Bids (project_id, freelancer_id, bid_amount, status)
                        VALUES (@ProjectId, @FreelancerId, @BidAmount, 'bid');";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.Parameters.AddWithValue("@FreelancerId", freelancerId);
                    cmd.Parameters.AddWithValue("@BidAmount", bidAmount.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                        throw new ApplicationException("Failed to place bid. Please try again.");
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while creating bid: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<(string clientName, string freelancerName, string name, string description, decimal budget, DateTime deadline, string skills, string projectStatus, int projectId, decimal bidAmount, string bidStatus)> getBidList(int userId, bool isClient, int? projectId = null)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                string query = @"
                    SELECT 
                        c_user.username AS clientName,
                        f_user.username AS freelancerName,
                        p.name,
                        p.description,
                        p.budget,
                        p.deadline,
                        p.skills,
                        p.status AS projectStatus,
                        p.id AS projectId,
                        b.bid_amount AS bidAmount,
                        b.status AS bidStatus
                    FROM Bids b
                    INNER JOIN Projects p ON p.id = b.project_id
                    INNER JOIN Users c_user ON c_user.id = p.client_id
                    INNER JOIN Users f_user ON f_user.id = b.freelancer_id
                    WHERE ";

                query += isClient ? "p.client_id = @UserId" : "b.freelancer_id = @UserId";
                if (projectId != null)
                {
                    query += " AND p.id = @ProjectId";
                }

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    if (projectId != null)
                        cmd.Parameters.AddWithValue("@ProjectId", projectId);

                    var bidList = new List<(string, string, string, string, decimal, DateTime, string, string, int, decimal, string)>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string clientName = reader.GetString("clientName");
                            string freelancerName = reader.GetString("freelancerName");
                            string name = reader.GetString("name");
                            string description = reader.GetString("description");
                            decimal budget = reader.GetDecimal("budget");
                            DateTime deadline = reader.GetDateTime("deadline");
                            string skills = reader.GetString("skills");
                            string projectStatus = reader.GetString("projectStatus");
                            int projectIdVal = reader.GetInt32("projectId");
                            decimal bidAmount = reader.GetDecimal("bidAmount");
                            string bidStatus = reader.GetString("bidStatus");

                            bidList.Add((clientName, freelancerName, name, description, budget, deadline, skills, projectStatus, projectIdVal, bidAmount, bidStatus));
                        }
                    }

                    return bidList;
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while fetching bid list: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void respondBid(int projectId, int bidId, bool approved)
        {
            try
            {
                var conn = DatabaseService.GetConnection();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string checkBidQuery = "SELECT status FROM Bids WHERE id = @BidId AND project_id = @ProjectId;";
                        string currentStatus;
                        using (var cmdCheck = new MySqlCommand(checkBidQuery, conn, transaction))
                        {
                            cmdCheck.Parameters.AddWithValue("@BidId", bidId);
                            cmdCheck.Parameters.AddWithValue("@ProjectId", projectId);

                            var result = cmdCheck.ExecuteScalar();
                            if (result == null)
                                throw new ApplicationException("Bid not found for the given project.");

                            currentStatus = result.ToString()!;
                            if (currentStatus != "bid")
                                throw new ApplicationException("This bid has already been responded to.");
                        }

                        string updateBidQuery = @"
                                    UPDATE Bids
                                    SET status = @Status
                                    WHERE id = @BidId AND project_id = @ProjectId;";

                        using (var cmd = new MySqlCommand(updateBidQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Status", approved ? "approved" : "rejected");
                            cmd.Parameters.AddWithValue("@BidId", bidId);
                            cmd.Parameters.AddWithValue("@ProjectId", projectId);
                            cmd.ExecuteNonQuery();
                        }

                        if (approved)
                        {
                            string rejectOthersQuery = @"
                                    UPDATE Bids
                                    SET status = 'rejected'
                                    WHERE project_id = @ProjectId AND id != @BidId;";
                            using (var cmdReject = new MySqlCommand(rejectOthersQuery, conn, transaction))
                            {
                                cmdReject.Parameters.AddWithValue("@ProjectId", projectId);
                                cmdReject.Parameters.AddWithValue("@BidId", bidId);
                                cmdReject.ExecuteNonQuery();
                            }

                            int freelancerId;
                            string getFreelancerQuery = "SELECT freelancer_id FROM Bids WHERE id = @BidId;";
                            using (var cmdGet = new MySqlCommand(getFreelancerQuery, conn, transaction))
                            {
                                cmdGet.Parameters.AddWithValue("@BidId", bidId);
                                freelancerId = Convert.ToInt32(cmdGet.ExecuteScalar()!);
                            }

                            string updateProjectQuery = @"
                                    UPDATE Projects
                                    SET status = 'in_progress',
                                        freelancer_id = @FreelancerId
                                    WHERE id = @ProjectId;";
                            using (var cmdProj = new MySqlCommand(updateProjectQuery, conn, transaction))
                            {
                                cmdProj.Parameters.AddWithValue("@FreelancerId", freelancerId);
                                cmdProj.Parameters.AddWithValue("@ProjectId", projectId);
                                cmdProj.ExecuteNonQuery();
                            }
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
                throw new ApplicationException("Database error while responding to bid: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void updateProjectStatus(int projectId, string newStatus /* completed, closed */)
        {
            var conn = DatabaseService.GetConnection();

            using (var transaction = conn.BeginTransaction())
            {
                try
                {
                    string checkStatusQuery = "SELECT status FROM Projects WHERE id = @ProjectId;";
                    string currentStatus;
                    using (var cmdCheck = new MySqlCommand(checkStatusQuery, conn, transaction))
                    {
                        cmdCheck.Parameters.AddWithValue("@ProjectId", projectId);
                        var result = cmdCheck.ExecuteScalar();
                        if (result == null)
                            throw new ApplicationException("Project not found.");

                        currentStatus = result.ToString()!;
                        if (currentStatus != "posted")
                            throw new ApplicationException("Project status can only be updated if it is currently 'posted'.");
                    }

                    string updateProjectQuery = @"
                            UPDATE Projects
                            SET status = @Status
                            WHERE id = @ProjectId;";

                    using (var cmd = new MySqlCommand(updateProjectQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Status", newStatus);
                        cmd.Parameters.AddWithValue("@ProjectId", projectId);
                        cmd.ExecuteNonQuery();
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

        public void giveReview(int projectId, int rating, string comment)
        {
            try
            {
                if (rating < 0 || rating > 5)
                    throw new ApplicationException("Rating must be between 0 and 5.");

                var conn = DatabaseService.GetConnection();

                string checkQuery = "SELECT COUNT(*) FROM Reviews WHERE project_id = @ProjectId";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@ProjectId", projectId);
                    long existingCount = (long)checkCmd.ExecuteScalar();

                    if (existingCount > 0)
                        throw new ApplicationException("A review has already been submitted for this project.");
                }

                string insertQuery = @"
                        INSERT INTO Reviews (project_id, rating, comment, created_at)
                        VALUES (@ProjectId, @Rating, @Comment, NOW())";

                using (var cmd = new MySqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);
                    cmd.Parameters.AddWithValue("@Rating", rating);
                    cmd.Parameters.AddWithValue("@Comment", comment ?? string.Empty);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw new ApplicationException("Database error while submitting review: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
