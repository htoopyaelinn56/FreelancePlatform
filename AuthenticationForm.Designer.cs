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
            SuspendLayout();
            // 
            // formTitle
            // 
            formTitle.AutoSize = true;
            formTitle.Font = new Font("JetBrains Mono Medium", 18F);
            formTitle.Location = new Point(12, 9);
            formTitle.Name = "formTitle";
            formTitle.Size = new Size(341, 40);
            formTitle.TabIndex = 0;
            formTitle.Text = "Freelance Platform";
            formTitle.Click += formTitle_Click;
            // 
            // AuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(formTitle);
            Name = "AuthenticationForm";
            Text = "AuthenticationForm";
            Load += AuthenticationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formTitle;
    }
}