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
        private bool isClient;
        public DashboardForm(int userId, bool isClient)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
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

            // Add dummy data
            projectsGrid.Rows.Add("1", "Website Design", "Design a modern website", "2025-11-15", "500", "UI/UX", "Alice", "View");
            projectsGrid.Rows.Add("2", "Mobile App", "Develop a Flutter app", "2025-12-01", "1200", "Flutter, Firebase", "Bob", "View");
            projectsGrid.Rows.Add("3", "Data Analysis", "Analyze sales data", "2025-11-30", "800", "Python, Pandas", "Charlie", "View");
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (isClient)
            {
                var clientProfileForm = new ClientProfileForm(this.userId);
                clientProfileForm.Show();
            }
            else
            {
                var freelancerProfileForm = new FreelancerProfileForm(this.userId);
                freelancerProfileForm.Show();
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
                var projectDetail = new ProjectDetailForm(userId: this.userId, isClient: this.isClient, projectId: projectIdInInteger, fromDashboard: true);
                projectDetail.Show();

            }
        }
    }
}
