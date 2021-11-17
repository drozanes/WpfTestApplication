using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTestApplication
{
    class SendMailViewModel
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Data { get; set; }


        private ICommand _sendCommand;
        public ICommand SendCommand
        {
            get
            {
                return _sendCommand ?? (_sendCommand = new CommandHandler(() => SendMail(), true));
            }
        }

        public void SendMail()
        {
            string from = "drozanes@gmail.com";
            MailMessage message = new MailMessage(from, To);
            message.Subject = Subject;
            message.Body = Data;
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("drozanes@gmail.com", "password"),
                EnableSsl = true,
            };
            client.UseDefaultCredentials = false;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
        }

    }

 
}