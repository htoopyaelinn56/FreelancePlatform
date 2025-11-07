using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreelancePlatform.src
{
    public partial class ClientProfileEditForm : BaseForm
    {
        private int userId;
        private Repository repository = new Repository();
        public ClientProfileEditForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ClientProfileEditForm_Load(object sender, EventArgs e)
        {
            GetClientProfileData();
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var clientProfile = new ClientProfileForm(this.userId);
            clientProfile.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                repository.editClientProfile(
                    this.userId,
                    nameTextBox.Text,
                    emailTextBox.Text,
                    phoneTextBox.Text,
                    companyNameTextBox.Text,
                    addressTextBox.Text
                );
                MessageBox.Show("Profile edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var clientProfile = new ClientProfileForm(this.userId);
                clientProfile.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetClientProfileData()
        {
            try
            {
                var result = repository.getClientProfileData(userId);
                nameTextBox.Text = result.username;
                emailTextBox.Text = result.email;
                phoneTextBox.Text = result.phone;
                companyNameTextBox.Text = result.companyName;
                addressTextBox.Text = result.address;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving profile data: " + ex.Message);

            }
        }
    }
}
