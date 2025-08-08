using GetMailWithAttachment.Data;
using GetMailWithAttachment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MailKit.Net.Smtp;
using System.IO;
using System.Threading.Tasks;
using Org.BouncyCastle.Tls;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace GetMailWithAttachment.Repository
{
    public class Services
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public Services(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _context = applicationDbContext;
            _configuration = configuration;
        }

        public async Task<bool> SendMailWithAttachment(EmailViewModel model)
        {
            if (model == null)
            {
                return false;
            }
            try
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("Shraddha Palande", "Mail From"));
                message.To.Add(new MailboxAddress("", model.Recipient));
                message.Subject = model.Subject;


                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = model.Body
                };

                foreach (var file in model.Attachments)
                {
                    if (file != null && file.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await file.CopyToAsync(stream);
                            bodyBuilder.Attachments.Add(file.FileName, stream.ToArray());
                        }
                    }
                }

                message.Body = bodyBuilder.ToMessageBody();
                using (var Client = new SmtpClient())
                {
                    Client.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    Client.Connect("URL", 25, MailKit.Security.SecureSocketOptions.StartTls);
                    Client.Authenticate("MailId", "Password");
                    await Client.SendAsync(message);
                    Client.Disconnect(true);
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}


