<%@ Page Title="" Language="C#" MasterPageFile="~/LogInMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RopeyDVDs.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div style="justify-content:center; padding-top: 7rem">
        <div class="row mt-3 align-content-center">
            <h1 class="text-center mb-1" style="color:#1E90FF; font-weight: 600;">WELCOME</h1>
            <div class="card mx-auto mt-4 shadow" style="width: 25rem; height: 31rem; padding: 0px 65px 0px 65px; border-radius:30px 30px 30px 30px;  border-radius:30px 30px 30px 30px; box-shadow:10px 10px 10px 10px rgba(0,0,0,0.5);">
                <div class="card-body">
                    <form id="form1" runat="server">
                        <div class="row mt-2 mb-4">
                            <div class="col mb-4">
                                <center>
                                    <h4>Login</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-12">
                                <label for="userNameTB" id="lblUserName">
                                    Username
                                </label>
                                <asp:TextBox ID="userNameTB" runat="server" class="form-control" placeHolder="Enter Your Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="userNameTB" ErrorMessage="ERROR: User Name must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row mt-2">
                            <div class="col-12">
                                <label for="passwordTB" id="lblPassword">
                                    Password
                                </label>
                                <asp:TextBox ID="passwordTB" runat="server" class="form-control" placeHolder="Enter Your Password" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="passwordTB" ErrorMessage="ERROR: Password must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row mt-2 mb-3">
                            <div class="col-12">
                                <label for="UserTypeDDL" id="lblUserType">
                                    User Type
                                </label>
                                <br />
                                <%--class="btn btn-secondary btn-lg dropdown-toggle"--%>
                                <asp:DropDownList ID="userTypeDDL" runat="server" Width="100%" Height="75%">
                                    <asp:ListItem Value="Manager">Manager</asp:ListItem>
                                    <asp:ListItem Value="Assistant">Assistant</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mx-auto mt-5">
                            <center>
                                 <asp:Button class="btn btn-primary" ID="btnLogin" style="background-color: #1E90FF; width: 80%; font-size: 25px; font-weight: 500; padding: 5px; border-radius:10px 10px 10px 10px;" runat="server" Text="Login" OnClick="btnLogin_Click" />
                            </center>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
