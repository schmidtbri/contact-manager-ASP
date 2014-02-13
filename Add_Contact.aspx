<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Add_Contact.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br /><center>
<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br /><br />

        Contact Details:<br />
          <table border="0">
           <tr><td>First Name:</td><td><asp:TextBox ID="FirstName" runat="server"></asp:TextBox></td>
           <td><asp:RequiredFieldValidator id="RequiredFieldValidator1"  runat="server" ControlToValidate="FirstName" ErrorMessage="Please enter a first name." /></td></tr>

           <tr><td>Last Name: </td><td><asp:TextBox ID="LastName" runat="server"></asp:TextBox></td>
           <td><asp:RequiredFieldValidator id="RequiredFieldValidator2"  runat="server" ControlToValidate="LastName" ErrorMessage="Please enter a last name." /></td></tr>

           <tr><td>Email: </td><td><asp:TextBox ID="Email" runat="server"></asp:TextBox></td>
           <td><asp:RequiredFieldValidator id="RequiredFieldValidator3"  runat="server" ControlToValidate="Email" ErrorMessage="Please enter an email." />
           <asp:RegularExpressionValidator ID="regexpemail" runat="server" ErrorMessage="This is not a valid email address" ControlToValidate="Email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
           </td></tr>

           <tr><td>Home Phone: </td><td><asp:TextBox ID="HomePhone" runat="server"></asp:TextBox></td>
           <td><asp:RequiredFieldValidator id="RequiredFieldValidator4"  runat="server" ControlToValidate="HomePhone" ErrorMessage="Please enter a home phone." />
           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="This is not a valid phone number." ControlToValidate="HomePhone" ValidationExpression="^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$" />
           </td></tr> 

           <tr><td>Cell Phone: </td><td><asp:TextBox ID="CellPhone" runat="server"></asp:TextBox></td>
           <td><asp:RequiredFieldValidator id="RequiredFieldValidator5"  runat="server" ControlToValidate="CellPhone" ErrorMessage="Please enter a cell phone." />
           <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="This is not a valid phone number." ControlToValidate="CellPhone" ValidationExpression="^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$" />
           </td></tr>
              
           <tr><td></td><td>
               <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" /></td></tr>
          </table>
        </center>

        
        


</asp:Content>

