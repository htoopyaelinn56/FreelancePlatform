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
    public partial class BrowseProjectsForm : BaseForm
    {
        private int userId;
        private Repository repository = new Repository();
        public BrowseProjectsForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void BrowseProjectsForm_Load(object sender, EventArgs e)
        {
            projectsGrid.ColumnCount = 8;
            projectsGrid.Columns[0].Name = "ID";
            projectsGrid.Columns[0].FillWeight = 40;
            projectsGrid.Columns[1].Name = "Name";
            projectsGrid.Columns[2].Name = "Description";
            projectsGrid.Columns[3].Name = "Deadline";
            projectsGrid.Columns[4].Name = "Budget ($)";
            projectsGrid.Columns[5].Name = "Required Skill";
            projectsGrid.Columns[6].Name = "Client Name";
            projectsGrid.Columns[7].Name = "Action";

            projectsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            projectsGrid.RowTemplate.Height = 50;
            projectsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            projectsGrid.MultiSelect = false;
            projectsGrid.RowHeadersVisible = false;
            projectsGrid.AllowUserToAddRows = false;

            setData();
        }

        void setData()
        {
            try
            {
                var postedProjects = repository.getProjectList(null, false, searchTextField.Text);

                projectsGrid.Rows.Clear();

                foreach (var project in postedProjects)
                {
                    projectsGrid.Rows.Add(
                        project.projectId,
                        project.name,
                        project.description,
                        project.deadline.ToString("yyyy-MM-dd"),
                        project.budget.ToString("C"), 
                        project.skills,
                        project.clientName,
                        "View"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void projectsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If Action button clicked
            if (e.RowIndex >= 0 && e.ColumnIndex == projectsGrid.Columns["Action"].Index)
            {
                string projectId = projectsGrid.Rows[e.RowIndex].Cells["ID"].Value.ToString() ?? "";
                int projectIdInInteger = int.Parse(projectId);
                this.Hide();
                var projectDetail = new ProjectDetailForm(userId: this.userId, isClient: false, projectId: projectIdInInteger, fromBrowseProjects: true);
                projectDetail.Show();

            }
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var freelancerProfileForm = new FreelancerProfileForm(this.userId);
            freelancerProfileForm.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            BrowseProjectsForm_Load(sender, e);
        }
    }
}
