using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.MailServices
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] {to},subject,body,isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
           foreach (string to in tos)
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(configuration["Mail:UserName"],"",System.Text.Encoding.UTF8);//birinci alanda mail adresi ikinci alanda bir display name uygulama ismi gibi

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(configuration["Mail:UserName"], configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);

        }

        public async Task SendPasswordResetMailAsync(string to,string userId)
        {
            StringBuilder mail = new();
            mail.Append("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine(configuration["PasswordResetUrl"]);
            mail.AppendLine($"userId={userId}");
            mail.AppendLine("\">Yeni şifre talebi için tıklayınız....</a></strong><br><br><span  style=\"font-size:12px;\">Not:Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili dikkate almayınız</span>");


            await SendMailAsync(to,"Şifre Yenileme Talebi",mail.ToString());

        }
    }
}
