using System.Net;
using System.Net.Mail;

namespace WEB.Services
{
    
    public class EmailSender
    {
        public void SendEmail(string recipientEmail, string subject, string body)
        {
            var fromAddress = new MailAddress("tung020802@gmail.com", "Tung");
            var toAddress = new MailAddress(recipientEmail, "Recipient Name");
            const string fromPassword = "bvio humm nitm jxds";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }

}
