function updateStates() {
    var country = document.getElementById("selectCountry").value;
    var stateDropdown = document.getElementById("selectState");
    stateDropdown.innerHTML = "";

    switch (country) {
        case "India":
            addOption(stateDropdown, "Odisha", "Odisha");
            addOption(stateDropdown, "Mumbai", "Mumbai");
            addOption(stateDropdown, "Bangalore", "Bangalore");
            addOption(stateDropdown, "Delhi", "Delhi");
            addOption(stateDropdown, "West Bengal", "West Bengal");
            break;
        case "USA":
            addOption(stateDropdown, "New York", "New York");
            addOption(stateDropdown, "California", "California");
            addOption(stateDropdown, "San Fransisco", "San Fransisco");
            break;
        case "UK":
            addOption(stateDropdown, "London", "London");
            addOption(stateDropdown, "England", "England");
            addOption(stateDropdown, "Scotland", "Scotland");
            addOption(stateDropdown, "Wales", "Wales");
            break;
        case "Singapore":
            addOption(stateDropdown, "Woodlands", "Woodlands");
            addOption(stateDropdown, "Jurong East", "Jurong East");
            break;
        default:
            break;
    }
}

function onLoad(){
    var mtechMarks = document.querySelector(".m-tech-marks");
    var btechMarks = document.querySelector(".b-tech-marks");
    var higherSecondaryMarks = document.querySelector(".higher-secondary-marks");
    var higherSecondarySchool = document.querySelector(".higher-secondary-school-name");
    var btechSchoolName = document.querySelector(".b-tech-college-name");
    var mtechSchoolName = document.querySelector(".m-tech-college-name");
    higherSecondaryMarks.style.display="none";
    btechMarks.style.display="none";
    mtechMarks.style.display="none";
    higherSecondarySchool.style.display="none";
    btechSchoolName.style.display="none";
    mtechSchoolName.style.display="none";
    if(localStorage.getItem("txtFirstName")===null){
        closeModal();
    }
    else{
        openModal();
    }
}

function updateEdu() {
    var edu = document.getElementById("selectEducation").value;
    var stateDropdown = document.getElementById("selectBranch");
    var mtechMarks = document.querySelector(".m-tech-marks");
    var btechMarks = document.querySelector(".b-tech-marks");
    var higherSecondarymarks = document.querySelector(".higher-secondary-marks");
    var higherSecondarySchool = document.querySelector(".higher-secondary-school-name");
    var btechSchoolName = document.querySelector(".b-tech-college-name");
    var mtechSchoolName = document.querySelector(".m-tech-college-name");
    stateDropdown.innerHTML = "";

    switch (edu) {
        case "B.Tech":
            addOption(stateDropdown, "CSE", "CSE");
            addOption(stateDropdown, "Civil", "Civil");
            addOption(stateDropdown, "Electrical", "Electrical");
            addOption(stateDropdown, "Electronics", "Electronics");
            addOption(stateDropdown, "Mechanical", "Mechanical");
            higherSecondarymarks.style.display="flex";
            btechMarks.style.display="flex";
            mtechMarks.style.display="none";
            higherSecondarySchool.style.display="flex";
            btechSchoolName.style.display="flex";
            mtechSchoolName.style.display="none";
            break;
        case "M.Tech":
            addOption(stateDropdown, "CSE", "CSE");
            addOption(stateDropdown, "Civil", "Civil");
            addOption(stateDropdown, "Electrical", "Electrical");
            addOption(stateDropdown, "Electronics", "Electronics");
            addOption(stateDropdown, "Mechanical", "Mechanical");
            higherSecondarymarks.style.display="flex";
            btechMarks.style.display="flex";
            mtechMarks.style.display="flex";
            higherSecondarySchool.style.display="flex";
            btechSchoolName.style.display="flex";
            mtechSchoolName.style.display="flex";
            break;
        case "Higher Secondary":
            addOption(stateDropdown, "Arts", "Arts");
            addOption(stateDropdown, "Science", "Science");
            addOption(stateDropdown, "Commerce", "Commerce");
            higherSecondarymarks.style.display="flex";
            btechMarks.style.display="none";
            mtechMarks.style.display="none";
            higherSecondarySchool.style.display="flex";
            btechSchoolName.style.display="none";
            mtechSchoolName.style.display="none";
            break;
        default:
            addOption(stateDropdown, "All", "All");
            higherSecondarymarks.style.display="none";
            btechMarks.style.display="none";
            mtechMarks.style.display="none";
            higherSecondarySchool.style.display="none";
            btechSchoolName.style.display="none";
            mtechSchoolName.style.display="none";;
    }
}

function addOption(select, text, value) {
    var option = document.createElement("option");
    option.text = text;
    option.value = value;
    select.add(option);
}

function validateNo(ip) {
    ip.value=ip.value.replace(/\D/g,'');
}

