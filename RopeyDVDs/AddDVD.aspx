<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="AddDVD.aspx.cs" Inherits="RopeyDVDs.AddDVD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div style="justify-content: center; padding-top: 5rem">
        <div class="row mt-1 align-content-center">
            <div class="card mx-auto mt-4 shadow" style="width: 50rem; padding: 0px 80px 0px 80px; box-shadow: 10px 10px 10px 10px rgba(0,0,0,0.5);">
                <div class="card-body">
                    <div class="row mt-4 mb-4">
                        <div class="col mb-4">
                            <center>
                                <h4>Add New DVD.</h4>
                            </center>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-12">
                            <div class="row align-items-baseline">
                                <div class="col" style="margin-right: 30px;">
                                    <label for="dvdTitleTB" id="lblDVDTitle">
                                        DVD Title
                                    </label>
                                    <asp:TextBox ID="dvdTitleTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <label for="releaseDateTB" id="lblReleaseDate">
                                        Release Date
                                    </label>
                                    <%--<input asp-for="DateReleased" class="form-control" />
                                    <span asp-validation-for="DateReleased" class="text-danger"></span>--%>
                                    <asp:TextBox ID="releaseDateTB" runat="server" placeHolder="mm/dd/yyyy" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12">
                             <div class="row align-items-baseline">
                                <div class="col" style="margin-right: 30px;">
                                    <label for="standardChargeTB" id="lblStandardCharge">
                                        Standard Charge
                                    </label>
                                    <asp:TextBox ID="standardChargeTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <label for="penaltyChargeTB" id="lblPenaltyCharge">
                                        Penalty Charge
                                    </label>
                                    <asp:TextBox ID="penaltyChargeTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="row mt-3">
                        <div class="col-12">
                             <div class="row align-items-baseline">
                                <div class="col" style="margin-right: 30px;">
                                    <label for="actorFirstNameTB" id="lblActorFirstName">
                                        Actor First Name
                                    </label>
                                    <asp:TextBox ID="actorFirstNameTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <label for="actorLastNameTB" id="lblActorLastName">
                                        Actor Last Name
                                    </label>
                                    <asp:TextBox ID="actorLastNameTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12">
                             <div class="row align-items-baseline">
                                <div class="col" style="margin-right: 30px;">
                                    <label for="producerNameTB" id="lblProducerName">
                                        Producer Name
                                    </label>
                                    <asp:TextBox ID="producerNameTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col">
                                    <label for="studioNameTB" id="lblStudioName">
                                        Studio Name
                                    </label>
                                    <asp:TextBox ID="studioNameTB" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12">
                             <div class="row align-items-baseline">
                                <div class="col" style="margin-right: 30px;">
                                    <label for="categoryDD" id="lblCategory">
                                        Category
                                    </label>
                                    <asp:DropDownList ID="categoryDD" runat="server" Width="100%" Height="75%">
                                        <asp:ListItem Value="Assistant">Action</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Comedy</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Horror</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Romance</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Thriller</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Mystery</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Fantasy</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Drama</asp:ListItem>
                                        <asp:ListItem Value="Assistant">Scify</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col">
                                    <label for="ageRestrictedDD" id="lblAgeRestricted">
                                        Age Restricted
                                    </label>
                                    <asp:DropDownList ID="ageRestrictedDD" runat="server" Width="100%" Height="75%">
                                        <asp:ListItem Value="true">true</asp:ListItem>
                                        <asp:ListItem Value="false">false</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4">
                        <div class="col-12">
                             <div class="row align-items-baseline">
                                <div class="col" style="margin-right: 30px;">
                                    <label for="dvdImageFU" id="lblDVDImage">
                                        DVD Image: 
                                    </label>
                                        <asp:FileUpload ID="dvdImageFU" runat="server" />
                                </div>
                                 <div class="col" style="margin-right: 30px;">
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3">
                        <div class="col-12">
                        </div>
                    </div>
                    <div class="mx-auto mt-5" style="margin-bottom:30px;">
                        <center>
                            <asp:Button class="btn btn-primary" ID="btnAdd" Style="background-color: #1E90FF; width: 60%; font-size: 25px; font-weight: 500; padding: 5px;" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>

    

</asp:Content>
