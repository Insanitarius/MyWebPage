using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MyWebPage
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signUp(object sender, EventArgs e)
        {
            Response.Write(supEmail.Text);
        }

        protected void signIn(object sender, EventArgs e)
        {
            Response.Redirect("animate.html");
        }
        protected override void OnPreRender(EventArgs e)
        {
            Response.Output.Write("<br/>");
        }
    }
}
