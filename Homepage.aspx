<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><br /><asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow runat="server">   <asp:TableCell runat="server">Username: </asp:TableCell><asp:TableCell ID="TableCell1" runat="server">     <asp:TextBox ID="Username" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            <asp:TableRow runat="server">   <asp:TableCell runat="server">Password: </asp:TableCell><asp:TableCell runat="server">    <asp:TextBox ID="Password" runat="server"></asp:TextBox></asp:TableCell></asp:TableRow>
            
        </asp:Table> 
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" style="height: 26px"></asp:Button>
     </center>
</asp:Content>

