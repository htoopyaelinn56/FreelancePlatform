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
    }
}
