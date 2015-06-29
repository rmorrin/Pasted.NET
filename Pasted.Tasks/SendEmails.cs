using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace Pasted.Tasks
{
    public class SendEmails
    {

        

        public void SendSingle()
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();

                // Check which env. we are dev, prod?!
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

                MailAddress mailFrom = new MailAddress("no-reply@pasted.bla", "Pasted.Net");
                MailAddress mailTo = new MailAddress("you@pasted.blabla" ,"Hello You");

                MailMessage mailToSend = new MailMessage(mailTo, mailFrom);
                mailToSend.Subject = "Pasted expires in x days";
                mailToSend.SubjectEncoding = System.Text.Encoding.UTF8;

                mailToSend.Body = "Your pasted xya will expire...";
                mailToSend.BodyEncoding = System.Text.Encoding.UTF8;
                mailToSend.IsBodyHtml = false;

                smtpClient.Send(mailToSend);
            }
            catch (SmtpException e)
            {
                throw new SmtpException(e.Message);
            }
        }

        public void SendMultiple(List<MailAddress> recipients)
        {
            foreach (var recipient in recipients)
            {
                //SendSingle(recipient);
            }
        }        

    }
}
