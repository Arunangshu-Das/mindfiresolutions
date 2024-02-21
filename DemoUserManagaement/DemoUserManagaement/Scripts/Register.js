var id = null;
$(document).ready(function () {

    var urlParams = new URLSearchParams(window.location.search);
    id = parseInt(urlParams.get('id'));

    $('#m-tech-marks, #b-tech-marks, #higher-secondary-marks, #higher-secondary-school-name, #b-tech-college-name, #m-tech-college-name').css('display', 'none');

    $('#selectEducation').change(function () {
        updateEdu();
    });

    var urlParams = new URLSearchParams(window.location.search);
    var userId = urlParams.get('id');

    if (userId) {
        updateCountry();
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

            console.log(result);

            var selectedValue = result.CurrentCountry;

            // Loop through the options and set the selected attribute for the matching option
            for (var i = 0; i < selectCurrentCountry.options.length; i++) {
                if (selectCurrentCountry.options[i].text == selectedValue) {
                    selectCurrentCountry.options[i].selected = true;
                    updateStates("selectCurrentCountry", "selectCurrentState");
                    break; // Break out of the loop once the value is set
                }
            }

            selectedValue = result.PermarentCountry;

            // Loop through the options and set the selected attribute for the matching option
            for (var i = 0; i < selectPermarentCountry.options.length; i++) {
                if (selectPermarentCountry.options[i].text == selectedValue) {
                    selectPermarentCountry.options[i].selected = true;
                    updateStates("selectPermarentCountry", "selectPermarentState");
                    break; // Break out of the loop once the value is set
                }
            }

            selectedValue = result.CurrentStateField;

            // Loop through the options and set the selected attribute for the matching option
            for (var i = 0; i < selectCurrentState.options.length; i++) {
                if (selectCurrentState.options[i].text == selectedValue) {
                    selectCurrentState.options[i].selected = true;
                    break; // Break out of the loop once the value is set
                }
            }

            selectedValue = result.PermarentStateField;

            // Loop through the options and set the selected attribute for the matching option
            for (var i = 0; i < selectPermarentState.options.length; i++) {
                if (selectPermarentState.options[i].text == selectedValue) {
                    selectPermarentState.options[i].selected = true;
                    break; // Break out of the loop once the value is set
                }
            }
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

    PageMethods.FindEmail(userId, emailInput.val(), onSucess, onError);

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

    //if (!flag) {
    //    window.scroll({
    //        top: 0,
    //        left: 0,
    //        behavior: 'smooth',
    //    });
    //    $("#toast-message").removeClass("hide-toast");
    //    return false;
    //}
    //else {
    //    $("toast-message").addClass("hide");
    //}

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

    var urlParams = new URLSearchParams(window.location.search);
    var userId = urlParams.get('id');
    if (userId != null) {
        jsonObject["UserID"] = id;
    }


    var fileInput = document.getElementById('fileAadharCard');
    var filename = uuidv4();

    uploadFile(fileInput, filename);

    jsonObject['GuidAadharcard'] = filename;
    jsonObject['Aadharcard'] = fileInput.value.replace(/^.*[\\/]/, '');


    fileInput = document.getElementById('fileImage');
    filename = uuidv4();

    uploadFile(fileInput, filename);


    jsonObject['GuidProfilePhoto'] = filename;
    jsonObject['ProfilePhoto'] = fileInput.value.replace(/^.*[\\/]/, '');

    fileInput = document.getElementById('fileImage');
    filename = uuidv4();

    uploadFile(fileInput, filename);


    jsonObject['GuidMyResume'] = filename;
    jsonObject['MyResume'] = fileInput.value.replace(/^.*[\\/]/, '');


    // Print or use the jsonObject as needed
    var jsonData = JSON.stringify(jsonObject);

    if (userId == null) {
        PageMethods.UserSave(jsonData, onSucess, onError);
    }
    else {
        PageMethods.UserUpdate(jsonData, onSucess, onError);
    }

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

function uploadFile(fileInput, filename) {
    var file = fileInput.files[0];

    if (file) {
        var formData = new FormData();
        formData.append('image', file);
        formData.append('name', filename);

        $.ajax({
            url: '/Upload.ashx',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                // Handle the response from the server, e.g., update UI or display a message
                return response;
            },
            error: function (error) {
                return error;
            }
        });
    } else {
        console.error('No file selected.');
    }
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}
