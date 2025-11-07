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
    public partial class ProjectReviewForm : BaseForm
    {
        private int userId;
        private int projectId;
        public ProjectReviewForm(int userId, int projectId)
        {
            InitializeComponent();
            this.userId = userId;
            this.projectId = projectId;
        }

        private void ProjectReviewForm_Load(object sender, EventArgs e)
        {

        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Close();
            var projectDetailForm = new ProjectDetailForm(userId: this.userId, isClient: true, projectId: this.projectId, fromBidAgreement: true);
            projectDetailForm.Show();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Review given successully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var projectDetailForm = new ProjectDetailForm(userId: this.userId, isClient: true, projectId: this.projectId, fromBidAgreement: true);
            projectDetailForm.Show();
        }
    }
}
