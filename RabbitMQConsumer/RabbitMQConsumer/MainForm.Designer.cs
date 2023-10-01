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
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(118, 81);
            textBoxEmail.Multiline = true;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(564, 93);
            textBoxEmail.TabIndex = 0;
            // 
            // LogTextBox
            // 
            LogTextBox.Location = new Point(118, 263);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.Size = new Size(564, 112);
            LogTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(356, 231);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Log Box";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(356, 40);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Details";
            label2.Click += label2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LogTextBox);
            Controls.Add(textBoxEmail);
            Name = "MainForm";
            Text = "Consumer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEmail;
        private TextBox LogTextBox;
        private Label label1;
        private Label label2;
    }
}