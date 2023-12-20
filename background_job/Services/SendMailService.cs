using background_job.Interfaces;
using background_job.Models.Requests;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace background_job.Services
{
    public class SendMailService : ISendMailService
    {
        public SendMailService() { }

        public async Task SendMailAsync(SendMailRequest request)
        {
            try
            {
                //Sender Info
                string senderEmail = ""; //Sender email [Gmail]
                string senderPassword = ""; //App password (not pwd of gmail), you can get app pwd at here https://myaccount.google.com/security

                //Initialize MimeMessage
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("no-reply", senderEmail));
                message.To.Add(new MailboxAddress("Recipient Name", request.ReceiverEmail));
                message.Subject = request.Subject;
                message.Body = new TextPart(TextFormat.Plain)
                {
                    Text = request.Content
                };

                //Initialize SmtpClient
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    client.Authenticate(senderEmail, senderPassword);

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
