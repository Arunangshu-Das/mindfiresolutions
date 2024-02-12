
$(document).ready(function () {
    return;
    updateStates();

    $('#m-tech-marks, #b-tech-marks, #higher-secondary-marks, #higher-secondary-school-name, #b-tech-college-name, #m-tech-college-name').css('display', 'none');

    if (localStorage.getItem("txtFirstName") === null) {
        closeModal();
    } else {
        openModal();
    }

    $('#selectCountry').change(function () {
        updateStates();
    });

    $('#selectEducation').change(function () {
        updateEdu();
    });

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
});

$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();   
  });



function onLoad(){
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
    higherSecondarymarks.css("display","none");
    btechMarks.css("display","none");
    mtechMarks.css("display","none");
    higherSecondarySchool.css("display","none");
    btechSchoolName.css("display","none");
    mtechSchoolName.css("display","none");
    
}

function updateEdu() {
    var edu = $('#selectEducation').val();
    var stateDropdown = $('#selectBranch');
    var mtechMarks = $('#m-tech-marks');
    var btechMarks = $('#b-tech-marks');
    var higherSecondarymarks = $("#higher-secondary-marks");
    var higherSecondarySchool = $("#txtHigherSecondarySchoolName");
    var btechSchoolName = $("#txtBTechCollegeName");
    var mtechSchoolName = $("#txtMTechCollegeName");
    stateDropdown.innerHTML = "";

    switch (edu) {
        case "B.Tech":
            stateDropdown.empty();
            addOption(stateDropdown, "CSE", "CSE");
            addOption(stateDropdown, "Civil", "Civil");
            addOption(stateDropdown, "Electrical", "Electrical");
            addOption(stateDropdown, "Electronics", "Electronics");
            addOption(stateDropdown, "Mechanical", "Mechanical");
            higherSecondarymarks.css("display","flex");
            btechMarks.css("display","flex");
            mtechMarks.css("display","none");
            higherSecondarySchool.css("display","flex");
            btechSchoolName.css("display","flex");
            mtechSchoolName.css("display","none");
            break;
        case "M.Tech":
            stateDropdown.empty();
            addOption(stateDropdown, "CSE", "CSE");
            addOption(stateDropdown, "Civil", "Civil");
            addOption(stateDropdown, "Electrical", "Electrical");
            addOption(stateDropdown, "Electronics", "Electronics");
            addOption(stateDropdown, "Mechanical", "Mechanical");
            higherSecondarymarks.css("display","flex");
            btechMarks.css("display","flex");
            mtechMarks.css("display","flex");
            higherSecondarySchool.css("display","flex");
            btechSchoolName.css("display","flex");
            mtechSchoolName.css("display","flex");
            break;
        case "Higher Secondary":
            stateDropdown.empty();
            addOption(stateDropdown, "Arts", "Arts");
            addOption(stateDropdown, "Science", "Science");
            addOption(stateDropdown, "Commerce", "Commerce");
            higherSecondarymarks.css("display","flex");
            btechMarks.css("display","none");
            mtechMarks.css("display","none");
            higherSecondarySchool.css("display","flex");
            btechSchoolName.css("display","none");
            mtechSchoolName.css("display","none");
            break;
        default:
            stateDropdown.empty();
            addOption(stateDropdown, "All", "All");
            higherSecondarymarks.css("display","none");
            btechMarks.css("display","none");
            mtechMarks.css("display","none");
            higherSecondarySchool.css("display","none");
            btechSchoolName.css("display","none");
            mtechSchoolName.css("display","none");
    }
}

function addOption(select, text, value) {
    select.append(
        $('<asp:ListItem/>').Text(value).Value(text)
    );
}

function validateNo(ip) {
    ip.value=ip.value.replace(/\D/g,'');
}

function updateCol(check){
    var a=document.getElementById("labelNewsletter");
    if(check.checked){
        a.style.color = "green";
    }
    else{
        a.style.color = "black";
    }
}


