namespace FreelancePlatform.src
{
    partial class ProjectDetailForm
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
            projectDetailLabel = new Label();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(13, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 42;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // projectDetailLabel
            // 
            projectDetailLabel.AutoSize = true;
            projectDetailLabel.Font = new Font("JetBrains Mono Medium", 16F);
            projectDetailLabel.Location = new Point(50, 9);
            projectDetailLabel.Name = "projectDetailLabel";
            projectDetailLabel.Size = new Size(239, 36);
            projectDetailLabel.TabIndex = 41;
            projectDetailLabel.Text = "Project Detail";
            projectDetailLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ProjectDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backArrowLabel);
            Controls.Add(projectDetailLabel);
            Name = "ProjectDetailForm";
            Text = "Project Detail";
            Load += ProjectDetailForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label projectDetailLabel;
    }
}