<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br /><br /><center><asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
    <table bprder="0">
        <tr><td>Name: </td><td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td></tr>
        <tr><td>Username: </td><td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td></tr>
        <tr><td>Password: </td><td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td></tr>
        <tr><td></td><td><asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"></asp:Button></td></tr>
    </table>
        </center>
    
    

</asp:Content>

