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
    public partial class ProjectDetailForm : BaseForm
    {
        private int userId;
        private bool isClient; // else isFreelancer
        private int projectId;
        private bool fromBidAgreement;
        private bool fromBrowseProjects;
        public ProjectDetailForm(int userId, bool isClient, int projectId, bool fromBidAgreement = false, bool fromBrowseProjects = false)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
            this.projectId = projectId;
            this.fromBidAgreement = fromBidAgreement;
            this.fromBrowseProjects = fromBrowseProjects;
        }

        private void ProjectDetailForm_Load(object sender, EventArgs e)
        {
            if (!this.isClient)
            {
                this.bidAmountValue.Visible = false;
                this.bidAmountDropdown.Visible = true;
                this.bidAmountPerHourLabel.Visible = true;
                this.reviewButton.Visible = false;
                this.bidButton.Visible = true;

                // show when coming from dashboard
                // this.completeButton.Visible = true;
            }
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (this.fromBidAgreement)
            {
                var bidAgreementForm = new BidAgreementForm(this.userId, this.isClient);
                bidAgreementForm.Show();
            }
            else if (this.fromBrowseProjects)
            {
                var browseProjetsForm = new BrowseProjectsForm(this.userId);
                browseProjetsForm.Show();
            }
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reviewForm = new ProjectReviewForm(this.userId, this.projectId);
            reviewForm.Show();
        }

        private void bidButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Bidded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var browseProjetsForm = new BrowseProjectsForm(this.userId);
            browseProjetsForm.Show();
        }
    }
}
