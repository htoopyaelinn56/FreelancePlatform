using System;
using System.Collections.Generic;
using System.ComponentModel;
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
          
        }

        private String? GetUserType()
        {
            if (!clientRadioButton.Checked && !freelancerRadioButton.Checked)
            {
                return null;
            }
            return clientRadioButton.Checked ? "client" : "freelancer";
        }

        private bool IsPasswordValidForRegister()
        {
            var password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
