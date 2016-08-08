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
    public partial class users : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["RegisterConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            //Adds a new user
            Random rand = new Random();
            int number = rand.Next(10, 99); //Generates a random number between 10 to 99
            string username = "t" + Convert.ToString(DateTime.Now.Year).Substring(3) + fName.Text.Substring(0, 2) + lName.Text.Substring(0, 2) + Convert.ToString(number); //Creates the username by adding the last number of the year to the letter T, combing it with a the first 2 letters of the firtsname and lastname adding a random number at the end
            string psw = Convert.ToString(rand.Next(1000, 9999)); //Makes the password a random number between 1000 and 9999
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("INSERT INTO users(username, psw, firstname, lastname, usertype) VALUES('" + username.ToLower() + "', '" + psw + "', '" + fName.Text + "', '" + lName.Text + "', '" + roleList.SelectedValue + "')", conn); //Adds to the database
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            fName.Text = null;
            lName.Text = null;
            userDataSource.DataBind();
            userGrid.DataBind();
            //Bind the new data to the Data source and gridView
        }
    }
}