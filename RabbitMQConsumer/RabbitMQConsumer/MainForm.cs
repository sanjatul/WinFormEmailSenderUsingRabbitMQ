using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RabbitMQConsumer
{
    public partial class MainForm : Form
    {
        private IModel channel;
        private EventingBasicConsumer consumer;

        public MainForm()
        {
            InitializeComponent();
            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "email-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var messageJson = Encoding.UTF8.GetString(body);

                // Deserialize the JSON message into an EmailMessage object
                var emailMessage = JsonConvert.DeserializeObject<EmailMessage>(messageJson);

                // Display the email details in the text area
                DisplayEmailDetails(emailMessage);

                // Send the email
                SendEmail(emailMessage);

                // Acknowledge the message
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "email-queue", autoAck: false, consumer: consumer);
        }

        private void DisplayEmailDetails(EmailMessage emailMessage)
        {
            // Use Invoke to update the UI control from the UI thread
            textBoxEmail.Invoke(new Action(() =>
            {
                // Display the email details in the text area
                textBoxEmail.AppendText($"Recipient: {emailMessage.RecipientEmail}\n");
                textBoxEmail.AppendText($"Email Body: {emailMessage.EmailBody}\n");
                textBoxEmail.AppendText(new string('-', 50) + "\n"); // Separator line
            }));
        }


        private void SendEmail(EmailMessage emailMessage)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("shsiam800@gmail.com");
                mail.To.Add(emailMessage.RecipientEmail);
                mail.Subject = "RabbitMQ Mailer";
                mail.Body = emailMessage.EmailBody;

                // Configure SMTP credentials and other settings for Gmail
                client.Credentials = new NetworkCredential("shsiam800@gmail.com", "mazz ovxz jdwv ugah");
                client.EnableSsl = true;
                client.Port = 587; // Gmail SMTP port

                client.Send(mail);

                // Update UI or log success using Invoke
                LogTextBox.Invoke(new Action(() =>
                {
                    LogTextBox.AppendText($"Email sent to {emailMessage.RecipientEmail} successfully.\n");
                }));
            }
            catch (Exception ex)
            {
                // Handle and log any exceptions using Invoke
                LogTextBox.Invoke(new Action(() =>
                {
                    LogTextBox.AppendText($"Error sending email: {ex.Message}\n");
                }));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    public class EmailMessage
    {
        public string RecipientEmail { get; set; }
        public string EmailBody { get; set; }
    }
}
