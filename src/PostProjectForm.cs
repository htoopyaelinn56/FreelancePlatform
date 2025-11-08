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
    public partial class PostProjectForm : BaseForm
    {
        private int userId;
        private Repository repository = new Repository();
        public PostProjectForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void PostProjectForm_Load(object sender, EventArgs e)
        {

        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var clientProfile = new ClientProfileForm(this.userId);
            clientProfile.Show();
        }

        private void postButton_Click(object sender, EventArgs e)
        {
            try
            {
                repository.postProject(
                    this.userId,
                    nameTextBox.Text,
                    descriptionTextBox.Text,
                    budgetNumericDropdown.Value,
                    deadlineDatePicker.Value, 
                    skillsTextBox.Text
                );
                MessageBox.Show("Project posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var clientProfileForm = new ClientProfileForm(this.userId);
                clientProfileForm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
