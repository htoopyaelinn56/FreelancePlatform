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
        private Repository repository = new Repository();

        public FreelancerListForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void FreelancerListForm_Load(object sender, EventArgs e)
        {
            freelancerDataGrid.ColumnCount = 8;
            freelancerDataGrid.Columns[0].Name = "ID";
            freelancerDataGrid.Columns[0].FillWeight = 30;
            freelancerDataGrid.Columns[1].Name = "Name";
            freelancerDataGrid.Columns[2].Name = "Phone";
            freelancerDataGrid.Columns[3].Name = "Email";
            freelancerDataGrid.Columns[4].Name = "Skills";
            freelancerDataGrid.Columns[5].Name = "Expertise";
            freelancerDataGrid.Columns[6].Name = "Portfolio";
            freelancerDataGrid.Columns[7].Name = "Past Work";

            freelancerDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            freelancerDataGrid.RowTemplate.Height = 50;
            freelancerDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            freelancerDataGrid.MultiSelect = false;
            freelancerDataGrid.RowHeadersVisible = false;
            freelancerDataGrid.AllowUserToAddRows = false;

            setData();
        }

        private void setData()
        {
            var freelancers = repository.getFreelancers(searchTextField.Text);
            freelancerDataGrid.Rows.Clear();
            foreach (var freelancer in freelancers)
            {
                freelancerDataGrid.Rows.Add(new string[]
                {
                    freelancer.id.ToString(),
                    freelancer.name,
                    freelancer.phone ?? "",
                    freelancer.email ?? "",
                    freelancer.skills ?? "",
                    freelancer.expertise ?? "",
                    freelancer.portfolio ?? "",
                    freelancer.pastwork ?? ""
                });
            }
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
                string idString = row.Cells["ID"].Value?.ToString() ?? "";
                int id = int.Parse(idString);
                this.Hide();
                var freelancerProfileForm = new FreelancerProfileForm(id, this.userId, true);
                freelancerProfileForm.Show();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            FreelancerListForm_Load(sender, e);
        }
    }
}
