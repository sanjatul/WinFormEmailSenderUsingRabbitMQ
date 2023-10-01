namespace RabbitMQProducer
{
    partial class MainForm
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
            emailTextBox = new TextBox();
            Details = new Label();
            StartSendingButton = new Button();
            SuspendLayout();
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(180, 90);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(493, 23);
            emailTextBox.TabIndex = 0;
            // 
            // Details
            // 
            Details.AutoSize = true;
            Details.Location = new Point(337, 42);
            Details.Name = "Details";
            Details.Size = new Size(74, 15);
            Details.TabIndex = 1;
            Details.Text = "Email Details";
            // 
            // StartSendingButton
            // 
            StartSendingButton.BackColor = SystemColors.ControlDark;
            StartSendingButton.Location = new Point(337, 262);
            StartSendingButton.Name = "StartSendingButton";
            StartSendingButton.Size = new Size(75, 23);
            StartSendingButton.TabIndex = 2;
            StartSendingButton.Text = "Send";
            StartSendingButton.UseVisualStyleBackColor = false;
            StartSendingButton.Click += StartSendingButton_Click_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartSendingButton);
            Controls.Add(Details);
            Controls.Add(emailTextBox);
            Name = "MainForm";
            Text = "Producer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailTextBox;
        private Label Details;
        private Button StartSendingButton;
    }
}