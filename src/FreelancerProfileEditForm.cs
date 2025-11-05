namespace FreelancePlatform.src
{
    public partial class FreelancerProfileEditForm : BaseForm
    {
        private int userId;
        public FreelancerProfileEditForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FreelancerProfileEditForm_Load(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Profile edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var freelancerProfileForm = new FreelancerProfileForm(this.userId);
            freelancerProfileForm.Show();
        }

        private void backArrowLabel_Click(Object sender, EventArgs e) {
            this.Hide();
            var freelancerProfileForm = new FreelancerProfileForm(this.userId);
            freelancerProfileForm.Show();
        }

    }
}
