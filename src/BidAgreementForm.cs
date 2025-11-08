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
        private Repository repository = new Repository();
        public BidAgreementForm(int userId, bool isClient)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
        }

        private void BidAgreementForm_Load(object? sender, EventArgs? e)
        {
            bidAgreementDataGrid.ColumnCount = 11 - (isClient ? 0 : 2);
            bidAgreementDataGrid.Columns[0].Name = "ID";
            bidAgreementDataGrid.Columns[0].FillWeight = 40;
            bidAgreementDataGrid.Columns[1].Name = "Title";
            bidAgreementDataGrid.Columns[2].Name = "Description";
            bidAgreementDataGrid.Columns[3].Name = "Deadline";
            bidAgreementDataGrid.Columns[4].Name = "Budget ($)";
            bidAgreementDataGrid.Columns[5].Name = "Bid Amount ($)";
            bidAgreementDataGrid.Columns[6].Name = "Required Skill";
            bidAgreementDataGrid.Columns[7].Name = this.isClient ? "Freelancer" : "Client";
            bidAgreementDataGrid.Columns[8].Name = "Status";

            if (this.isClient)
            {
                bidAgreementDataGrid.Columns[9].Name = "Action 1";
                bidAgreementDataGrid.Columns[10].Name = "Action 2";
            }

            bidAgreementDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bidAgreementDataGrid.RowTemplate.Height = 50;
            bidAgreementDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bidAgreementDataGrid.MultiSelect = false;
            bidAgreementDataGrid.RowHeadersVisible = false;
            bidAgreementDataGrid.AllowUserToAddRows = false;

            setData();
        }

        private void setData()
        {
            bidAgreementDataGrid.Rows.Clear();
            var bidAgreementData = repository.getBidList(userId, isClient);

            if (bidAgreementData == null || bidAgreementData.Count == 0)
                return;

            foreach (var bid in bidAgreementData)
            {
                int rowIndex = bidAgreementDataGrid.Rows.Add(
                    bid.id.ToString(),
                    bid.name,
                    bid.description,
                    bid.deadline.ToString("yyyy-MM-dd"),
                    bid.budget.ToString("C"),
                    bid.bidAmount.ToString("C"),
                    bid.skills,
                    this.isClient ? bid.freelancerName : bid.clientName,
                    bid.bidStatus
                );

                // Set dynamic actions if client
                if (this.isClient)
                {
                    DataGridViewRow row = bidAgreementDataGrid.Rows[rowIndex];
                    string status = bid.bidStatus?.ToLower() ?? "";

                    if (status == "bid")
                    {
                        row.Cells["Action 1"].Value = "Accept";
                        row.Cells["Action 2"].Value = "Reject";
                    }
                    else
                    {
                        row.Cells["Action 1"].Value = "Details";
                    }
                }
            }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !isClient) return;

            DataGridViewRowCollection rows = bidAgreementDataGrid.Rows;
            string projectId = rows[e.RowIndex].Cells["ID"].Value.ToString()!;
            string buttonName = bidAgreementDataGrid.Columns[e.ColumnIndex].Name;
            string status = rows[e.RowIndex].Cells["Status"].Value.ToString()!.ToLower();

            if (buttonName == "Action 1")
            {
                if (status == "bid")
                {
                    // Accept button
                    MessageBox.Show($"Accepted bid for project ID: {projectId}");
                }
                else
                {
                    this.Hide();
                    int projectIdInteger = int.Parse(projectId);
                    var projectDetailForm = new ProjectDetailForm(userId: this.userId, isClient: this.isClient, projectId: projectIdInteger, fromBidAgreement: true);
                    projectDetailForm.Show();
                }
            }
            else if (buttonName == "Action 2")
            {
                if (status == "bid")
                {
                    // Reject button
                    MessageBox.Show($"Rejected bid for project ID: {projectId}");
                }
            }


            BidAgreementForm_Load(sender, e);
        }
    }
}
