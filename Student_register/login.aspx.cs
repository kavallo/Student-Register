using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_register
{
    public partial class login : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["RegisterConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //On page load, checks if you are already logged in by checking if "current_user" cookies exists, if yes, redirects to the next page
            if (Request.Cookies["current_user"] != null)
            {
                string role = Request.Cookies["current_user"]["role"];
                if(role == "admin")
                    Response.Redirect("~/courses.aspx");
                else
                    Response.Redirect("~/myCourses.aspx");
            }
                
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            //Checks if the enterned username and password exist and match inside of the database
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username='" + username.Text + "' AND psw='" + password.Text + "'", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                //If it doesn't find a mtach, informs the user about it
                message.Text = "Invalid username or password";
                conn.Close();
            }
            else
            {
                //If finds, creates a new cookie with the user information that will be used on the pages and redirects to the next page
                message.Text = null;
                HttpCookie userCookie = new HttpCookie("current_user");
                userCookie["id"] = Convert.ToString(reader.GetInt32(0));
                userCookie["username"] = reader.GetString(1);
                userCookie["password"] = reader.GetString(2);
                userCookie["firstname"] = reader.GetString(3);
                userCookie["lastname"] = reader.GetString(4);
                userCookie["role"] = reader.GetString(5);
                userCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(userCookie);
                if(reader.GetString(5) == "admin")
                    Response.Redirect("~/courses.aspx");
                else
                    Response.Redirect("~/myCourses.aspx");
                conn.Close();
            }
        }
    }
}