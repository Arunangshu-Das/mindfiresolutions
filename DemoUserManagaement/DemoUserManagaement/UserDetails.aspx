<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="DemoUserManagaement.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js" integrity="sha384-BBtl+eGJRgqQAUMxJ7pMwbEyER4l1g+O15P+16Ep7Q9Q+zqX6gSbd85u4mG4QzX+" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
    <script src="Scripts/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="formMain" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container w-100 m-auto mt-5" style="background-color: white; box-shadow: -5px -5px 5px 5px #5c5656;">

            <fieldset>
                <legend>
                    <h3>Your Details</h3>
                </legend>
                <h3>Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName">First name<span class="star">*</span>:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtFirstName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="First name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblMiddleName" runat="server" AssociatedControlID="txtMiddleName">Middle name:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtMiddleName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Middle name" data-take="input"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Last name<span class="star">*</span>:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtLastName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Last name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <h3>Father Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblFatherFirstName" runat="server" AssociatedControlID="txtFatherFirstName">First name<span class="star">*</span>:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtFatherFirstName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="First name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblFatherMiddleName" runat="server" AssociatedControlID="txtFatherMiddleName">Middle name:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtFatherMiddleName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Middle name" data-take="input"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblFatherLastName" runat="server" AssociatedControlID="txtFatherLastName">Last name<span class="star">*</span>:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtFatherLastName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Last name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <h3>Mother Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblMotherFirstName" runat="server" AssociatedControlID="txtMotherFirstName">First name<span class="star">*</span>:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtMotherFirstName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="First name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblMotherMiddleName" runat="server" AssociatedControlID="txtMotherMiddleName">Middle name:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtMotherMiddleName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Middle name" data-take="input"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <asp:Label ID="lblMotherLastName" runat="server" AssociatedControlID="txtMotherLastName">Last name<span class="star">*</span>:</asp:Label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox ID="txtMotherLastName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Last name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset id="pnlPersonalDetails" runat="server">
                <legend>
                    <h3>Personal Details</h3>
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtEmail">Email address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-envelope-at-fill"></i></span>
                            <asp:TextBox ID="txtEmail" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="email@gmail.com" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPhoneNumber">Phone no<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-telephone-fill"></i></span>
                            <asp:TextBox ID="txtPhoneNumber" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="+91" oninput="validateNo(this)" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3" style="margin-top: -10px;">
                        <p>Choose your Gender<span class="star">*</span>:</p>
                        <div class="gender d-flex">
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Male">
                                <div class="input-group-text">
                                    <asp:RadioButton ID="radioMale" ClientIDMode="Static" runat="server" GroupName="genderGroup" Text="Male" Checked="true" />
                                </div>
                                <label for="radioMale">
                                    <span class="form-control" clientidmode="Static" id="addon-wrapping"><i class="bi bi-gender-male"></i></span>
                                </label>
                            </div>
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Female">
                                <div class="input-group-text">
                                    <asp:RadioButton ID="radioFemale" ClientIDMode="Static" runat="server" GroupName="genderGroup" Text="Female" />
                                </div>
                                <label for="radioFemale">
                                    <span class="form-control" id="addon-wrapping"><i class="bi bi-gender-female"></i></span>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="dateOfBirth">Enter Date of Birth<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-cake2-fill"></i></span>
                            <asp:TextBox ID="dateOfBirth" ClientIDMode="Static" runat="server" CssClass="form-control" TextMode="Date" Max="2016-12-31" Min="2000-01-01" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </fieldset>

            <asp:Panel ID="Panel1" runat="server">
                <legend>
                    <h3>Current Address Details</h3>
                </legend>

                <div class="row">

                    <div class="col-xs-12 col-sm-4">
                        <asp:UpdatePanel ID="CurrentcountryPanel" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" CssClass="form-label star-mark required" AssociatedControlID="ddlCurrentCountryName">Country</asp:Label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
                                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlCurrentCountryName" CssClass="form-select"
                                        DataToggle="tooltip" Title="Select your country" DataLabel="Country" AutoPostBack="true"
                                        OnSelectedIndexChanged="DdlCurrentCountryName_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select Your Country--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCurrentCountryName"
                                    ErrorMessage="Please select your country" ForeColor="Red"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlCurrentCountryName" EventName="SelectedIndexChanged" />
                            </Triggers>

                        </asp:UpdatePanel>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <asp:UpdatePanel ID="CurrentstatePanel" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" CssClass="form-label star-mark required" AssociatedControlID="ddlCurrentStateName">State</asp:Label>
                                <div class="input-group">
                                    <span class="input-group-text" id="state-icon"><i class="bi bi-geo-alt-fill"></i></span>
                                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlCurrentStateName" CssClass="form-select"
                                        DataToggle="tooltip" Title="Select your state" DataLabel="State"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="--Select Your State--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCurrentStateName"
                                    ErrorMessage="Please select your state" ForeColor="Red"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtAddress">Address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-house-door-fill"></i></span>
                            <asp:TextBox ID="txtAddressCurrent" runat="server" CssClass="form-control" placeholder="Address" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-geo-alt-fill"></i></span>
                            <asp:TextBox ID="txtPincodeCurrent" runat="server" CssClass="form-control" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                    </div>
                </div>

            </asp:Panel>

            <asp:Panel ID="Panel2" runat="server">
                <legend>
                    <h3>Permarent Address Details</h3>
                </legend>

                <asp:Panel ID="pnlSubscribe" runat="server" CssClass="ml-5 mt-3">
                    <h3>
                        <asp:CheckBox ID="checkboxSubscribe" runat="server" CssClass="ml-5" Text="Both Address are common" AutoPostBack="true" onchange="toggle" /></h3>
                </asp:Panel>

                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <asp:UpdatePanel ID="PermanentcountryPanel" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" CssClass="form-label star-mark required" AssociatedControlID="ddlPermanentCountryName">Country</asp:Label>
                                <div class="input-group">
                                    <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
                                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlPermanentCountryName" CssClass="form-select"
                                        DataToggle="tooltip" Title="Select your country" DataLabel="Country" AutoPostBack="true"
                                        OnSelectedIndexChanged="DdlPermanentCountryName_SelectedIndexChanged">
                                        <asp:ListItem Text="--Select Your Country--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPermanentCountryName"
                                    ErrorMessage="Please select your country" ForeColor="Red"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlPermanentCountryName" EventName="SelectedIndexChanged" />
                            </Triggers>

                        </asp:UpdatePanel>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <asp:UpdatePanel ID="PermanentstatePanel" runat="server">
                            <ContentTemplate>
                                <asp:Label runat="server" CssClass="form-label star-mark required" AssociatedControlID="ddlPermanentStateName">State</asp:Label>
                                <div class="input-group">
                                    <span class="input-group-text" id="state-icon"><i class="bi bi-geo-alt-fill"></i></span>
                                    <asp:DropDownList runat="server" ClientIDMode="Static" ID="ddlPermanentStateName" CssClass="form-select"
                                        DataToggle="tooltip" Title="Select your state" DataLabel="State"
                                        AutoPostBack="true">
                                        <asp:ListItem Text="--Select Your State--" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPermanentStateName"
                                    ErrorMessage="Please select your state" ForeColor="Red"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtAddress">Address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-house-door-fill"></i></span>
                            <asp:TextBox ID="txtAddressPermarent" runat="server" CssClass="form-control" placeholder="Address" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-geo-alt-fill"></i></span>
                            <asp:TextBox ID="txtPincodePermarent" runat="server" CssClass="form-control" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                    </div>
                </div>

            </asp:Panel>

            <asp:Panel ID="pnlEducationalDetails" runat="server">
                <legend>
                    <h3>Educational Details</h3>
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="ddlHighestEducation">Highest Education<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-backpack-fill"></i></span>
                            <asp:DropDownList ID="selectEducation" ClientIDMode="Static" runat="server" CssClass="form-select" DataValueField="Value" DataTextField="Text" data-take="input">
                                <asp:ListItem Text="Secondary" Value="Secondary" />
                                <asp:ListItem Text="Higher Secondary" Value="Higher Secondary" />
                                <asp:ListItem Text="B.Tech" Value="B.Tech" />
                                <asp:ListItem Text="M.Tech" Value="M.Tech" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <label for="Branch">Branch<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-motherboard-fill"></i></span>
                            <asp:DropDownList ID="selectBranch" ClientIDMode="Static" runat="server" CssClass="form-select" DataValueField="Value" DataTextField="Text" data-take="input" class="w-100">
                                <asp:ListItem Text="All" Value="All" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <label for="ddlYearOfPassout">Year of passout<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-calendar-fill"></i></span>
                            <asp:DropDownList ID="ddlYearOfPassout" ClientIDMode="Static" runat="server" CssClass="form-select" DataValueField="Value" DataTextField="Text" data-take="input">
                                <asp:ListItem Text="2024" Value="2024" />
                                <asp:ListItem Text="2025" Value="2025" />
                                <asp:ListItem Text="2026" Value="2026" />
                                <asp:ListItem Text="2027" Value="2027" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="d-flex justify-content-around flex-row-reverse flex-wrap" style="margin-top: 10px;">
                    <div class="flex-fill">
                        <div>
                            <div class="col-xs-12" id="secondary-marks">
                                <label for="txtSecondaryMarks">Enter Secondary marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:TextBox ID="txtSecondaryMarks" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-marks">
                                <label for="txtHigherSecondaryMarks">Enter Higher Secondary marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:TextBox ID="txtHigherSecondaryMarks" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-marks">
                                <label for="txtBTechMarks">Enter B.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:TextBox ID="txtBTechMarks" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-marks">
                                <label for="txtMTechMarks">Enter M.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:TextBox ID="txtMTechMarks" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="flex-fill">
                        <div>
                            <div class="col-xs-12" id="secondary-school-name">
                                <label for="txtSecondarySchoolName">Enter Secondary School name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <asp:TextBox ID="txtSecondarySchoolName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="ABC School" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-school-name">
                                <label for="txtHigherSecondarySchoolName">Enter Higher Secondary School name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <asp:TextBox ID="txtHigherSecondarySchoolName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="ABC School" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-college-name">
                                <label for="txtBTechCollegeName">Enter B.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <asp:TextBox ID="txtBTechCollegeName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="XYZ College" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-college-name">
                                <label for="txtMTechCollegeName">Enter M.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <asp:TextBox ID="txtMTechCollegeName" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="XYZ College" data-take="input"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlDocuments" runat="server">
                <legend>
                    <h3>Documents</h3>
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileImage">Enter Your image<span class="star">*</span>:</label>
                        <img id="imgOutput" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-image-fill"></i></span>
                            <asp:FileUpload ID="fileImage" runat="server" ClientIDMode="Static" CssClass="form-control upload" accept="image/png, image/jpg, image/jpeg" data-validate="validate" data-take="input" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileAadharCard">Enter Your Aadhaar Card<span class="star">*</span>:</label>
                        <img id="imgAadharCard" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-image-fill"></i></span>
                            <asp:FileUpload ID="fileAadharCard" ClientIDMode="Static" runat="server" CssClass="form-control upload" accept="image/png, image/jpg, image/jpeg" data-validate="validate" data-take="input" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileResume">Enter Resume<span class="star">*</span>:</label>
                        <iframe id="showResume" class="showReponse" width="200" style="display: none;"></iframe>
                        <div class="input-group flex-nowrap mt-4">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-earmark-pdf-fill"></i></span>
                            <asp:FileUpload ID="fileResume" ClientIDMode="Static" runat="server" CssClass="form-control upload mt-3" accept="application/pdf" data-validate="validate" data-take="input" />
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlAboutYou" runat="server">
                <fieldset>
                    <legend>
                        <h3>About You</h3>
                    </legend>
                    <div class="row">
                        <div class="col-xs-12 col-sm-6">
                            <label for="txtAboutYourself">Tell me about Yourself:</label>
                            <asp:TextBox ID="txtAboutYourself" ClientIDMode="Static" runat="server" CssClass="form-control w-75" TextMode="MultiLine" Rows="5" data-take="input"></asp:TextBox>
                        </div>
                        <div class="col-xs-12 col-sm-6">
                            <label for="txtHobbies">Enter your hobbies:</label>
                            <asp:TextBox ID="txtHobbies" ClientIDMode="Static" runat="server" CssClass="form-control w-75" TextMode="MultiLine" Rows="5" data-take="input"></asp:TextBox>
                        </div>
                    </div>
                </fieldset>
            </asp:Panel>

            
<asp:TextBox ID="PermarentAddressId" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="100" oninput="validateNo(this)" data-take="input" hidden="True"></asp:TextBox>



<asp:TextBox ID="CurrentAddressId" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="100" oninput="validateNo(this)" data-take="input" hidden="True"></asp:TextBox>

            <asp:Panel ID="pnlButtons" runat="server" CssClass="container d-flex w-100 justify-content-between flex-wrap">
                <asp:Button ID="btnSubmit" runat="server" ClientIDMode="Static" CssClass="col-xs-12 col-sm-4 m-auto btn btn-outline-success" Text="Submit Form" OnClientClick="return validateForm();" OnClick="BtnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" ClientIDMode="Static" CssClass="col-xs-12 col-sm-4 m-auto btn btn-outline-danger" Text="Reset Form" OnClientClick="resetForm();" CausesValidation="False" />
            </asp:Panel>

        </div>
    </form>

    <%--    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/script.js") %>
    </asp:PlaceHolder>--%>
</body>
</html>
