using Domain;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Api.Services
{
    public class EmailService
    {
        IWebHostEnvironment _Enviroment;
        IConfiguration _Configuration;        
        string BaseUrlEnv;
        string EmailEnv;
        string PasswordEnv;
        public EmailService(IWebHostEnvironment Enviroment, IConfiguration Configuration)
        {
            _Enviroment = Enviroment;
            _Configuration = Configuration;
            EmailEnv = Configuration.GetSection("Email").Value;
            PasswordEnv = Configuration.GetSection("EmailPassword").Value;
        }

        public void Send(string username, string email, string emailToken)
        {
            if (_Enviroment.EnvironmentName == "Development")
                BaseUrlEnv = _Configuration.GetSection("BaseUrlDev").Value;
            else
                BaseUrlEnv = _Configuration.GetSection("BaseUrlProd").Value;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Auth.NET", EmailEnv));
            message.To.Add(new MailboxAddress(username, email));
            message.Subject = "Cadastro de usuário - Auth.NET";
            message.Body = new TextPart("html")
            {
                Text = "<h3>Clique " +
                $"<a  href='{BaseUrlEnv}/api/Auth/EmailValidate/{emailToken}'>AQUI</a> para validar seu e-mail</h3>"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(EmailEnv, PasswordEnv);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void ResetPassword(string username, string email, string randomPassword)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Auth.NET", EmailEnv));
            message.To.Add(new MailboxAddress(username, email));
            message.Subject = "Redefinição de Senha - Auth.NET";
            message.Body = new TextPart("html")
            {
                Text = $"<p style='font-size:16px'>Entre com esta senha: <strong>{randomPassword}</strong></p>" +
                "<p>Altere esta senha assim que possível.</p>"
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(EmailEnv, PasswordEnv);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}