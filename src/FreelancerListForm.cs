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
    public partial class FreelancerListForm : BaseForm
    {
        private int userId;

        public FreelancerListForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FreelancerListForm_Load(object sender, EventArgs e)
        {
            freelancerDataGrid.ColumnCount = 6;
            freelancerDataGrid.Columns[0].Name = "ID";
            freelancerDataGrid.Columns[0].FillWeight = 30;
            freelancerDataGrid.Columns[1].Name = "Name";
            freelancerDataGrid.Columns[2].Name = "Skills";
            freelancerDataGrid.Columns[3].Name = "Expertise";
            freelancerDataGrid.Columns[4].Name = "Portfolio";
            freelancerDataGrid.Columns[5].Name = "Past Work";

            freelancerDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            freelancerDataGrid.RowTemplate.Height = 50;
            freelancerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            freelancerDataGrid.MultiSelect = false;
            freelancerDataGrid.RowHeadersVisible = false;
            freelancerDataGrid.AllowUserToAddRows = false;

            AddSampleData();
        }

        private void AddSampleData()
        {
            freelancerDataGrid.Rows.Add("1", "Alice Smith", "Flutter, Dart", "Mobile App Dev", "github.com/alice/flutterapp", "Food Delivery App");
            freelancerDataGrid.Rows.Add("2", "John Doe", "React, Node.js", "Fullstack Dev", "johnportfolio.com", "E-Commerce Platform");
            freelancerDataGrid.Rows.Add("3", "Emma Lee", "UI/UX, Figma", "Design", "behance.net/emma", "Dashboard Design");
            freelancerDataGrid.Rows.Add("4", "Michael Chan", "Python, ML", "Data Science", "mikechan.dev", "Prediction Model Project");
        }

        private void backArrowLabel_Click(object sender, EventArgs e)
        {
            this.Close();
            var clientProfileForm = new ClientProfileForm(userId);
            clientProfileForm.Show();
        }

        private void freelancerDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = freelancerDataGrid.Rows[e.RowIndex];
                string freelancerName = row.Cells["Name"].Value?.ToString() ?? "";
                MessageBox.Show($"You clicked on: {freelancerName}");
            }
        }
    }
}
