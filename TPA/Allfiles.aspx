<%@ Page Title="" Language="C#" MasterPageFile="~/Tpa/Clouds.master" AutoEventWireup="true" CodeFile="Allfiles.aspx.cs" Inherits="User_Filedata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="650px">
        <tr>
            <td class="heading">FILES TO BE VERIFIED</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="950px">
                    <Columns>
                        <asp:BoundField DataField="fileid" HeaderText="FILEID" />
                        <asp:BoundField DataField="fowner" HeaderText="OWNER" />
                        <asp:BoundField DataField="fname" HeaderText="NAME" />
                        <asp:BoundField DataField="fext" HeaderText="EXTENSION" />
                        <asp:BoundField DataField="fsize" HeaderText="SIZE" />
                        <%--<asp:BoundField DataField="fkey" HeaderText="KEY" />--%>
                        <asp:BoundField DataField="fsecurity" HeaderText="SECURITY" />
                        <asp:BoundField DataField="fdate" HeaderText="DATE" />
                        <asp:TemplateField HeaderText="DOWNLOAD">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("fileid") %>' OnCommand="LinkButton1_Command">Verify</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

