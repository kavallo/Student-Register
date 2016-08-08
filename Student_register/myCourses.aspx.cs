using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student_register
{
    public partial class myCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Based on user type, changes the SelectCommand for the DataSource
            if(Request.Cookies["current_user"] != null)
            {
                if (Request.Cookies["current_user"]["role"] == "student") //If you are a student, selects only courses that you are nerolled in
                    studentCourses.SelectCommand = "SELECT courses.id, courses.name FROM courses, enrolls WHERE enrolls.student_id = " + Convert.ToInt32(Request.Cookies["current_user"]["id"]) + "AND enrolls.course_id = courses.id";
                else if (Request.Cookies["current_user"]["role"] == "teacher") //If you are a teaher, selects only courses you teach
                    studentCourses.SelectCommand = "SELECT courses.id, courses.name FROM courses WHERE courses.teacher_id = " + Convert.ToInt32(Request.Cookies["current_user"]["id"]);
            }
            studentCourses.DataBind();
            coursesGrid.DataBind();
        }

        protected void coursesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (Request.Cookies["current_user"] != null)
                {
                    if (Request.Cookies["current_user"]["role"] == "student") //If you are a student, redirects straight to the grades page, passing the right id's
                        Response.Redirect("~/grades.aspx?student_id=" + Request.Cookies["current_user"]["id"] + "&course_id=" + coursesGrid.Rows[index].Cells[1].Text);
                    else if (Request.Cookies["current_user"]["role"] == "teacher")// If you are a teacher, redirects to the course page instad
                        Response.Redirect("~/course.aspx?course_id=" + coursesGrid.Rows[index].Cells[1].Text);
                }
                    
            }
        }
    }
}