<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="ProfileEdit.aspx.cs" Inherits="Reristration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650" 
    style="background-image: url('img/logout-icon6.png'); background-repeat: no-repeat; background-position: right center">
        <tr>
            <td class="heading" colspan="3">
                profile details</td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="430">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                User ID</td>
            <td>
            <asp:TextBox ID="txt_id" runat="server" CssClass="textbox" OnTextChanged="txt_name_TextChanged" ReadOnly="True"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_id_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_id" 
                WatermarkCssClass="watermark" WatermarkText="Enter your name">
            </cc1:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                First
                Name</td>
            <td>
            <asp:TextBox ID="txt_fname" runat="server" CssClass="textbox" OnTextChanged="txt_name_TextChanged"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_fname_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_fname" 
                WatermarkCssClass="watermark" WatermarkText="Enter your name">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_fname"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Last Name</td>
            <td>
            <asp:TextBox ID="txt_lname" runat="server" CssClass="textbox" OnTextChanged="txt_name_TextChanged"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_lname_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_lname" 
                WatermarkCssClass="watermark" WatermarkText="Enter your name">
            </cc1:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                User Name</td>
            <td>
            <asp:TextBox ID="txt_userid" runat="server" CssClass="textbox" ReadOnly="True"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_userid_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_userid" 
                WatermarkCssClass="watermark" WatermarkText="Enter userid">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_userid"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Mobile</td>
            <td>
            <asp:TextBox ID="txt_mobile" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_mobile_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_mobile" 
                WatermarkCssClass="watermark" WatermarkText="Enter mobile number">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_mobile"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Email ID</td>
            <td>
            <asp:TextBox ID="txt_email" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_email_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_email" 
                WatermarkCssClass="watermark" WatermarkText="Enter e_mail">
            </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="*" ControlToValidate="txt_email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txt_email" ErrorMessage="Not a valid mail" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Age</td>
            <td>
            <asp:TextBox ID="txt_age" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txt_age_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txt_age" 
                WatermarkCssClass="watermark" WatermarkText="Enter age">
            </cc1:TextBoxWatermarkExtender>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Gender</td>
            <td>
                <asp:RadioButtonList ID="rbl_gender" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Photo</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_submit" runat="server" CssClass="myButton" 
                    onclick="btn_submit_Click" Text="update" />
            &nbsp;<asp:Button ID="btn_submit0" runat="server" CssClass="myButton" OnClientClick="return confirm('Profile Deletion causes delettion of all files in cloud. Are you sure you want delete');" 
                    onclick="btn_submit0_Click" Text="delete" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

