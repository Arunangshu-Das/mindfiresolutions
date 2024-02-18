<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DemoUserManagaement.Register" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Salsa&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Nunito:wght@400;600&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@300;400&display=swap');
        @import url('https://fonts.googleapis.com/css2?family=Merriweather:ital@1&display=swap');

        .hide-toast {
            display: none;
        }

        select {
            width: 92%;
            margin-top: 5px;
            padding: 2px;
            font-family: 'Montserrat', sans-serif;
            font-size: 18px;
        }
        /* .gender{
    display: flex;
    flex-wrap: wrap;
}

.gender div{
    display: flex;
    flex-direction: row;
}*/

        body h1 {
            font-family: 'Merriweather', serif;
            text-shadow: 0px 0px 12px black;
            color: white;
        }

        .gender {
            margin-top: -10px;
        }

            .gender div input:hover, .gender div label:hover {
                cursor: pointer;
            }

            .gender div label {
                margin-left: 10px;
                margin-right: 20px;
            }

        .showReponse {
            margin-bottom: 4px;
        }

        .result-details {
            position: relative;
            display: flex;
            flex-direction: column;
            flex-wrap: wrap;
            text-align: center;
            align-items: center;
        }

            .result-details fieldset {
                width: 70%;
            }

        @media (max-width: 600px) {
            .result-details fieldset {
                width: 90%;
            }
        }

        .result-details fieldset div {
            margin: 20px 0;
        }

        .result-details div {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            padding-bottom: 6px;
            height: 50px;
        }

            .result-details div div {
                flex: 50%;
                justify-content: start;
            }

        .inline {
            max-width: 400px;
            margin: auto;
        }

        .input-icons i {
            position: absolute;
        }

        .input-icons {
            width: 100%;
            margin-bottom: 10px;
        }

        select:focus-visible {
            outline: none;
        }

        input:focus-visible {
            outline: none;
        }

        .icon {
            padding: 10px;
            min-width: 40px;
        }

        .input-field {
            width: 100%;
            padding: 10px;
            text-align: center;
            margin-bottom: 3px;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">




    <div class="container w-100 m-auto mt-5" style="background-color: white; box-shadow: -5px -5px 5px 5px #5c5656;">
        <div class="form-floating p-2">
            <fieldset>
                <legend>
                    <h3>Your Details</h3>
                </legend>
                <h3>Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFirstName" name="txtFirstName" placeholder="First name" data-name="FirstName" data-take="input" data-validate="validate">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMiddleName" name="txtMiddleName" placeholder="Middle name" data-name="MiddleName" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtLastName" name="txtLastName" placeholder="Last name" data-take="input" data-name="LastName" data-validate="validate">
                        </div>
                    </div>
                </div>
                <h3>Father Name</h3>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherFirstName">First name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFatherFirstName" name="txtFatherFirstName" placeholder="First name" data-take="input" data-name="FatherFirstName" data-validate="validate">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherMiddleName">Middle name:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtFatherMiddleName" name="txtFatherMiddleName" placeholder="Middle name" data-name="FatherMiddleName" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtFatherLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMotherMiddleName" name="txtMotherMiddleName" placeholder="Middle name" data-name="MotherMiddleName" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label for="txtMotherLastName">Last name<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-person-fill"></i></span>
                            <input type="text" class="form-control" id="txtMotherLastName" name="txtMotherLastName" placeholder="Last name" data-take="input" data-name="MotherLastName" data-validate="validate">
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>
                    <h3>Personal Details</h3>
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="txtEmail">Email address<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-envelope-at-fill"></i></span>
                            <input type="text" class="form-control" id="txtEmail" name="txtEmail" placeholder="email@gmail.com" data-take="input" data-validate="validate" data-name="Email" data-toggle="tooltip" title="" onchange="CheckEmail()">
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPhoneNumber">Phone no<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-telephone-fill"></i></span>
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
                                    <span class="form-control" id="addon-wrapping"><i class="bi bi-gender-male"></i></span>
                                </label>
                            </div>
                            <div class="d-flex input-group w-75 flex-nowrap" data-toggle="tooltip" title="Female">
                                <div class="input-group-text">
                                    <input type="radio" id="radioFemale" name="radioGender" value="Female" data-name="Gender">
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
                            <input type="date" class="form-control" id="dateOfBirth" name="dateOfBirth" max="2016-12-31" min="2000-01-01" data-take="input" data-name="DateOfBirth" data-validate="validate">
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-shop"></i></span>
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-house-door-fill"></i></span>
                            <input type="text" class="form-control" id="txtCurrentAddress" name="txtAddress" placeholder="Address" data-take="input" data-name="CurrentAddressField" data-validate="validate">
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-geo-alt-fill"></i></span>
                            <input type="text" class="form-control" id="txtCurrentPincode" name="txtPincode" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-name="CurrentPincode" data-validate="validate" data-toggle="tooltip" title="">
                        </div>

                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>Permarent Address</legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-3">
                        <label for="selectCountry">Enter Country<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-shop"></i></span>
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
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-house-door-fill"></i></span>
                            <input type="text" class="form-control" id="txtPermarentAddress" name="txtAddress" placeholder="Address" data-take="input" data-name="PermarentAddressField" data-validate="validate">
                        </div>
                    </div>

                    <div class="col-xs-12 col-sm-3">
                        <label for="txtPincode">Pincode<span class="star">*</span>:</label>
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-geo-alt-fill"></i></span>
                            <input type="text" class="form-control" id="txtPermarentPincode" name="txtPincode" placeholder="Pincode" oninput="validateNo(this)" data-take="input" data-name="PermarentPincode" data-validate="validate" data-toggle="tooltip" title="">
                        </div>

                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>
                    <h3>Educational Details</h3>
                </legend>
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
                                    <input type="text" class="form-control" id="txtSecondaryMarks" name="txtSecondaryMarks" placeholder="100" oninput="validateNo(this)" data-name="SecondaryMarks" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-marks">
                                <label for="txtHigherSecondaryMarks">Enter Higher Secondary marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <input type="text" class="form-control" id="txtHigherSecondaryMarks" name="txtHigherSecondaryMarks" placeholder="100" oninput="validateNo(this)" data-name="HigherSecondaryMarks" data-take="input">
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-marks">
                                <label for="txtBTechMarks">Enter B.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
                                    <input type="text" class="form-control" id="txtBTechMarks" name="txtBTechMarks" placeholder="100" oninput="validateNo(this)" data-name="BTechMarks" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-marks">
                                <label for="txtMTechMarks">Enter M.Tech marks out of 100<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-mortarboard-fill"></i></span>
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
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtSecondarySchoolName" name="txtSecondarySchoolName" placeholder="ABC School" data-name="SecondarySchoolName" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="higher-secondary-school-name">
                                <label for="txtHigherSecondarySchoolName">Enter Higher Secondary School name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtHigherSecondarySchoolName" name="txtHigherSecondarySchoolName" placeholder="ABC School" data-name="HigherSecondarySchoolName" data-take="input">
                                </div>
                            </div>
                        </div>

                        <div>
                            <div class="col-xs-12 flex-column" id="b-tech-college-name">
                                <label for="txtBTechCollegeName">Enter B.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtBTechCollegeName" name="txtBTechCollegeName" placeholder="XYZ College" data-name="BTechCollegeName" data-take="input">
                                </div>
                            </div>
                            <div class="col-xs-12 flex-column" id="m-tech-college-name">
                                <label for="txtMTechCollegeName">Enter M.Tech college name<span class="star">*</span>:</label>
                                <div class="input-group flex-nowrap">
                                    <span class="input-group-text" id="addon-wrapping"><i class="bi bi-building-fill"></i></span>
                                    <input type="text" class="form-control" id="txtMTechCollegeName" name="txtMTechCollegeName" placeholder="XYZ College" data-name="MTechCollegeName" data-take="input">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </fieldset>

            <fieldset>
                <legend>
                    <h3>Documents</h3>
                </legend>
                <div class="row">
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileImage">Enter Your image<span class="star">*</span>:</label>
                        <img id="imgOutput" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-image-fill"></i></span>
                            <input type="file" class="form-control" id="fileImage" name="fileImage" class="upload" accept="image/png, image/jpg, image/jpeg" data-validate="validate" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileAadharCard">Enter Your Aadhaar Card<span class="star">*</span>:</label>
                        <img id="imgAadharCard" class="showReponse" width="200" />
                        <div class="input-group flex-nowrap">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-image-fill"></i></span>
                            <input type="file" class="form-control" id="fileAadharCard" name="fileAadharCard" class="upload" accept="image/png, image/jpg, image/jpeg" data-validate="validate" data-take="input">
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-4">
                        <label class="w-100" for="fileResume">Enter Resume<span class="star">*</span>:</label>
                        <iframe id="showResume" class="showReponse" width="200" style="display: none;"></iframe>
                        <div class="input-group flex-nowrap mt-4">
                            <span class="input-group-text" id="addon-wrapping"><i class="bi bi-file-earmark-pdf-fill"></i></span>
                            <input type="file" class="form-control" id="fileResume" name="fileResume" class="upload mt-3" accept="application/pdf" data-validate="validate" data-take="input">
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
    </div>


    <script>
        $(document).ready(function () {


            $('#m-tech-marks, #b-tech-marks, #higher-secondary-marks, #higher-secondary-school-name, #b-tech-college-name, #m-tech-college-name').css('display', 'none');

            $('#selectEducation').change(function () {
                updateEdu();
            });

            var urlParams = new URLSearchParams(window.location.search);
            var userId = urlParams.get('id');

            if (userId) {
                PageMethods.LoadUser(userId, onSucess, onError);
                function onSucess(result) {
                    $.each(result, function (key, value) {
                        // Find the input element with the corresponding data-name attribute
                        var inputElement = $("[data-name='" + key + "']");

                        // Check the type of input element and set its value accordingly
                        if (inputElement.is(":checkbox")) {
                            // Handle checkboxes
                            inputElement.prop("checked", value);
                        } else if (inputElement.is(":radio")) {
                            // Handle radio buttons
                            $("input[name='" + inputElement.attr("name") + "'][value='" + value + "']").prop("checked", true);
                        } else if (inputElement.is("textarea")) {
                            // Handle text areas
                            inputElement.val(value);
                        } else {
                            // Handle other input types
                            inputElement.val(value);
                        }
                    });
                }
                function onError(result) {
                    alert('Something wrong.');
                }
            }



            $('#txtPhoneNumber').on('input', function () {
                validateNo(this);
            });

            $('[data-take="input"]').on('input', function () {
                checkFieldsChangeOrNot(this);
            });

            $('#btnSubmit').on('click', function () {
                if (validateForm()) {
                    allDone();
                }
            });

            $('#btnCloseModal').on('click', function () {
                closeModal();
            });

            $('#fileImage').on('change', function (event) {
                loadImage(event);
            });

            $('#fileAadharCard').on('change', function (event) {
                loadAadharCard(event);
            });

            $('#fileResume').on('change', function (event) {
                showResume(event);
            });

            $(document).on('keydown', function (e) {
                const modal = $('.modal');
                if (e.key === 'Escape' && !modal.hasClass('hidden')) {
                    closeModal();
                }
            });

            updateCountry();
        });

        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });


        function CheckEmail() {
            var urlParams = new URLSearchParams(window.location.search);
            var userId = urlParams.get('id');

            if (userId == null) {
                userId = 0;
            }

            var emailInput = $("#txtEmail");

            PageMethods.FindEmail(userId, emailInput.val(),onSucess, onError);

            function onSucess(result) {
                if (result == true) {
                    emailInput.addClass("is-invalid");
                    emailInput[0].setAttribute("data-bs-original-title", "Email Must be unique");
                }
            }

            function onError(result) {
                alert('Something wrong.');
            }
        }

        function updateCountry() {
            var countryId1 = $("#selectCurrentCountry");
            var countryId2 = $("#selectPermarentCountry");

            PageMethods.GetAllCountries(onSucess, onError);

            function onSucess(result) {
                countryId1.empty();
                countryId2.empty();
                console.log(result);
                $.each(result, function (index, item) {
                    countryId1.append($("<option></option>").val(item.CountryId).html(item.CountryNames));
                    countryId2.append($("<option></option>").val(item.CountryId).html(item.CountryNames));
                });
            }
            function onError(result) {
                alert('Something wrong.');
            }

        }


        function updateStates(countryDropdownId, stateDropdownId) {
            var countryId = $("#" + countryDropdownId).val();


            PageMethods.GetAllStates(countryId, onSucess, onError);

            function onSucess(result) {
                var stateDropdown = $("#" + stateDropdownId);
                stateDropdown.empty();
                console.log(result);
                $.each(result, function (index, item) {
                    stateDropdown.append($("<option></option>").val(item.StateId).html(item.StateNames));
                });
            }

            function onError(result) {
                alert('Something wrong.');
            }
        }

        // Call the function when the country dropdown changes
        $("#selectCurrentCountry").change(function () {
            updateStates("selectCurrentCountry", "selectCurrentState");
        });

        $("#selectPermarentCountry").change(function () {
            updateStates("selectPermarentCountry", "selectPermarentState");
        });

        function onLoad() {
            updateCountry();
            var edu = $('#selectEducation').val();
            var stateDropdown = $('#selectBranch');
            var mtechMarks = $('#m-tech-marks');
            var btechMarks = $('#b-tech-marks');
            var higherSecondarymarks = $("#higher-secondary-marks");
            var higherSecondarySchool = $("#higher-secondary-school-name");
            var btechSchoolName = $("#b-tech-college-name");
            var mtechSchoolName = $("#m-tech-college-name");
            stateDropdown.empty();
            addOption(stateDropdown, "All", "All");
            higherSecondarymarks.css("display", "none");
            btechMarks.css("display", "none");
            mtechMarks.css("display", "none");
            higherSecondarySchool.css("display", "none");
            btechSchoolName.css("display", "none");
            mtechSchoolName.css("display", "none");

        }

        function updateEdu() {
            var edu = $('#selectEducation').val();
            var stateDropdown = $('#selectBranch');
            var mtechMarks = $('#m-tech-marks');
            var btechMarks = $('#b-tech-marks');
            var higherSecondarymarks = $("#higher-secondary-marks");
            var higherSecondarySchool = $("#higher-secondary-school-name");
            var btechSchoolName = $("#b-tech-college-name");
            var mtechSchoolName = $("#m-tech-college-name");
            stateDropdown.innerHTML = "";

            switch (edu) {
                case "B.Tech":
                    stateDropdown.empty();
                    addOption(stateDropdown, "CSE", "CSE");
                    addOption(stateDropdown, "Civil", "Civil");
                    addOption(stateDropdown, "Electrical", "Electrical");
                    addOption(stateDropdown, "Electronics", "Electronics");
                    addOption(stateDropdown, "Mechanical", "Mechanical");
                    higherSecondarymarks.css("display", "flex");
                    btechMarks.css("display", "flex");
                    mtechMarks.css("display", "none");
                    higherSecondarySchool.css("display", "flex");
                    btechSchoolName.css("display", "flex");
                    mtechSchoolName.css("display", "none");
                    break;
                case "M.Tech":
                    stateDropdown.empty();
                    addOption(stateDropdown, "CSE", "CSE");
                    addOption(stateDropdown, "Civil", "Civil");
                    addOption(stateDropdown, "Electrical", "Electrical");
                    addOption(stateDropdown, "Electronics", "Electronics");
                    addOption(stateDropdown, "Mechanical", "Mechanical");
                    higherSecondarymarks.css("display", "flex");
                    btechMarks.css("display", "flex");
                    mtechMarks.css("display", "flex");
                    higherSecondarySchool.css("display", "flex");
                    btechSchoolName.css("display", "flex");
                    mtechSchoolName.css("display", "flex");
                    break;
                case "Higher Secondary":
                    stateDropdown.empty();
                    addOption(stateDropdown, "Arts", "Arts");
                    addOption(stateDropdown, "Science", "Science");
                    addOption(stateDropdown, "Commerce", "Commerce");
                    higherSecondarymarks.css("display", "flex");
                    btechMarks.css("display", "none");
                    mtechMarks.css("display", "none");
                    higherSecondarySchool.css("display", "flex");
                    btechSchoolName.css("display", "none");
                    mtechSchoolName.css("display", "none");
                    break;
                default:
                    stateDropdown.empty();
                    addOption(stateDropdown, "All", "All");
                    higherSecondarymarks.css("display", "none");
                    btechMarks.css("display", "none");
                    mtechMarks.css("display", "none");
                    higherSecondarySchool.css("display", "none");
                    btechSchoolName.css("display", "none");
                    mtechSchoolName.css("display", "none");
            }
        }

        function addOption(select, text, value) {
            select.append(
                $('<option></option>').val(value).html(text)
            );
        }

        function validateNo(ip) {
            ip.value = ip.value.replace(/\D/g, '');
        }

        function updateCol(check) {
            var a = document.getElementById("labelNewsletter");
            if (check.checked) {
                a.style.color = "green";
            }
            else {
                a.style.color = "black";
            }
        }


        function validateForm() {
            var allList = $('[data-validate="validate"]');
            var flag = true;

            //for (var i = 0; i < allList.length; i++) {
            //    var element = $(allList[i])
            //    var newError = $('<div class="alert alert-primary errormsg">Please fill this</div>');
            //    var errDiv = $('<div class="err"></div>').append(newError);

            //    if (element.val() === "" && element.next() && element.next().hasClass('err')) {
            //        flag = false;
            //    } else if (element.val() === "") {
            //        element.addClass("is-invalid")
            //    }
            //    else {
            //        element.addClass("is-valid")
            //    }
            //}

            var pno = $("#txtPhoneNumber");

            if (pno.val().length !== 10) {
                var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Phone Number must be in 10 digits</div>');
                var errDiv = $('<div class="err"></div>').append(newError);
                pno[0].setAttribute("data-bs-original-title", "Phone no must be 10 digit!!");
                pno.removeClass("is-valid")
                pno.addClass("is-invalid");
                flag = false;
            }
            else {
                pno[0].setAttribute("data-bs-original-title", "");
            }

            var pincode = $("#txtCurrentPincode");

            if (pincode.val().length !== 6) {
                var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Pincode must be in 6 digits</div>');
                var errDiv = $('<div class="err"></div>').append(newError);
                // pincode.after(errDiv);
                pincode[0].setAttribute("data-bs-original-title", "Pincode must be in 6 digits!!");
                pincode.removeClass("is-valid")
                pincode.addClass("is-invalid")
                flag = false;
            }
            else {
                pincode[0].setAttribute("data-bs-original-title", "");
            }

            pincode = $("#txtPermarentPincode");

            if (pincode.val().length !== 6) {
                var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Pincode must be in 6 digits</div>');
                var errDiv = $('<div class="err"></div>').append(newError);
                // pincode.after(errDiv);
                pincode[0].setAttribute("data-bs-original-title", "Pincode must be in 6 digits!!");
                pincode.removeClass("is-valid")
                pincode.addClass("is-invalid")
                flag = false;
            }
            else {
                pincode[0].setAttribute("data-bs-original-title", "");
            }

            var email = $("#txtEmail").val();
            var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

            if (!emailPattern.test(email)) {
                var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Can\'t be a Email</div>');
                var errDiv = $('<div class="err"></div>').append(newError);
                // $("#txtEmail").after(errDiv)
                $("#txtEmail")[0].setAttribute("data-bs-original-title", "Can\'t be an Email");
                $("#txtEmail").removeClass("is-valid")
                $("#txtEmail").addClass("is-invalid")
                flag = false;
            } else {

                $("#txtEmail")[0].setAttribute("data-bs-original-title", "");
            }

            if (!flag) {
                window.scroll({
                    top: 0,
                    left: 0,
                    behavior: 'smooth',
                });
                $("#toast-message").removeClass("hide-toast");
                return false;
            }
            else {
                $("toast-message").addClass("hide");
            }

            var jsonObject = {};

            // Iterate through each input element with data-name attribute
            $("[data-name]").each(function () {
                // Get the data-name attribute value
                var key = $(this).data("name");

                // Get the input value based on the type of input element
                var value;
                if ($(this).is(":checkbox")) {
                    // Handle checkboxes
                    value = $(this).is(":checked");
                } else if ($(this).is(":radio")) {
                    // Handle radio buttons
                    value = $("input[name='" + $(this).attr("name") + "']:checked").val();
                } else if ($(this).is("textarea")) {
                    // Handle text areas
                    value = $(this).val();
                } else {
                    // Handle other input types
                    value = $(this).val();
                }

                // Add the key-value pair to the object
                jsonObject[key] = value;
            });

            jsonObject['CurrentStateId'] = $('#selectCurrentState').val();
            jsonObject['PermarentStateId'] = $('#selectPermarentState').val()

            // Print or use the jsonObject as needed
            var jsonData = JSON.stringify(jsonObject);
            PageMethods.UserSave(jsonData, onSucess, onError);

            function onSucess(result) {
                window.location.href = "Login.aspx";
            }

            function onError(result) {
                alert('Something wrong.');
            }


            return false;
        }

        const closeModal = function () {
            // var body = document.body;
            // const modal = $('.modal');
            // const overlay = $('.overlay');
            // modal.addClass('hidden');
            // modal.css("display","none");
            // overlay.addClass('hidden');
            // body.classList.remove("stop");
            // $("#exampleModal").css("display","none");
            $("#exampleModal").modal('hide');
            localStorage.clear();
        };

        const openModal = function () {
            window.scroll({
                top: 0,
                left: 0,
                behavior: 'smooth',
            });
            // var body = document.body;
            // const modal = $('.modal');
            // const overlay = $('.overlay');
            // modal.removeClass('hidden');
            // modal.css("display","block");
            // overlay.removeClass('hidden');
            // body.classList.add("stop");
            // $("#exampleModal").css("display","block");
            $("#exampleModal").modal('show');
            getitem();
        };


        const allDone = function () {
            window.open("save.html", "_self");
        }

        const saveData = function () {
            var allList = $('[data-take="input"]');

            for (var i = 0; i < allList.length; i++) {
                var element = $(allList[i])[0]
                var id = element.id;
                var value = element.value.replace(/^.*[\\/]/, '');
                localStorage.setItem(id, value);
            }

            const gender = document.querySelector('input[name="radioGender"]:checked').value;
            localStorage.setItem("radioGender", gender);

            const subscribe = document.getElementById("checkboxSubscribe").checked == false ? "NA" : "Yes";
            localStorage.setItem("checkboxSubscribe", subscribe);
        }

        function getitem() {
            var keys = Object.keys(localStorage);

            keys.forEach(function (key) {
                var elementId = "result-" + key;
                var element = document.getElementById(elementId);

                if (element) {
                    var value = localStorage.getItem(key);
                    element.innerText = value === "" ? "NA" : value;
                }
            });
        }

        var loadImage = function (event) {
            var image = $('#imgOutput');
            image.attr("src", URL.createObjectURL(event.target.files[0]));
        };

        var loadAadharCard = function (event) {
            var image = $('#imgAadharCard');
            image.attr("src", URL.createObjectURL(event.target.files[0]));
        };

        var showResume = function (event) {
            var image = $('#showResume');
            // image.src = URL.createObjectURL(event.target.files[0]);
            image.attr("src", URL.createObjectURL(event.target.files[0]));
            image.css("display", "block");
        };

        const checkFieldsChangeOrNot = function (e) {
            var element = $(e)
            if (element.next() && element.next().hasClass('err')) {
                element.next().remove();
            }
            element.removeClass("is-invalid")
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.min.js" integrity="sha384-BBtl+eGJRgqQAUMxJ7pMwbEyER4l1g+O15P+16Ep7Q9Q+zqX6gSbd85u4mG4QzX+" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

</asp:Content>