function validateForm() {
    var allList = $('[data-validate="validate"]');
    var flag = true;

    for(var i=0;i<allList.length ;i++){
        var element=$(allList[i])
        var newError = $('<div class="alert alert-primary errormsg">Please fill this</div>');
        var errDiv = $('<div class="err"></div>').append(newError);

        if (element.val() === "" && element.next() && element.next().hasClass('err')) {
            flag = false;
        } else if (element.val() === "") {
            element.addClass("is-invalid")
        }
        else{
            element.addClass("is-valid")
        }
    }

    var pno = $("#txtPhoneNumber");

    if (pno.val().length !== 10) {
        var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Phone Number must be in 10 digits</div>');
        var errDiv = $('<div class="err"></div>').append(newError);
        pno[0].setAttribute("data-bs-original-title","Phone no must be 10 digit!!");
        pno.removeClass("is-valid")
        pno.addClass("is-invalid");
        flag = false;
    }
    else{
        pno[0].setAttribute("data-bs-original-title","");
    }

    var pincode = $("#txtPincode");

    if (pincode.val().length !== 6) {
        var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Pincode must be in 6 digits</div>');
        var errDiv = $('<div class="err"></div>').append(newError);
        // pincode.after(errDiv);
        pincode[0].setAttribute("data-bs-original-title","Pincode must be in 6 digits!!");
        pincode.removeClass("is-valid")
        pincode.addClass("is-invalid")
        flag = false;
    }
    else{
        pincode[0].setAttribute("data-bs-original-title","");
    }

    var email = $("#txtEmail").val();
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailPattern.test(email)) {
        var newError = $('<div class="alert alert-warning alert-dismissible fade show" role="alert">Can\'t be a Email</div>');
        var errDiv = $('<div class="err"></div>').append(newError);
        // $("#txtEmail").after(errDiv)
        $("#txtEmail")[0].setAttribute("data-bs-original-title","Can\'t be an Email");
        $("#txtEmail").removeClass("is-valid")
        $("#txtEmail").addClass("is-invalid")
        flag = false;
    }else{
        
        $("#txtEmail")[0].setAttribute("data-bs-original-title","");
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
    else{
        $("toast-message").addClass("hide");
    }

    saveData();
    return true;
}


const saveData=function(){
    var allList = $('[data-take="input"]');

    for(var i=0;i<allList.length ;i++){
        var element=$(allList[i])[0]
        var id = element.id;
        var value = element.value.replace(/^.*[\\/]/, '');
        localStorage.setItem(id, value);
    }

    const gender=document.querySelector('input[name="radioGender"]:checked').value;
    localStorage.setItem("radioGender", gender);

    const subscribe=document.getElementById("checkboxSubscribe").checked==false?"NA":"Yes";
    localStorage.setItem("checkboxSubscribe",subscribe);
}

function getitem(){
    var keys = Object.keys(localStorage);

    keys.forEach(function(key) {
        var elementId = "result-" + key; 
        var element = document.getElementById(elementId);

        if (element) {
            var value = localStorage.getItem(key);
            element.innerText = value === "" ? "NA" : value;
        }
    });
}

var loadImage = function(event) {
	var image = $('#imgOutput');
	image.attr("src",URL.createObjectURL(event.target.files[0]));
};

var loadAadharCard = function(event) {
	var image = $('#imgAadharCard');
	image.attr("src",URL.createObjectURL(event.target.files[0]));
};

var showResume = function(event) {
	var image = $('#showResume');
	// image.src = URL.createObjectURL(event.target.files[0]);
    image.attr("src",URL.createObjectURL(event.target.files[0]));
    image.css("display","block");
};

const checkFieldsChangeOrNot=function(e){
    var element=$(e)
    if (element.next() && element.next().hasClass('err')) {
        element.next().remove();
     }
    element.removeClass("is-invalid")
}




