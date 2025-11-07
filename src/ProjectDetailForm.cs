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
        public ProjectDetailForm(int userId, bool isClient, int projectId, bool fromBidAgreement)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
            this.projectId = projectId;
            this.fromBidAgreement = fromBidAgreement;
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
                this.completeButton.Visible = true;
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
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reviewForm = new ProjectReviewForm(this.userId, this.projectId);
            reviewForm.Show();
        }
    }
}
