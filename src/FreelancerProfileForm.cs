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
        public FreelancerProfileForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FreelancerProfileForm_Load(object sender, EventArgs e)
        {

        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var editForm = new FreelancerProfileEditForm(this.userId);
            editForm.Show();
        }
    }
}
