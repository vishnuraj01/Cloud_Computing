<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="CreateDeleteTPA2.aspx.cs" Inherits="Admin_CreateDeleteTPA" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1030">
        <tr>
            <td class="heading" colspan="3">
                create / delete TPA</td>
        </tr>
        <tr>
            <td width="160">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="430">
                <asp:ScriptManager ID="ScriptManager2" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td width="160">
                &nbsp;</td>
            <td width="150">
                &nbsp;</td>
            <td width="430">
                <asp:RadioButton ID="rbtn_create" runat="server" AutoPostBack="True" 
                    GroupName="1" oncheckedchanged="rbtn_create_CheckedChanged" Text="Create" 
                    CssClass="style1" />
                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
                    GroupName="1" Text="Delete" 
                    oncheckedchanged="RadioButton2_CheckedChanged" />
            </td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="150" colspan="2">
                <asp:Panel ID="Panel1" runat="server">
                    <table width="580">
                        <tr>
                            <td   colspan="2" 
                                style="font-size: x-large; font-style: italic; color: #CC3300;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="200"  >
                                Name</td>
                            <td width="380" >
                                <asp:TextBox ID="txt_name" runat="server" Placeholder="Enter Username" CssClass="textbox"></asp:TextBox>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td  >
                                Password</td>
                            <td  >
                                <asp:TextBox ID="txt_pwd" runat="server" 
                TextMode="Password" Placeholder="Enter Password" CssClass="textbox"></asp:TextBox>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Confirm Password</td>
                            <td>
                                <asp:TextBox ID="txt_cpwd" runat="server" Placeholder="Confirm Password" CssClass="textbox" 
                                    TextMode="Password"></asp:TextBox>
                                
                                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_pwd" ControlToValidate="txt_cpwd" ErrorMessage="Mismatch" ForeColor="Red"></asp:CompareValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" >
                                
                                <asp:Button ID="Button2" runat="server" CssClass="myButton" onclick="Button1_Click" Text="create" />
                                &nbsp;
                                <asp:Button ID="dtn_cancel" runat="server" CssClass="myButton"  Text="Cancel" OnClick="dtn_cancel_Click" />
                                </td>
                        </tr>
                        <tr>
                            <td >
                                &nbsp;</td>
                            <td >
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="50">
                &nbsp;</td>
            <td width="350" colspan="2">
                <asp:Panel ID="Panel2" runat="server">
                    <table width="580" >
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                                    Width="555px" AutoGenerateColumns="False" DataKeyNames="id" 
                                    onrowdeleting="GridView1_RowDeleting">
                                    <Columns>
                                        <asp:BoundField DataField="name" HeaderText="TPA Name" />
                                        <asp:BoundField DataField="cloud" HeaderText="Cloud" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                    <RowStyle ForeColor="#000066" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
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
                        </tr>
                    </table>
                </asp:Panel>
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

