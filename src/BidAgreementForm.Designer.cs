namespace FreelancePlatform.src
{
    partial class BidAgreementForm
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
            bidAgreementLabel = new Label();
            SuspendLayout();
            // 
            // backArrowLabel
            // 
            backArrowLabel.AutoSize = true;
            backArrowLabel.Font = new Font("JetBrains Mono Medium", 16F);
            backArrowLabel.Location = new Point(12, 9);
            backArrowLabel.Name = "backArrowLabel";
            backArrowLabel.Size = new Size(31, 36);
            backArrowLabel.TabIndex = 40;
            backArrowLabel.Text = "←";
            backArrowLabel.Click += backArrowLabel_Click;
            // 
            // bidAgreementLabel
            // 
            bidAgreementLabel.AutoSize = true;
            bidAgreementLabel.Font = new Font("JetBrains Mono Medium", 16F);
            bidAgreementLabel.Location = new Point(49, 9);
            bidAgreementLabel.Name = "bidAgreementLabel";
            bidAgreementLabel.Size = new Size(223, 36);
            bidAgreementLabel.TabIndex = 39;
            bidAgreementLabel.Text = "Bid Agreement";
            bidAgreementLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BidAgreementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backArrowLabel);
            Controls.Add(bidAgreementLabel);
            Name = "BidAgreementForm";
            Text = "Bid Agreement";
            Load += BidAgreementForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label backArrowLabel;
        private Label bidAgreementLabel;
    }
}