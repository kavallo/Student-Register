using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_register
{
    public partial class Menu : System.Web.UI.MasterPage
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["current_user"] != null)
            {
                //On page load, based on the user type, fills the navigational bar with the right links by injecting the div tab with HTML
                string role = Request.Cookies["current_user"]["role"];
                userLabel.Text = "Hello, " + Request.Cookies["current_user"]["firstname"] + ", logged-in as: " + Request.Cookies["current_user"]["role"];
                if(role == "admin")
                    menuBar.InnerHtml = "<li><a href='courses.aspx'>Courses</a></li> <li><a href='users.aspx'>Users</a></li> <li><a href='profile.aspx'>Profile</a></li>";
                else if(role == "teacher")
                    menuBar.InnerHtml = "<li><a href='myCourses.aspx'>My Courses</a></li> <li><li><a href='profile.aspx'>Profile</a></li>";
                else if(role == "student")
                    menuBar.InnerHtml = "<li><a href='myCourses.aspx'>My Courses</a></li> <li><a href='courses.aspx'>Courses</a></li> <li><a href='profile.aspx'>Profile</a></li>";
            }
            else
            {
                //If a user is not logged-in, redirects back to the login page
                Response.Redirect("~/login.aspx");
            }
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            //Logs out the user by removing his or hers cookie
            if (Request.Cookies["current_user"] != null)
            {
                Response.Cookies["current_user"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("~/login.aspx");
            }
        }
    }
}