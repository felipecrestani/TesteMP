using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace TesteMP.Services
{
    public class MessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string text)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Meus Pedidos", "testemeuspedidos@outlook.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject + " - " + new Guid().ToString().Substring(0,5);
            message.Body = new TextPart("plain")
            {
                Text = text
            };

            using (var client = new SmtpClient())   
            {
                client.Connect("smtp-mail.outlook.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("testemeuspedidos@outlook.com", "Teste@MeusPedidos");
                client.Send(message);
                client.Disconnect(true);
            }
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
