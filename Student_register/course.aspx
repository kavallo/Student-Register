<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="course.aspx.cs" Inherits="Student_register.course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="courseName" runat="server" CssClass="h1"></asp:Label><br />
    <asp:Label ID="courseTeacher" runat="server" CssClass="h4"></asp:Label>
    <asp:GridView ID="studentGrid" runat="server" AutoGenerateColumns="False" CssClass="table-condensed" DataKeyNames="id" DataSourceID="studentsSource" EmptyDataText="No students enrolled" OnRowDeleted="studentGrid_RowDeleted" OnRowCommand="studentGrid_RowCommand">
        <Columns>
            <asp:CommandField DeleteText="Unenroll" ShowDeleteButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Student ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="firstname" HeaderText="Firstname" SortExpression="firstname" />
            <asp:BoundField DataField="lastname" HeaderText="Lastname" SortExpression="lastname" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="studentsSource" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterConnection %>" 
        SelectCommand="SELECT users.id, users.firstname, users.lastname FROM users, enrolls WHERE users.id = enrolls.student_id AND enrolls.course_id = @course_id"
        DeleteCommand="DELETE FROM enrolls WHERE student_id = @id AND course_id = @course_id">
        <SelectParameters>
	        <asp:QueryStringParameter Name="course_id" QueryStringField="course_id" />
        </SelectParameters>
        <DeleteParameters>
	        <asp:QueryStringParameter Name="course_id" QueryStringField="course_id" />
        </DeleteParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Panel ID="newStudentPanel" runat="server"> 
        <h3>Enroll new student:</h3>
        <label>Firstname:</label>
        <asp:Label ID="fNameLabel" runat="server"></asp:Label>
        <label>, Lastname:</label>
        <asp:DropDownList ID="studentList" runat="server" CssClass="dropdown" DataSourceID="newStudentSource" DataTextField="lastname" DataValueField="id" AutoPostBack="True" OnDataBound="studentList_DataBound" OnSelectedIndexChanged="studentList_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Button ID="enrollButton" runat="server" CssClass="btn" OnClick="enrollButton_Click" Text="Enroll" />
    </asp:Panel>
    <asp:SqlDataSource ID="newStudentSource" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterConnection %>" SelectCommand="SELECT id, lastname FROM users WHERE id NOT IN(SELECT student_id FROM enrolls WHERE course_id = @course_id) AND usertype = 'student'" OnSelected="newStudentSource_Selected">
        <SelectParameters>
	        <asp:QueryStringParameter Name="course_id" QueryStringField="course_id" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
