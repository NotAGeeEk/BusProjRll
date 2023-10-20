<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="BusBookingProject.Admin.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    
    
    <div class="container" style="margin-top:6%">
        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False" PageSize="20"  Width="100%"  OnRowEditing="GridViewUsers_RowEditing" OnRowCancelingEdit="GridViewUsers_RowCancelingEdit" OnRowUpdating="GridViewUsers_RowUpdating" OnRowDeleting="GridViewUsers_RowDeleting" Font-Size="12">
            <Columns>
                <asp:TemplateField HeaderText="Sr.No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                <asp:BoundField DataField="regId" HeaderText="ID" />
                <asp:BoundField DataField="Fname" HeaderText="First Name" />
                <asp:BoundField DataField="Lname" HeaderText="Last Name" />
                <asp:BoundField DataField="EmailId" HeaderText="Email" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="City" HeaderText="City" />
                <asp:BoundField DataField="Picode" HeaderText="Postal Code" />
                <asp:BoundField DataField="Contact" HeaderText="Contact" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
 <asp:LinkButton ID="lnkEdit" runat="server" href="http://localhost:1778/Admin/UpdateRegs.aspx" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("regId") %>' />                       
                        <asp:LinkButton ID="lnkDelete" runat="server" href="http://localhost:1778/Admin/DeleteRegs.aspx" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("regId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
