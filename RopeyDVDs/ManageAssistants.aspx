<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ManageAssistants.aspx.cs" Inherits="RopeyDVDs.ManageAssistant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-2 mb-3">
        <div class="card shadow p-2">
            <div class="card-body">
                <center>
                    <h2 style="color: #1E90FF;">Assistants Detail.</h2>
                </center>
            </div>
            <div class="card-body">
                <div class="row">
                    <asp:GridView ID="gvDVD" class="table" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnRowCommand="GV_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="UserNumber" HeaderText="ID" ReadOnly="True" SortExpression="UserNumber">
                                <ItemStyle Font-Bold="false" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="container-fluid m-2">
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserName") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row mt-2">
                                                    <div class="col-12">
                                                        <span>User Type - </span>
                                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("UserType") %>'></asp:Label>
                                                        &nbsp;| Password -
                                                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("UserPassword") %>'></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 my-auto p-5">
                                                <asp:LinkButton ID="Select" class="btn btn-primary mx-auto d-block p-3" runat="server" CommandName="select" CommandArgument='<%#Bind("UserNumber")%>' Style="background-color: #1E90FF;">Select</asp:LinkButton>
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




    <div style="justify-content: center; padding-top: 2rem">
        <div class="row mt-1 align-content-center">
            <div class="card mx-auto mt-4 shadow" style="width: 35rem; padding-left: 100px; padding-right: 100px; box-shadow: 10px 10px 10px 10px rgba(0,0,0,0.5);">
                <div class="card-body">
                    <div class="row mt-2 mb-4">
                        <div class="col mb-4">
                            <center>
                                <h4>Credentials</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row mt-4" style="margin-bottom: 30px;">
                        <div class="col-12">
                            <label for="assistantNameTB" id="lblAssistantName">
                                UserName
                            </label>
                            <asp:TextBox ID="assistantNameTB" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="passwordChange" ControlToValidate="assistantNameTB" ErrorMessage="ERROR: Password must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-12">
                            <label for="userTypeDD" id="lblUserType">
                                User Type
                            </label>
                            <asp:DropDownList ID="userTypeDD" runat="server" Width="100%" Height="75%">
                                <asp:ListItem Value="Assistant">Assistant</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row mt-4"> </div>
                    <div class="row mt-4" style="margin-top: 20px;">
                        <div class="col-12">
                            <label for="passwordTB" id="lblPassword">
                                Password
                            </label>
                            <asp:TextBox ID="passwordTB" runat="server" class="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="passwordChange" ControlToValidate="passwordTB" ErrorMessage="ERROR: Password must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="container mt-5" style="margin-bottom:20px;">
                        <div class="row align-items-baseline">
                            <div class="col">
                                <asp:Button class="btn btn-primary" ID="btnUpdate" ValidationGroup="passwordChange" Style="background-color: #1E90FF;  width: 100%; font-size: 20px; font-weight: 500; padding: 5px;" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            </div>
                            <div class="col">
                                <asp:Button class="btn btn-primary" ID="btnDelete" ValidationGroup="passwordChange" Style="background-color: #1E90FF; width: 100%; font-size: 20px; font-weight: 500; padding: 5px;" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                            </div>
                            <div class="col">
                                <asp:Button class="btn btn-primary" ID="btnAdd" ValidationGroup="passwordChange" Style="background-color: #1E90FF; width: 100%; font-size: 20px; font-weight: 500; padding: 5px;" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="row ">
                         <asp:TextBox ID="checkUserTB" runat="server" class="form-control" Visible="false"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
