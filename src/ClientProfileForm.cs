using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FreelancePlatform.src
{
    public partial class ClientProfileForm : BaseForm
    {
        private int userId;
        private Repository repository = new Repository();
        public ClientProfileForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ClientProfileForm_Load(object sender, EventArgs e)
        {
            GetClientProfileData();
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editForm = new ClientProfileEditForm(userId);
            editForm.Show();
        }

        private void postProjectButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var postProjectForm = new PostProjectForm(userId);
            postProjectForm.Show();
        }

        private void viewFreelancerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var freelancerListForm = new FreelancerListForm(userId);
            freelancerListForm.Show();
        }

        private void bidProjectsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var bidAgreementForm = new BidAgreementForm(userId, true);
            bidAgreementForm.Show();
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            // logout
            var authenticationForm = new AuthenticationForm();
            authenticationForm.Show();
        }

        private void GetClientProfileData()
        {
            try
            {
                var result = repository.getClientProfileData(userId);
                nameValue.Text = result.username;
                emailValue.Text = result.email;
                phoneValue.Text = result.phone;
                companyNameValue.Text = result.companyName;
                addressValue.Text = result.address;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving profile data: " + ex.Message);

            }
        }
    }
}
