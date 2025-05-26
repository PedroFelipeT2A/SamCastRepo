using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Painel.Lib
{
    public class Email : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static async Task EnviarEmail(string paraEmail, string titulo, string mensagem)
        {
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress("contato@appvision.com.br", "Vision")
            };

            mail.To.Add(new MailAddress(paraEmail));
            mail.Bcc.Add(new MailAddress("otagomes@hotmail.com"));
            //mail.Bcc.Add(new MailAddress("marcelomatheus92@gmail.com"));

            mail.Subject = $"{titulo}";
            mail.Body = $"{mensagem}";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            using (SmtpClient smtp = new SmtpClient("ds3.hospedam.com", 587))
            {
                smtp.Credentials = new NetworkCredential("contato@appvision.com.br", "@.1Prime.2#");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}