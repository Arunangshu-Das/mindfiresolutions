﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="RegistrationForm.RegistrationForm" %>

<%@ Register TagPrefix="common" TagName="uc" Src="~/WebUserControl1.ascx" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Form</title>
    <webopt:bundlereference runat="server" path="~/Content/css/style.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
</head>
<body onload="onLoad()">
    <center class="mt-4"><h1><u>New User Registration Form</u></h1></center>

    <%--<div id="toast-message" class="hide-toast toast show position-fixed end-0 bottom-0 hide" style="z-index: 1000;" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="toast-header text-bg-danger">
            <strong class="me-auto">Error</strong>
            <small class="text-body-dark">Now</small>
            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
        <div class="toast-body">
            Check all the field and try again
        </div>
    </div>--%>

    <div class="container w-100 m-auto mt-5" style="background-color: white; box-shadow: -5px -5px 5px 5px #5c5656;">
        <form class="form-floating p-2" method="get" onsubmit="return validateForm()" runat="server">
            

            <common:uc id="ai" runat="server" PageName="tttttt"  /> 
            <fieldset>
                <legend><h3>Your Details</h3></legend>
                <h3>Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <asp:label for="txtFirstName" runat="server">First name<span class="star">*</span>:</asp:label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtFirstName" name="txtFirstName" placeholder="First name" data-take="input" data-validate="validate" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtMiddleName" name="txtMiddleName" placeholder="Middle name" data-take="input"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtLastName" name="txtLastName" placeholder="Last name" data-take="input" data-validate="validate" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <h3>Father Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtFatherFirstName" name="txtFatherFirstName" placeholder="First name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" runat="server" id="txtFatherMiddleName" name="txtFatherMiddleName" placeholder="Middle name" data-take="input" >
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtFatherLastName" name="txtFatherLastName" placeholder="Last name" data-take="input" data-validate="validate" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <h3>Mother Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtMotherFirstName" name="txtMotherFirstName" placeholder="First name" data-take="input" data-validate="validate" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtMotherMiddleName" name="txtMotherMiddleName" placeholder="Middle name" data-take="input" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtMotherLastName" name="txtMotherLastName" placeholder="Last name" data-take="input" data-validate="validate"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend><h3>Personal Details</h3></legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtEmail">Email address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-envelope-at-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtEmail" name="txtEmail" placeholder="email@gmail.com" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPhoneNumber">Phone no<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-telephone-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" runat="server" id="txtPhoneNumber" name="txtPhoneNumber" placeholder="+91" oninput="validateNo(this)" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="selectCountry">Enter Country<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                            <select id="selectCountry" class="form-select" name="selectCountry" data-take="input">
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-shop"></i></span>
                            <select id="selectState" class="form-select" name="selectState" data-take="input">
                                <option value="Odisha">Odisha</option>
                                <option value="Mumbai">Mumbai</option>
                                <option value="Bangalore">Bangalore</option>
                                <option value="Delhi">Delhi</option>
                                <option value="WestBengal">West Bengal</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div class="row" style="margin-top: 20px;">
                    <div class="col-xs-12 col-sm-3" style="margin-top: -10px;">
                        <p>Choose your Gender<span class="star">*</span>:</p>
                        <div class="gender d-flex">
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Male">
                                <div class="input-group-text">
                                    <input type="radio" id="radioMale" name="radioGender" value="Male" checked>
                                </div>
                                <label for="radioMale">
                                    <span class="form-control" id="addon-wrapping"><i class="bi bi-gender-male"></i></span>
                                </label>
                            </div>
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Female">
                                <div class="input-group-text">
                                    <input type="radio" id="radioFemale" name="radioGender" value="Female">
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
                            <input type="date" class="form-control" id="dateOfBirth" name="dateOfBirth" max="2016-12-31" min="2000-01-01" data-take="input" data-validate="validate" >
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtAddress">Address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-house-door-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" id="txtAddress" name="txtAddress" placeholder="Address" data-take="input" data-validate="validate" ></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-geo-alt-fill"></i></span>
                            <asp:TextBox type="text" class="form-control" id="txtPincode" name="txtPincode" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-validate="validate" data-toggle="tooltip" title=""></asp:TextBox>
                        </div>
                          
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend><h3>Educational Details</h3></legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="selectEducation">Highest Education<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-backpack-fill"></i></span>
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-motherboard-fill"></i></span>
                            <select id="selectBranch" name="selectBranch" class="form-select" data-take="input" class="w-100">
                                <option value="All">All</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-4">
                        <label for="selectYearOfPassout">Year of passout<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-calendar-fill"></i></span>
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
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:textbox type="text" class="form-control" id="txtSecondaryMarks" name="txtSecondaryMarks" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:textbox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-marks">
                                <label for="txtHigherSecondaryMarks">Enter Higher Secondary marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:textbox type="text" class="form-control" id="txtHigherSecondaryMarks" name="txtHigherSecondaryMarks" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-marks">
                                <label for="txtBTechMarks">Enter B.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:textbox type="text" class="form-control" id="txtBTechMarks" name="txtBTechMarks" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:textbox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-marks">
                                <label for="txtMTechMarks">Enter M.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <asp:textbox type="text" class="form-control" id="txtMTechMarks" name="txtMTechMarks" placeholder="100" oninput="validateNo(this)" data-take="input"></asp:textbox>
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
                                    <asp:textbox type="text" class="form-control" id="txtSecondarySchoolName" name="txtSecondarySchoolName" placeholder="ABC School" data-take="input"></asp:textbox>
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-school-name">
                                <label for="txtHigherSecondarySchoolName">Enter Higher Secondary School name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <asp:textbox type="text" class="form-control" id="txtHigherSecondarySchoolName" name="txtHigherSecondarySchoolName" placeholder="ABC School" data-take="input"></asp:textbox>
                                </div>
                            </div>
                        </div>
                
                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-college-name">
                                <label for="txtBTechCollegeName">Enter B.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtBTechCollegeName" name="txtBTechCollegeName" placeholder="XYZ College" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-college-name">
                                <label for="txtMTechCollegeName">Enter M.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtMTechCollegeName" name="txtMTechCollegeName" placeholder="XYZ College" data-take="input">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>                
            </fieldset>

            <fieldset>
                <legend><h3>Documents</h3></legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileImage">Enter Your image<span class="star">*</span>:</label>
                        <img id="imgOutput" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-image-fill"></i></span>
                            <input type="file" class="form-control" id="fileImage" name="fileImage" class="upload" accept="image/png, image/jpg, image/jpeg" data-validate="validate"  data-take="input" >
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileAadharCard">Enter Your Aadhaar Card<span class="star">*</span>:</label>
                        <img id="imgAadharCard" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-image-fill"></i></span>
                            <input type="file" class="form-control" id="fileAadharCard" name="fileAadharCard" class="upload" accept="image/png, image/jpg, image/jpeg" data-validate="validate"  data-take="input" >
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileResume">Enter Resume<span class="star">*</span>:</label>
                        <iframe id="showResume" class="showReponse" width="200" style="display: none;"></iframe>
                        <div class="input-group flex-nowrap mt-4">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-earmark-pdf-fill"></i></span>
                            <input type="file" class="form-control" id="fileResume" name="fileResume" class="upload mt-3" accept="application/pdf" data-validate="validate"  data-take="input">
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
                        <textarea class="form-control w-75" style="height: 100px"  id="txtHobbies" name="txtHobbies" cols="80" rows="5" data-take="input"></textarea>
                    </div>
                </div>
            </fieldset>

            <div class="ml-5 mt-3 form-check">
                <input class="ml-5 form-check-input border border-secondary" type="checkbox" id="checkboxSubscribe" name="checkboxSubscribe" value="subscribe" onchange="updateCol(this)" data-take="input">
                <label class="form-check-label" for="checkboxSubscribe" id="labelNewsletter"> Yes, I want to Subscribe newsletter</label>
            </div>

            <div class="container d-flex w-100 justify-content-between flex-wrap">
                <button class="col-xs-12 col-sm-4 m-auto btn btn-outline-success" type="submit" data-toggle="tooltip" title="Submit Form">Submit</button>
                <button class="col-xs-12 col-sm-4 m-auto btn btn-outline-danger" type="reset" data-toggle="tooltip" title="Reset Form">Reset</button>
            </div>

        </form>
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable">
          <div class="modal-content">
            <div class="modal-header">
              <h1 class="modal-title fs-5" id="exampleModalLabel">Check Once</h1>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" onclick="closeModal()"></button>
            </div>
                <div class="modal-body">
                    <div class="flex-column">
                        <fieldset>
                            <legend>
                                <h3 class="text-center">Details</h3></legend>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Your First Name:
                                </div>
                                <div id="result-txtFirstName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Your Middle Name:
                                </div>
                                <div id="result-txtMiddleName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Your Last Name:
                                </div>
                                <div id="result-txtLastName">
                
                                </div>
                            </div>
            
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Father First Name:
                                </div>
                                <div id="result-txtFatherFirstName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Father Middle Name:
                                </div>
                                <div id="result-txtFatherMiddleName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Father Last Name:
                                </div>
                                <div id="result-txtFatherLastName">
                
                                </div>
                            </div>
            
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Mother First Name:
                                </div>
                                <div id="result-txtMotherFirstName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Mother Middle Name:
                                </div>
                                <div id="result-txtMotherMiddleName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Mother Last Name:
                                </div>
                                <div id="result-txtMotherLastName">
                
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend><h3 class="text-center">Personal Details</h3></legend>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Email Address:
                                </div>
                                <div id="result-txtEmail">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Mobile No:
                                </div>
                                <div id="result-txtPhoneNumber">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Country:
                                </div>
                                <div id="result-selectCountry">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    State:
                                </div>
                                <div id="result-selectState">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Gender:
                                </div>
                                <div id="result-radioGender">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    DOB:
                                </div>
                                <div id="result-dateOfBirth">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Address:
                                </div>
                                <div id="result-txtAddress">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Pincode:
                                </div>
                                <div id="result-txtPincode">
                
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend><h3 class="text-center">Education</h3></legend>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Highest Education:
                                </div>
                                <div id="result-selectEducation">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Branch:
                                </div>
                                <div id="result-selectBranch">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    YOP:
                                </div>
                                <div id="result-selectYearOfPassout">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Secondary School:
                                </div>
                                <div id="result-txtSecondarySchoolName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Higher Secondary School:
                                </div>
                                <div id="result-txtHigherSecondarySchoolName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    B.Tech College:
                                </div>
                                <div id="result-txtBTechCollegeName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    M.Tech College:
                                </div>
                                <div id="result-txtMTechCollegeName">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Secondary Marks:
                                </div>
                                <div id="result-txtSecondaryMarks">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Higher Secondary Marks:
                                </div>
                                <div id="result-txtHigherSecondaryMarks">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    B.Tech Marks:
                                </div>
                                <div id="result-txtBTechMarks">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    M.Tech Marks:
                                </div>
                                <div id="result-txtMTechMarks">
                
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend><h3 class="text-center">Identity</h3></legend>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Resume:
                                </div>
                                <div id="result-fileResume">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Image:
                                </div>
                                <div id="result-fileImage">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Aadhar Card:
                                </div>
                                <div id="result-fileAadharCard">
                
                                </div>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend><h3>About you</h3></legend>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    About Yourself:
                                </div>
                                <div id="result-txtAboutYourself">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Your Hobbies:
                                </div>
                                <div id="result-txtHobbies">
                
                                </div>
                            </div>
                            <div class="d-flex justify-content-between m-2">
                                <div>
                                    Subscribe:
                                </div>
                                <div id="result-checkboxSubscribe">
                
                                </div>
                            </div>
                        </fieldset>
                    </div>
                </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" onclick="closeModal()">Close</button>
              <button type="button" class="btn btn-primary" onclick="allDone()">Save changes</button>
            </div>
          </div>
        </div>
      </div>

    </body>
    <script src="script.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js" integrity="sha384-BBtl+eGJRgqQAUMxJ7pMwbEyER4l1g+O15P+16Ep7Q9Q+zqX6gSbd85u4mG4QzX+" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</html>