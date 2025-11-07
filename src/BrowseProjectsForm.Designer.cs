namespace FreelancePlatform.src
{
    partial class BrowseProjectsForm
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
            browseProjectLabel = new Label();
            searchButton = new Button();
            searchTextField = new TextBox();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(16, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 42;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // browseProjectLabel
            // 
            browseProjectLabel.AutoSize = true;
            browseProjectLabel.Font = new Font("JetBrains Mono Medium", 16F);
            browseProjectLabel.Location = new Point(53, 9);
            browseProjectLabel.Name = "browseProjectLabel";
            browseProjectLabel.Size = new Size(255, 36);
            browseProjectLabel.TabIndex = 41;
            browseProjectLabel.Text = "Browse Projects";
            browseProjectLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(699, 19);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(94, 29);
            searchButton.TabIndex = 44;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // searchTextField
            // 
            searchTextField.Location = new Point(486, 18);
            searchTextField.Name = "searchTextField";
            searchTextField.Size = new Size(207, 29);
            searchTextField.TabIndex = 43;
            // 
            // BrowseProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(searchButton);
            Controls.Add(searchTextField);
            Controls.Add(backArrowLabel);
            Controls.Add(browseProjectLabel);
            Name = "BrowseProjectsForm";
            Text = "Browse Projects";
            Load += BrowseProjectsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label browseProjectLabel;
        private Button searchButton;
        private TextBox searchTextField;
    }
}