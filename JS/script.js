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
    if(localStorage.getItem("name")===null){
        closeModal();
    }
    else{
        openModal();
    }
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

function makeObjet(){
    var fname=document.getElementById("fname");
    var lname=document.getElementById("lname");
    var ffname=document.getElementById("ffname");
    var flname=document.getElementById("flname");
    var mfname=document.getElementById("mfname");
    var mlname=document.getElementById("mlname");
    var pno=document.getElementById("pno");
    const con=document.getElementById("con");
    const st=document.getElementById("st");
    const dob=document.getElementById("dob");
    const address=document.getElementById("address");
    const pincode=document.getElementById("pincode");
    const edu=document.getElementById("edu");
    const br=document.getElementById("br");
    const yop=document.getElementById("yop");
    const secondary=document.getElementById("secondary");
    const hsecondary=document.getElementById("hsecondary");
    const btech=document.getElementById("btech");
    const mtech=document.getElementById("mtech");
    const nsecondary=document.getElementById("nsecondary");
    const nhsecondary=document.getElementById("nhsecondary");
    const nbtech=document.getElementById("nbtech");
    const nmtech=document.getElementById("nmtech");
    const cv=document.getElementById("cv");
    const img=document.getElementById("img");
    const idcard=document.getElementById("idcard");
    const about=document.getElementById("about");
    const hobby=document.getElementById("hobby");
    const subscribe=document.getElementById("subscribe");
    const gender=document.querySelector('input[name="gender"]:checked');

    

}

