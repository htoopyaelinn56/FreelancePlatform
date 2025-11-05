namespace FreelancePlatform
{
    partial class AuthenticationForm
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
            formTitle = new Label();
            userNameLabel = new Label();
            passwordLabel = new Label();
            userNameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            showHidePasswordCheckbox = new CheckBox();
            clientRadioButton = new RadioButton();
            freelancerRadioButton = new RadioButton();
            userTypeLabel = new Label();
            loginButton = new Button();
            registerButton = new Button();
            SuspendLayout();
            // 
            // formTitle
            // 
            formTitle.AutoSize = true;
            formTitle.Font = new Font("JetBrains Mono Medium", 16F);
            formTitle.Location = new Point(12, 9);
            formTitle.Name = "formTitle";
            formTitle.Size = new Size(303, 36);
            formTitle.TabIndex = 0;
            formTitle.Text = "Freelance Platform";
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(12, 74);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(90, 22);
            userNameLabel.TabIndex = 1;
            userNameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 105);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(90, 22);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password";
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(209, 71);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(156, 29);
            userNameTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(209, 102);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(156, 29);
            passwordTextBox.TabIndex = 6;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // showHidePasswordCheckbox
            // 
            showHidePasswordCheckbox.AutoSize = true;
            showHidePasswordCheckbox.Location = new Point(371, 105);
            showHidePasswordCheckbox.Name = "showHidePasswordCheckbox";
            showHidePasswordCheckbox.Size = new Size(152, 26);
            showHidePasswordCheckbox.TabIndex = 8;
            showHidePasswordCheckbox.Text = "Show Pasword";
            showHidePasswordCheckbox.UseVisualStyleBackColor = true;
            showHidePasswordCheckbox.CheckedChanged += showHidePasswordCheckbox_CheckedChanged;
            // 
            // clientRadioButton
            // 
            clientRadioButton.AutoSize = true;
            clientRadioButton.Location = new Point(209, 171);
            clientRadioButton.Name = "clientRadioButton";
            clientRadioButton.Size = new Size(91, 26);
            clientRadioButton.TabIndex = 9;
            clientRadioButton.TabStop = true;
            clientRadioButton.Text = "Client";
            clientRadioButton.UseVisualStyleBackColor = true;
            // 
            // freelancerRadioButton
            // 
            freelancerRadioButton.AutoSize = true;
            freelancerRadioButton.Location = new Point(306, 171);
            freelancerRadioButton.Name = "freelancerRadioButton";
            freelancerRadioButton.Size = new Size(131, 26);
            freelancerRadioButton.TabIndex = 10;
            freelancerRadioButton.TabStop = true;
            freelancerRadioButton.Text = "Freelancer";
            freelancerRadioButton.UseVisualStyleBackColor = true;
            // 
            // userTypeLabel
            // 
            userTypeLabel.AutoSize = true;
            userTypeLabel.Location = new Point(12, 171);
            userTypeLabel.Name = "userTypeLabel";
            userTypeLabel.Size = new Size(100, 22);
            userTypeLabel.TabIndex = 11;
            userTypeLabel.Text = "User Type";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(198, 240);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(102, 29);
            loginButton.TabIndex = 12;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // registerButton
            // 
            registerButton.Location = new Point(306, 240);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(102, 29);
            registerButton.TabIndex = 13;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = true;
            registerButton.Click += registerButton_Click;
            // 
            // AuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerButton);
            Controls.Add(loginButton);
            Controls.Add(userTypeLabel);
            Controls.Add(freelancerRadioButton);
            Controls.Add(clientRadioButton);
            Controls.Add(showHidePasswordCheckbox);
            Controls.Add(passwordTextBox);
            Controls.Add(userNameTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(userNameLabel);
            Controls.Add(formTitle);
            Name = "AuthenticationForm";
            Text = "Authentication Form";
            Load += AuthenticationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formTitle;
        private Label userNameLabel;
        private Label passwordLabel;
        private TextBox userNameTextBox;
        private TextBox passwordTextBox;
        private CheckBox showHidePasswordCheckbox;
        private RadioButton clientRadioButton;
        private RadioButton freelancerRadioButton;
        private Label userTypeLabel;
        private Button loginButton;
        private Button registerButton;
    }
}