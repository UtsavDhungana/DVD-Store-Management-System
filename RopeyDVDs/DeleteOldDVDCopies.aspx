<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="DeleteOldDVDCopies.aspx.cs" Inherits="RopeyDVDs.DeleteOldDVDCopies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-2 mb-3">
        <div class="card shadow">
            <div class="card-body">
                <center>
                    <h2 style="color: #1E90FF;">Old DVD Copies</h2>
                </center>
            </div>
            <div class="card-body">
                <div class="row">
                        <div class="col-11 mx-auto">
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
                                                                <span>Copy Purchase Date - </span>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("DatePurchased") %>'></asp:Label>
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
                        <div class="mx-auto mt-3">
                        <center>
                            <asp:Button class="btn btn-primary" ID="btnErrorMessage" Style="width: 100%; font-size: 35px; font-weight: 600; padding: 5px; border:hidden;" BackColor="White" runat="server" ForeColor="Black"  />
                        </center>
                            </div>
                        <div class="mx-auto mt-5">
                        <center>
                            <asp:Button class="btn btn-primary" ID="btnDeleteOldCopies" Style="background-color: #1E90FF; width: 20%; font-size: 20px; font-weight: 400; padding: 5px; border-radius: 10px 10px 10px 10px;" runat="server" Text="Delete All Old Copies" OnClick="btnDeleteOldCopies_Click"  />
                        </center>
                    </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
