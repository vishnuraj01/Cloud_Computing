<%@ Page Title="" Language="C#" MasterPageFile="~/Tpa/TPALogin/Tpa.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
    <div class="wthreename agileinfow3ls">
						<div class="wthreename-lable wthreelable">
							<label>Username</label><span class="colon">:</span>
						</div>
						<div class="wthreename-input wthreeinput">
                            <asp:TextBox ID="txt_uname" CssClass="top" placeholder="Username" runat="server"></asp:TextBox>
							 
						</div>
						<div class="clear"></div>
					</div>

    <div class="wthreename agileinfow3ls">
						<div class="wthreename-lable wthreelable">
							<label>Password</label><span class="colon">:</span>
						</div>
						<div class="wthreename-input wthreeinput">
							 <asp:TextBox ID="txt_pwd" CssClass="top" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
						</div>
						<div class="clear"></div>
					</div>
<div class="aitssubmitw3ls">

    <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
					</div>
    </asp:Content>

