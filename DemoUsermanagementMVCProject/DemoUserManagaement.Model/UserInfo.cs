using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagaement.Model
{
    public class UserInfo
    {
        public int UserID { get; set; }

        // UserDetails fields
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherMiddleName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMiddleName { get; set; }
        public string MotherLastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public string HighestEducation { get; set; }
        public string Branch { get; set; }
        public string YearOfPassout { get; set; }
        public string SecondarySchoolName { get; set; }
        public string HigherSecondarySchoolName { get; set; }
        public string BTechCollegeName { get; set; }
        public string MTechCollegeName { get; set; }
        public string SecondaryMarks { get; set; }
        public string HigherSecondaryMarks { get; set; }
        public string BTechMarks { get; set; }
        public string MTechMarks { get; set; }
        public string ProfilePhoto { get; set; }
        public string Aadharcard { get; set; }
        public string MyResume { get; set; }
        public string AboutMyself { get; set; }

        public string GuidProfilePhoto { get; set; }
        public string GuidAadharcard { get; set; }
        public string GuidMyResume { get; set; }
        public string Hobbies { get; set; }

        // AddressDetails fields
        public int PermarentAddressID { get; set; }

        public int PermarentStateId {  get; set; }
        public int PermarentAddressType { get; set; }
        public string PermarentCountry { get; set; }
        public string PermarentStateField { get; set; }
        public string PermarentAddressField { get; set; }
        public string PermarentPincode { get; set; }

        public int CurrentAddressID { get; set; }

        public int CurrentStateId { get; set; }
        public int CurrentAddressType { get; set; }
        public string CurrentCountry { get; set; }
        public string CurrentStateField { get; set; }
        public string CurrentAddressField { get; set; }
        public string CurrentPincode { get; set; }
    }
}
