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
        public ClientProfileEditForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void ClientProfileEditForm_Load(object sender, EventArgs e)
        {

        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var clientProfile = new ClientProfileForm(this.userId);
            clientProfile.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Profile edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var clientProfile = new ClientProfileForm(this.userId);
            clientProfile.Show();
        }
    }
}
