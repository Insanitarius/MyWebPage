<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signUpCompletion.aspx.cs" Inherits="MyWebPage.signUpCompletion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url('image.jpg')">
    <form id="form1" runat="server">


         <asp:RadioButtonList ID="RadioButtonList1" runat="server">
             <asp:ListItem Value="teacher">Teacher</asp:ListItem>
             <asp:ListItem Value="student">Student</asp:ListItem>
         </asp:RadioButtonList>


         <asp:Button ID="Button1" runat="server" Text="Submit" onClick="submit"/>
    </form>
</body>
</html>
