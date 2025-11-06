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
    public partial class FreelancerProfileForm : BaseForm
    {
        private int userId;

        // variable to put client userId when navigate back to freelancer list
        private int? clientId;
        private bool fromFreelancerList;
        
        public FreelancerProfileForm(int userId, int? clientId = null,  bool fromFreelancerList = false)
        {
            InitializeComponent();
            this.userId = userId;
            this.clientId = clientId;
            this.fromFreelancerList = fromFreelancerList;
        }

        private void FreelancerProfileForm_Load(object sender, EventArgs e)
        {
            if (fromFreelancerList)
            {
                editProfileButton.Visible = false;
                dashboardButton.Visible = false;
                biddedProjectsButton.Visible = false;
                browseProjectsButton.Visible = false;
                backArrowLabel.Visible = true;
            }
        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editForm = new FreelancerProfileEditForm(this.userId);
            editForm.Show();
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var freelancerListForm = new FreelancerListForm((int)this.clientId!);
            freelancerListForm.Show();
        }
    }
}
