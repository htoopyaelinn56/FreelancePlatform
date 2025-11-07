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
        public BidAgreementForm(int userId, bool isClient)
        {
            InitializeComponent();
            this.userId = userId;
            this.isClient = isClient;
        }

        private void BidAgreementForm_Load(object? sender, EventArgs? e)
        {
            bidAgreementDataGrid.ColumnCount = 9 - (isClient ? 0 : 2);
            bidAgreementDataGrid.Columns[0].Name = "ID";
            bidAgreementDataGrid.Columns[0].FillWeight = 40;
            bidAgreementDataGrid.Columns[1].Name = "Title";
            bidAgreementDataGrid.Columns[2].Name = "Description";
            bidAgreementDataGrid.Columns[3].Name = "Deadline";
            bidAgreementDataGrid.Columns[4].Name = "Budget ($)";
            bidAgreementDataGrid.Columns[5].Name = "Required Skill";
            bidAgreementDataGrid.Columns[6].Name = "Status";

            if (this.isClient)
            {
                bidAgreementDataGrid.Columns[7].Name = "Action 1";
                bidAgreementDataGrid.Columns[8].Name = "Action 2";
            }

            bidAgreementDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            bidAgreementDataGrid.RowTemplate.Height = 50;
            bidAgreementDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bidAgreementDataGrid.MultiSelect = false;
            bidAgreementDataGrid.RowHeadersVisible = false;
            bidAgreementDataGrid.AllowUserToAddRows = false;

            AddSampleData();
        }

        private void AddSampleData()
        {
            bidAgreementDataGrid.Rows.Clear();
            // Sample rows
            string[,] sampleData = new string[,]
            {
        { "1", "Website Design", "Design a website for shop", "2025-12-10", "500", "UI/UX", "posted" },
        { "2", "Mobile App", "Flutter app for e-commerce", "2025-12-20", "1000", "Flutter,Dart", "bidded" },
        { "3", "Data Analysis", "Analyze sales data", "2025-11-30", "300", "Python,ML", "confirmed" },
        { "4", "Logo Design", "Logo for new brand", "2025-12-05", "100", "Design,Illustrator", "completed" }
            };

            for (int i = 0; i < sampleData.GetLength(0); i++)
            {
                int rowIndex = bidAgreementDataGrid.Rows.Add(
                    sampleData[i, 0], sampleData[i, 1], sampleData[i, 2],
                    sampleData[i, 3], sampleData[i, 4], sampleData[i, 5],
                    sampleData[i, 6] // Status
                );

                // Set dynamic actions if client
                if (this.isClient)
                {
                    string status = sampleData[i, 6];
                    DataGridViewRow row = bidAgreementDataGrid.Rows[rowIndex];

                    if (status == "bidded")
                    {
                        row.Cells["Action 1"].Value = "Accept";
                        row.Cells["Action 2"].Value = "Reject";
                    }
                    else if (status == "posted" || status == "confirmed" || status == "completed")
                    {
                        row.Cells["Action 1"].Value = "Details";
                        row.Cells["Action 2"].Value = "Remove";
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
                if (status == "bidded")
                {
                    // Accept button
                    MessageBox.Show($"Accepted bid for project ID: {projectId}");
                }
                else if (status == "posted" || status == "confirmed" || status == "completed")
                {
                    // Details button
                    MessageBox.Show($"Viewing details for project ID: {projectId}");

                }
            }
            else if (buttonName == "Action 2")
            {
                if (status == "bidded")
                {
                    // Reject button
                    MessageBox.Show($"Rejected bid for project ID: {projectId}");
                }
                else if (status == "confirmed")
                {
                    MessageBox.Show("You can\'t remove the ongoing project. You can remove when the project is Completed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (status == "posted" || status == "completed")
                {
                    // Remove button (soft delete)
                    MessageBox.Show($"Removed project ID: {projectId} from listings");
                }
            }


            BidAgreementForm_Load(null, null);
        }
    }
}
