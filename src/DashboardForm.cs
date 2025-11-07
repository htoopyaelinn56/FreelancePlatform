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
    public partial class DashboardForm : BaseForm
    {
        private int userId;
        public DashboardForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Close();
            var freelancerProfileForm = new FreelancerProfileForm(this.userId);
            freelancerProfileForm.Show();
        }
    }
}
