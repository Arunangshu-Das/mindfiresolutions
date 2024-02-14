using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoUserManagaement.Model;
using DemoUserManagaement.Business;
using System.Xml.Linq;
using System.IO;
using DemoUserManagaement.Utils;

namespace DemoUserManagaement
{
    public partial class UserDetails : System.Web.UI.Page
    {
        Service service = new Service();


        protected void Page_Load(object sender, EventArgs e)
        {
            int userid;
            notes.IdValue = Request.QueryString["id"];
            docs.IdValue = Request.QueryString["id"];
            //checkboxSubscribe.CheckedChanged += new EventHandler(Copy_Address);
            if (!IsPostBack)
            {
                List<CountryName> countryNames = service.CountryNames();

                ddlPermanentCountryName.DataSource = countryNames;
                ddlPermanentCountryName.DataValueField = "CountryId"; // Property of your State class representing the value
                ddlPermanentCountryName.DataTextField = "CountryNames";
                ddlPermanentCountryName.DataBind();

                ddlCurrentCountryName.DataSource = countryNames;
                ddlCurrentCountryName.DataValueField = "CountryId"; // Property of your State class representing the value
                ddlCurrentCountryName.DataTextField = "CountryNames";
                ddlCurrentCountryName.DataBind();

                if (Request.QueryString["id"] != null)
                {
                    userid = Convert.ToInt32(Request.QueryString["id"]);
                    LoadUser(userid);
                }
                else
                {
                    notes.Visible = false;
                    docs.Visible = false;
                }
            }
        }


        public void LoadUser(int userid)
        {
            try
            {
                UserInfo user = service.UserGet(userid);
                txtFirstName.Text = user.FirstName;
                txtMiddleName.Text = user.MiddleName;
                txtLastName.Text = user.LastName;

                txtFatherFirstName.Text = user.FatherFirstName;
                txtFatherMiddleName.Text = user.FatherMiddleName;
                txtFatherLastName.Text = user.FatherLastName;
                txtMotherFirstName.Text = user.MotherFirstName;
                txtMotherMiddleName.Text = user.MotherMiddleName;
                txtMotherLastName.Text = user.MotherLastName;
                txtEmail.Text = user.Email;
                txtPhoneNumber.Text = user.ContactNumber;
                PermarentAddressId.Text = Convert.ToString(user.PermarentAddressID);
                CurrentAddressId.Text = Convert.ToString(user.CurrentAddressID);

                if (user.Gender == "Male") radioMale.Checked = true;
                else radioFemale.Checked = true;

                dateOfBirth.Text = "";

                dateOfBirth.Text = user.DateOfBirth.ToString("yyyy-MM-dd");



                ddlPermanentCountryName.SelectedValue = user.PermarentCountry;
                ddlPermanentCountryName.SelectedIndex = Convert.ToInt32(ddlPermanentCountryName.SelectedValue);
                int id = Convert.ToInt32(ddlPermanentCountryName.SelectedValue);
                ddlPermanentStateName.Items.Clear();
                List<StateName> states = service.AllStates(id);

                ddlPermanentStateName.DataSource = states;
                ddlPermanentStateName.DataValueField = "StateId"; // Property of your State class representing the value
                ddlPermanentStateName.DataTextField = "StateNames";
                ddlPermanentStateName.DataBind();
                ddlPermanentStateName.SelectedValue = user.PermarentStateField;
                ddlPermanentStateName.SelectedIndex = Convert.ToInt32(ddlPermanentStateName.SelectedValue);
                txtAddressPermarent.Text = user.PermarentAddressField;
                txtPincodePermarent.Text = user.PermarentPincode;

                ddlCurrentCountryName.SelectedValue = user.CurrentCountry;
                ddlCurrentCountryName.SelectedIndex = Convert.ToInt32(ddlCurrentCountryName.SelectedValue);
                id = Convert.ToInt32(ddlCurrentCountryName.SelectedValue);
                ddlCurrentStateName.Items.Clear();
                states = service.AllStates(id);
                ddlCurrentStateName.DataSource = states;
                ddlCurrentStateName.DataValueField = "StateId"; // Property of your State class representing the value
                ddlCurrentStateName.DataTextField = "StateNames";
                ddlCurrentStateName.DataBind();
                ddlCurrentStateName.SelectedValue = user.CurrentStateField;
                ddlCurrentStateName.SelectedIndex = Convert.ToInt32(ddlCurrentStateName.SelectedValue);
                txtAddressCurrent.Text = user.CurrentAddressField;
                txtPincodeCurrent.Text = user.CurrentPincode;

                // Educational Details
                selectEducation.Text = user.HighestEducation;
                selectBranch.Text = user.Branch;
                ddlYearOfPassout.Text = user.YearOfPassout;
                txtSecondaryMarks.Text = user.SecondaryMarks;
                txtHigherSecondaryMarks.Text = user.HigherSecondaryMarks;
                txtBTechMarks.Text = user.BTechMarks;
                txtMTechMarks.Text = user.MTechMarks;
                txtSecondarySchoolName.Text = user.SecondarySchoolName;
                txtHigherSecondarySchoolName.Text = user.HigherSecondaryMarks;
                txtBTechCollegeName.Text = user.BTechCollegeName;
                txtMTechCollegeName.Text = user.MTechCollegeName;

                // Documents
                // Assuming fileImage, fileAadharCard, and fileResume are FileUpload controls
                fileImageNameDisplay.Text = Path.GetFileNameWithoutExtension(user.ProfilePhoto);
                fileAadharCardNameDisplay.Text = Path.GetFileNameWithoutExtension(user.Aadharcard);
                fileResumeNameDisplay.Text = Path.GetFileNameWithoutExtension(user.MyResume);


                // About You
                txtAboutYourself.Text = user.AboutMyself;
                txtHobbies.Text = user.Hobbies;

                txtAddressCurrent.Text = user.CurrentAddressField;
                txtAddressPermarent.Text = user.PermarentAddressField;
            }
            catch(Exception ex)
            {
                Logger.AddData(ex);
            }
        }


