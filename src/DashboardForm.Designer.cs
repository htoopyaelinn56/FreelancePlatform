namespace FreelancePlatform.src
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backArrowLabel = new Label();
            dashboardLabel = new Label();
            projectsGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)projectsGrid).BeginInit();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(13, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 44;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // dashboardLabel
            // 
            dashboardLabel.AutoSize = true;
            dashboardLabel.Font = new Font("JetBrains Mono Medium", 16F);
            dashboardLabel.Location = new Point(50, 9);
            dashboardLabel.Name = "dashboardLabel";
            dashboardLabel.Size = new Size(159, 36);
            dashboardLabel.TabIndex = 43;
            dashboardLabel.Text = "Dashboard";
            dashboardLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // projectsGrid
            // 
            projectsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            projectsGrid.Location = new Point(12, 59);
            projectsGrid.Name = "projectsGrid";
            projectsGrid.RowHeadersWidth = 51;
            projectsGrid.Size = new Size(946, 572);
            projectsGrid.TabIndex = 46;
            projectsGrid.CellClick += projectsGrid_CellClick;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 643);
            Controls.Add(projectsGrid);
            Controls.Add(backArrowLabel);
            Controls.Add(dashboardLabel);
            Name = "DashboardForm";
            Text = "Dashboard Form";
            Load += DashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)projectsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label dashboardLabel;
        private DataGridView projectsGrid;
    }
}