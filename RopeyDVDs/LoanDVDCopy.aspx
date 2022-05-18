<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="LoanDVDCopy.aspx.cs" Inherits="RopeyDVDs.LoanDVDCopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="justify-content: center; padding-top: 0rem">
        <div class="row mt-1 align-content-center">
            <div class="card mx-auto mt-4 shadow" style="width: 30rem; padding: 0px 80px 0px 80px; box-shadow: 10px 10px 10px 10px rgba(0,0,0,0.5);">
                <div class="card-body">
                    <div class="row mt-2 mb-4">
                        <div class="col mb-4">
                            <center>
                                <h4>Loan DVD Copies.</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-12">
                            <label for="memberNameTB" id="lblMemberName">
                                Member Number
                            </label>
                            <asp:DropDownList ID="memberNumberDD" runat="server" AutoPostBack="false" Width="100%" Height="75%"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mt-3"></div>
                    <div class="row mt-3">
                        <div class="col-12">
                            <label for="dvdTitleTB" id="lblDVDTitle">
                                Available Copy Number
                            </label>
                            <asp:DropDownList ID="CopyNumberDD" runat="server" Width="100%" AutoPostBack="false" Height="75%"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mt-3"></div>
                    <div class="row mt-3">
                        <div class="col-12">
                            <label for="loanNumberTB" id="lblLoanNumber">
                                Loan Type Number
                            </label>
                            <asp:DropDownList ID="LoanTypeNumberDD" runat="server" Width="100%" AutoPostBack="false" Height="75%"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mt-3"></div>
                    <div class="row mt-3">
                        <div class="col-12">
                            <label for="dueDateTB" id="lblDueDateTB">
                                Date Out
                            </label>
                            <asp:TextBox ID="dateOutTB" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="mx-auto mt-5">
                        <center>
                            <asp:Button class="btn btn-primary" ID="btnLoan" Style="background-color: #1E90FF; width: 80%; font-size: 25px; font-weight: 500; padding: 5px;" runat="server" Text="Loan" OnClick="btnLoan_Click" />
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container mt-5 mb-3">
        <div class="card shadow">
            <div class="card-body">
                <center>
                    <h2 style="color: #1E90FF;">Loaned DVD Copies</h2>
                </center>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-11 mx-auto">
                        <asp:GridView ID="gvDVD" class="table" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                            <Columns>
                                <asp:BoundField DataField="LoanNumber" HeaderText="Loan.No" ReadOnly="True" SortExpression="LoanNumber">
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
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("MemberName") %>'></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row mt-2">
                                                        <div class="col-12">
                                                            <span>Copy No. - </span>
                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("CopyNumber") %>'></asp:Label>
                                                            &nbsp;| Loaned Date -
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("DateOut") %>'></asp:Label>
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
