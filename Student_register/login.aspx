<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Student_register.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="login" runat="server">
    <div style="padding:20%">
        <div class="form-group" style="padding-left:20%; padding-right:20%">
        <label>Username</label>
        <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" CssClass="label-warning" ErrorMessage="Username field is empty"></asp:RequiredFieldValidator>
        <br />
        <label>Password</label>
        <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" CssClass="label-warning" ErrorMessage="Password field is empty"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="loginButton" runat="server" OnClick="loginButton_Click" Text="Login" CssClass="btn" />
        <asp:Label ID="message" runat="server" CssClass="label-danger"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
