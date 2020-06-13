using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            labelErrorMessage.Visible = false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] pass = (Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            string passw = new string(pass);
            MailMessage mailMessage = new MailMessage();
            MailAddress fromAddress = new MailAddress("recovery@mail.com");
            mailMessage.From = fromAddress;
            mailMessage.To.Add(txtEmail.Text);
            mailMessage.Body = "new password: " + passw;
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = " Recovery password";
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "localhost";
            smtpClient.Send(mailMessage);

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\LocalDBPai;initial Catalog=PAI;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM UserTable WHERE UserName=@UserName";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", txtEmail.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    query = "UPDATE UserTable SET Password = '"+ passw + "' WHERE UserName=@UserName;";
                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@UserName", txtEmail.Text.Trim());
                    sqlCmd.ExecuteScalar();

                    Response.Redirect("Login.aspx");

                }
                else
                {
                    labelErrorMessage.Visible = true;

                }
            }
        }
    }
}