namespace FreelancePlatform.src
{
    partial class FreelancerProfileEditForm
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
            pastWorkLabel = new Label();
            portfolioLabel = new Label();
            expertiseLabel = new Label();
            skillsLabel = new Label();
            nameLabel = new Label();
            freelancerProfileLabel = new Label();
            nameTextBox = new TextBox();
            skillsTextBox = new TextBox();
            expertiseTextBox = new TextBox();
            portfolioTextBox = new TextBox();
            pastWorkTextBox = new TextBox();
            editButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backArrowLabel = new Label();
            SuspendLayout();
            // 
            // pastWorkLabel
            // 
            pastWorkLabel.AutoSize = true;
            pastWorkLabel.Location = new Point(12, 255);
            pastWorkLabel.Name = "pastWorkLabel";
            pastWorkLabel.Size = new Size(100, 22);
            pastWorkLabel.TabIndex = 16;
            pastWorkLabel.Text = "Past Work";
            // 
            // portfolioLabel
            // 
            portfolioLabel.AutoSize = true;
            portfolioLabel.Location = new Point(12, 222);
            portfolioLabel.Name = "portfolioLabel";
            portfolioLabel.Size = new Size(100, 22);
            portfolioLabel.TabIndex = 15;
            portfolioLabel.Text = "Portfolio";
            // 
            // expertiseLabel
            // 
            expertiseLabel.AutoSize = true;
            expertiseLabel.Location = new Point(12, 190);
            expertiseLabel.Name = "expertiseLabel";
            expertiseLabel.Size = new Size(100, 22);
            expertiseLabel.TabIndex = 14;
            expertiseLabel.Text = "Expertise";
            // 
            // skillsLabel
            // 
            skillsLabel.AutoSize = true;
            skillsLabel.Location = new Point(12, 93);
            skillsLabel.Name = "skillsLabel";
            skillsLabel.Size = new Size(70, 22);
            skillsLabel.TabIndex = 13;
            skillsLabel.Text = "Skills";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 62);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 22);
            nameLabel.TabIndex = 12;
            nameLabel.Text = "Name";
            // 
            // freelancerProfileLabel
            // 
            freelancerProfileLabel.AutoSize = true;
            freelancerProfileLabel.Font = new Font("JetBrains Mono Medium", 16F);
            freelancerProfileLabel.Location = new Point(51, 9);
            freelancerProfileLabel.Name = "freelancerProfileLabel";
            freelancerProfileLabel.Size = new Size(383, 36);
            freelancerProfileLabel.TabIndex = 11;
            freelancerProfileLabel.Text = "Freelancer Profile Edit";
            freelancerProfileLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(190, 62);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(188, 29);
            nameTextBox.TabIndex = 17;
            // 
            // skillsTextBox
            // 
            skillsTextBox.Location = new Point(190, 97);
            skillsTextBox.Multiline = true;
            skillsTextBox.Name = "skillsTextBox";
            skillsTextBox.Size = new Size(267, 80);
            skillsTextBox.TabIndex = 18;
            // 
            // expertiseTextBox
            // 
            expertiseTextBox.Location = new Point(190, 183);
            expertiseTextBox.Name = "expertiseTextBox";
            expertiseTextBox.Size = new Size(188, 29);
            expertiseTextBox.TabIndex = 19;
            // 
            // portfolioTextBox
            // 
            portfolioTextBox.Location = new Point(190, 218);
            portfolioTextBox.Name = "portfolioTextBox";
            portfolioTextBox.Size = new Size(188, 29);
            portfolioTextBox.TabIndex = 20;
            // 
            // pastWorkTextBox
            // 
            pastWorkTextBox.Location = new Point(190, 253);
            pastWorkTextBox.Multiline = true;
            pastWorkTextBox.Name = "pastWorkTextBox";
            pastWorkTextBox.Size = new Size(267, 80);
            pastWorkTextBox.TabIndex = 21;
            // 
            // editButton
            // 
            editButton.Location = new Point(363, 387);
            editButton.Name = "editButton";
            editButton.Size = new Size(94, 29);
            editButton.TabIndex = 22;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += this.editButton_Click;
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(14, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 23;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += this.backArrowLabel_Click;
            // 
            // FreelancerProfileEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backArrowLabel);
            Controls.Add(editButton);
            Controls.Add(pastWorkTextBox);
            Controls.Add(portfolioTextBox);
            Controls.Add(expertiseTextBox);
            Controls.Add(skillsTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(pastWorkLabel);
            Controls.Add(portfolioLabel);
            Controls.Add(expertiseLabel);
            Controls.Add(skillsLabel);
            Controls.Add(nameLabel);
            Controls.Add(freelancerProfileLabel);
            Name = "FreelancerProfileEditForm";
            Text = "Freelancer Profile Edit";
            Load += this.FreelancerProfileEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label pastWorkLabel;
        private Label portfolioLabel;
        private Label expertiseLabel;
        private Label skillsLabel;
        private Label nameLabel;
        private Label freelancerProfileLabel;
        private TextBox nameTextBox;
        private TextBox skillsTextBox;
        private TextBox expertiseTextBox;
        private TextBox portfolioTextBox;
        private TextBox pastWorkTextBox;
        private Button editButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label backArrowLabel;
    }
}