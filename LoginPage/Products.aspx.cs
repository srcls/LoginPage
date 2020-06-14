using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginPage
{
    public partial class Products : System.Web.UI.Page
    {
        List<List<string>> columnData = new List<List<string>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (SqlConnection sqlCon =
                new SqlConnection(@"Data Source=(LocalDB)\LocalDBPai;initial Catalog=PAI;Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "SELECT ProductName FROM Products";
                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData.Add(new List<string>());
                            columnData[columnData.Count - 1].Add(reader.GetString(0));
                            
                        }
                    }
                }

                int i = 0;
                query = "SELECT Price FROM Products";
                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            columnData[i].Add(reader.GetInt32(0).ToString());
                            i++;
                        }
                    }
                }

                i = 0;
                string tableHtml = "<table border=1>\n<tr><th>Produkt</th><th>Cena</th></tr>";
                foreach (var element in columnData)
                {
                    tableHtml += "<tr><td>" + element[0] + "</td>";
                    tableHtml += "<td>" + element[1] + "</td>";
                    tableHtml += "<td><button type=\"button\" onclick=\"location.href = \'Cart.aspx?ProductName="+element[0]+"&Price="+element[1]+"\'; \">Add to cart</button></td></tr>";
                    i++;
                }

                tableHtml += "</table>";
                txtProduct.Text = tableHtml;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSort_Click(object sender, EventArgs e)
        {
            if (SortList.SelectedValue == "PriceAsc")
            {
                columnData = columnData.OrderBy(o => Int32.Parse(o[1])).ToList();

            }
            else
            {
                columnData = columnData.OrderBy(o => Int32.Parse(o[1])).ToList();
                columnData.Reverse();
            }
            string tableHtml = "<table border=1>\n<tr><th>Produkt</th><th>Cena</th></tr>";
            foreach (var element in columnData)
            {
                tableHtml += "<tr><td>" + element[0] + "</td>";
                tableHtml += "<td>" + element[1] + "</td>";
                tableHtml += "<td><button type=\"button\">Add to cart</button></td></tr>";

            }

            tableHtml += "</table>";
            txtProduct.Text = tableHtml;
        }

        protected void btnFiltr_Click(object sender, EventArgs e)
        {
            Regex rx = new Regex(".*"+txtFiltr.Text+".*",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            

            
            string tableHtml = "<table border=1>\n<tr><th>Produkt</th><th>Cena</th></tr>";
            foreach (var element in columnData)
            {
                MatchCollection matches = rx.Matches(element[0]);
                if (matches.Count > 0)
                {
                    tableHtml += "<tr><td>" + element[0] + "</td>";
                    tableHtml += "<td>" + element[1] + "</td>";
                    tableHtml += "<td><button type=\"button\">Add to cart</button></td></tr>";
                }
            }

            tableHtml += "</table>";
            txtProduct.Text = tableHtml;
        }
    }
}