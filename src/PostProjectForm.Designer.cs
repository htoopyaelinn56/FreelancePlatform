namespace FreelancePlatform.src
{
    partial class PostProjectForm
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
            postProjectLabel = new Label();
            postButton = new Button();
            descriptionTextBox = new TextBox();
            nameTextBox = new TextBox();
            addressLabel = new Label();
            emailLabel = new Label();
            phoneLabel = new Label();
            nameLabel = new Label();
            label1 = new Label();
            skillsTextBox = new TextBox();
            deadlineDatePicker = new DateTimePicker();
            budgetNumericDropdown = new NumericUpDown();
            budgetDollarPerHourLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)budgetNumericDropdown).BeginInit();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(12, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 36;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // postProjectLabel
            // 
            postProjectLabel.AutoSize = true;
            postProjectLabel.Font = new Font("JetBrains Mono Medium", 16F);
            postProjectLabel.Location = new Point(49, 9);
            postProjectLabel.Name = "postProjectLabel";
            postProjectLabel.Size = new Size(207, 36);
            postProjectLabel.TabIndex = 35;
            postProjectLabel.Text = "Post Project";
            postProjectLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // postButton
            // 
            postButton.Location = new Point(430, 384);
            postButton.Name = "postButton";
            postButton.Size = new Size(94, 29);
            postButton.TabIndex = 48;
            postButton.Text = "Post";
            postButton.UseVisualStyleBackColor = true;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(185, 195);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(339, 106);
            descriptionTextBox.TabIndex = 45;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(185, 52);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(339, 29);
            nameTextBox.TabIndex = 44;
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(14, 160);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(70, 22);
            addressLabel.TabIndex = 43;
            addressLabel.Text = "Skills";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(14, 125);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(70, 22);
            emailLabel.TabIndex = 42;
            emailLabel.Text = "Budget";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(14, 90);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(90, 22);
            phoneLabel.TabIndex = 41;
            phoneLabel.Text = "Deadline";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(14, 55);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 22);
            nameLabel.TabIndex = 40;
            nameLabel.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 191);
            label1.Name = "label1";
            label1.Size = new Size(120, 22);
            label1.TabIndex = 49;
            label1.Text = "Description";
            // 
            // skillsTextBox
            // 
            skillsTextBox.Location = new Point(185, 160);
            skillsTextBox.Name = "skillsTextBox";
            skillsTextBox.Size = new Size(339, 29);
            skillsTextBox.TabIndex = 50;
            // 
            // deadlineDatePicker
            // 
            deadlineDatePicker.Location = new Point(185, 90);
            deadlineDatePicker.Name = "deadlineDatePicker";
            deadlineDatePicker.Size = new Size(339, 29);
            deadlineDatePicker.TabIndex = 51;
            // 
            // budgetNumericDropdown
            // 
            budgetNumericDropdown.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            budgetNumericDropdown.Location = new Point(185, 125);
            budgetNumericDropdown.Maximum = new decimal(new int[] { 276447231, 23283, 0, 0 });
            budgetNumericDropdown.Name = "budgetNumericDropdown";
            budgetNumericDropdown.Size = new Size(150, 29);
            budgetNumericDropdown.TabIndex = 52;
            budgetNumericDropdown.TextAlign = HorizontalAlignment.Right;
            budgetNumericDropdown.ThousandsSeparator = true;
            // 
            // budgetDollarPerHourLabel
            // 
            budgetDollarPerHourLabel.AutoSize = true;
            budgetDollarPerHourLabel.Location = new Point(341, 127);
            budgetDollarPerHourLabel.Name = "budgetDollarPerHourLabel";
            budgetDollarPerHourLabel.Size = new Size(50, 22);
            budgetDollarPerHourLabel.TabIndex = 53;
            budgetDollarPerHourLabel.Text = "$/Hr";
            // 
            // PostProjectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(budgetDollarPerHourLabel);
            Controls.Add(budgetNumericDropdown);
            Controls.Add(deadlineDatePicker);
            Controls.Add(skillsTextBox);
            Controls.Add(label1);
            Controls.Add(postButton);
            Controls.Add(descriptionTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(addressLabel);
            Controls.Add(emailLabel);
            Controls.Add(phoneLabel);
            Controls.Add(nameLabel);
            Controls.Add(backArrowLabel);
            Controls.Add(postProjectLabel);
            Name = "PostProjectForm";
            Text = "PostProjectForm";
            Load += PostProjectForm_Load;
            ((System.ComponentModel.ISupportInitialize)budgetNumericDropdown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label postProjectLabel;
        private Button postButton;
        private TextBox descriptionTextBox;
        private TextBox nameTextBox;
        private Label addressLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label nameLabel;
        private Label label1;
        private TextBox skillsTextBox;
        private DateTimePicker deadlineDatePicker;
        private NumericUpDown budgetNumericDropdown;
        private Label budgetDollarPerHourLabel;
    }
}