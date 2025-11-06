namespace FreelancePlatform.src
{
    partial class FreelancerListForm
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
            freelancersLabel = new Label();
            searchTextField = new TextBox();
            searchButton = new Button();
            freelancerDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)freelancerDataGrid).BeginInit();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(17, 10);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 38;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // freelancersLabel
            // 
            freelancersLabel.AutoSize = true;
            freelancersLabel.Font = new Font("JetBrains Mono Medium", 16F);
            freelancersLabel.Location = new Point(54, 10);
            freelancersLabel.Name = "freelancersLabel";
            freelancersLabel.Size = new Size(191, 36);
            freelancersLabel.TabIndex = 37;
            freelancersLabel.Text = "Freelancers";
            freelancersLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchTextField
            // 
            searchTextField.Location = new Point(481, 16);
            searchTextField.Name = "searchTextField";
            searchTextField.Size = new Size(207, 29);
            searchTextField.TabIndex = 39;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(694, 17);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(94, 29);
            searchButton.TabIndex = 40;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // freelancerDataGrid
            // 
            freelancerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            freelancerDataGrid.Location = new Point(12, 65);
            freelancerDataGrid.Name = "freelancerDataGrid";
            freelancerDataGrid.RowHeadersWidth = 51;
            freelancerDataGrid.Size = new Size(776, 373);
            freelancerDataGrid.TabIndex = 41;
            freelancerDataGrid.CellClick += freelancerDataGrid_CellClick;
            // 
            // FreelancerListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(freelancerDataGrid);
            Controls.Add(searchButton);
            Controls.Add(searchTextField);
            Controls.Add(backArrowLabel);
            Controls.Add(freelancersLabel);
            Name = "FreelancerListForm";
            Text = "Freelancer List";
            Load += FreelancerListForm_Load;
            ((System.ComponentModel.ISupportInitialize)freelancerDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label freelancersLabel;
        private TextBox searchTextField;
        private Button searchButton;
        private DataGridView freelancerDataGrid;
    }
}