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

        private Repository repository = new Repository();

        public FreelancerProfileForm(int userId, int? clientId = null, bool fromFreelancerList = false)
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
                bidProjectsButton.Visible = false;
                browseProjectsButton.Visible = false;
            }

            GetFreelancerProfileData();
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
            if(this.fromFreelancerList)
            {
                var freelancerListForm = new FreelancerListForm((int)this.clientId!);
                freelancerListForm.Show();
            }
            else /* from authentication form (logout) */
            {
                var authenticationForm = new AuthenticationForm();
                authenticationForm.Show();
            }
        
        }

        private void bidProjectsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var bidAgreementForm = new BidAgreementForm(userId, false);
            bidAgreementForm.Show();
        }

        private void browseProjectsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var browseProjectsForm = new BrowseProjectsForm(userId);
            browseProjectsForm.Show();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dashboardForm = new DashboardForm(userId);
            dashboardForm.Show();
        }

        private void GetFreelancerProfileData()
        {
            var freelancerData = repository.getFreelancerProfileData(this.userId);
            nameValue.Text = freelancerData.username;
            emailValue.Text = freelancerData.email;
            phoneValue.Text = freelancerData.phone;
            skillsValue.Text = freelancerData.skills;
            expertiseValue.Text = freelancerData.expertise;
            portfolioValue.Text = freelancerData.portfolio;
            pastWorkValue.Text = freelancerData.pastwork;
        }
    }
}
