using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace TeachingSystem.Domain
{
    public class SendEmail
    {
        public static bool SendMailUseGmail(string toAddress)
        {
            MailMessage msg = new MailMessage();

            msg.To.Add(toAddress);
            /* 3个参数分别是发件人地址（可以随便写），发件人姓名，编码*/
            msg.From = new MailAddress("a@a.com", "AlphaWu", System.Text.Encoding.UTF8);
            
            msg.Subject = "这是测试邮件";//邮件标题 
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码 
            msg.Body = "邮件内容";//邮件内容 
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码 
            msg.IsBodyHtml = false;//是否是HTML邮件 
            msg.Priority = MailPriority.High;//邮件优先级 
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("username@gmail.com", "password");
            //上述写你的GMail邮箱和密码 
            client.Port = 587;//Gmail使用的端口 
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;//经过ssl加密 
            object userState = msg;
            try
            {
                client.SendAsync(msg, userState);
                //简单一点儿可以client.Send(msg); 
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
            }
        }
    }
}
