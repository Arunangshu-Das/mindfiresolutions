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
    var m = document.querySelector(".m-tech-marks");
    var b = document.querySelector(".b-tech-marks");
    var hsec = document.querySelector(".higher-secondary-marks");
    var ihsec = document.querySelector(".higher-secondary-school-name");
    var ib = document.querySelector(".b-tech-college-name");
    var im = document.querySelector(".m-tech-college-name");
    hsec.style.display="none";
    b.style.display="none";
    m.style.display="none";
    ihsec.style.display="none";
    ib.style.display="none";
    im.style.display="none";
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
    var m = document.querySelector(".m-tech-marks");
    var b = document.querySelector(".b-tech-marks");
    var hsec = document.querySelector(".higher-secondary-marks");
    var ihsec = document.querySelector(".higher-secondary-school-name");
    var ib = document.querySelector(".b-tech-college-name");
    var im = document.querySelector(".m-tech-college-name");
    stateDropdown.innerHTML = "";

    switch (edu) {
        case "B.Tech":
            addOption(stateDropdown, "CSE", "CSE");
            addOption(stateDropdown, "Civil", "Civil");
            addOption(stateDropdown, "Electrical", "Electrical");
            addOption(stateDropdown, "Electronics", "Electronics");
            addOption(stateDropdown, "Mechanical", "Mechanical");
            hsec.style.display="flex";
            b.style.display="flex";
            m.style.display="none";
            ihsec.style.display="flex";
            ib.style.display="flex";
            im.style.display="none";
            break;
        case "M.Tech":
            addOption(stateDropdown, "CSE", "CSE");
            addOption(stateDropdown, "Civil", "Civil");
            addOption(stateDropdown, "Electrical", "Electrical");
            addOption(stateDropdown, "Electronics", "Electronics");
            addOption(stateDropdown, "Mechanical", "Mechanical");
            hsec.style.display="flex";
            b.style.display="flex";
            m.style.display="flex";
            ihsec.style.display="flex";
            ib.style.display="flex";
            im.style.display="flex";
            break;
        case "Higher Secondary":
            addOption(stateDropdown, "Arts", "Arts");
            addOption(stateDropdown, "Science", "Science");
            addOption(stateDropdown, "Commerce", "Commerce");
            hsec.style.display="flex";
            b.style.display="none";
            m.style.display="none";
            ihsec.style.display="flex";
            ib.style.display="none";
            im.style.display="none";
            break;
        default:
            addOption(stateDropdown, "All", "All");
            hsec.style.display="none";
            b.style.display="none";
            m.style.display="none";
            ihsec.style.display="none";
            ib.style.display="none";
            im.style.display="none";;
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
    var newerr=document.createElement('div');
    newerr.innerHTML="Please fill this";
    newerr.classList.add('errormsg');

    var err=document.createElement('div');
    err.appendChild(newerr);
    err.classList.add('err');

    var a=document.querySelectorAll('[data-take="input"]');

    for(var i=0;i<a.length;i++){
        if(a[i].value===""){
            a[i].insertAdjacentElement("afterend",err);
            window.scroll({
                top: 0, 
                left: 0, 
                behavior: 'smooth',
              });
            return false;
        }
        else if(a[i].nextElementSibling && a[i].nextElementSibling.classList.contains('err')){
            a[i].nextElementSibling.remove();
        }
    }

    var pno=document.querySelector("#txtPhoneNumber").value;

    if(pno.length!==10){
        console.log(pno);
        console.log(pno.length);
        alert("Phone number must be in 10 digit");
        return false;
    }

    if(document.querySelector("#txtPincode").value.length!==6){
        alert("pincode must be in 6 digit");
        return false;
    }

    const email=document.getElementById("txtEmail").value;
    var emailpattern=/^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if(!emailpattern.test(email)){
        alert("Can't be a email");
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
    // localStorage.clear();
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
        var value = element.value;
        localStorage.setItem(id, value);
    });
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

