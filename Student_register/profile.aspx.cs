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
    public partial class profile : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["RegisterConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //On page load, gets the information about the current user from the database
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE id = " + int.Parse(Request.Cookies["current_user"]["id"]), conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //Sets the basic information to the labels
                userNameLabel.Text = reader.GetString(1);
                nameLabel.Text = reader.GetString(3) + " " + reader.GetString(4);
                roleLabel.Text = reader.GetString(5);
            }
            conn.Close();
        }

        protected void changeButton_Click(object sender, EventArgs e)
        {
            //Checks if the old password matches with the one that was entered by the user
            if (Request.Cookies["current_user"]["password"] == oldPswBox.Text)
            {
                //If yes, calls an UPDATE query and updates the password of the user
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("UPDATE users SET psw = '" + newPswBox.Text + "' WHERE id = " + Request.Cookies["current_user"]["id"], conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                successPanel.InnerHtml = "<div class='panel-heading'>Success!</div> <div class='panel-body'>Your password has been changed!</div>";
            }
            else
            {
                pswLabel.Text = "Entered password doesn't match current one"; //Informs the user that the entered password doesn't match with the one in the database
            }
        }
    }
}