using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Rss2Email
{
    class Messager
    {
        private List<Record> Buffer;
        public string MailAddress { get; set; }

        private const string SmtpServer = "smtp.gmail.com";
        public string Password { get; set; }
        public string Sender { get; set; }
        private const int Port = 587;
        private const bool EnableSsl = true;


        public Messager()
        {
            Buffer = new List<Record>();
        }

        public void AddRecord(Record record)
        {
            if (Buffer.Contains(record)) return;
            Buffer.Add(record);
            if (Buffer.Count == 5)
                SendMail();
        }

        private void SendMail()
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(Sender);
                mail.To.Add(new MailAddress(MailAddress));
                mail.Subject = "RSS";

                var builder = new StringBuilder();
                foreach (var record in Buffer)
                    builder.Append(record);
                mail.Body = builder.ToString();

                var client = new SmtpClient();
                client.Host = SmtpServer;
                client.Port = Port;
                client.EnableSsl = EnableSsl;
                client.Credentials = new NetworkCredential(Sender.Split('@')[0], Password);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mail);
                mail.Dispose();
                Buffer.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
