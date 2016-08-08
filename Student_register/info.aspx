<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="Student_register.info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-left:5%; padding-right:5%">
        <h1>Info Page</h1>
        <h3>Data Base</h3>
        <img src="Img/diagram.jpg" />
        <p>
            The database for the Student Register contains 4 tables.
        </p>
        <p>
            The table "users" contains the information about the users(students, teachers and admins).
            It holds information such as: the id number of the user, his or hers username and password, first and last names and
            their user type which will be used to limit what each user can do on the webstie.
        </p>
        <p>
            Next table is "courses". This is where the information about the courses is held.
            Each courses has it's own id number, name and foreign key that links to a tacher from the users table.
        </p>
        <p>
            Afterwords, we have the "enrolls" table which is used to to specify which course each student is enrolled.
            It holds two foreign keys: student_id and course_id. Using them we can find out which students belong to which course.
        </p>
        <p>
            Lastly, there is the "grades" table which holds the grade information students. Same as enrolls table it contains
            same foreign keys(student_id and course_id) to specify which grade beongs to which student and course.
            The other colllumns are: grade which holds the grade itself and the grade_date which specifies when theg grade was given.
        </p>
        <h3>Pages</h3>
        <p>
            In this project I'm using Bootstrap for the css mark-up. The project uses 8 pages(including the info page) that all
            have a Master page as it's menu (except for the login page).
        </p>
        <h4>Login.aspx</h4>
        <p>
            This page is used to login into the system. The users inputs a username and password and then the webpage checks
            the database if the username exists and if the password provided matches it. If not, the user is notified the he or she
            entered invalid infomartion. Otherwise, the system puts the user info into a Cookie for future use and remember the log-in
            and based on the user type redirects to either myCourses if you are a teacher or student and to Courses if admin.
        </p>
        <h4>Courses.aspx</h4>
        <p>
            This pages displays all of the courses in the database. As an admin, you can add/edit/remove the courses and select
            any of them to see a list of students. As a student, you can see courses you are not enrolled in and can enroll into 
            one of them which disapears afterwards. Teacher cannot access this page.
        </p>
        <h4>Course.aspx</h4>
        <p>
            This page displays a list of students where an admin or a teacher can enroll and unroll students from this course.
            You can also select a student and see his or hers grades. Students cannot see this page.
        </p>
        <h4>Users.aspx</h4>
        <p>
            This page can only be accessed by an admin. Here, he or she can add/edit/remove students and teachers. The usernames
            and passwords are generated automatically.
        </p>
        <h4>MyCourses.aspx</h4>
        <p>
            This page is meant for students and teacher. It will display courses that they teach or study. As a teacher, if you select one
            you will go alistf students where you can pick a student to modify their grades. As a student, if you select a course
            you will instead see your grades in that course.
        </p>
        <h4>Grades.aspx</h4>
        <p>
            This page displays the grade of each student in each course. Teachers can add/edit/remove grades while the students
            can only view them.
        </p>
        <h4>Profile.aspx</h4>
        <p>
            On this page, each user can see their own basic information and change their password.
        </p>
    </div>
</asp:Content>
