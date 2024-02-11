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

        protected void Page_Load(object sender, EventArgs e)
        {
            checkboxSubscribe.CheckedChanged += new EventHandler(Copy_Address);
        }

        protected void Copy_Address(object sender, EventArgs e)
        {
            if (checkboxSubscribe.Checked)
            {
                // Copy values from current address to permanent address
                CountryPermarent.SelectedValue = CountryCurrent.SelectedValue;
                StatePermarent.SelectedValue = StateCurrent.SelectedValue;
                txtAddressPermarent.Text = txtAddressCurrent.Text;
                txtPincodePermarent.Text = txtPincodeCurrent.Text;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();

            // Populate UserInfo properties with values from the HTML form
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


            userInfo.PermarentCountry = CountryPermarent.SelectedValue;
            userInfo.PermarentStateField = StatePermarent.SelectedValue;
            userInfo.PermarentAddressField = txtAddressPermarent.Text;
            userInfo.PermarentPincode = txtPincodePermarent.Text;

            userInfo.CurrentCountry = CountryCurrent.SelectedValue;
            userInfo.CurrentStateField = StateCurrent.SelectedValue;
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

            service.UserSave(userInfo);
        }
    }
}