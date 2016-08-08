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
    public partial class course : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["RegisterConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //On page load, connect to the database and selects information about a specific course
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT courses.id, courses.name, users.firstname, users.lastname FROM courses, users WHERE courses.id = " + Convert.ToInt32(Request.QueryString["course_id"]) + " AND courses.teacher_id = users.id", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //Sets the retrieves information to the labels to display the the course name and it's teacher
                courseName.Text = reader.GetString(1);
                courseTeacher.Text = "Teacher: " + reader.GetString(2) + " " + reader.GetString(3);
            }
            conn.Close();
        }

        protected void enrollButton_Click(object sender, EventArgs e)
        {
            //Inserts a new entry into the enrolls table based which course and student in the droplist is selected
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("INSERT INTO enrolls(student_id, course_id) VALUES(" + studentList.SelectedValue + ", " + Request.QueryString["course_id"] + ")", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            newStudentSource.DataBind();
            studentGrid.DataBind();
            studentList.DataBind();
            //Refreshes the page to update the content in the controls
            //Response.Redirect("~/course.aspx?course_id=" + Request.QueryString["course_id"]);
        }

        protected void studentGrid_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //Called when a student is deleted and refreshes the page
            Response.Redirect("~/course.aspx?course_id=" + Request.QueryString["course_id"]);
        }

        protected void studentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Called when you select a student
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                //Checks the command name and redirects to the grades page
                Response.Redirect("~/grades.aspx?student_id=" + studentGrid.Rows[index].Cells[1].Text + "&course_id=" + Request.QueryString["course_id"]);
            }
        }

        protected void newStudentSource_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            //Checks if the dataSource has any data in it, if yes it will display the panel for enrolling students, otherwise it hides it until new students become available
            if (e.AffectedRows < 1)
            {
                newStudentPanel.Visible = false;
            }
            else
            {
                newStudentPanel.Visible = true;
            }
        }

        void setName()
        {
            //Sets the label text to the name of the student that is selected in the droplist
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT firstname FROM users WHERE id=" + studentList.SelectedValue, conn);
            conn.Open();
            fNameLabel.Text = cmd.ExecuteScalar().ToString();

            conn.Close();
        }

        protected void studentList_DataBound(object sender, EventArgs e)
        {
            //Calls the setName method if the droplist is not empty
            if(studentList.Items.Count > 0)
                setName();
        }

        protected void studentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check if there are students in the list, if not hides the panel for enrolling
            if (studentList.Items.Count > 0)
                setName();
            else
                newStudentPanel.Visible = false;
        }
    }
}