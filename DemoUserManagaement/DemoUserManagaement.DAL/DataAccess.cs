using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUserManagaement.Model;

namespace DemoUserManagaement.DAL
{
    public class DataAccess
    {
        public bool UserSave(UserInfo userInfo)
        {
            bool flag = false;
            using (DemoUserManagaementEntities context = new DemoUserManagaementEntities())
            {
                UserDetail userDetail = new UserDetail
                {
                    FirstName = userInfo.FirstName,
                    MiddleName = userInfo.MiddleName,
                    LastName = userInfo.LastName,
                    FatherFirstName = userInfo.FatherFirstName,
                    MotherFirstName = userInfo.MotherFirstName,
                    FatherMiddleName = userInfo.FatherMiddleName,
                    MotherMiddleName = userInfo.MotherMiddleName,
                    FatherLastName = userInfo.FatherLastName,
                    MotherLastName = userInfo.MotherLastName,
                    Email = userInfo.Email,
                    ContactNumber = userInfo.ContactNumber,
                    Gender = userInfo.Gender,
                    DateOfBirth = userInfo.DateOfBirth,
                    HighestEducation = userInfo.HighestEducation,
                    Branch = userInfo.Branch,
                    YearOfPassout = userInfo.YearOfPassout,
                    SecondarySchoolName = userInfo.SecondarySchoolName,
                    HigherSecondarySchoolName = userInfo.HigherSecondarySchoolName,
                    BTechCollegeName = userInfo.BTechCollegeName,
                    MTechCollegeName = userInfo.MTechCollegeName,
                    SecondaryMarks = userInfo.SecondaryMarks,
                    HigherSecondaryMarks = userInfo.HigherSecondaryMarks,
                    BTechMarks = userInfo.BTechMarks,
                    MTechMarks = userInfo.MTechMarks,
                    Hobbies = userInfo.Hobbies,
                    ProfilePhoto = userInfo.ProfilePhoto,
                    Aadharcard = userInfo.Aadharcard,
                    MyResume = userInfo.MyResume,
                    AboutMyself = userInfo.AboutMyself,
                };
                context.UserDetails.Add(userDetail);
                context.SaveChanges();
                int userid = userDetail.UserID;
                AddressDetail currentaddress = new AddressDetail
                {
                    UserID = userid,
                    AddressType = 1,
                    Country = userInfo.CurrentCountry,
                    StateField = userInfo.CurrentStateField,
                    AddressField = userInfo.CurrentAddressField,
                    Pincode = userInfo.CurrentPincode,
                };

                AddressDetail permarentaddress = new AddressDetail
                {
                    UserID = userid,
                    AddressType = 2,
                    Country = userInfo.PermarentCountry,
                    StateField = userInfo.PermarentStateField,
                    AddressField = userInfo.PermarentAddressField,
                    Pincode = userInfo.PermarentPincode,
                };
                context.AddressDetails.Add(currentaddress);
                context.SaveChanges();
                context.AddressDetails.Add(permarentaddress);
                context.SaveChanges();
                flag = true;
            }
            return flag;
        }


