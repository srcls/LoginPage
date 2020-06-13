using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPage
{
    public partial class ResetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] passw = (Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var msg = "New password: " + passw;
            var sClient = new SmtpClient("domain-com.mail.protection.outlook.com");
            var message = new MailMessage();

            sClient.Port = 25;
            sClient.EnableSsl = false;
            sClient.Credentials = new NetworkCredential("user", "password");
            sClient.UseDefaultCredentials = false;

            message.Body = msg;
            message.From = new MailAddress("test@test.com");
            
            message.Subject = "Test";
            message.CC.Add(new MailAddress("dude@good.com"));

            sClient.Send(message);
        }
    }
}