<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="myCourses.aspx.cs" Inherits="Student_register.myCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My courses:</h1>
    <asp:GridView ID="coursesGrid" runat="server" AutoGenerateColumns="False" CssClass="table-condensed" DataKeyNames="id" DataSourceID="studentCourses" OnRowCommand="coursesGrid_RowCommand" EmptyDataText="No courses available" GridLines="Horizontal">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="Course ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="Course Name" SortExpression="name" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="studentCourses" runat="server" ConnectionString="<%$ ConnectionStrings:RegisterConnection %>" SelectCommand=""></asp:SqlDataSource>

</asp:Content>
