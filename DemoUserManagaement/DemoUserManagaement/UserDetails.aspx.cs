using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagaement.Model;
using DemoUserManagaement.Business;
using System.Xml.Linq;

namespace DemoUserManagaement
{
    public partial class UserDetails : System.Web.UI.Page
    {
        Service service = new Service();

        public int userid = -1;

        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}

        //protected void CountryCurrent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Call a method to populate states based on the selected country
        //    PopulateStates();
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

            //checkboxSubscribe.CheckedChanged += new EventHandler(Copy_Address);
            if (!IsPostBack)
            {
                List<CountryName> countryNames = service.CountryNames();

                foreach (CountryName c in countryNames)
                {
                    ListItem item = new ListItem(c.CountryNames);
                    ddlPermanentCountryName.Items.Add(item);
                }
                foreach (CountryName c in countryNames)
                {
                    ListItem item = new ListItem(c.CountryNames);
                    ddlCurrentCountryName.Items.Add(item);
                }

                if (Request.QueryString["id"] != null)
                {
                    userid = Convert.ToInt32(Request.QueryString["id"]);
                    LoadUser(userid);
                }
                else
                {
                    
                }
            }
        }


        public void LoadUser(int userid)
        {
            UserInfo user = service.UserGet(userid);
            txtFirstName.Text = user.FirstName;
            txtMiddleName.Text = user.MiddleName;
            txtLastName.Text = user.LastName;

            txtFatherFirstName.Text=user.FatherFirstName;
            txtFatherMiddleName.Text=user.FatherMiddleName;
            txtFatherLastName.Text=user.FatherLastName;
            txtMotherFirstName.Text=user.MotherFirstName;
            txtMotherMiddleName.Text=user.MotherMiddleName;
            txtMotherLastName.Text=user.MotherLastName;
            txtEmail.Text=user.Email;
            txtPhoneNumber.Text=user.ContactNumber;
            PermarentAddressId.Text = Convert.ToString(user.PermarentAddressID);
            CurrentAddressId.Text = Convert.ToString(user.CurrentAddressID);

            if (user.Gender == "Male") radioMale.Checked=true;
            else radioFemale.Checked=true;

            dateOfBirth.Text = "";

            dateOfBirth.Text = user.DateOfBirth.ToString("yyyy-MM-dd");



            ddlPermanentCountryName.Text=user.PermarentCountry;
            int id = 0;
            if (ddlPermanentCountryName.SelectedValue == "USA")
            {
                id = 2;
            }
            else
            {
                id = 1;
            }
            ddlPermanentStateName.Items.Clear();
            List<StateName> states = service.AllStates(id);
            foreach (StateName s in states)
            {
                ListItem item = new ListItem(s.StateNames);
                ddlPermanentStateName.Items.Add(item);
            }
            ddlPermanentStateName.Text=user.PermarentStateField;
            txtAddressPermarent.Text=user.PermarentAddressField;
            txtPincodePermarent.Text=user.PermarentPincode;

            ddlCurrentCountryName.Text=user.CurrentCountry;
            if (ddlCurrentCountryName.SelectedValue == "USA")
            {
                id = 2;
            }
            else
            {
                id = 1;
            }
            ddlCurrentStateName.Items.Clear();
            states = service.AllStates(id);
            foreach (StateName s in states)
            {
                ListItem item = new ListItem(s.StateNames);
                ddlCurrentStateName.Items.Add(item);
            }
            ddlCurrentStateName.Text=user.CurrentStateField;
            txtAddressCurrent.Text=user.CurrentAddressField;
            txtPincodeCurrent.Text=user.CurrentPincode;

            // Educational Details
            selectEducation.Text=user.HighestEducation;
            selectBranch.Text=user.Branch;
            ddlYearOfPassout.Text=user.YearOfPassout;
            txtSecondaryMarks.Text=user.SecondaryMarks;
            txtHigherSecondaryMarks.Text=user.HigherSecondaryMarks;
            txtBTechMarks.Text=user.BTechMarks;
            txtMTechMarks.Text=user.MTechMarks;
            txtSecondarySchoolName.Text=user.SecondarySchoolName;
            txtHigherSecondarySchoolName.Text=user.HigherSecondaryMarks;
            txtBTechCollegeName.Text=user.BTechCollegeName;
            txtMTechCollegeName.Text=user.MTechCollegeName;

            // Documents
            // Assuming fileImage, fileAadharCard, and fileResume are FileUpload controls
            //fileImage.FileBytes=user.ProfilePhoto;
            //fileAadharCard.FileBytes=user.Aadharcard;
            //fileResume.FileBytes = user.MyResume;

            // About You
            txtAboutYourself.Text=user.AboutMyself;
            txtHobbies.Text=user.Hobbies;



            txtAddressCurrent.Text = user.CurrentAddressField;
            txtAddressPermarent.Text = user.PermarentAddressField;
        }


        public void DdlPermanentCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (ddlPermanentCountryName.SelectedValue == "USA")
            {
                id = 2;
            }
            else
            {
                id = 1;
            }
            ddlPermanentStateName.Items.Clear();
            List<StateName> states = service.AllStates(id);
            foreach (StateName s in states)
            {
                ListItem item = new ListItem(s.StateNames);
                ddlPermanentStateName.Items.Add(item);
            }
        }

        public void DdlCurrentCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            if (ddlCurrentCountryName.SelectedValue == "USA")
            {
                id = 2;
            }
            else
            {
                id = 1;
            }
            ddlCurrentStateName.Items.Clear();
            List<StateName> states = service.AllStates(id);
            foreach (StateName s in states)
            {
                ListItem item = new ListItem(s.StateNames);
                ddlCurrentStateName.Items.Add(item);
            }
        }

        public void Copy_Address(object sender, EventArgs e)
        {

        }

        //protected void ddlCurrentCountryName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    CountryStateBLL countryStateBLL = new CountryStateBLL();
        //    countryStateBLL.LoadStates(ddlCurrentCountryName.SelectedValue, ddlCurrentStateName);
        //}

        //private void PopulateStates()
        //{
        //    string selectedCountry = CountryCurrent.SelectedValue;

        //    // Perform logic to get states based on the selected country
        //    // For demonstration purposes, a simple switch statement is used here
        //    int id;
        //    if (selectedCountry == "India")
        //    {
        //        id = 1;
        //    }
        //    else
        //    {
        //        id = 2;
        //    }
        //    List<StateName> states = service.AllStates(id);

        //    // Clear existing items in the StateCurrent DropDownList
        //    StateCurrent.Items.Clear();

        //    // Add new items to the StateCurrent DropDownList
        //    foreach (StateName state in states)
        //    {
        //        StateCurrent.Items.Add(new ListItem(state.StateNames, state.StateNames));
        //    }
        //}


        //protected void Copy_Address(object sender, EventArgs e)
        //{
        //    if (checkboxSubscribe.Checked)
        //    {
        //        // Copy values from current address to permanent address
        //        CountryPermarent.SelectedValue = CountryCurrent.SelectedValue;
        //        StatePermarent.SelectedValue = StateCurrent.SelectedValue;
        //        txtAddressPermarent.Text = txtAddressCurrent.Text;
        //        txtPincodePermarent.Text = txtPincodeCurrent.Text;
        //    }
        //}

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();

            // Populate UserInfo properties with values from the HTML form
            if(Convert.ToInt32(Request.QueryString["id"]) != -1)
            {
                userInfo.UserID = Convert.ToInt32(Request.QueryString["id"]);
            }
            userInfo.FirstName = txtFirstName.Text;
            userInfo.MiddleName = txtMiddleName.Text;
            userInfo.LastName = txtLastName.Text;
            userInfo.FatherFirstName = txtFatherFirstName.Text;
            userInfo.FatherMiddleName = txtFatherMiddleName.Text;
            userInfo.FatherLastName = txtFatherLastName.Text;
            userInfo.MotherFirstName = txtMotherFirstName.Text;
            userInfo.MotherMiddleName = txtMotherMiddleName.Text;
            userInfo.MotherLastName = txtMotherLastName.Text;
            userInfo.Email = txtEmail.Text;
            userInfo.ContactNumber = txtPhoneNumber.Text;

            // Gender: Assuming radioMale and radioFemale are RadioButton controls
            userInfo.Gender = radioMale.Checked ? "Male" : "Female";

            // DateOfBirth: Assuming dateOfBirth is a TextBox for date input
            DateTime dob;
            if (DateTime.TryParse(dateOfBirth.Text, out dob))
            {
                userInfo.DateOfBirth = dob;
            }


            userInfo.PermarentCountry = ddlPermanentCountryName.SelectedValue;
            userInfo.PermarentStateField = ddlPermanentStateName.SelectedValue;
            userInfo.PermarentAddressField = txtAddressPermarent.Text;
            userInfo.PermarentPincode = txtPincodePermarent.Text;

            userInfo.PermarentAddressID = Convert.ToInt32(PermarentAddressId.Text);
            userInfo.CurrentAddressID = Convert.ToInt32(CurrentAddressId.Text);

            userInfo.CurrentCountry = ddlCurrentCountryName.SelectedValue;
            userInfo.CurrentStateField = ddlCurrentStateName.SelectedValue;
            userInfo.CurrentAddressField = txtAddressCurrent.Text;
            userInfo.CurrentPincode = txtPincodeCurrent.Text;

            // Educational Details
            userInfo.HighestEducation = selectEducation.SelectedValue;
            userInfo.Branch = selectBranch.SelectedValue;
            userInfo.YearOfPassout = ddlYearOfPassout.SelectedValue;
            userInfo.SecondaryMarks = txtSecondaryMarks.Text;
            userInfo.HigherSecondaryMarks = txtHigherSecondaryMarks.Text;
            userInfo.BTechMarks = txtBTechMarks.Text;
            userInfo.MTechMarks = txtMTechMarks.Text;
            userInfo.SecondarySchoolName = txtSecondarySchoolName.Text;
            userInfo.HigherSecondarySchoolName = txtHigherSecondarySchoolName.Text;
            userInfo.BTechCollegeName = txtBTechCollegeName.Text;
            userInfo.MTechCollegeName = txtMTechCollegeName.Text;

            // Documents
            // Assuming fileImage, fileAadharCard, and fileResume are FileUpload controls
            userInfo.ProfilePhoto = fileImage.FileBytes;
            userInfo.Aadharcard = fileAadharCard.FileBytes;
            userInfo.MyResume = fileResume.FileBytes;

            // About You
            userInfo.AboutMyself = txtAboutYourself.Text;
            userInfo.Hobbies = txtHobbies.Text;

            if (Convert.ToInt32(Request.QueryString["id"]) == -1) 
            {
                service.UserSave(userInfo);
            }
            else
            {
                service.UserUpdate(userInfo);
            }
        }
    }
}