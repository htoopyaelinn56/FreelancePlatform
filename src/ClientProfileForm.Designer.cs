namespace FreelancePlatform.src
{
    partial class ClientProfileForm
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
            postProjectsButton = new Button();
            biddedProjectsButton = new Button();
            viewFreelancerButton = new Button();
            editProfileButton = new Button();
            addressValue = new Label();
            emailValue = new Label();
            phoneValue = new Label();
            nameValue = new Label();
            addressLabel = new Label();
            emailLabel = new Label();
            phoneLabel = new Label();
            nameLabel = new Label();
            freelancerProfileLabel = new Label();
            SuspendLayout();
            // 
            // postProjectsButton
            // 
            postProjectsButton.Location = new Point(565, 256);
            postProjectsButton.Name = "postProjectsButton";
            postProjectsButton.Size = new Size(181, 29);
            postProjectsButton.TabIndex = 29;
            postProjectsButton.Text = "Post Projects";
            postProjectsButton.UseVisualStyleBackColor = true;
            // 
            // biddedProjectsButton
            // 
            biddedProjectsButton.Location = new Point(372, 256);
            biddedProjectsButton.Name = "biddedProjectsButton";
            biddedProjectsButton.Size = new Size(187, 29);
            biddedProjectsButton.TabIndex = 28;
            biddedProjectsButton.Text = "Bidded Projects";
            biddedProjectsButton.UseVisualStyleBackColor = true;
            // 
            // viewFreelancerButton
            // 
            viewFreelancerButton.Location = new Point(183, 256);
            viewFreelancerButton.Name = "viewFreelancerButton";
            viewFreelancerButton.Size = new Size(183, 29);
            viewFreelancerButton.TabIndex = 27;
            viewFreelancerButton.Text = "View Freelancers";
            viewFreelancerButton.UseVisualStyleBackColor = true;
            // 
            // editProfileButton
            // 
            editProfileButton.Location = new Point(12, 256);
            editProfileButton.Name = "editProfileButton";
            editProfileButton.Size = new Size(165, 29);
            editProfileButton.TabIndex = 26;
            editProfileButton.Text = "Edit Profile";
            editProfileButton.UseVisualStyleBackColor = true;
            editProfileButton.Click += editProfileButton_Click;
            // 
            // addressValue
            // 
            addressValue.AutoSize = true;
            addressValue.Location = new Point(191, 157);
            addressValue.Name = "addressValue";
            addressValue.Size = new Size(140, 22);
            addressValue.TabIndex = 24;
            addressValue.Text = "Address Value";
            // 
            // emailValue
            // 
            emailValue.AutoSize = true;
            emailValue.Location = new Point(191, 125);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(120, 22);
            emailValue.TabIndex = 23;
            emailValue.Text = "Email Value";
            // 
            // phoneValue
            // 
            phoneValue.AutoSize = true;
            phoneValue.Location = new Point(191, 93);
            phoneValue.Name = "phoneValue";
            phoneValue.Size = new Size(120, 22);
            phoneValue.TabIndex = 22;
            phoneValue.Text = "Phone Value";
            // 
            // nameValue
            // 
            nameValue.AutoSize = true;
            nameValue.Location = new Point(191, 62);
            nameValue.Name = "nameValue";
            nameValue.Size = new Size(110, 22);
            nameValue.TabIndex = 21;
            nameValue.Text = "Name Value";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(12, 157);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(80, 22);
            addressLabel.TabIndex = 19;
            addressLabel.Text = "Address";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(12, 125);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(60, 22);
            emailLabel.TabIndex = 18;
            emailLabel.Text = "Email";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(12, 93);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(60, 22);
            phoneLabel.TabIndex = 17;
            phoneLabel.Text = "Phone";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 62);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 22);
            nameLabel.TabIndex = 16;
            nameLabel.Text = "Name";
            // 
            // freelancerProfileLabel
            // 
            freelancerProfileLabel.AutoSize = true;
            freelancerProfileLabel.Font = new Font("JetBrains Mono Medium", 16F);
            freelancerProfileLabel.Location = new Point(12, 9);
            freelancerProfileLabel.Name = "freelancerProfileLabel";
            freelancerProfileLabel.Size = new Size(239, 36);
            freelancerProfileLabel.TabIndex = 15;
            freelancerProfileLabel.Text = "Client Profile";
            freelancerProfileLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClientProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(postProjectsButton);
            Controls.Add(biddedProjectsButton);
            Controls.Add(viewFreelancerButton);
            Controls.Add(editProfileButton);
            Controls.Add(addressValue);
            Controls.Add(emailValue);
            Controls.Add(phoneValue);
            Controls.Add(nameValue);
            Controls.Add(addressLabel);
            Controls.Add(emailLabel);
            Controls.Add(phoneLabel);
            Controls.Add(nameLabel);
            Controls.Add(freelancerProfileLabel);
            Name = "ClientProfileForm";
            Text = "Client Profile";
            Load += ClientProfileForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button postProjectsButton;
        private Button biddedProjectsButton;
        private Button viewFreelancerButton;
        private Button editProfileButton;
        private Label addressValue;
        private Label emailValue;
        private Label phoneValue;
        private Label nameValue;
        private Label addressLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label nameLabel;
        private Label freelancerProfileLabel;
    }
}