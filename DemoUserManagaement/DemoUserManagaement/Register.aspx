<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DemoUserManagaement.Register" %>

<%@ Register TagPrefix="note" TagName="uc" Src="~/notes.ascx" %>

<%@ Register TagPrefix="doc" TagName="uc" Src="~/document.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="Content/Register.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">


    <div class="container w-100 m-auto mt-5" style="background-color: white; box-shadow: -5px -5px 5px 5px #5c5656;">
        <div class="form-floating p-2">
            <fieldset>
                <legend>
                    Your Details
                </legend>
                <h3>Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFirstName" name="txtFirstName" placeholder="First name" data-name="FirstName" data-take="input" data-validate="validate">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMiddleName" name="txtMiddleName" placeholder="Middle name" data-name="MiddleName" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtLastName" name="txtLastName" placeholder="Last name" data-take="input" data-name="LastName" data-validate="validate">
                        </div>
                    </div>
                </div>
                <h3>Father Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFatherFirstName" name="txtFatherFirstName" placeholder="First name" data-take="input" data-name="FatherFirstName" data-validate="validate">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFatherMiddleName" name="txtFatherMiddleName" placeholder="Middle name" data-name="FatherMiddleName" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFatherLastName" name="txtFatherLastName" placeholder="Last name" data-take="input" data-name="FatherLastName" data-validate="validate">
                        </div>
                    </div>
                </div>
                <h3>Mother Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMotherFirstName" name="txtMotherFirstName" placeholder="First name" data-take="input" data-name="MotherFirstName" data-validate="validate">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMotherMiddleName" name="txtMotherMiddleName" placeholder="Middle name" data-name="MotherMiddleName" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMotherLastName" name="txtMotherLastName" placeholder="Last name" data-take="input" data-name="MotherLastName" data-validate="validate">
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>
                    Personal Details
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtEmail">Email address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-envelope-at-fill"></i></span>
                            <input type="text" class="form-control" id="txtEmail" name="txtEmail" placeholder="email@gmail.com" data-take="input" data-validate="validate" data-name="Email" data-toggle="tooltip" title="" onchange="CheckEmail()">
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPhoneNumber">Phone no<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-telephone-fill"></i></span>
                            <input type="text" class="form-control" id="txtPhoneNumber" name="txtPhoneNumber" placeholder="+91" oninput="validateNo(this)" data-take="input" data-name="ContactNumber" data-validate="validate" data-toggle="tooltip" title="">
                        </div>
                    </div>


                    <div class="col-xs-12 col-sm-3" style="margin-top: -10px;">
                        <p>Choose your Gender<span class="star">*</span>:</p>
                        <div class="gender d-flex">
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Male">
                                <div class="input-group-text">
                                    <input type="radio" id="radioMale" name="radioGender" value="Male" data-name="Gender" checked>
                                </div>
                                <label for="radioMale">
                                    <span class="form-control"><i class="bi bi-gender-male"></i></span>
                                </label>
                            </div>
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Female">
                                <div class="input-group-text">
                                    <input type="radio" id="radioFemale" name="radioGender" value="Female" data-name="Gender">
                                </div>
                                <label for="radioFemale">
                                    <span class="form-control"><i class="bi bi-gender-female"></i></span>
                                </label>
                            </div>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="dateOfBirth">Enter Date of Birth<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-cake2-fill"></i></span>
                            <input type="date" class="form-control" id="dateOfBirth" name="dateOfBirth" max="2016-12-31" min="2000-01-01" data-take="input" data-name="DateOfBirth" data-validate="validate">
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPassword">Password<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-envelope-at-fill"></i></span>
                            <input type="password" class="form-control" id="txtPassword" name="txtPassword" placeholder="password" data-take="input" data-validate="validate" data-name="Password" data-toggle="tooltip" title="">
                        </div>
                    </div>
                </div>
            </fieldset>
            <fieldset>
                <legend>Current Address</legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="selectCountry">Enter Country<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-building-fill"></i></span>
                            <select id="selectCurrentCountry" class="form-select" name="selectCurrentCountry" data-name="CurrentCountry" data-take="input">
                                <option value="India">India</option>
                                <option value="USA">USA</option>
                                <option value="UK">UK</option>
                                <option value="Singapore">Singapore</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="selectState">Enter State<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-shop"></i></span>
                            <select id="selectCurrentState" class="form-select" name="selectCurrentState" data-name="CurrentStateField" data-take="input">
                                <option value="Odisha">Odisha</option>
                                <option value="Mumbai">Mumbai</option>
                                <option value="Bangalore">Bangalore</option>
                                <option value="Delhi">Delhi</option>
                                <option value="WestBengal">West Bengal</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtAddress">Address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-house-door-fill"></i></span>
                            <input type="text" class="form-control" id="txtCurrentAddress" name="txtAddress" placeholder="Address" data-take="input" data-name="CurrentAddressField" data-validate="validate">
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
                            <input type="text" class="form-control" id="txtCurrentPincode" name="txtPincode" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-name="CurrentPincode" data-validate="validate" data-toggle="tooltip" title="">
                        </div>

                    </div>
                </div>
                <input type="text" class="form-control" id="PermarentAddressID" name="PermarentAddressID" placeholder="PermarentAddressID" data-take="input" data-name="PermarentAddressID" hidden>
            </fieldset>

            <fieldset>
                <legend>Permarent Address</legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="selectCountry">Enter Country<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-building-fill"></i></span>
                            <select id="selectPermarentCountry" class="form-select" name="selectCountry" data-name="PermarentCountry" data-take="input">
                                <option value="India">India</option>
                                <option value="USA">USA</option>
                                <option value="UK">UK</option>
                                <option value="Singapore">Singapore</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="selectState">Enter State<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-shop"></i></span>
                            <select id="selectPermarentState" class="form-select" name="selectState" data-name="PermarentStateField" data-take="input">
                                <option value="Odisha">Odisha</option>
                                <option value="Mumbai">Mumbai</option>
                                <option value="Bangalore">Bangalore</option>
                                <option value="Delhi">Delhi</option>
                                <option value="WestBengal">West Bengal</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtAddress">Address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-house-door-fill"></i></span>
                            <input type="text" class="form-control" id="txtPermarentAddress" name="txtAddress" placeholder="Address" data-take="input" data-name="PermarentAddressField" data-validate="validate">
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-geo-alt-fill"></i></span>
                            <input type="text" class="form-control" id="txtPermarentPincode" name="txtPincode" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-name="PermarentPincode" data-validate="validate" data-toggle="tooltip" title="">
                        </div>

                    </div>
                </div>

                <input type="text" class="form-control" id="CurrentAddressID" name="CurrentAddressID" placeholder="CurrentAddressID" data-take="input" data-name="CurrentAddressID" hidden>
            </fieldset>

            <fieldset>
                <legend>
                    Educational Details
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="selectEducation">Highest Education<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-backpack-fill"></i></span>
                            <select id="selectEducation" class="form-select" name="selectEducation" data-take="input">
                                <option value="Secondary">Secondary</option>
                                <option value="Higher Secondary">Higher Secondary</option>
                                <option value="B.Tech">B.Tech</option>
                                <option value="M.Tech">M.Tech</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <label for="selectBranch">Branch<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-motherboard-fill"></i></span>
                            <select id="selectBranch" name="selectBranch" class="form-select w-100" data-take="input">
                                <option value="All">All</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <label for="selectYearOfPassout">Year of passout<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-calendar-fill"></i></span>
                            <select id="selectYearOfPassout" class="form-select" name="selectYearOfPassout" data-take="input">
                                <option value="2024">2024</option>
                                <option value="2025">2025</option>
                                <option value="2026">2026</option>
                                <option value="2027">2027</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div class="d-flex justify-content-around flex-row-reverse flex-wrap" style="margin-top: 10px;">
                    <div class="flex-fill">
                        <div>
                            <div class="col-xs-12" id="secondary-marks">
                                <label for="txtSecondaryMarks">Enter Secondary marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-mortarboard-fill"></i></span>
                                    <input type="text" class="form-control" id="txtSecondaryMarks" name="txtSecondaryMarks" placeholder="100" oninput="validateNo(this)" data-name="SecondaryMarks" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-marks">
                                <label for="txtHigherSecondaryMarks">Enter Higher Secondary marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-mortarboard-fill"></i></span>
                                    <input type="text" class="form-control" id="txtHigherSecondaryMarks" name="txtHigherSecondaryMarks" placeholder="100" oninput="validateNo(this)" data-name="HigherSecondaryMarks" data-take="input">
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-marks">
                                <label for="txtBTechMarks">Enter B.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-mortarboard-fill"></i></span>
                                    <input type="text" class="form-control" id="txtBTechMarks" name="txtBTechMarks" placeholder="100" oninput="validateNo(this)" data-name="BTechMarks" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-marks">
                                <label for="txtMTechMarks">Enter M.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-mortarboard-fill"></i></span>
                                    <input type="text" class="form-control" id="txtMTechMarks" name="txtMTechMarks" placeholder="100" oninput="validateNo(this)" data-name="MTechMarks" data-take="input">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="flex-fill">
                        <div>
                            <div class="col-xs-12" id="secondary-school-name">
                                <label for="txtSecondarySchoolName">Enter Secondary School name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtSecondarySchoolName" name="txtSecondarySchoolName" placeholder="ABC School" data-name="SecondarySchoolName" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-school-name">
                                <label for="txtHigherSecondarySchoolName">Enter Higher Secondary School name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtHigherSecondarySchoolName" name="txtHigherSecondarySchoolName" placeholder="ABC School" data-name="HigherSecondarySchoolName" data-take="input">
                                </div>
                            </div>
                        </div>

                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-college-name">
                                <label for="txtBTechCollegeName">Enter B.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtBTechCollegeName" name="txtBTechCollegeName" placeholder="XYZ College" data-name="BTechCollegeName" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-college-name">
                                <label for="txtMTechCollegeName">Enter M.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtMTechCollegeName" name="txtMTechCollegeName" placeholder="XYZ College" data-name="MTechCollegeName" data-take="input">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>
                    Documents
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileImage">Enter Your image<span class="star">*</span>:</label>
                        <img id="imgOutput" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-file-image-fill"></i></span>
                            <input type="file" class="form-control upload" id="fileImage" name="fileImage" accept="image/png, image/jpg, image/jpeg" data-validate="validate" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileAadharCard">Enter Your Aadhaar Card<span class="star">*</span>:</label>
                        <img id="imgAadharCard" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text"><i class="bi bi-file-image-fill"></i></span>
                            <input type="file" class="form-control upload" id="fileAadharCard" name="fileAadharCard" accept="image/png, image/jpg, image/jpeg" data-validate="validate" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileResume">Enter Resume<span class="star">*</span>:</label>
                        <iframe id="showResume" class="showReponse" width="200" style="display: none;"></iframe>
                        <div class="input-group flex-nowrap mt-4">
                            <span class="input-group-text"><i class="bi bi-file-earmark-pdf-fill"></i></span>
                            <input type="file" class="form-control upload mt-3" id="fileResume" name="fileResume" accept="application/pdf" data-validate="validate" data-take="input">
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <h3>About You</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-6">
                        <label for="txtAboutYourself">Tell me about Yourself:</label>
                        <textarea class="form-control w-75" style="height: 100px" id="txtAboutYourself" name="txtAboutYourself" cols="80" rows="5" data-take="input"></textarea>
                    </div>
                    <div class="col-xs-12 col-sm-6">
                        <label for="txtHobbies">Enter your hobbies:</label>
                        <textarea class="form-control w-75" style="height: 100px" id="txtHobbies" name="txtHobbies" cols="80" rows="5" data-take="input"></textarea>
                    </div>
                </div>
            </fieldset>

            <div class="ml-5 mt-3 form-check">
                <input class="ml-5 form-check-input border border-secondary" type="checkbox" id="checkboxSubscribe" name="checkboxSubscribe" value="subscribe" onchange="updateCol(this)" data-take="input">
                <label class="form-check-label" for="checkboxSubscribe" id="labelNewsletter">Yes, I want to Subscribe newsletter</label>
            </div>

            <div class="container d-flex w-100 justify-content-between flex-wrap">
                <asp:Button CssClass="col-xs-12 col-sm-4 m-auto btn btn-outline-success" ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return validateForm();" CausesValidation="true" />
                <button class="col-xs-12 col-sm-4 m-auto btn btn-outline-danger" type="reset">Reset</button>
            </div>

        </div>

        <div class="row mt-5 mb-5">
            <div class="col-xs-6 col-sm-6">
                <note:uc ID="notes" runat="server"></note:uc>
            </div>

            <div class="col-xs-6 col-sm-6">
                <doc:uc ID="docs" runat="server"></doc:uc>
            </div>
        </div>
    </div>


    <script src="scripts/Register.js"></script>  
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js" integrity="sha384-BBtl+eGJRgqQAUMxJ7pMwbEyER4l1g+O15P+16Ep7Q9Q+zqX6gSbd85u4mG4QzX+" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

</asp:Content>
