﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Invalidfiles.aspx.cs" Inherits="Admin_AlfilesCloud1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650">
        <tr>
            <td class="heading" colspan="3">
                Invalid files</td>
        </tr>
        <tr>
            <td width="10">
                &nbsp;</td>
            <td width="630">
                &nbsp;</td>
            <td width="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="center">
                <asp:GridView ID="GridView1" 
                runat="server" AutoGenerateColumns="False" AllowPaging="True" BackColor="White" 
                    BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    onpageindexchanging="GridView1_PageIndexChanging" Width="630px" CssClass="Grid" AlternatingRowStyle-CssClass="alt" PagerStyle-CssClass="pgr"
                    PageSize="15" DataKeyNames="Fid" onrowdeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="fowner" HeaderText="File Owner " />
                        <asp:BoundField DataField="fsubject" HeaderText="File Name" />
                        <asp:BoundField DataField="fsizeinkb" HeaderText="File Size(KB)" />
                        <asp:BoundField DataField="fdatetime" HeaderText="Uploaded Date" />
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
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

