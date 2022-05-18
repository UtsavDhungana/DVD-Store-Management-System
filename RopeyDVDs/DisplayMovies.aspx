<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMaster.Master" AutoEventWireup="true" CodeBehind="DisplayMovies.aspx.cs" Inherits="RopeyDVDs.DisplayMovies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">

        <div class="container mt-2 mb-3">
            <div class="card shadow">
                <div class="card-body">
                    <center>
                        <h2 style="color: #1E90FF;">DVD's</h2>
                    </center>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-11 mx-auto">
                            <div class="mb-3">
                                <h6 style="color:grey;">Find By Actor Surname:<asp:DropDownList ID="ddActorSurname" runat="server" Width="10%" AutoPostBack="True" style="margin-left:10px;" ></asp:DropDownList>
                                </h6> 
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
                                                    <div class="row mt-3">
                                                            <div class="col-12">
                                                                <span>Actor - </span>
                                                                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("ActorName") %>'></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row2mt-3">
                                                            <div class="col-12">
                                                                <span>Category - </span>
                                                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("CategoryDescription") %>'></asp:Label>
                                                                &nbsp;| <span><span>&nbsp;</span>Producer - </span>
                                                                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("ProducerName") %>'></asp:Label>
                                                            </div>
                                                        </div>
                                                        
                                                        <div class="row mt-2">
                                                            <div class="col-12">
                                                                Released On -
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("DateReleased") %>'></asp:Label>
                                                                &nbsp;| Studio -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("StudioName") %>'></asp:Label>

                                                            </div>
                                                        </div>
                                                        <div class="row mt-2">
                                                            <div class="col-12">
                                                                Standard Charge -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("StandardCharge") %>'></asp:Label>
                                                                &nbsp;| Penalty Charge -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("PenaltyCharge") %>'></asp:Label>
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
    </form>
</asp:Content>
