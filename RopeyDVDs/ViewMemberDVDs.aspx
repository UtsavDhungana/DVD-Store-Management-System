<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ViewMemberDVDs.aspx.cs" Inherits="RopeyDVDs.ViewDVDs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container mt-2 mb-3">
            <div class="card shadow p-2">
                <div class="card-body">
                    <center>
                        <h2 style="color: #1E90FF;">DVDs Loaned By Member Within 31 Days.</h2>
                    </center>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="row" style="padding-left: 79%">
                            <div id="current_date" style="color: grey;"><p></p></div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-8 mb-3" style="padding-left: 40px">
                                <h6 style="color: grey;">Filter By Member Surname:<asp:DropDownList ID="ddMemberSurname" runat="server" Width="15%" AutoPostBack="True" Style="margin-left: 10px;"></asp:DropDownList></h6>
                            </div>
                            <div class="col-4 mb-3" style="padding-left: 100px">
                                 <h6 style="color: grey;">Filter By Member Number:<asp:DropDownList ID="ddMemberNumber" runat="server" Width="20%" AutoPostBack="True" Style="margin-left: 10px;"></asp:DropDownList></h6>
                            </div>
                           
                        </div>
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
                                                    <div class="row mt-2">
                                                        <div class="col-12">
                                                            <span>Member - </span>
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("MemberName") %>'></asp:Label>
                                                            &nbsp;| Member Number -
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("MemberNumber") %>'></asp:Label>
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


    <script>
        var today = new Date();
        document.getElementById("current_date").innerHTML = 'Current Date: ' + today.getDate() + ' / ' + (today.getMonth() + 1) + ' / ' + today.getFullYear();
    </script>

</asp:Content>
