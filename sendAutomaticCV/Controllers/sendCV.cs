using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;

namespace sendAutomaticCV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class sendCV : ControllerBase
    {
        
        [HttpGet]
        public dynamic sendCv(string to= "dvirbsh95@gmail.com",string job = "תקציבאי",string password="")
        {
            try
            {
                //var fromAddress = new MailAddress("lidann46@gmail.com");
                //var toAddress = new MailAddress(to);
                //const string fromPassword = "lidlid012";
                var fromAddress = new MailAddress("dvirbenshlush95@gmail.com");
                var toAddress = new MailAddress(to);
                string fromPassword = password;
                string subject = "הגשת מועמדות למשרת " + job;
                string body = "Body6";
                string file = "lidann_cv.docx";

                Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                // Add time stamp information for the file.
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                // Add the file attachment to this email message.

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    message.Attachments.Add(data);
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //private String GetFormattedMessageHTML()
        //{
        //    return "<!DOCTYPE html> " +
        //        "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
        //        "<head>" +
        //            "<title>Email</title>" +
        //        "</head>" +
        //        "<body style=\"font-family:'Century Gothic'\">" +
        //            "<h1 style=\"text-align:center;\"> " + subjectTextBox.Text + "</h1>" +
        //            "<h2 style=\"font-size:14px;\">" +
        //                "Name : " + firstNameTextBox.Text + " " + lastNameTextBox.Text + "<br />" +
        //                "Company : " + companyTextBox.Text + "<br />" +
        //                "Email : " + emailTextBox.Text +
        //            "</h2>" +
        //            "<p>" + messageTextBox.Text + "</p>" +
        //        "</body>" +
        //        "</html>";
        //}
        //

    }
}
