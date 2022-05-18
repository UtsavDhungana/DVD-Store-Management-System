<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ViewCopyDetailsWithNoBorrowSince31Days.aspx.cs" Inherits="RopeyDVDs.ViewCopyDetailsWithNoBorrowSince31Days" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-2 mb-3">
        <div class="card shadow p-2">
            <div class="card-body">
                <center>
                    <h2 style="color: #1E90FF;">Details of DVD Copies which has not been loaned in last 31 days.</h2>
                </center>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-12 mx-auto">
                        <asp:GridView ID="gvDVD" class="table" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                            <Columns>
                                <asp:BoundField DataField="DVDNumber" HeaderText="S.No" ReadOnly="True" SortExpression="DVDNumber">
                                    <ItemStyle Font-Bold="false" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid m-2">
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("DVDTitle") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row mt-3">
                                                        <div class="col-12">
                                                            <span>Copy No. - </span>
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("CopyNumber") %>'></asp:Label>
                                                            &nbsp;| <span><span>&nbsp;</span>Loaned Date - </span>
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("DateOut") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row mt-2">
                                                        <div class="col-12">
                                                            <span>Days Since Last Loan - </span>
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Days Since First Loan") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2 card shadow">
                                                    <asp:Image class="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("DVDImage") %>' />
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
    </div>
</asp:Content>
