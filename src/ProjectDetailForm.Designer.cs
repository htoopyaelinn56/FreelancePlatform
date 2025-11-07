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
            nameLabel = new Label();
            deadlineLabel = new Label();
            skillFieldLabel = new Label();
            statusLabel = new Label();
            clientNameLabel = new Label();
            bidAmountLabel = new Label();
            freelancerNameLabel = new Label();
            descriptionLabel = new Label();
            descriptionValue = new Label();
            freelancerNameValue = new Label();
            clientNameValue = new Label();
            bidAmountValue = new Label();
            skillFieldValue = new Label();
            statusValue = new Label();
            deadlineValue = new Label();
            nameValue = new Label();
            bidAmountDropdown = new NumericUpDown();
            bidAmountPerHourLabel = new Label();
            reviewButton = new Button();
            bidButton = new Button();
            completeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)bidAmountDropdown).BeginInit();
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
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(50, 60);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 22);
            nameLabel.TabIndex = 43;
            nameLabel.Text = "Name";
            // 
            // deadlineLabel
            // 
            deadlineLabel.AutoSize = true;
            deadlineLabel.Location = new Point(50, 100);
            deadlineLabel.Name = "deadlineLabel";
            deadlineLabel.Size = new Size(90, 22);
            deadlineLabel.TabIndex = 44;
            deadlineLabel.Text = "Deadline";
            // 
            // skillFieldLabel
            // 
            skillFieldLabel.AutoSize = true;
            skillFieldLabel.Location = new Point(50, 220);
            skillFieldLabel.Name = "skillFieldLabel";
            skillFieldLabel.Size = new Size(120, 22);
            skillFieldLabel.TabIndex = 46;
            skillFieldLabel.Text = "Skill Field";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(50, 140);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(70, 22);
            statusLabel.TabIndex = 45;
            statusLabel.Text = "Status";
            // 
            // clientNameLabel
            // 
            clientNameLabel.AutoSize = true;
            clientNameLabel.Location = new Point(50, 260);
            clientNameLabel.Name = "clientNameLabel";
            clientNameLabel.Size = new Size(120, 22);
            clientNameLabel.TabIndex = 48;
            clientNameLabel.Text = "Client Name";
            // 
            // bidAmountLabel
            // 
            bidAmountLabel.AutoSize = true;
            bidAmountLabel.Location = new Point(50, 180);
            bidAmountLabel.Name = "bidAmountLabel";
            bidAmountLabel.Size = new Size(110, 22);
            bidAmountLabel.TabIndex = 47;
            bidAmountLabel.Text = "Bid Amount";
            // 
            // freelancerNameLabel
            // 
            freelancerNameLabel.AutoSize = true;
            freelancerNameLabel.Location = new Point(50, 300);
            freelancerNameLabel.Name = "freelancerNameLabel";
            freelancerNameLabel.Size = new Size(160, 22);
            freelancerNameLabel.TabIndex = 49;
            freelancerNameLabel.Text = "Freelancer Name";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(50, 340);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(120, 22);
            descriptionLabel.TabIndex = 50;
            descriptionLabel.Text = "Description";
            // 
            // descriptionValue
            // 
            descriptionValue.AutoSize = true;
            descriptionValue.Location = new Point(321, 340);
            descriptionValue.Name = "descriptionValue";
            descriptionValue.Size = new Size(120, 22);
            descriptionValue.TabIndex = 58;
            descriptionValue.Text = "Description";
            // 
            // freelancerNameValue
            // 
            freelancerNameValue.AutoSize = true;
            freelancerNameValue.Location = new Point(321, 300);
            freelancerNameValue.Name = "freelancerNameValue";
            freelancerNameValue.Size = new Size(160, 22);
            freelancerNameValue.TabIndex = 57;
            freelancerNameValue.Text = "Freelancer Name";
            // 
            // clientNameValue
            // 
            clientNameValue.AutoSize = true;
            clientNameValue.Location = new Point(321, 260);
            clientNameValue.Name = "clientNameValue";
            clientNameValue.Size = new Size(120, 22);
            clientNameValue.TabIndex = 56;
            clientNameValue.Text = "Client Name";
            // 
            // bidAmountValue
            // 
            bidAmountValue.AutoSize = true;
            bidAmountValue.Location = new Point(321, 180);
            bidAmountValue.Name = "bidAmountValue";
            bidAmountValue.Size = new Size(110, 22);
            bidAmountValue.TabIndex = 55;
            bidAmountValue.Text = "Bid Amount";
            // 
            // skillFieldValue
            // 
            skillFieldValue.AutoSize = true;
            skillFieldValue.Location = new Point(321, 220);
            skillFieldValue.Name = "skillFieldValue";
            skillFieldValue.Size = new Size(120, 22);
            skillFieldValue.TabIndex = 54;
            skillFieldValue.Text = "Skill Field";
            // 
            // statusValue
            // 
            statusValue.AutoSize = true;
            statusValue.Location = new Point(321, 140);
            statusValue.Name = "statusValue";
            statusValue.Size = new Size(70, 22);
            statusValue.TabIndex = 53;
            statusValue.Text = "Status";
            // 
            // deadlineValue
            // 
            deadlineValue.AutoSize = true;
            deadlineValue.Location = new Point(321, 100);
            deadlineValue.Name = "deadlineValue";
            deadlineValue.Size = new Size(90, 22);
            deadlineValue.TabIndex = 52;
            deadlineValue.Text = "Deadline";
            // 
            // nameValue
            // 
            nameValue.AutoSize = true;
            nameValue.Location = new Point(321, 60);
            nameValue.Name = "nameValue";
            nameValue.Size = new Size(50, 22);
            nameValue.TabIndex = 51;
            nameValue.Text = "Name";
            // 
            // bidAmountDropdown
            // 
            bidAmountDropdown.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            bidAmountDropdown.Location = new Point(321, 180);
            bidAmountDropdown.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            bidAmountDropdown.Name = "bidAmountDropdown";
            bidAmountDropdown.Size = new Size(150, 29);
            bidAmountDropdown.TabIndex = 60;
            bidAmountDropdown.TextAlign = HorizontalAlignment.Right;
            bidAmountDropdown.Visible = false;
            // 
            // bidAmountPerHourLabel
            // 
            bidAmountPerHourLabel.AutoSize = true;
            bidAmountPerHourLabel.Location = new Point(477, 182);
            bidAmountPerHourLabel.Name = "bidAmountPerHourLabel";
            bidAmountPerHourLabel.Size = new Size(50, 22);
            bidAmountPerHourLabel.TabIndex = 61;
            bidAmountPerHourLabel.Text = "$/Hr";
            bidAmountPerHourLabel.Visible = false;
            // 
            // reviewButton
            // 
            reviewButton.Location = new Point(412, 394);
            reviewButton.Name = "reviewButton";
            reviewButton.Size = new Size(110, 30);
            reviewButton.TabIndex = 62;
            reviewButton.Text = "Review";
            reviewButton.UseVisualStyleBackColor = true;
            reviewButton.Click += reviewButton_Click;
            // 
            // bidButton
            // 
            bidButton.Location = new Point(528, 394);
            bidButton.Name = "bidButton";
            bidButton.Size = new Size(110, 30);
            bidButton.TabIndex = 63;
            bidButton.Text = "Bid";
            bidButton.UseVisualStyleBackColor = true;
            bidButton.Visible = false;
            bidButton.Click += bidButton_Click;
            // 
            // completeButton
            // 
            completeButton.Location = new Point(644, 394);
            completeButton.Name = "completeButton";
            completeButton.Size = new Size(110, 30);
            completeButton.TabIndex = 64;
            completeButton.Text = "Complete";
            completeButton.UseVisualStyleBackColor = true;
            completeButton.Visible = false;
            completeButton.Click += completeButton_Click;
            // 
            // ProjectDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(completeButton);
            Controls.Add(bidButton);
            Controls.Add(reviewButton);
            Controls.Add(bidAmountPerHourLabel);
            Controls.Add(bidAmountDropdown);
            Controls.Add(descriptionValue);
            Controls.Add(freelancerNameValue);
            Controls.Add(clientNameValue);
            Controls.Add(bidAmountValue);
            Controls.Add(skillFieldValue);
            Controls.Add(statusValue);
            Controls.Add(deadlineValue);
            Controls.Add(nameValue);
            Controls.Add(descriptionLabel);
            Controls.Add(freelancerNameLabel);
            Controls.Add(clientNameLabel);
            Controls.Add(bidAmountLabel);
            Controls.Add(skillFieldLabel);
            Controls.Add(statusLabel);
            Controls.Add(deadlineLabel);
            Controls.Add(nameLabel);
            Controls.Add(backArrowLabel);
            Controls.Add(projectDetailLabel);
            Name = "ProjectDetailForm";
            Text = "Project Detail";
            Load += ProjectDetailForm_Load;
            ((System.ComponentModel.ISupportInitialize)bidAmountDropdown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label projectDetailLabel;
        private Label nameLabel;
        private Label deadlineLabel;
        private Label skillFieldLabel;
        private Label statusLabel;
        private Label clientNameLabel;
        private Label bidAmountLabel;
        private Label freelancerNameLabel;
        private Label descriptionLabel;
        private Label descriptionValue;
        private Label freelancerNameValue;
        private Label clientNameValue;
        private Label bidAmountValue;
        private Label skillFieldValue;
        private Label statusValue;
        private Label deadlineValue;
        private Label nameValue;
        private NumericUpDown numericUpDown1;
        private NumericUpDown bidAmountDropdown;
        private Label bidAmountPerHourLabel;
        private Button reviewButton;
        private Button bidButton;
        private Button completeButton;
    }
}