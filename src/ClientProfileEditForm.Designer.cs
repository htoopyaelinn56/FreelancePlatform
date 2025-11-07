namespace FreelancePlatform.src
{
    partial class ClientProfileEditForm
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
            addressLabel = new Label();
            emailLabel = new Label();
            phoneLabel = new Label();
            nameLabel = new Label();
            clientProfileLabel = new Label();
            backArrowLabel = new Label();
            nameTextBox = new TextBox();
            addressTextBox = new TextBox();
            emailTextBox = new TextBox();
            phoneTextBox = new TextBox();
            editButton = new Button();
            companyNameTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(12, 202);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new Size(80, 22);
            addressLabel.TabIndex = 29;
            addressLabel.Text = "Address";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(12, 132);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(60, 22);
            emailLabel.TabIndex = 28;
            emailLabel.Text = "Email";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(12, 97);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(60, 22);
            phoneLabel.TabIndex = 27;
            phoneLabel.Text = "Phone";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 62);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(50, 22);
            nameLabel.TabIndex = 26;
            nameLabel.Text = "Name";
            // 
            // clientProfileLabel
            // 
            clientProfileLabel.AutoSize = true;
            clientProfileLabel.Font = new Font("JetBrains Mono Medium", 16F);
            clientProfileLabel.Location = new Point(51, 9);
            clientProfileLabel.Name = "clientProfileLabel";
            clientProfileLabel.Size = new Size(239, 36);
            clientProfileLabel.TabIndex = 25;
            clientProfileLabel.Text = "Client Profile";
            clientProfileLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(14, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 34;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(183, 59);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(205, 29);
            nameTextBox.TabIndex = 35;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(183, 199);
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(205, 106);
            addressTextBox.TabIndex = 36;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(183, 129);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(205, 29);
            emailTextBox.TabIndex = 37;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(183, 94);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(205, 29);
            phoneTextBox.TabIndex = 38;
            // 
            // editButton
            // 
            editButton.Location = new Point(294, 389);
            editButton.Name = "editButton";
            editButton.Size = new Size(94, 29);
            editButton.TabIndex = 39;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // companyNameTextBox
            // 
            companyNameTextBox.Location = new Point(183, 164);
            companyNameTextBox.Name = "companyNameTextBox";
            companyNameTextBox.Size = new Size(205, 29);
            companyNameTextBox.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 167);
            label1.Name = "label1";
            label1.Size = new Size(130, 22);
            label1.TabIndex = 40;
            label1.Text = "Company Name";
            // 
            // ClientProfileEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(companyNameTextBox);
            Controls.Add(label1);
            Controls.Add(editButton);
            Controls.Add(phoneTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(addressTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(backArrowLabel);
            Controls.Add(addressLabel);
            Controls.Add(emailLabel);
            Controls.Add(phoneLabel);
            Controls.Add(nameLabel);
            Controls.Add(clientProfileLabel);
            Name = "ClientProfileEditForm";
            Text = "Client Profile Edit";
            Load += ClientProfileEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label addressLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private Label nameLabel;
        private Label clientProfileLabel;
        private Label backArrowLabel;
        private TextBox nameTextBox;
        private TextBox addressTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private Button editButton;
        private TextBox companyNameTextBox;
        private Label label1;
    }
}