function validateForm(){

    // <div class="errormsg">Please fill this</div>
    var newerr=document.createElement('div');
    newerr.innerHTML="Please fill this";
    newerr.classList.add('errormsg');

    var err=document.createElement('div');
    err.appendChild(newerr);
    err.classList.add('err');

    var fname=document.getElementById("fname");
    var lname=document.getElementById("lname");
    var ffname=document.getElementById("ffname");
    var flname=document.getElementById("flname");
    var mfname=document.getElementById("mfname");
    var mlname=document.getElementById("mlname");
    var pno=document.getElementById("pno");
    const con=document.getElementById("con");
    const st=document.getElementById("st");
    const dob=document.getElementById("dob");
    const address=document.getElementById("address");
    const pincode=document.getElementById("pincode");
    const edu=document.getElementById("edu");
    const br=document.getElementById("br");
    const yop=document.getElementById("yop");
    const secondary=document.getElementById("secondary");
    const hsecondary=document.getElementById("hsecondary");
    const btech=document.getElementById("btech");
    const mtech=document.getElementById("mtech");
    const nsecondary=document.getElementById("nsecondary");
    const nhsecondary=document.getElementById("nhsecondary");
    const nbtech=document.getElementById("nbtech");
    const nmtech=document.getElementById("nmtech");
    const cv=document.getElementById("cv");
    const img=document.getElementById("img");
    const idcard=document.getElementById("idcard");
    const about=document.getElementById("about");
    const hobby=document.getElementById("hobby");
    const subscribe=document.getElementById("subscribe");
    const gender=document.querySelector('input[name="gender"]:checked');

    if(fname.value===""){
        fname.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(fname.nextElementSibling && fname.nextElementSibling.classList.contains('err')){
        fname.nextElementSibling.remove();
    }

    if(lname.value===""){
        lname.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(lname.nextElementSibling && lname.nextElementSibling.classList.contains('err')){
        fname.nextElementSibling.remove();
    }

    if(ffname.value===""){
        ffname.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(ffname.nextElementSibling && ffname.nextElementSibling.classList.contains('err')){
        ffname.nextElementSibling.remove();
    }

    if(flname.value===""){
        flname.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(flname.nextElementSibling && flname.nextElementSibling.classList.contains('err')){
        flname.nextElementSibling.remove();
    }

    if(mfname.value===""){
        mfname.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(mfname.nextElementSibling && mfname.nextElementSibling.classList.contains('err')){
        mfname.nextElementSibling.remove();
    }

    if(mlname.value===""){
        mlname.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(mlname.nextElementSibling && mlname.nextElementSibling.classList.contains('err')){
        mlname.nextElementSibling.remove();
    }

    if(pno.value===""){
        pno.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(pno.nextElementSibling && pno.nextElementSibling.classList.contains('err')){
        pno.nextElementSibling.remove();
    }

    if(con.value===""){
        con.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(con.nextElementSibling && con.nextElementSibling.classList.contains('err')){
        con.nextElementSibling.remove();
    }

    if(st.value===""){
        st.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(st.nextElementSibling && st.nextElementSibling.classList.contains('err')){
        st.nextElementSibling.remove();
    }

    if(dob.value===""){
        dob.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(dob.nextElementSibling && dob.nextElementSibling.classList.contains('err')){
        dob.nextElementSibling.remove();
    }

    if(address.value===""){
        address.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(address.nextElementSibling && address.nextElementSibling.classList.contains('err')){
        address.nextElementSibling.remove();
    }

    if(pincode.value===""){
        pincode.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(pincode.nextElementSibling && pincode.nextElementSibling.classList.contains('err')){
        pincode.nextElementSibling.remove();
    }

    if(edu.value===""){
        edu.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(edu.nextElementSibling && edu.nextElementSibling.classList.contains('err')){
        edu.nextElementSibling.remove();
    }

    if(br.value===""){
        br.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(br.nextElementSibling && br.nextElementSibling.classList.contains('err')){
        br.nextElementSibling.remove();
    }

    if(yop.value===""){
        yop.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(yop.nextElementSibling && yop.nextElementSibling.classList.contains('err')){
        yop.nextElementSibling.remove();
    }

    if(cv.value===""){
        cv.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(cv.nextElementSibling && cv.nextElementSibling.classList.contains('err')){
        cv.nextElementSibling.remove();
    }

    if(img.value===""){
        img.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(img.nextElementSibling && img.nextElementSibling.classList.contains('err')){
        img.nextElementSibling.remove();
    }

    if(idcard.value===""){
        idcard.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(idcard.nextElementSibling && idcard.nextElementSibling.classList.contains('err')){
        idcard.nextElementSibling.remove();
    }

    if(about.value===""){
        about.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(about.nextElementSibling && about.nextElementSibling.classList.contains('err')){
        about.nextElementSibling.remove();
    }

    if(hobby.value===""){
        hobby.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(hobby.nextElementSibling && hobby.nextElementSibling.classList.contains('err')){
        hobby.nextElementSibling.remove();
    }

    if(subscribe.value===""){
        subscribe.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(subscribe.nextElementSibling && subscribe.nextElementSibling.classList.contains('err')){
        subscribe.nextElementSibling.remove();
    }

    if(gender.value===""){
        gender.insertAdjacentElement("afterend",err);
        window.scroll({
            top: 0, 
            left: 0, 
            behavior: 'smooth',
          });
        return false;
    }
    else if(gender.nextElementSibling && gender.nextElementSibling.classList.contains('err')){
        gender.nextElementSibling.remove();
    }

    var pno=document.querySelector("#pno").value;

    if(pno.length!==10){
        console.log(pno);
        console.log(pno.length);
        alert("Phone number must be in 10 digit");
        return false;
    }
    if(pincode.value.length!==6){
        alert("pincode must be in 6 digit");
        return false;
    }

    const email=document.getElementById("email").value;
    var emailpattern=/^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if(!emailpattern.test(email)){
        alert("Can't be a email");
        return false;
    }

    if(Number(secondary.value)>100 || Number(hsecondary.value)>100 || Number(btech.value)>100 || Number(mtech.value)>100 || Number(secondary.value)<0 || Number(hsecondary.value)<0 || Number(btech.value)<0 || Number(mtech.value)<0){
        alert("Marks must be in 0 to 100");
        return false;
    }

    var hsec=document.getElementById("hsecondary").value;
    var bte=document.getElementById("btech").value;
    var mte=document.getElementById("mtech").value;
    switch (edu.value) {
        case "M.Tech":
            if(mte.value==="" || nmtech.value===""){
                alert("Mtech domain must be filled");
                return false;
            }

        case "B.Tech":
            if(bte.value==="" || nbtech.value===""){
                alert("Btech domain must be filled");
                return false;
            }

        case "Higher Secondary":
            if(hsec.value==="" || nhsecondary.value===""){
                alert("Higher Secondry domain must be filled");
                return false;
            }
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
    const name=document.getElementById("fname").value+" "+document.getElementById("mname").value+" "+document.getElementById("lname").value;

    const fname=document.getElementById("ffname").value+" "+document.getElementById("fmname").value+" "+document.getElementById("flname").value;

    const mname=document.getElementById("mfname").value+" "+document.getElementById("mmname").value+" "+document.getElementById("mlname").value;

    const email=document.getElementById("email").value;

    const pno=document.getElementById("pno").value;

    const con=document.getElementById("con").value;

    const st=document.getElementById("st").value;

    const dob=document.getElementById("dob").value;

    const address=document.getElementById("address").value;

    const pincode=document.getElementById("pincode").value;

    const edu=document.getElementById("edu").value;

    const br=document.getElementById("br").value;

    const yop=document.getElementById("yop").value;

    const secondary=document.getElementById("secondary").value;

    const hsecondary=document.getElementById("hsecondary").value;

    const btech=document.getElementById("btech").value;

    const mtech=document.getElementById("mtech").value;

    const nsecondary=document.getElementById("nsecondary").value;

    const nhsecondary=document.getElementById("nhsecondary").value;

    const nbtech=document.getElementById("nbtech").value;

    const nmtech=document.getElementById("nmtech").value;

    const cv=document.getElementById("cv").value.replace(/^.*[\\/]/, '');

    const img=document.getElementById("img").value.replace(/^.*[\\/]/, '');

    const idcard=document.getElementById("idcard").value.replace(/^.*[\\/]/, '');

    const about=document.getElementById("about").value;

    const hobby=document.getElementById("hobby").value;

    const subscribe=document.getElementById("subscribe").value;

    const gender=document.querySelector('input[name="gender"]:checked').value;

    localStorage.setItem("name", name);
    localStorage.setItem("fname", fname);
    localStorage.setItem("mname", mname);
    localStorage.setItem("email", email);
    localStorage.setItem("pno", pno);
    localStorage.setItem("con", con);
    localStorage.setItem("st", st);
    localStorage.setItem("dob", dob);
    localStorage.setItem("address", address);
    localStorage.setItem("pincode", pincode);
    localStorage.setItem("edu", edu);
    localStorage.setItem("br", br);
    localStorage.setItem("yop", yop);
    localStorage.setItem("secondary", secondary);
    localStorage.setItem("hsecondary", hsecondary);
    
    localStorage.setItem("btech", btech);
    localStorage.setItem("mtech", mtech);
    localStorage.setItem("nsecondary", nsecondary);
    localStorage.setItem("nhsecondary", nhsecondary);
    localStorage.setItem("nbtech", nbtech);
    localStorage.setItem("nmtech", nmtech);
    localStorage.setItem("cv", cv);
    localStorage.setItem("img", img);
    localStorage.setItem("idcard", idcard);
    localStorage.setItem("about", about);
    localStorage.setItem("hobby", hobby);
    localStorage.setItem("subscribe", subscribe);
    localStorage.setItem("gender", gender);
}

function getitem(){
    document.getElementById("rname").innerText=localStorage.getItem("name");
    document.getElementById("rfname").innerText=localStorage.getItem("fname");
    document.getElementById("rmname").innerText=localStorage.getItem("mname");
    document.getElementById("remail").innerText=localStorage.getItem("email");
    document.getElementById("rph").innerText=localStorage.getItem("pno");
    document.getElementById("rcon").innerText=localStorage.getItem("con");
    document.getElementById("rstate").innerText=localStorage.getItem("st");
    document.getElementById("rdob").innerText=localStorage.getItem("dob");
    document.getElementById("raddress").innerText=localStorage.getItem("address");
    document.getElementById("rpin").innerText=localStorage.getItem("pincode");
    document.getElementById("rhedu").innerText=localStorage.getItem("edu");
    document.getElementById("rbranch").innerText=localStorage.getItem("br");
    document.getElementById("ryop").innerText=localStorage.getItem("yop");
    document.getElementById("rmsec").innerText=localStorage.getItem("secondary")===""?"NA":localStorage.getItem("secondary");
    document.getElementById("rmhsec").innerText=localStorage.getItem("hsecondary")===""?"NA":localStorage.getItem("hsecondary");
    
    document.getElementById("rmbtech").innerText=localStorage.getItem("btech")===""?"NA":localStorage.getItem("btech");
    document.getElementById("rmmtech").innerText=localStorage.getItem("mtech")===""?"NA":localStorage.getItem("mtech");
    document.getElementById("rssec").innerText=localStorage.getItem("nsecondary")===""?"NA":localStorage.getItem("nsecondary");
    document.getElementById("rhssec").innerText=localStorage.getItem("nhsecondary")===""?"NA":localStorage.getItem("nhsecondary");
    document.getElementById("rbtech").innerText=localStorage.getItem("nbtech")===""?"NA":localStorage.getItem("nbtech");
    document.getElementById("rmtech").innerText=localStorage.getItem("nmtech")===""?"NA":localStorage.getItem("nmtech");
    document.getElementById("rresume").innerText=localStorage.getItem("cv");
    document.getElementById("rimg").innerText=localStorage.getItem("img");
    document.getElementById("raadhar").innerText=localStorage.getItem("idcard");
    document.getElementById("rabout").innerText=localStorage.getItem("about")===""?"NA":localStorage.getItem("about");
    document.getElementById("rhobby").innerText=localStorage.getItem("hobby")===""?"NA":localStorage.getItem("hobby");
    document.getElementById("rsub").innerText=localStorage.getItem("subscribe")==="subscribe"?"Yes":"No";
    document.getElementById("rgen").innerText=localStorage.getItem("gender");

    console.log(localStorage.getItem("email"));
}

var loadimage = function(event) {
	var image = document.getElementById('imgoutput');
	image.src = URL.createObjectURL(event.target.files[0]);
};

var loadid = function(event) {
	var image = document.getElementById('imgidcard');
	image.src = URL.createObjectURL(event.target.files[0]);
};

var showresume = function(event) {
	var image = document.getElementById('showresume');
	image.src = URL.createObjectURL(event.target.files[0]);
    image.style.display="block";
};

