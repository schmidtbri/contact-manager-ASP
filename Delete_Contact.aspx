<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Delete_Contact.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center>
    First Name:
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Last Name:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
&nbsp;
        <br /><br /><asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
        </center>
</asp:Content>


