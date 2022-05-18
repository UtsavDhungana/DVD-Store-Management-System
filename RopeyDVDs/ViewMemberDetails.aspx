<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ViewMemberDetails.aspx.cs" Inherits="RopeyDVDs.ViewMemberDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-2 mb-3">
        <div class="card shadow p-2">
            <div class="card-body">
                <center>
                    <h2 style="color: #1E90FF;">Member Details.</h2>
                </center>
            </div>
            <div class="card-body">
                <div class="row">
                    <asp:GridView ID="gvDVD" class="table" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                        <Columns>
                            <asp:BoundField DataField="MemberNumber" HeaderText="S.No" ReadOnly="True" SortExpression="MemberNumber">
                                <ItemStyle Font-Bold="false" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="container-fluid m-2">
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("MemberName") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mt-4">
                                                    <div class="col-12">
                                                        <span>Membership Type - </span>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("MembershipCategoryDescription") %>'></asp:Label>
                                                        &nbsp;| Total Allowed Loan -
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("MembershipCategoryTotalLoans") %>'></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mt-3">
                                                    <div class="col-12">
                                                        <span>Total Loan - </span>
                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Total Loan") %>'></asp:Label>
                                                        &nbsp;| Current Loan -
                                                                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Total Current Loan") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 my-auto">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Larger" Style="color:red;" Text='<%# Eval("Error Message") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="#1E90FF" Font-Bold="True" ForeColor="white" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
