<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyWebPage.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link href="Main.css" rel="stylesheet"/>
        <script src="jquery-1.10.2.min.js"></script>
        <script src="JQUERYMain.js"></script>
        <meta name="viewport" content="width=device-width,intial-scale=1" />
    </head>
    <body>
        <form id="form1" runat="server">
        <div id="main">
            <table border="0" cellspacing="10">
                <tr>
                    <td>
                        <div id="title">SIGN IN</div>
                        <hr size="1px" width="100px" color="black"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="sinEmail" runat="server" class="input100" placeholder="EMAIL ID"></asp:TextBox>    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="sinPass" runat="server" class="input100" placeholder="PASSWORD" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <div id="frt">FORGOT PASSWORD?</div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                         <asp:Button ID="signInBtn" runat="server" Text="SIGN IN" onClick="signIn" />        
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div id="signUpMsg">DON'T HAVE AN ACCOUNT? <a href="#" id="flipToSignUp">REGISTER</a></div>
                    </td>
                </tr>
            </table>
        </div>
        
        <div id="signUpForm">
            <table border="0" cellspacing="10">
                <tr>
                    <td>
                        <div id="title">REGISTER</div>
                        <hr size="1px" width="130px" color="black"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="supFname" runat="server" class="input100" placeholder="FULL NAME"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="supEmail" runat="server" class="input100" placeholder="EMAIL ID"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="supPass" runat="server" class="input100" placeholder="PASSWORD" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="signUpBtn" runat="server" Text="REGISTER" OnClick="signUp" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <div id="signInMsg">HAVE AN ACCOUNT? <a href="#" id="flipToSignIn">SIGN IN</a></div>
                    </td>
                </tr>
            </table>
        </div>
        
        
        </form>
        
        
    </body>
</html>