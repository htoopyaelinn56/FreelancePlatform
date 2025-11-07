namespace FreelancePlatform.src
{
    partial class FreelancerProfileForm
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
            freelancerProfileLabel = new Label();
            nameLabel = new Label();
            skillsLabel = new Label();
            expertiseLabel = new Label();
            portfolioLabel = new Label();
            pastWorkLabel = new Label();
            nameValue = new Label();
            skillsValue = new Label();
            expertiseValue = new Label();
            portfolioValue = new Label();
            pastWorkValue = new Label();
            editProfileButton = new Button();
            dashboardButton = new Button();
            biddedProjectsButton = new Button();
            browseProjectsButton = new Button();
            backArrowLabel = new Label();
            SuspendLayout();
            // 
            // freelancerProfileLabel
            // 
            freelancerProfileLabel.AutoSize = true;
            freelancerProfileLabel.Font = new Font("JetBrains Mono Medium", 16F);
            freelancerProfileLabel.Location = new Point(48, 9);
            freelancerProfileLabel.Name = "freelancerProfileLabel";
            freelancerProfileLabel.Size = new Size(303, 36);
            freelancerProfileLabel.TabIndex = 0;
            freelancerProfileLabel.Text = "Freelancer Profile";
            freelancerProfileLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 62);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 22);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Name";
            // 
            // skillsLabel
            // 
            skillsLabel.AutoSize = true;
            skillsLabel.Location = new Point(12, 93);
            skillsLabel.Name = "skillsLabel";
            skillsLabel.Size = new Size(70, 22);
            skillsLabel.TabIndex = 2;
            skillsLabel.Text = "Skills";
            // 
            // expertiseLabel
            // 
            expertiseLabel.AutoSize = true;
            expertiseLabel.Location = new Point(12, 125);
            expertiseLabel.Name = "expertiseLabel";
            expertiseLabel.Size = new Size(100, 22);
            expertiseLabel.TabIndex = 3;
            expertiseLabel.Text = "Expertise";
            // 
            // portfolioLabel
            // 
            portfolioLabel.AutoSize = true;
            portfolioLabel.Location = new Point(12, 157);
            portfolioLabel.Name = "portfolioLabel";
            portfolioLabel.Size = new Size(100, 22);
            portfolioLabel.TabIndex = 4;
            portfolioLabel.Text = "Portfolio";
            // 
            // pastWorkLabel
            // 
            pastWorkLabel.AutoSize = true;
            pastWorkLabel.Location = new Point(12, 190);
            pastWorkLabel.Name = "pastWorkLabel";
            pastWorkLabel.Size = new Size(100, 22);
            pastWorkLabel.TabIndex = 5;
            pastWorkLabel.Text = "Past Work";
            // 
            // nameValue
            // 
            nameValue.AutoSize = true;
            nameValue.Location = new Point(191, 190);
            nameValue.Name = "nameValue";
            nameValue.Size = new Size(160, 22);
            nameValue.TabIndex = 10;
            nameValue.Text = "Past Work Value";
            // 
            // skillsValue
            // 
            skillsValue.AutoSize = true;
            skillsValue.Location = new Point(191, 157);
            skillsValue.Name = "skillsValue";
            skillsValue.Size = new Size(160, 22);
            skillsValue.TabIndex = 9;
            skillsValue.Text = "Portfolio Value";
            // 
            // expertiseValue
            // 
            expertiseValue.AutoSize = true;
            expertiseValue.Location = new Point(191, 125);
            expertiseValue.Name = "expertiseValue";
            expertiseValue.Size = new Size(170, 22);
            expertiseValue.TabIndex = 8;
            expertiseValue.Text = "Experience Value";
            // 
            // portfolioValue
            // 
            portfolioValue.AutoSize = true;
            portfolioValue.Location = new Point(191, 93);
            portfolioValue.Name = "portfolioValue";
            portfolioValue.Size = new Size(130, 22);
            portfolioValue.TabIndex = 7;
            portfolioValue.Text = "Skills Value";
            // 
            // pastWorkValue
            // 
            pastWorkValue.AutoSize = true;
            pastWorkValue.Location = new Point(191, 62);
            pastWorkValue.Name = "pastWorkValue";
            pastWorkValue.Size = new Size(110, 22);
            pastWorkValue.TabIndex = 6;
            pastWorkValue.Text = "Name Value";
            // 
            // editProfileButton
            // 
            editProfileButton.Location = new Point(12, 256);
            editProfileButton.Name = "editProfileButton";
            editProfileButton.Size = new Size(165, 29);
            editProfileButton.TabIndex = 11;
            editProfileButton.Text = "Edit Profile";
            editProfileButton.UseVisualStyleBackColor = true;
            editProfileButton.Click += editProfileButton_Click;
            // 
            // dashboardButton
            // 
            dashboardButton.Location = new Point(183, 256);
            dashboardButton.Name = "dashboardButton";
            dashboardButton.Size = new Size(115, 29);
            dashboardButton.TabIndex = 12;
            dashboardButton.Text = "Dashboard";
            dashboardButton.UseVisualStyleBackColor = true;
            // 
            // biddedProjectsButton
            // 
            biddedProjectsButton.Location = new Point(304, 256);
            biddedProjectsButton.Name = "biddedProjectsButton";
            biddedProjectsButton.Size = new Size(187, 29);
            biddedProjectsButton.TabIndex = 13;
            biddedProjectsButton.Text = "Bidded Projects";
            biddedProjectsButton.UseVisualStyleBackColor = true;
            biddedProjectsButton.Click += biddedProjectsButton_Click;
            // 
            // browseProjectsButton
            // 
            browseProjectsButton.Location = new Point(497, 256);
            browseProjectsButton.Name = "browseProjectsButton";
            browseProjectsButton.Size = new Size(181, 29);
            browseProjectsButton.TabIndex = 14;
            browseProjectsButton.Text = "Browse Projects";
            browseProjectsButton.UseVisualStyleBackColor = true;
            browseProjectsButton.Click += browseProjectsButton_Click;
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(12, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 35;
            backArrowLabel.Text = "←";
            backArrowLabel.Visible = false;
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // FreelancerProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backArrowLabel);
            Controls.Add(browseProjectsButton);
            Controls.Add(biddedProjectsButton);
            Controls.Add(dashboardButton);
            Controls.Add(editProfileButton);
            Controls.Add(nameValue);
            Controls.Add(skillsValue);
            Controls.Add(expertiseValue);
            Controls.Add(portfolioValue);
            Controls.Add(pastWorkValue);
            Controls.Add(pastWorkLabel);
            Controls.Add(portfolioLabel);
            Controls.Add(expertiseLabel);
            Controls.Add(skillsLabel);
            Controls.Add(nameLabel);
            Controls.Add(freelancerProfileLabel);
            Name = "FreelancerProfileForm";
            Text = "Freelancer Profile";
            Load += FreelancerProfileForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label freelancerProfileLabel;
        private Label nameLabel;
        private Label skillsLabel;
        private Label expertiseLabel;
        private Label portfolioLabel;
        private Label pastWorkLabel;
        private Label nameValue;
        private Label skillsValue;
        private Label expertiseValue;
        private Label portfolioValue;
        private Label pastWorkValue;
        private Button editProfileButton;
        private Button dashboardButton;
        private Button biddedProjectsButton;
        private Button browseProjectsButton;
        private Label backArrowLabel;
    }
}