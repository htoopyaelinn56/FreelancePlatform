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
            freelancerProfileLabel = new Label();
            backArrowLabel = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            editButton = new Button();
            SuspendLayout();
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new Point(12, 167);
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
            // freelancerProfileLabel
            // 
            freelancerProfileLabel.AutoSize = true;
            freelancerProfileLabel.Font = new Font("JetBrains Mono Medium", 16F);
            freelancerProfileLabel.Location = new Point(51, 9);
            freelancerProfileLabel.Name = "freelancerProfileLabel";
            freelancerProfileLabel.Size = new Size(239, 36);
            freelancerProfileLabel.TabIndex = 25;
            freelancerProfileLabel.Text = "Client Profile";
            freelancerProfileLabel.TextAlign = ContentAlignment.MiddleCenter;
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
            // textBox1
            // 
            textBox1.Location = new Point(183, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(205, 29);
            textBox1.TabIndex = 35;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(183, 164);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(205, 106);
            textBox2.TabIndex = 36;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(183, 129);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(205, 29);
            textBox3.TabIndex = 37;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(183, 94);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(205, 29);
            textBox4.TabIndex = 38;
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
            // ClientProfileEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(editButton);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(backArrowLabel);
            Controls.Add(addressLabel);
            Controls.Add(emailLabel);
            Controls.Add(phoneLabel);
            Controls.Add(nameLabel);
            Controls.Add(freelancerProfileLabel);
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
        private Label freelancerProfileLabel;
        private Label backArrowLabel;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button editButton;
    }
}