<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Awesome Login Form Responsive Widget,Login form widgets, Sign up Web forms , Login signup Responsive web form,Flat Pricing table,Flat Drop downs,Registration Forms,News letter Forms,Elements" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- Meta tag Keywords -->
<!-- css files -->
<link rel="stylesheet" href="css/style.css" type="text/css" media="all" /> <!-- Style-CSS --> 
<link rel="stylesheet" href="css/font-awesome.css"> <!-- Font-Awesome-Icons-CSS -->
<!-- //css files -->
<!-- web-fonts -->
<link href="//fonts.googleapis.com/css?family=Philosopher:400,400i,700,700i&amp;subset=cyrillic,cyrillic-ext,vietnamese" rel="stylesheet">

</head>
<body>
     

<div data-vide-bg="video/social2">
	<div class="center-container">
		<!--header-->
		<div class="header-w3l">
			 
		</div>
		<!--//header-->
		<!--main-->
		<div class="main-content-agile">
			<div class="wthree-pro">
				<h2>CHANGE PASSWORD</h2>
			</div>
			<div class="sub-main-w3">	
				<form id="form1" runat="server">
                    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
					   <asp:TextBox ID="txtPwd" runat="server" CssClass="textbox" MaxLength="15" TextMode="Password" placeholder="NEW PASSWORD"></asp:TextBox>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPwd" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
           
					<span class="icon1"><i class="fa fa-user" aria-hidden="true"></i></span>
					 <asp:TextBox ID="txtCPwd" runat="server" CssClass="textbox" TextMode="Password" MaxLength="15" placeholder="CONFIRM PASSWORD"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="**" ForeColor="Red"></asp:RequiredFieldValidator>
           <span class="icon2"><i class="fa fa-unlock" aria-hidden="true"></i></span>
                    <table width="100%">
                        <tr>
                            <td align="left" style="float:left;">
 
						<a href="../Home.aspx">Back to Home</a>
						 
					 
                            </td>
                            <td align="right" style="float:right;">
   
						  
					 
                            </td>
                        </tr>
                        <tr>
                            <td height="35px"></td>
                        </tr>
                    </table>
					
                  
					<div class="navbar-right social-icons"> 
							<ul>
								<li><a href="#" class="fa fa-facebook icon-border facebook"> </a></li>
								<li><a href="#" class="fa fa-twitter icon-border twitter"> </a></li>
								<li><a href="#" class="fa fa-google-plus icon-border googleplus"> </a></li> 
								<li><a href="#" class="fa fa-pinterest icon-border rss"> </a></li>
							</ul>  
						</div>
					 <asp:Button ID="btnLogin" runat="server" Text="UPDATE" OnClick="btnLogin_Click" />
                </form>
			</div>
		</div>
		<!--//main-->
		<!--footer-->
		<div class="footer">
            <p>© 2024 Multicloud Storage. All rights reserved | Design by <a href="#">Vishnuraj Nellithanam Raveendran</a></p>
		</div>
		<!--//footer-->
	</div>
</div>
<!-- js -->
<script type="text/javascript" src="js/jquery-2.1.4.min.js"></script>
<script src="js/jquery.vide.min.js"></script>
<!-- //js -->

 
    
</body>
</html>
