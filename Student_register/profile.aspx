<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Student_register.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-success" runat="server" id="successPanel">
        
    </div>
    <label class="h2">Profile:</label><br />
    <b class="h3">Username: </b><asp:Label ID="userNameLabel" runat="server" CssClass="h4"></asp:Label><br />
    <b class="h3">Name: </b><asp:Label ID="nameLabel" runat="server" CssClass="h4"></asp:Label><br />
    <b class="h3">Role: </b><asp:Label ID="roleLabel" runat="server" CssClass="h4"></asp:Label><br />
    <label class="h2">Change password:</label><br />
    <b class="h3">Old password: </b><asp:TextBox ID="oldPswBox" runat="server" CssClass="form-inline" TextMode="Password"></asp:TextBox>
<asp:Label ID="pswLabel" runat="server" CssClass="label-danger"></asp:Label>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldPswBox" CssClass="label-warning" Display="Dynamic" ErrorMessage="Field cannot be empty"></asp:RequiredFieldValidator>
<br />
    <b class="h3">New password: </b><asp:TextBox ID="newPswBox" runat="server" CssClass="form-inline" TextMode="Password"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="newPswBox" CssClass="label-warning" Display="Dynamic" ErrorMessage="Field cannot be empty"></asp:RequiredFieldValidator>
<br />
    <b class="h3">Repeat password: </b><asp:TextBox ID="rePswBox" runat="server" CssClass="form-inline" TextMode="Password"></asp:TextBox>
<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="newPswBox" ControlToValidate="rePswBox" CssClass="label-danger" Display="Dynamic" ErrorMessage="Passwords don't match"></asp:CompareValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="rePswBox" CssClass="label-warning" Display="Dynamic" ErrorMessage="Field cannot be empty"></asp:RequiredFieldValidator>
<br />
<asp:Button ID="changeButton" runat="server" CssClass="btn" OnClick="changeButton_Click" Text="Change Password" />
</asp:Content>
