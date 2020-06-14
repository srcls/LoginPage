using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPage
{

    public partial class Cart : System.Web.UI.Page
    {
        public float sum = 0;
        public List<string> prods = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] == null)
            {
                Session["Cart"] = "Zawartosc koszyka: ";
                Session["Sum"] = 0;
            }




            if (Request.QueryString["ProductName"] != null)
            {
                Session["Cart"] += Request.QueryString["ProductName"];
                prods.Add(Request.QueryString["ProductName"]);
            }

            if (Request.QueryString["Price"] != null)
            {
                Session["Cart"] += ": " + Request.QueryString["Price"] + ",\t\t";
                sum = Int32.Parse(Request.QueryString["Price"]) + Int32.Parse(Session["Sum"].ToString());
                Session["Sum"] = sum;
            }

            Response.Write(Session["Cart"]);
            lblSum.Text = "Suma: " + Session["Sum"];
        }

        protected void btnBuy_Click(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                using (SqlConnection sqlCon =
                    new SqlConnection(@"Data Source=(LocalDB)\LocalDBPai;initial Catalog=PAI;Integrated Security=True;")
                )
                {
                    int id = 0;
                    sqlCon.Open();
                    string query = "SELECT UserID FROM UserTable WHERE UserName=@UserName";
                    using (SqlCommand command = new SqlCommand(query, sqlCon))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader.GetInt32(0);
                                query = "INSERT INTO Zamowienie (UserID) VALUES (" + id + ")";
                                SqlCommand newcommand = new SqlCommand(query, sqlCon);
                                newcommand.ExecuteNonQuery();
                            }
                        }
                    }

                    foreach (var element in prods)
                    {
                        query = "INSERT INTO Zamowienie (ProductName) VALUES(\"" + element + "\")";
                        using (SqlCommand command = new SqlCommand(query, sqlCon))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }

                Session["Cart"] = null;
                Session["Sum"] = null;
            }
        }
    }
}