        public void DdlPermanentCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlPermanentCountryName.SelectedValue);
            ddlPermanentStateName.Items.Clear();
            List<StateName> states = service.AllStates(id);

            ddlPermanentStateName.DataSource = states;
            ddlPermanentStateName.DataValueField = "StateId"; // Property of your State class representing the value
            ddlPermanentStateName.DataTextField = "StateNames";
            ddlPermanentStateName.DataBind();
        }

        public void DdlCurrentCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlCurrentCountryName.SelectedValue);
            ddlCurrentStateName.Items.Clear();
            List<StateName> states = service.AllStates(id);
            ddlCurrentStateName.DataSource = states;
            ddlCurrentStateName.DataValueField = "StateId"; // Property of your State class representing the value
            ddlCurrentStateName.DataTextField = "StateNames";
            ddlCurrentStateName.DataBind();
        }

        public void Copy_Address(object sender, EventArgs e)
        {

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo userInfo = new UserInfo();

                // Populate UserInfo properties with values from the HTML form
                if (Request.QueryString["id"] != null)
                {
                    userInfo.UserID = Convert.ToInt32(Request.QueryString["id"]);
                    userInfo.PermarentAddressID = Convert.ToInt32(PermarentAddressId.Text);
                    userInfo.CurrentAddressID = Convert.ToInt32(CurrentAddressId.Text);
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

                userInfo.PermarentStateId = Convert.ToInt32(ddlPermanentStateName.SelectedValue);
                userInfo.PermarentCountry = ddlPermanentCountryName.SelectedValue;
                userInfo.PermarentStateField = ddlPermanentStateName.SelectedValue;
                userInfo.PermarentAddressField = txtAddressPermarent.Text;
                userInfo.PermarentPincode = txtPincodePermarent.Text;


                userInfo.CurrentStateId = Convert.ToInt32(ddlCurrentStateName.SelectedItem.Value);
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

                string fileImageLocation = "", fileAadharCardLocation = "", fileResumeLocation = "", guidFileImageLocation = "", guidFileAadharCardLocation = "", guiFileResumeLocation = "";

                if ((fileImage.PostedFile != null) && (fileImage.PostedFile.ContentLength > 0))
                {
                    Guid obj = Guid.NewGuid();
                    string fn = System.IO.Path.GetFileName(fileImage.PostedFile.FileName);
                    fileImageLocation = Server.MapPath("upload") + "\\" + fn;
                    guidFileImageLocation = Server.MapPath("upload") + "\\" + obj.ToString() + Path.GetExtension(fileImage.PostedFile.FileName);
                    try
                    {
                        fileImage.PostedFile.SaveAs(guidFileImageLocation);
                    }
                    catch (Exception ex)
                    {
                        Logger.AddData(ex);
                    }
                }

                if ((fileAadharCard.PostedFile != null) && (fileAadharCard.PostedFile.ContentLength > 0))
                {
                    Guid obj = Guid.NewGuid();
                    string fn = System.IO.Path.GetFileName(fileAadharCard.PostedFile.FileName);
                    fileAadharCardLocation = Server.MapPath("upload") + "\\" + fn;
                    guidFileAadharCardLocation = Server.MapPath("upload") + "\\" + obj.ToString() + Path.GetExtension(fileAadharCard.PostedFile.FileName);
                    try
                    {
                        fileAadharCard.PostedFile.SaveAs(guidFileAadharCardLocation);
                    }
                    catch (Exception ex)
                    {
                        Logger.AddData(ex);
                    }
                }

                if ((fileResume.PostedFile != null) && (fileResume.PostedFile.ContentLength > 0))
                {
                    Guid obj = Guid.NewGuid();
                    string fn = System.IO.Path.GetFileName(fileResume.PostedFile.FileName);
                    fileResumeLocation = Server.MapPath("upload") + "\\" + fn;
                    guiFileResumeLocation = Server.MapPath("upload") + "\\" + obj.ToString() + Path.GetExtension(fileResume.PostedFile.FileName);
                    try
                    {
                        fileResume.PostedFile.SaveAs(guiFileResumeLocation);
                    }
                    catch (Exception ex)
                    {
                        Logger.AddData(ex);
                    }
                }

                if (fileImageLocation != "")
                {
                    userInfo.ProfilePhoto = Path.GetFileName(fileImageLocation);
                    userInfo.GuidProfilePhoto = Path.GetFileName(guidFileImageLocation);
                }

                if (fileAadharCardLocation != null)
                {
                    userInfo.Aadharcard = Path.GetFileName(fileAadharCardLocation);
                    userInfo.GuidAadharcard = Path.GetFileName(guidFileAadharCardLocation);
                }

                if (fileResumeLocation != null)
                {
                    userInfo.MyResume = Path.GetFileName(fileResumeLocation);
                    userInfo.GuidMyResume = Path.GetFileName(guiFileResumeLocation);
                }
                 

                // About You
                userInfo.AboutMyself = txtAboutYourself.Text;
                userInfo.Hobbies = txtHobbies.Text;

                if (Request.QueryString["id"] == null)
                {
                    service.UserSave(userInfo);
                }
                else
                {
                    service.UserUpdate(userInfo);
                }
            }
            catch(Exception ex)
            {
                Logger.AddData(ex);
            }
            Response.Redirect("~/Users");
        }
    }
}