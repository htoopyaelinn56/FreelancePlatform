namespace FreelancePlatform.src
{
    public partial class FreelancerProfileEditForm : BaseForm
    {
        private int userId;
        private Repository repository = new Repository();
        public FreelancerProfileEditForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FreelancerProfileEditForm_Load(object sender, EventArgs e)
        {
            GetFreelancerProfileData();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                repository.editFreelancerProfile(
                    this.userId,
                    nameTextBox.Text,
                    emailTextBox.Text,
                    phoneTextBox.Text,
                    skillsTextBox.Text,
                    expertiseTextBox.Text,
                    portfolioTextBox.Text,
                    pastWorkTextBox.Text
                );
                MessageBox.Show("Profile edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var freelancerProfileForm = new FreelancerProfileForm(this.userId);
                freelancerProfileForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void backArrowLabel_Click(Object sender, EventArgs e)
        {
            this.Hide();
            var freelancerProfileForm = new FreelancerProfileForm(this.userId);
            freelancerProfileForm.Show();
        }

        private void GetFreelancerProfileData()
        {
            var freelancerData = repository.getFreelancerProfileData(this.userId);
            nameTextBox.Text = freelancerData.username;
            emailTextBox.Text = freelancerData.email;
            phoneTextBox.Text = freelancerData.phone;
            skillsTextBox.Text = freelancerData.skills;
            expertiseTextBox.Text = freelancerData.expertise;
            portfolioTextBox.Text = freelancerData.portfolio;
            pastWorkTextBox.Text = freelancerData.pastwork;
        }
    }
}
