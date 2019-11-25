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
    public partial class signUpCompletion : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cs);
            int uids = Int32.Parse(Session["uid"].ToString());
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO roles (uid,role) VALUES("+uids+",'"+ RadioButtonList1.SelectedValue + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            Session.Abandon();
            Response.Redirect("index.aspx");
        }

    }
}