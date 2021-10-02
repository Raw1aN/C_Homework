using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
namespace InstagramAPI
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("123", "shchukin9490@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("123", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("shchukin9490@gmail.com", "ALEXRED123321!@q");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}