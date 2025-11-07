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

namespace FreelancePlatform.src
{
    public partial class ClientProfileForm : BaseForm
    {
        private int userId;
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
            var conn = DatabaseService.GetConnection();

            string query = @"
                SELECT u.id, u.username, u.email, u.phone,
                       c.address, c.company_name
                FROM Users u
                INNER JOIN Clients c ON u.id = c.user_id
                WHERE u.id = @userId;";

            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@userId", this.userId);

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

                        nameValue.Text = username;
                        emailValue.Text = email;
                        phoneValue.Text = phone;
                        companyNameValue.Text = companyName;
                        addressValue.Text = address;

                    }
                }
            }
        }

    }
}
