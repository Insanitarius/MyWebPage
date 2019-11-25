using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebPage
{
    public partial class classes : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            SqlConnection connection = new SqlConnection(cs);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT role FROM roles r,users u WHERE r.uid=u.uid AND u.email='"+email+"'", connection);
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader(); 
            string temp="";
            while (reader.Read())
            {
                temp += reader["role"].ToString();
            }
            connection.Close();

            if (temp == "teacher")
            {
                Response.Write("<script>alert('Teacher');</script>");
            }
            else
            {
                Response.Write("<script>alert('Student');</script>");
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Response.Output.Write("<br/>");
        }
    }
}