namespace FreelancePlatform.src
{
    partial class ProjectReviewForm
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
            projectReviewLabel = new Label();
            commentLabel = new Label();
            ratingLabel = new Label();
            ratingDropdown = new NumericUpDown();
            starLabel = new Label();
            commentTextBox = new TextBox();
            submitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)ratingDropdown).BeginInit();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(11, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 44;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // projectReviewLabel
            // 
            projectReviewLabel.AutoSize = true;
            projectReviewLabel.Font = new Font("JetBrains Mono Medium", 16F);
            projectReviewLabel.Location = new Point(48, 9);
            projectReviewLabel.Name = "projectReviewLabel";
            projectReviewLabel.Size = new Size(239, 36);
            projectReviewLabel.TabIndex = 43;
            projectReviewLabel.Text = "Project Review";
            projectReviewLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Location = new Point(48, 106);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new Size(80, 22);
            commentLabel.TabIndex = 46;
            commentLabel.Text = "Comment";
            // 
            // ratingLabel
            // 
            ratingLabel.AutoSize = true;
            ratingLabel.Location = new Point(48, 66);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new Size(70, 22);
            ratingLabel.TabIndex = 45;
            ratingLabel.Text = "Rating";
            // 
            // ratingDropdown
            // 
            ratingDropdown.Location = new Point(181, 64);
            ratingDropdown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            ratingDropdown.Name = "ratingDropdown";
            ratingDropdown.Size = new Size(79, 29);
            ratingDropdown.TabIndex = 47;
            ratingDropdown.TextAlign = HorizontalAlignment.Right;
            // 
            // starLabel
            // 
            starLabel.AutoSize = true;
            starLabel.Font = new Font("JetBrains Mono Medium", 16F);
            starLabel.Location = new Point(266, 57);
            starLabel.Name = "starLabel";
            starLabel.Size = new Size(37, 36);
            starLabel.TabIndex = 48;
            starLabel.Text = "★";
            // 
            // commentTextBox
            // 
            commentTextBox.Location = new Point(178, 106);
            commentTextBox.Multiline = true;
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(306, 169);
            commentTextBox.TabIndex = 49;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(390, 355);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(94, 29);
            submitButton.TabIndex = 50;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // ProjectReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(submitButton);
            Controls.Add(commentTextBox);
            Controls.Add(starLabel);
            Controls.Add(ratingDropdown);
            Controls.Add(commentLabel);
            Controls.Add(ratingLabel);
            Controls.Add(backArrowLabel);
            Controls.Add(projectReviewLabel);
            Name = "ProjectReviewForm";
            Text = "Project Review";
            Load += ProjectReviewForm_Load;
            ((System.ComponentModel.ISupportInitialize)ratingDropdown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label projectReviewLabel;
        private Label commentLabel;
        private Label ratingLabel;
        private NumericUpDown ratingDropdown;
        private Label starLabel;
        private TextBox commentTextBox;
        private Button submitButton;
    }
}