function updateCol(check){
    var a=document.getElementById("newsletter");
    if(check.checked){
        a.style.color="green";
    }
    else{
        a.style.color="black";
    }
}

function validateForm(){
    // <div class="errormsg">Please fill this</div>

    var allList = document.querySelectorAll('[data-validate="validate"]');
    
    var flag=true;

    for(var i = 0; i < allList.length; i++){
        var newError=document.createElement('div');
        newError.innerHTML="Please fill this";
        newError.classList.add('errormsg');

        var errDiv=document.createElement('div');
        errDiv.appendChild(newError);
        errDiv.classList.add('err');
        if(allList[i].value=="" && allList[i].nextElementSibling && allList[i].nextElementSibling.classList.contains('err')){
            flag=false;
            continue;
        }
        else if(allList[i].value==""){
            allList[i].insertAdjacentElement("afterend",errDiv);
            flag= false;
        }
        else if(allList[i].nextElementSibling && allList[i].nextElementSibling.classList.contains('err')){
            allList[i].nextElementSibling.remove();
        }
    }

    var pno=document.querySelector("#txtPhoneNumber");

    if(pno.value.length!==10){
        var newError=document.createElement('div');
        newError.innerHTML="Phone number should be 10 digit";
        newError.classList.add('errormsg');

        var errDiv=document.createElement('div');
        errDiv.appendChild(newError);
        errDiv.classList.add('err');

        if(pno.nextElementSibling && pno.nextElementSibling.classList.contains('err')){
            pno.nextElementSibling.remove();
        }
        
        pno.insertAdjacentElement("afterend",errDiv);
        
        flag=false;
    }

    if(document.querySelector("#txtPincode").value.length!==6){
        // alert("pincode must be in 6 digit");
        var newError=document.createElement('div');
        newError.innerHTML="pincode must be in 6 digit";
        newError.classList.add('errormsg');

        var errDiv=document.createElement('div');
        errDiv.appendChild(newError);
        errDiv.classList.add('err');

        if(document.querySelector("#txtPincode").nextElementSibling && document.querySelector("#txtPincode").nextElementSibling.classList.contains('err')){
            document.querySelector("#txtPincode").nextElementSibling.remove();
        }
        
        document.querySelector("#txtPincode").insertAdjacentElement("afterend",errDiv);
        
        flag=false;
    }

    const email=document.getElementById("txtEmail").value;
    var emailpattern=/^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if(!emailpattern.test(email)){
        var newError=document.createElement('div');
        newError.innerHTML="Can't be a email";
        newError.classList.add('errormsg');

        var errDiv=document.createElement('div');
        errDiv.appendChild(newError);
        errDiv.classList.add('err');

        if(document.getElementById("txtEmail").nextElementSibling && document.getElementById("txtEmail").nextElementSibling.classList.contains('err')){
            document.getElementById("txtEmail").nextElementSibling.remove();
        }
        
        document.getElementById("txtEmail").insertAdjacentElement("afterend",errDiv);
        
        flag=false;
    }

    if(!flag){
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
        });
        return false;
    }

    saveData();
    return true;
}

const closeModal = function () {
    var body = document.body;
    const modal = document.querySelector('.modal');
    const overlay = document.querySelector('.overlay');
    modal.classList.add('hidden');
    overlay.classList.add('hidden');
    body.classList.remove("stop");
    localStorage.clear();
};

const openModal = function () {
    window.scroll({
        top: 0, 
        left: 0, 
        behavior: 'smooth',
      });
    var body = document.body;
    const modal = document.querySelector('.modal');
    const overlay = document.querySelector('.overlay');
    modal.classList.remove('hidden');
    overlay.classList.remove('hidden');
    body.classList.add("stop");
    getitem();
};


const allDone = function () {
    window.open("save.html","_self");
}

document.addEventListener('keydown', function (e) {
    const modal = document.querySelector('.modal');
    if (e.key === 'Escape' && !modal.classList.contains('hidden')) {
        closeModal();
    }
});

const saveData=function(){
    var elements = document.querySelectorAll('[data-take="input"]');

    elements.forEach(function(element) {
        var id = element.id;
        var value = element.value.replace(/^.*[\\/]/, '');
        localStorage.setItem(id, value);
    });

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
	var image = document.getElementById('imgOutput');
	image.src = URL.createObjectURL(event.target.files[0]);
};

var loadAadharCard = function(event) {
	var image = document.getElementById('imgAadharCard');
	image.src = URL.createObjectURL(event.target.files[0]);
};

var showResume = function(event) {
	var image = document.getElementById('showResume');
	image.src = URL.createObjectURL(event.target.files[0]);
    image.style.display="block";
};

const check=function(e){
    console.log(e);
    console.log(e.nextElementSibling);
    if(e.nextElementSibling && e.nextElementSibling.classList.contains('err')){
        e.nextElementSibling.remove();
    }
}