        public UserInfo UserGet(int id)
        {
            UserInfo users = null;
            try
            {
                using (DemoUserManagaementEntities context = new DemoUserManagaementEntities())
                {
                    UserDetail user = context.UserDetails.Find(id);
                    List<AddressDetail> addresses = (List<AddressDetail>)(from address in context.AddressDetails
                                                                          where address.UserID == id
                                                                          select new AddressDetail
                                                                          {
                                                                              AddressField = address.AddressField,
                                                                              AddressType = address.AddressType,
                                                                              Country = address.Country,
                                                                              StateField = address.StateField,
                                                                              AddressID = address.AddressID,
                                                                              UserID = address.UserID,
                                                                              Pincode = address.Pincode,
                                                                          });

                    users = new UserInfo
                    {
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        FatherFirstName = user.FatherFirstName,
                        MotherFirstName = user.MotherFirstName,
                        FatherMiddleName = user.FatherMiddleName,
                        MotherMiddleName = user.MotherMiddleName,
                        FatherLastName = user.FatherLastName,
                        MotherLastName = user.MotherLastName,
                        Email = user.Email,
                        ContactNumber = user.ContactNumber,
                        Gender = user.Gender,
                        DateOfBirth = (DateTime)user.DateOfBirth,
                        HighestEducation = user.HighestEducation,
                        Branch = user.Branch,
                        YearOfPassout = user.YearOfPassout,
                        SecondarySchoolName = user.SecondarySchoolName,
                        HigherSecondarySchoolName = user.HigherSecondarySchoolName,
                        BTechCollegeName = user.BTechCollegeName,
                        MTechCollegeName = user.MTechCollegeName,
                        SecondaryMarks = user.SecondaryMarks,
                        HigherSecondaryMarks = user.HigherSecondaryMarks,
                        BTechMarks = user.BTechMarks,
                        MTechMarks = user.MTechMarks,
                        Hobbies = user.Hobbies,
                        ProfilePhoto = user.ProfilePhoto,
                        Aadharcard = user.Aadharcard,
                        MyResume = user.MyResume,
                        AboutMyself = user.AboutMyself,
                    };

                    foreach (var item in addresses)
                    {
                        if (item.AddressType == 1)
                        {
                            users.CurrentCountry = item.Country;
                            users.CurrentAddressField = item.AddressField;
                            users.CurrentCountry = item.Country.ToString();
                            users.CurrentPincode = item.Pincode;
                            users.CurrentStateField = item.StateField;
                        }
                        else
                        {
                            users.PermarentCountry = item.Country;
                            users.PermarentAddressField = item.AddressField;
                            users.PermarentCountry = item.Country.ToString();
                            users.PermarentPincode = item.Pincode;
                            users.PermarentStateField = item.StateField;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;
        }

        public List<StateName> AllStates(int id)
        {
            List<StateName> statenames = null;
            try
            {
                using (DemoUserManagaementEntities context = new DemoUserManagaementEntities())
                {
                    statenames = (List<StateName>)(from state in context.States
                                                   where state.CountryId == id
                                                   select new StateName
                                                   {
                                                       StateNames = state.StateName.ToString(),
                                                   });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return statenames;
        }

        public List<UserInfo> Allusers()
        {
            List<UserInfo> users = null;
            try
            {
                using (DemoUserManagaementEntities context = new DemoUserManagaementEntities())
                {
                    List<UserDetail> alluser = context.UserDetails.ToList();
                    users= new List<UserInfo>();

                    foreach (UserDetail user in alluser)
                    {
                        users.Add(new UserInfo
                        {
                            FirstName = user.FirstName,
                            MiddleName = user.MiddleName,
                            LastName = user.LastName,
                            FatherFirstName = user.FatherFirstName,
                            MotherFirstName = user.MotherFirstName,
                            FatherMiddleName = user.FatherMiddleName,
                            MotherMiddleName = user.MotherMiddleName,
                            FatherLastName = user.FatherLastName,
                            MotherLastName = user.MotherLastName,
                            Email = user.Email,
                            ContactNumber = user.ContactNumber,
                            Gender = user.Gender,
                            DateOfBirth = (DateTime)user.DateOfBirth,
                            HighestEducation = user.HighestEducation,
                            Branch = user.Branch,
                            YearOfPassout = user.YearOfPassout,
                            SecondarySchoolName = user.SecondarySchoolName,
                            HigherSecondarySchoolName = user.HigherSecondarySchoolName,
                            BTechCollegeName = user.BTechCollegeName,
                            MTechCollegeName = user.MTechCollegeName,
                            SecondaryMarks = user.SecondaryMarks,
                            HigherSecondaryMarks = user.HigherSecondaryMarks,
                            BTechMarks = user.BTechMarks,
                            MTechMarks = user.MTechMarks,
                            Hobbies = user.Hobbies,
                            ProfilePhoto = user.ProfilePhoto,
                            Aadharcard = user.Aadharcard,
                            MyResume = user.MyResume,
                            AboutMyself = user.AboutMyself
                        });
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return users;
        }

        
    }
}