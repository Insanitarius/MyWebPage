using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;


namespace MyWebPage
{
    public partial class index : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cs);
        }


        public static class Validator
        {

            static Regex ValidEmailRegex = CreateValidEmailRegex();
            static Regex ValidPasswordRegex = CreateValidPasswordRegex();
            private static Regex CreateValidEmailRegex()
            {
                string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
            }

            private static Regex CreateValidPasswordRegex()
            {
                string validPasswordPattern = @"^[a-zA-Z0-9'@&#.\s]{5,18}$";
                //string validPasswordPattern = @"(?=^[^\s]{5,}$)(?=.*\d)(?=.*[a-zA-Z])";

                return new Regex(validPasswordPattern, RegexOptions.IgnoreCase);
            }

            internal static bool EmailIsValid(string emailAddress)
            {
                bool isValid = ValidEmailRegex.IsMatch(emailAddress);

                return isValid;
            }

            internal static bool PasswordIsValid(string password)
            {
                bool isValid = ValidPasswordRegex.IsMatch(password);

                return isValid;
            }
        }






        protected void signUp(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cs);
            int count = 0;
            connection.Open();
            string strngcmd = "SELECT COUNT(*) FROM users WHERE email='" + supEmail.Text + "'";
            SqlCommand commands = new SqlCommand(strngcmd, connection);
            count = (int)commands.ExecuteScalar();
            connection.Close();

            if (!(Validator.EmailIsValid(supEmail.Text))  || String.IsNullOrEmpty(supEmail.Text))
            {
                Response.Write("<script>alert('Invalid Email');</script>");
            }
            
            else if (String.IsNullOrEmpty(supFname.Text) || (supFname.Text == " "))
            {
                Response.Write("<script>alert('Full name cannot be empty!');</script>");
            }

            else if (!(Validator.PasswordIsValid(supPass.Text)) || String.IsNullOrEmpty(supPass.Text))
            {
                Response.Write("<script>alert('Password length must be between 5 to 18 characters');</script>");
            }

            else if (count != 0)
            {
                Response.Write("<script>alert('An account with this Email already exits');</script>");
            }

            else
            {
                string securepass = FormsAuthentication.HashPasswordForStoringInConfigFile(supPass.Text, "SHA512");
                connection.Open();
                string strcmd = "INSERT INTO users (email, pass) VALUES('" + supEmail.Text + "', '" + securepass + "')";
                SqlCommand command = new SqlCommand(strcmd, connection);
                command.ExecuteNonQuery();
                command = new SqlCommand("SELECT * FROM users WHERE email='" + supEmail.Text + "' and pass='" + securepass + "'", connection);
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                command = new SqlCommand("SELECT uid FROM users where email='" + supEmail.Text + "'", connection);
                int uid = (int)command.ExecuteScalar();
                command = new SqlCommand("INSERT INTO temp (uid,fname) VALUES('" + uid + "','" + supFname.Text + "')",connection);
                command.ExecuteNonQuery();
                foreach (DataRow dr in dt.Rows)
                {
                    Session["uid"] = dr["uid"].ToString();
                    Response.Redirect("signUpCompletion.aspx");
                }
                connection.Close();
            }   
        }







        protected void signIn(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(cs);
            string securepass = FormsAuthentication.HashPasswordForStoringInConfigFile(sinPass.Text, "SHA512");
            if (String.IsNullOrEmpty(sinEmail.Text))
            {
                Response.Write("<script>alert('Email cannot be empty!');</script>");
            }

            else if (String.IsNullOrEmpty(sinPass.Text))
            {
                Response.Write("<script>alert('Password cannot be empty!');</script>");
            }

            else {         
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT uid FROM users where email='" + sinEmail.Text + "'", connection);
                int uid = (int)command.ExecuteScalar();
                command = new SqlCommand("SELECT COUNT(*) FROM roles WHERE uid=" + uid, connection);

                if ((int)command.ExecuteScalar() == 0)
                {
                    command = new SqlCommand("SELECT * FROM users WHERE email='" + sinEmail.Text + "' and pass='" + securepass + "'", connection);
                    command.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Session["uid"] = dr["uid"].ToString();
                        Response.Redirect("signUpCompletion.aspx");
                    }
                }

                else { 
                    string strcmd = "SELECT * FROM users WHERE email='"+sinEmail.Text+"' and pass='"+securepass+"'";
                    command = new SqlCommand(strcmd, connection);
                    command.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dt);
                    foreach(DataRow dr in dt.Rows)
                    {
                        Session["email"] = dr["email"].ToString();
                        Response.Redirect("openGates.aspx");
                    }
                }
                connection.Close();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            Response.Output.Write("<br/>");
        }
    }
}
