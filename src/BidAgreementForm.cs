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
    public partial class BidAgreementForm : BaseForm
    {
        private int userId;
        private bool isClient; // else isFreelancer
        public BidAgreementForm(int userId, bool isClient)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
        }

        private void BidAgreementForm_Load(object sender, EventArgs e)
        {

        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (isClient)
            {
                var clientProfileForm = new ClientProfileForm(userId);
                clientProfileForm.Show();
            }
            else
            {
                var freelancerProfileForm = new FreelancerProfileForm(userId);
                freelancerProfileForm.Show();
            }
        }
    }
}
