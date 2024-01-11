function updateStates() {
    var country = document.getElementById("con").value;
    var stateDropdown = document.getElementById("st");
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
    var m = document.querySelector(".m");
    var b = document.querySelector(".b");
    var hsec = document.querySelector(".hsec");
    var ihsec = document.querySelector(".ihsec");
    var ib = document.querySelector(".ib");
    var im = document.querySelector(".im");
    hsec.style.display="none";
    b.style.display="none";
    m.style.display="none";
    ihsec.style.display="none";
    ib.style.display="none";
    im.style.display="none";
}

function updateEdu() {
    var edu = document.getElementById("edu").value;
    var stateDropdown = document.getElementById("br");
    var m = document.querySelector(".m");
    var b = document.querySelector(".b");
    var hsec = document.querySelector(".hsec");
    var ihsec = document.querySelector(".ihsec");
    var ib = document.querySelector(".ib");
    var im = document.querySelector(".im");
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
            break;
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
    var pno=document.querySelector("#pno").value;
    if(pno.length!==10){
        console.log(pno);
        console.log(pno.length);
        alert("Phone number must be in 10 digit");
        return false;
    }
    var pincode=document.getElementById("pincode").value;
    if(pincode.length!==6){
        alert("pincode must be in 6 digit");
        return false;
    }

    var secondary=document.getElementById("secondary").value;
    var hsecondary=document.getElementById("hsecondary").value;
    var btech=document.getElementById("btech").value;
    var mtech=document.getElementById("mtech").value;

    if(Number(secondary)>100 || Number(hsecondary)>100 || Number(btech)>100 || Number(mtech)>100 || Number(secondary)<0 || Number(hsecondary)<0 || Number(btech)<0 || Number(mtech)<0){
        alert("Marks must be in 0 to 100");
        return false;
    }

    var edu = document.getElementById("edu").value;
    var hsec=document.getElementById("hsecondary").value;
    var bte=document.getElementById("btech").value;
    var mte=document.getElementById("mtech").value;
    var nhsecondary=document.getElementById("nhsecondary").value;
    var nbtech=document.getElementById("nbtech").value;
    var nmtech=document.getElementById("nmtech").value;
    switch (edu) {
        case "M.Tech":
            if(mte==="" || nmtech===""){
                alert("Mtech domain must be filled");
                return false;
            }

        case "B.Tech":
            if(bte==="" || nbtech===""){
                alert("Btech domain must be filled");
                return false;
            }

        case "Higher Secondary":
            if(hsec==="" || nhsecondary===""){
                alert("Higher Secondry domain must be filled");
                return false;
            }
        }

    return true;
}