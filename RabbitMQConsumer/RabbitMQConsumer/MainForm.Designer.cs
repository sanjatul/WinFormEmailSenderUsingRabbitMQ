namespace RabbitMQConsumer
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
            textBoxEmail = new TextBox();
            LogTextBox = new TextBox();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(109, 157);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(564, 23);
            textBoxEmail.TabIndex = 0;
            // 
            // LogTextBox
            // 
            LogTextBox.Location = new Point(118, 214);
            LogTextBox.Name = "LogTextBox";
            LogTextBox.Size = new Size(564, 23);
            LogTextBox.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LogTextBox);
            Controls.Add(textBoxEmail);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEmail;
        private TextBox LogTextBox;
    }
}