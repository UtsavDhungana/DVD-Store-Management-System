<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="CurrentlyLoanedDVD.aspx.cs" Inherits="RopeyDVDs.CurrentlyLoanedDVD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container mt-5 mb-3">
        <div class="card shadow">
            <div class="card-body">
                <center>
                    <h2 style="color: #1E90FF;">All DVD Copies Currently On Loan</h2>
                </center>
            </div>
            <div class="card-body">
                <div class="row">
                     <div class="row mt-4">
                            <div class="col-8 mb-3" style="padding-left: 100px">
                                <asp:Button class="btn btn-primary" ID="btnTitle" Style="background-color: #1E90FF; width: 30%; font-size: 20px; font-weight: 400; padding: 5px;" runat="server" Text="Sort By DVD Title" OnClick="btnTitle_Click" />
                            </div>
                            <div class="col-4 mb-3" style="padding-left: 100px">
                                <asp:Button class="btn btn-primary" ID="btnDateOut" Style="background-color: #1E90FF; width: 80%; font-size: 20px; font-weight: 400; padding: 5px;" runat="server" Text="Sort By Date Out" OnClick="btnDateOut_Click" />
                            </div>
                        </div>
                    <div class="col-11 mx-auto mt-2">
                        <asp:GridView ID="gvDVD" class="table" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                            <Columns>
                                <asp:BoundField DataField="CopyNumber" HeaderText="Copy.No" ReadOnly="True" SortExpression="CopyNumber">
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
                                                    <div class="row mt-2">
                                                        <div class="col-12">
                                                            <span>Member - </span>
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Member Name") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row mt-2">
                                                        <div class="col-12">
                                                            <span>Date Out - </span>
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("DateOut") %>'></asp:Label>
                                                            &nbsp;| No. of loan on each date out -
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("total loan of the member by day") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row mt-2">
                                                        <div class="col-12">
                                                            <span>Due Date - </span>
                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("DateDue") %>'></asp:Label>
                                                            &nbsp;| Return Date -
                                                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("DateReturned") %>'></asp:Label>
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
