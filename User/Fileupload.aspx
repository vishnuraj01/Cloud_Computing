<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.master" AutoEventWireup="true" CodeFile="Fileupload.aspx.cs" Inherits="User_Fileupload" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <table>
        <tr>
            <td colspan="3">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table width="650">
                            <tr>
                                <td class="heading" colspan="3">file upload</td>
                            </tr>
                            <tr>
                                <td width="100">&nbsp;</td>
                                <td width="150">&nbsp;</td>
                                <td width="380">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>User Name</td>
                                <td>
                                    <asp:Label ID="lbl_uid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Upload Option</td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">Minimum</asp:ListItem>
                                        <asp:ListItem Value="2">Medium</asp:ListItem>
                                        <asp:ListItem Value="3">High</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>File Key</td>
                                <td>
                                    <asp:TextBox ID="txt_filekey" runat="server" CssClass="textbox" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                    <cc1:TextBoxWatermarkExtender ID="txt_filekey_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txt_filekey" WatermarkCssClass="watermark" WatermarkText="key">
                                    </cc1:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>Upload File</td>
                                <td>
                                    <asp:FileUpload ID="flup_user" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="300">&nbsp;</td>
            <td>
                    <asp:Button ID="btn_submit" runat="server" CssClass="myButton" onclick="btn_submit_Click" Text="Submit" />
                    &nbsp;<asp:Button ID="btn_cancel" runat="server" CausesValidation="False" CssClass="myButton" OnClick="btn_cancel_Click" Text="Cancel" />
                </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>


