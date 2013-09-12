using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;

namespace Sunny.Common.Security.Client
{
    public class MailManage
    {
        public static bool SendingEmail(EmailParms Email)
        {

            System.Net.Mail.MailMessage mms = new System.Net.Mail.MailMessage();

            System.Text.Encoding emaiEncodingType;
            //设置邮件编码类型 
            switch (Email.EncodingType)
            {
                case "UTF7":
                    emaiEncodingType = System.Text.Encoding.UTF7;
                    break;
                case "UTF8":
                    emaiEncodingType = System.Text.Encoding.UTF8;
                    break;
                case "UTF32":
                    emaiEncodingType = System.Text.Encoding.UTF32;
                    break;
                case "ASCII":
                    emaiEncodingType = System.Text.Encoding.ASCII;
                    break;
                default:
                    emaiEncodingType = System.Text.Encoding.Default;
                    break;
            }

            mms.To.Add(Email.ToEmailAddress);
            mms.From = new System.Net.Mail.MailAddress(Email.FromEmailAddress, Email.EmailPersonName, emaiEncodingType);
            mms.Subject = Email.EmailSubject;
            mms.SubjectEncoding = emaiEncodingType;
            mms.Body = Email.EmailBody;
            mms.BodyEncoding = emaiEncodingType;

            //设置邮件是否为HTML格式 
            if (Email.isBodyHtml == false)
            {
                mms.IsBodyHtml = Email.isBodyHtml;
            }
            else
            {
                mms.IsBodyHtml = true;
            }

            //设置邮件优级先级 
            switch (Email.EmailPriority)
            {
                case "normal":
                    mms.Priority = System.Net.Mail.MailPriority.Normal;
                    break;
                case "low":
                    mms.Priority = System.Net.Mail.MailPriority.Low;
                    break;
                default:
                    mms.Priority = System.Net.Mail.MailPriority.High;
                    break;
            }

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(Email.FromEmailAddress, Email.FromEmailPassword);

            client.Port = Email.EmailPort;
            client.Host = Email.EmailHostName;
            client.EnableSsl = Email.isEnableSsl;

            try
            {
                client.Send(mms);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public struct EmailParms
    {
        /// <summary>
        /// 收件人邮箱地址
        /// </summary>
        public string ToEmailAddress;

        /// <summary>
        /// 发件人邮箱地址
        /// </summary>
        public string FromEmailAddress;

        /// <summary>
        /// 发件人邮箱密码
        /// </summary>
        public string FromEmailPassword;

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string EmailSubject;

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string EmailBody;

        /// <summary>
        /// 发件人姓名
        /// </summary> 
        public string EmailPersonName;

        /// <summary> 
        /// SMTP主机名称 
        /// 例:Gmail为smtp.gmail.com 
        /// </summary> 
        public string EmailHostName;

        /// <summary> 
        /// 邮件优先级：high（高）、low(低)、normal(正常) 
        /// 默认为high 
        /// </summary> 
        public string EmailPriority;

        /// <summary> 
        /// 邮箱端口号 
        /// 例:Gmail为587,一般为25 
        /// </summary> 
        public int EmailPort;

        /// <summary> 
        /// 邮件是否加密:true(加密),false(不加密) 
        /// 默认为true 
        /// </summary> 
        public bool isEnableSsl;

        /// <summary> 
        /// 邮件内容是否为HTML格式(true加密,false不加密),默认为false 
        /// </summary> 
        public bool isBodyHtml;

        /// <summary> 
        /// 邮件编码类型:UTF7、UTF8(推荐)、UTF32、ASCII和Default. 
        /// </summary> 
        public string EncodingType;
    }

}
