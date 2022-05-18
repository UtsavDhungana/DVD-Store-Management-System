<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="RopeyDVDs.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="justify-content: center; padding-top: 7rem">
        <div class="row mt-3 align-content-center">
            <h1 class="text-center mb-1" style="color: #1E90FF; font-weight: 600;">Change Password</h1>
            <div class="card mx-auto mt-4 shadow" style="width: 25rem; height: 32rem; padding: 0px 55px 0px 55px; border-radius: 30px 30px 30px 30px; border-radius: 30px 30px 30px 30px; box-shadow: 10px 10px 10px 10px rgba(0,0,0,0.5);">
                <div class="card-body">
                    <div class="row mt-5">
                        <div class="col-12">
                            <label for="userNameTB" id="lblUserName">
                                Current Password
                            </label>
                            <asp:TextBox ID="currentPasswordTB" runat="server" class="form-control" placeHolder="Enter Current Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="passwordChange" ControlToValidate="currentPasswordTB" ErrorMessage="ERROR: User Name must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mt-3" style="margin-bottom: 10px;">
                        <div class="col-12">
                            <label for="passwordTB" id="lblPassword">
                               New Password
                            </label>
                            <asp:TextBox ID="newPasswordTB" runat="server" class="form-control" placeHolder="Enter New Password" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="passwordChange" ControlToValidate="newPasswordTB" ErrorMessage="ERROR: Password must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row mt-3" style="margin-bottom: 10px;">
                        <div class="col-12">
                            <label for="passwordTB" id="lblPassword2">
                               Confirm Password
                            </label>
                            <asp:TextBox ID="confirmPasswordTB" runat="server" class="form-control" placeHolder="Confirm New Password" MaxLength="12"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" validationGroup="passwordChange" ControlToValidate="confirmPasswordTB" ErrorMessage="ERROR: Password must not be empty!!" ForeColor="Red" Font-Size="12px"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mx-auto mt-5">
                        <center>
                            <asp:Button class="btn btn-primary" ID="btnChangePassword" ValidationGroup="passwordChange" Style="background-color: #1E90FF; width: 80%; font-size: 20px; font-weight: 400; padding: 5px; border-radius: 10px 10px 10px 10px;" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
