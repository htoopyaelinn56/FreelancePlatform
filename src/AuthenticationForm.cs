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
        private Repository repository = new Repository();
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
                    var result = repository.login(userNameTextBox.Text, passwordTextBox.Text);
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
                    repository.register(userNameTextBox.Text, passwordTextBox.Text, GetUserType()!);
                    MessageBox.Show("Registeration successful. Please login in again to continue!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Registeration failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
