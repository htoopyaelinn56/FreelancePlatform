using FreelancePlatform.src;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FreelancePlatform
{
    public partial class AuthenticationForm : BaseForm
    {
        bool showPassword = false;
        public AuthenticationForm()
        {
            InitializeComponent();
            this.Text = "Authentication Form";
        }

        private void AuthenticationForm_Load(object sender, EventArgs e)
        {

        }

        private void showHidePasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            showPassword = !showPassword;
            passwordTextBox.UseSystemPasswordChar = !showPassword;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var validationPass = CheckValidation(false);
            if (validationPass)
            {
                try
                {
                    var result = loginToSystem();
                    var userType = result.userType;
                    var userId = result.userId;

                    switch (userType)
                    {
                        case "client":
                            this.Hide();
                            var clientProfileForm = new ClientProfileForm(userId);
                            clientProfileForm.Show();
                            break;

                        case "freelancer":
                            this.Hide();
                            var freelancerProfileForm = new FreelancerProfileForm(userId);
                            freelancerProfileForm.Show();
                            break;

                        default:
                            MessageBox.Show("Something went wrong with user type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Login failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private String? GetUserType()
        {
            if (!clientRadioButton.Checked && !freelancerRadioButton.Checked)
            {
                return null;
            }
            return clientRadioButton.Checked ? "client" : "freelancer";
        }

        private bool IsPasswordValid(bool isRegister)
        {
            var password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (password.Length < 8 && isRegister)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool CheckValidation(bool isRegister)
        {
            var userType = GetUserType();
            var userName = userNameTextBox.Text;


            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Username cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var passwordValid = IsPasswordValid(isRegister);
            if (!passwordValid)
            {
                return false;
            }

            else if (userType == null && isRegister)
            {
                MessageBox.Show("Please select User Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            var validationPass = CheckValidation(true);
            if (validationPass)
            {
                try
                {
                    registerIntoUserTable();
                    MessageBox.Show("Registeration successful. Please login in again to continue!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Registeration failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void registerIntoUserTable()
        {
            string username = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string userType = GetUserType()!; // "freelancer" or "client", can null check because it is valided before inserting

            try
            {
                var conn = DatabaseService.GetConnection();

                string countQuery = @"
                     SELECT COUNT(*) FROM Users WHERE username = @username;";

                using (var countCmd = new MySqlCommand(countQuery, conn))
                {
                    countCmd.Parameters.AddWithValue("@username", username);
                    var count = Convert.ToInt32(countCmd.ExecuteScalar());
                    if (count != 0)
                    {
                        throw new ApplicationException("Username already exists. Please choose another username.");
                    }

                    string insertQuery = @"
                        INSERT INTO Users (username, password, type)
                        VALUES (@username, @password, @type);";

                    using (var cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@type", userType);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new ApplicationException("Something went wrong with inserting user into database. Please try again!");
                        }
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

        private (int userId, string userType) loginToSystem()
        {
            var userName = userNameTextBox.Text.Trim();
            var password = passwordTextBox.Text.Trim();

            var conn = DatabaseService.GetConnection();
            string query = @"
                    SELECT id, type FROM Users 
                    WHERE username = @username AND password = @password;";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", userName);
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
    }
}
