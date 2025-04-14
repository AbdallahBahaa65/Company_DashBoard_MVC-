using System.Net;
using System.Net.Mail;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Demo.Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com",587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("abdallahbahaa@gmail.com", "");
            client.Send("abdallahbahaa@gmail.com", email.To, email.Subject, email.Body);



        }
    }
}
