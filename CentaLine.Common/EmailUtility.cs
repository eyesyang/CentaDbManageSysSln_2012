using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace CentaLine.Common
{
    /// <summary>
    /// email操作类
    /// </summary>
    public class EmailUtility
    {
        public string Host
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string From
        {
            get;
            set;
        }

        public string[] To
        {
            get;
            set;
        }

        public bool IsBodyHtml
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string[] Attachments
        {
            get;
            set;
        }

        public int Priority
        {
            get;
            set;
        }

        public string[] CC
        {
            get;
            set;
        }

        public string[] Bcc
        {
            get;
            set;
        }

        public EmailUtility(string host, int port, string userName, string password)
        {
            this.Host = host;
            this.Port = port;
            this.UserName = userName;
            this.Password = password;
        }

        public void Send()
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(this.From);
                if (this.To != null && this.To.Length > 0)
                {

                    foreach (var item in this.To)
                    {
                        mailMessage.To.Add(new MailAddress(item));
                    }
                }
                else
                {
                    return;
                }
                mailMessage.IsBodyHtml = this.IsBodyHtml;
                mailMessage.Subject = this.Subject;
                mailMessage.Body = this.Body;
                if (this.Attachments != null && this.Attachments.Length > 0)
                {
                    foreach (var item in this.Attachments)
                    {
                        mailMessage.Attachments.Add(new Attachment(item));
                    }
                }
                if (this.CC != null && this.CC.Length > 0)
                {
                    foreach (var item in this.CC)
                    {
                        mailMessage.CC.Add(item);
                    }
                }
                if (this.Bcc != null && this.Bcc.Length > 0)
                {
                    foreach (var item in this.Bcc)
                    {
                        mailMessage.Bcc.Add(item);
                    }
                }
                if (this.Priority <= 3)
                {
                    mailMessage.Priority = MailPriority.Low;
                }
                else if (this.Priority > 6)
                {
                    mailMessage.Priority = MailPriority.High;
                }
                else
                {
                    mailMessage.Priority = MailPriority.Normal;
                }
                SmtpClient client = new SmtpClient(this.Host, this.Port);
                client.Credentials = new System.Net.NetworkCredential(this.UserName, this.Password);
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
