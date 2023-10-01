using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using System.Timers;

namespace RabbitMQProducer
{
    public partial class MainForm : Form
    {
        private IModel channel;
        private Queue<EmailMessage> emailQueue = new Queue<EmailMessage>();
        private System.Timers.Timer emailSenderTimer = new System.Timers.Timer();

        public MainForm()
        {
            InitializeComponent();
            InitializeRabbitMQ();
            InitializeEmailQueue();
            InitializeTimer();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare(queue: "email-queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        private void InitializeEmailQueue()
        {
            // Create a list of demo emails and bodies
            var demoEmails = new List<EmailMessage>
            {
                new EmailMessage { RecipientEmail = "sanjatulhasansiam.iit@gmail.com", EmailBody = "Email body 1" },
                new EmailMessage { RecipientEmail = "sanjatulhasansiam.iit@gmail.com", EmailBody = "Email body 2" },
                // Add more email messages as needed
            };

            // Queue up the emails
            foreach (var email in demoEmails)
            {
                emailQueue.Enqueue(email);
            }
        }

        private void InitializeTimer()
        {
            // Set the interval for sending emails (in milliseconds)
            emailSenderTimer.Interval = 5000; // 5 seconds
            emailSenderTimer.Elapsed += EmailSenderTimerElapsed;
            emailSenderTimer.AutoReset = true;
        }

        private void EmailSenderTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (emailQueue.Count > 0)
            {
                var emailMessage = emailQueue.Dequeue();

                // Update the non-editable textbox with the current email
                UpdateEmailTextBox(emailMessage);

                // Serialize the email message to JSON
                var messageJson = JsonConvert.SerializeObject(emailMessage);

                // Publish the JSON message to the RabbitMQ server
                var body = Encoding.UTF8.GetBytes(messageJson);
                channel.BasicPublish(exchange: "", routingKey: "email-queue", basicProperties: null, body: body);
            }
            else
            {
                // Stop the timer when all emails have been sent
                emailSenderTimer.Stop();
                MessageBox.Show("All emails sent.");
            }
        }

        private void UpdateEmailTextBox(EmailMessage emailMessage)
        {
            if (!string.IsNullOrEmpty(emailTextBox.Text))
            {
                emailTextBox.Invoke(new Action(() =>
                {
                    emailTextBox.AppendText("\n\n");
                }));
            }

            // Use Invoke to update the UI control from the UI thread
            emailTextBox.Invoke(new Action(() =>
            {
                emailTextBox.AppendText($"Recipient: {emailMessage.RecipientEmail}\n");
                emailTextBox.AppendText($"Email Body: {emailMessage.EmailBody}\n");
            }));
        }



        private void StartSendingButton_Click_1(object sender, EventArgs e)
        {
            // Start the email sender timer
            emailSenderTimer.Start();
        }
    }

    public class EmailMessage
    {
        public string RecipientEmail { get; set; }
        public string EmailBody { get; set; }
    }
}