function toggleCurrentAddress() {
    var chkSameAsPermanent = document.getElementById('<%= checkboxSubscribe.ClientID %>');

    var txtCurrentVillage = document.getElementById('<%= txtCurrentVillage.ClientID %>');
    var txtCurrentPoliceStation = document.getElementById('<%= txtCurrentPoliceStation.ClientID %>');
    var txtCurrentPostOffice = document.getElementById('<%= txtCurrentPostOffice.ClientID %>');
    var txtCurrentStreetAddress = document.getElementById('<%= txtCurrentStreetAddress.ClientID %>');
    var txtCurrentCity = document.getElementById('<%= txtCurrentCity.ClientID %>');
    var txtCurrentHouseNumber = document.getElementById('<%= txtCurrentHouseNumber.ClientID %>');
    var txtCurrentPincode = document.getElementById('<%= txtCurrentPincode.ClientID %>');
    var ddlCurrentCountryName = document.getElementById('<%= ddlCurrentCountryName.ClientID %>');
    var ddlCurrentStateName = document.getElementById('<%= ddlCurrentStateName.ClientID %>');

    var txtPermanentVillage = document.getElementById('<%= txtPermanentVillage.ClientID %>');
    var txtPermanentPoliceStation = document.getElementById('<%= txtPermanentPoliceStation.ClientID %>');
    var txtPermanentPostOffice = document.getElementById('<%= txtPermanentPostOffice.ClientID %>');
    var txtPermanentStreetAddress = document.getElementById('<%= txtPermanentStreetAddress.ClientID %>');
    var txtPermanentCity = document.getElementById('<%= txtPermanentCity.ClientID %>');
    var txtPermanentHouseNumber = document.getElementById('<%= txtPermanentHouseNumber.ClientID %>');
    var txtPermanentPinCode = document.getElementById('<%= txtPermanentPinCode.ClientID %>');
    var ddlPermanentCountryName = document.getElementById('<%= ddlPermanentCountryName.ClientID %>');
    var ddlPermanentStateName = document.getElementById('<%= ddlPermanentStateName.ClientID %>');

    if (chkSameAsPermanent.checked) {
        txtCurrentVillage.value = txtPermanentVillage.value;
        txtCurrentPoliceStation.value = txtPermanentPoliceStation.value;
        txtCurrentPostOffice.value = txtPermanentPostOffice.value;
        txtCurrentStreetAddress.value = txtPermanentStreetAddress.value;
        txtCurrentCity.value = txtPermanentCity.value;
        txtCurrentHouseNumber.value = txtPermanentHouseNumber.value;
        txtCurrentPincode.value = txtPermanentPinCode.value;
        ddlCurrentCountryName.value = ddlPermanentCountryName.value;
        ddlCurrentCountryName.options[ddlCurrentCountryName.selectedIndex].text = ddlPermanentCountryName.options[ddlPermanentCountryName.selectedIndex].text;
        __doPostBack('<%= ddlCurrentCountryName.UniqueID %>', '');
        ddlCurrentStateName.value = ddlPermanentStateName.value;
        ddlCurrentStateName.options[ddlCurrentStateName.selectedIndex].text = ddlPermanentStateName.options[ddlPermanentStateName.selectedIndex].text;
        __doPostBack('<%= ddlCurrentStateName.UniqueID %>', '');
    }
    else {
        txtCurrentVillage.value = '';
        txtCurrentPoliceStation.value = '';
        txtCurrentPostOffice.value = '';
        txtCurrentStreetAddress.value = '';
        txtCurrentCity.value = '';
        txtCurrentHouseNumber.value = '';
        txtCurrentPincode.value = '';
        ddlCurrentCountryName.value = '';
        ddlCurrentStateName.value = '';
    }
    document.getElementById('<%= ddlPermanentCountryName.ClientID %>').addEventListener('change', function () {
        toggleCurrentAddress();
    });
}