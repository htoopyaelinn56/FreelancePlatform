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
    public partial class ProjectDetailForm : Form
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

        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();

            if(this.fromBidAgreement)
            {
                var bidAgreementForm = new BidAgreementForm(this.userId, this.isClient);
                bidAgreementForm.Show();
            }    
        }
    }
}
