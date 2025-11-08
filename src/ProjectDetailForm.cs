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
        private bool fromDashboard;
        private Repository repository = new Repository();
        public ProjectDetailForm(int userId, bool isClient, int projectId, bool fromBidAgreement = false, bool fromBrowseProjects = false, bool fromDashboard = false)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
            this.projectId = projectId;
            this.fromBidAgreement = fromBidAgreement;
            this.fromBrowseProjects = fromBrowseProjects;
            this.fromDashboard = fromDashboard;
        }

        private void ProjectDetailForm_Load(object sender, EventArgs e)
        {
            setData();
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
            else if (this.fromDashboard)
            {
                var dashboardForm = new DashboardForm(this.userId, this.isClient);
                dashboardForm.Show();
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
            try
            {
                repository.createBidForProject(this.projectId, this.userId, bidAmountDropdown.Value);
                MessageBox.Show("Bid successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var browseProjetsForm = new BrowseProjectsForm(this.userId);
                browseProjetsForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void completeOrCloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                var isClose = this.isClient;
                repository.updateProjectStatus(this.projectId, isClose ? "closed" : "completed");
                MessageBox.Show((isClose ? "Closed" : "Completed") + " project successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var browseProjetsForm = new DashboardForm(this.userId, this.isClient);
                browseProjetsForm.Show();
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void setData() 
        { 
            var projectDetails = repository.getProjectDetail(this.projectId);
            nameValue.Text = projectDetails.name;
            descriptionValue.Text = projectDetails.description;
            deadlineValue.Text = projectDetails.deadline.ToString("yyyy-MM-dd");
            bidAmountValue.Text = projectDetails.budget.ToString("C");
            skillFieldValue.Text = projectDetails.skills;
            clientNameValue.Text= projectDetails.clientName;
            freelancerNameValue.Text = projectDetails.freelancerName ?? "";
            statusValue.Text = projectDetails.status;
            descriptionValue.Text = projectDetails.description;
            ratingValue.Text = projectDetails.reviewRating?.ToString() ?? "";
            commentValue.Text = projectDetails.reviewComment ?? "";
            budgetValue.Text = projectDetails.budget.ToString("C");

            var isCompleted = projectDetails.status == "completed";
            var isPosted = projectDetails.status == "posted";
            var isClosed = projectDetails.status == "closed";
            var inProgress = projectDetails.status == "in_progress";

            completeOrCloseButton.Text = isClient ? "Close" : "Complete";


            if (this.isClient)
            {
                completeOrCloseButton.Visible = isPosted;
                reviewButton.Visible = isCompleted;
            }
            else
            {
                this.reviewButton.Visible = false;

                if (this.fromBidAgreement || this.fromBrowseProjects)
                {
                    this.bidButton.Visible = true;
                    this.bidAmountDropdown.Visible = true;
                    this.bidAmountPerHourLabel.Visible = true;
                    this.bidAmountValue.Visible = false;
                }

                if (this.fromDashboard)
                {
                    this.completeOrCloseButton.Visible = true;
                }
            }
        }
    }
}
