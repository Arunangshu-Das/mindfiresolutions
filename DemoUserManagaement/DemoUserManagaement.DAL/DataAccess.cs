using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DemoUserManagaement.Model;
using DemoUserManagaement.Utils;

namespace DemoUserManagaement.DAL
{
    public class DataAccess
    {
        public bool UserSave(UserInfo userInfo)
        {
            bool flag = false;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
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
                        Password = BCryptConvertion.Encrypt(userInfo.Password),
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
                        GuidMyResume = userInfo.GuidMyResume,
                        GuidAadharcard = userInfo.GuidAadharcard,
                        GuidProfilePhoto = userInfo.GuidProfilePhoto,
                        AboutMyself = userInfo.AboutMyself,
                    };
                    context.UserDetails.Add(userDetail);
                    context.SaveChanges();
                    int userid = userDetail.UserID;
                    AddressDetail currentaddress = new AddressDetail
                    {
                        UserID = userid,
                        AddressType = (int)Enums.ADDRESS.CURRENT,
                        StateId = userInfo.CurrentStateId,
                        //Country = userInfo.CurrentCountry,
                        //StateField = userInfo.CurrentStateField,
                        AddressField = userInfo.CurrentAddressField,
                        Pincode = userInfo.CurrentPincode,
                    };

                    AddressDetail permarentaddress = new AddressDetail
                    {
                        UserID = userid,
                        AddressType = (int)Enums.ADDRESS.PERMARENT,
                        StateId = userInfo.PermarentStateId,
                        AddressField = userInfo.PermarentAddressField,
                        Pincode = userInfo.PermarentPincode,
                    };
                    context.AddressDetails.Add(currentaddress);
                    context.SaveChanges();
                    context.AddressDetails.Add(permarentaddress);
                    context.SaveChanges();

                    List<Role> role = context.Roles.Where(u => u.IsDefault == true).ToList();

                    foreach (Role r in role)
                    {
                        UserRole u = new UserRole();
                        u.UserId = userid;
                        u.RoleID = r.RoleID;
                        context.UserRoles.Add(u);
                    }

                    flag = true;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool FindEmail(int id, string email)
        {
            bool flag = false;
            if (id == 0)
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    List<UserDetail> u = (from user in context.UserDetails
                                          where user.Email == email
                                          select user)
                                                    .ToList();
                    if (u.Count > 0)
                    {
                        flag = true;
                    }
                }
            }
            else
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    List<UserDetail> u = (from user in context.UserDetails
                                          where user.Email == email
                                          select user)
                                                    .ToList();
                    foreach (UserDetail user in u)
                    {
                        if (user.UserID != id)
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        public bool UserUpdate(UserInfo userInfo)
        {
            bool flag = false;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    UserDetail user = context.UserDetails.Find(userInfo.UserID);
                    user.UserID = userInfo.UserID;
                    user.FirstName = userInfo.FirstName;
                    user.MiddleName = userInfo.MiddleName;
                    user.LastName = userInfo.LastName;
                    user.FatherFirstName = userInfo.FatherFirstName;
                    user.MotherFirstName = userInfo.MotherFirstName;
                    user.FatherMiddleName = userInfo.FatherMiddleName;
                    user.MotherMiddleName = userInfo.MotherMiddleName;
                    user.FatherLastName = userInfo.FatherLastName;
                    user.MotherLastName = userInfo.MotherLastName;
                    user.Email = userInfo.Email;
                    user.ContactNumber = userInfo.ContactNumber;
                    user.Gender = userInfo.Gender;
                    user.DateOfBirth = userInfo.DateOfBirth;
                    if (userInfo.Password != "" && userInfo.Password != null)
                    {
                        user.Password = userInfo.Password;
                    }
                    user.HighestEducation = userInfo.HighestEducation;
                    user.Branch = userInfo.Branch;
                    user.YearOfPassout = userInfo.YearOfPassout;
                    user.SecondarySchoolName = userInfo.SecondarySchoolName;
                    user.HigherSecondarySchoolName = userInfo.HigherSecondarySchoolName;
                    user.BTechCollegeName = userInfo.BTechCollegeName;
                    user.MTechCollegeName = userInfo.MTechCollegeName;
                    user.SecondaryMarks = userInfo.SecondaryMarks;
                    user.HigherSecondaryMarks = userInfo.HigherSecondaryMarks;
                    user.BTechMarks = userInfo.BTechMarks;
                    user.MTechMarks = userInfo.MTechMarks;
                    user.Hobbies = userInfo.Hobbies;
                    if (userInfo.ProfilePhoto != null && userInfo.ProfilePhoto != "")
                        user.ProfilePhoto = userInfo.ProfilePhoto;
                    if (userInfo.Aadharcard != null && userInfo.Aadharcard != "")
                        user.Aadharcard = userInfo.Aadharcard;
                    if (userInfo.MyResume != null && userInfo.MyResume != "")
                        user.MyResume = userInfo.MyResume;
                    if (userInfo.GuidMyResume != null && userInfo.GuidMyResume != "")
                        user.GuidMyResume = userInfo.GuidMyResume;
                    if (userInfo.GuidAadharcard != null && userInfo.GuidAadharcard != "")
                        user.GuidAadharcard = userInfo.GuidAadharcard;
                    if (userInfo.GuidProfilePhoto != null && userInfo.GuidProfilePhoto != "")
                        user.GuidProfilePhoto = userInfo.GuidProfilePhoto;
                    int userid = user.UserID;

                    AddressDetail currentaddress = context.AddressDetails.Find(userInfo.CurrentAddressID);

                    currentaddress.AddressField = userInfo.CurrentAddressField;
                    currentaddress.Pincode = userInfo.CurrentPincode;
                    currentaddress.StateId = userInfo.CurrentStateId;

                    AddressDetail permarentaddress = context.AddressDetails.Find(userInfo.PermarentAddressID);

                    permarentaddress.StateId = userInfo.PermarentStateId;
                    permarentaddress.AddressField = userInfo.PermarentAddressField;
                    permarentaddress.Pincode = userInfo.PermarentPincode;
                    context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public UserInfo UserGet(int id)
        {
            UserInfo users = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    UserDetail user = context.UserDetails.Find(id);

                    List<AddressDetail> addresses = (from address in context.AddressDetails
                                                     where address.UserID == id
                                                     select address)
                                                    .ToList();

                    if (user != null)
                    {
                        users = new UserInfo
                        {
                            UserID = user.UserID,
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
                            Password = user.Password,
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
                            GuidMyResume = user.GuidMyResume,
                            GuidAadharcard = user.GuidAadharcard,
                            GuidProfilePhoto = user.GuidProfilePhoto,
                            AboutMyself = user.AboutMyself,
                        };
                    }

                    foreach (var item in addresses)
                    {
                        if (item.AddressType == (int)Enums.ADDRESS.CURRENT)
                        {
                            users.CurrentAddressID = item.AddressID;
                            State s = context.States.Find(item.StateId);
                            users.CurrentCountry = context.Countries.Find(s.CountryId).CountryName;
                            users.CurrentStateField = s.StateName;
                            users.CurrentStateId = (int)item.StateId;
                            users.CurrentAddressField = item.AddressField;
                            users.CurrentPincode = item.Pincode;
                        }
                        else
                        {
                            users.PermarentAddressID = item.AddressID;
                            State s = context.States.Find(item.StateId);
                            users.PermarentCountry = context.Countries.Find(s.CountryId).CountryName;
                            users.PermarentStateField = s.StateName;
                            users.PermarentStateId = (int)item.StateId;
                            users.PermarentAddressField = item.AddressField;
                            users.PermarentPincode = item.Pincode;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return users;
        }

        public List<StateName> AllStates(int id)
        {
            List<StateName> statenames = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    List<State> s = context.States.ToList();
                    statenames = new List<StateName>();
                    foreach (var item in s)
                    {
                        if (item.CountryId == id)
                        {
                            StateName sname = new StateName();
                            sname.StateId = item.StateId;
                            sname.StateNames = item.StateName;
                            statenames.Add(sname);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return statenames;
        }

        public List<UserInfo> Allusers(string sortExpression, string sortDirection, int startRowIndex, int maximumRows)
        {
            List<UserInfo> users = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    IQueryable<UserDetail> query = context.UserDetails;

                    // Sorting
                    query = ApplySorting(query, sortExpression, sortDirection);

                    // Pagination
                    query = query.Skip(startRowIndex).Take(maximumRows);

                    List<UserDetail> alluser = query.ToList();
                    users = new List<UserInfo>();

                    foreach (UserDetail user in alluser)
                    {
                        users.Add(new UserInfo
                        {
                            UserID = user.UserID,
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
                            GuidAadharcard = user.GuidAadharcard,
                            GuidMyResume = user.GuidMyResume,
                            GuidProfilePhoto = user.GuidProfilePhoto,
                            AboutMyself = user.AboutMyself
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return users;
        }

        private static IQueryable<UserDetail> ApplySorting(IQueryable<UserDetail> query, string sortExpression, string sortDirection)
        {
            switch (sortExpression)
            {
                case "UserID":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.UserID) : query.OrderByDescending(u => u.UserID);
                    break;
                case "FirstName":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.FirstName) : query.OrderByDescending(u => u.FirstName);
                    break;
                case "LastName":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.LastName) : query.OrderByDescending(u => u.LastName);
                    break;
                case "Email":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.Email) : query.OrderByDescending(u => u.Email);
                    break;
                case "ContactNumber":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.ContactNumber) : query.OrderByDescending(u => u.ContactNumber);
                    break;
                case "Hobbies":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.Hobbies) : query.OrderByDescending(u => u.Hobbies);
                    break;
                case "ProfilePhoto":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.ProfilePhoto) : query.OrderByDescending(u => u.ProfilePhoto);
                    break;
                    // Add other cases for additional columns
            }

            return query;
        }

        public int Lenusers()
        {
            int lenuser = 0;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    List<UserDetail> alluser = context.UserDetails.ToList();
                    lenuser = alluser.Count;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return lenuser;
        }

        public List<CountryName> CountryNames()
        {
            List<CountryName> countrynames = null;

            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    List<Country> c = context.Countries.ToList();

                    countrynames = new List<CountryName>();
                    foreach (var item in c)
                    {
                        CountryName cname = new CountryName();
                        cname.CountryId = item.CountryId;
                        cname.CountryNames = item.CountryName;
                        countrynames.Add(cname);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return countrynames;

        }

        private static IQueryable<Note> ApplySorting(IQueryable<Note> query, string sortExpression, string sortDirection)
        {
            switch (sortExpression)
            {
                case "NoteID":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.NoteID) : query.OrderByDescending(u => u.NoteID);
                    break;
                case "NoteText":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.NoteText) : query.OrderByDescending(u => u.NoteText);
                    break;

                case "TimeStamp":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.TimeStamp) : query.OrderByDescending(u => u.TimeStamp);
                    break;
            }

            return query;
        }

        public List<NotesInfo> NotesInfos(string sortExpression, string sortDirection, int startRowIndex, int maximumRows, int id)
        {

            List<NotesInfo> notes = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    IQueryable<Note> query = context.Notes;

                    // Sorting
                    query = ApplySorting(query, sortExpression, sortDirection);

                    query = query.Where(u => u.ObjectID == id);

                    // Pagination
                    query = query.Skip(startRowIndex).Take(maximumRows);

                    List<Note> alluser = query.ToList();
                    notes = new List<NotesInfo>();

                    foreach (Note n in alluser)
                    {
                        notes.Add(new NotesInfo
                        {
                            NoteID = n.NoteID,
                            NoteText = n.NoteText,
                            TimeStamp = (DateTime)n.TimeStamp,
                            ObjectID = (int)n.ObjectID,
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return notes;
        }

        public bool NoteSave(NotesInfo noteinfo)
        {
            bool flag = false;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    Note note = new Note
                    {
                        TimeStamp = DateTime.Now,
                        NoteText = noteinfo.NoteText,
                        ObjectID = noteinfo.ObjectID,
                        ObjectType = noteinfo.ObjectType,
                    };
                    context.Notes.Add(note);
                    context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public int LenNotes(int id)
        {
            int lenuser = 0;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    IEnumerable<Note> alluser = context.Notes.ToList().Where(u => u.ObjectID == id);
                    foreach (var item in alluser)
                    {
                        lenuser++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return lenuser;
        }

        public bool DocumentSave(DocumentInfo docinfo)
        {
            bool flag = false;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    Document doc = new Document
                    {
                        TimeStamp = DateTime.Now,
                        DocumentOriginalName = docinfo.DocumentOriginalName,
                        DocumentType = docinfo.DocumentType,
                        DocumentGuidName = docinfo.DocumentGuidName,
                        ObjectID = docinfo.ObjectID,
                        ObjectType = docinfo.ObjectType,
                    };
                    context.Documents.Add(doc);
                    context.SaveChanges();
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public int LenDocs(int id)
        {
            int lenuser = 0;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    IEnumerable<Document> alluser = context.Documents.ToList().Where(u => u.ObjectID == id);
                    foreach (var item in alluser)
                    {
                        lenuser++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return lenuser;
        }

        public List<DocumentInfo> DocumentsInfos(string sortExpression, string sortDirection, int startRowIndex, int maximumRows, int id)
        {

            List<DocumentInfo> docs = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    IQueryable<Document> query = context.Documents;

                    // Sorting
                    query = ApplySorting(query, sortExpression, sortDirection);

                    query = query.Where(u => u.ObjectID == id);

                    // Pagination
                    query = query.Skip(startRowIndex).Take(maximumRows);

                    List<Document> alldocs = query.ToList();
                    docs = new List<DocumentInfo>();
                    List<DocumentTypeModel> documents = DocumentTypeNames(1);

                    foreach (Document doc in alldocs)
                    {
                        docs.Add(new DocumentInfo
                        {
                            DocumentID = doc.DocumentID,
                            DocumentType = doc.DocumentType,
                            DocumentOriginalName = doc.DocumentOriginalName,
                            DocumentGuidName = doc.DocumentGuidName,
                            TimeStamp = (DateTime)doc.TimeStamp,
                            DocumentTypeName = documents[doc.DocumentType - 1].Name,
                            ObjectID = (int)doc.ObjectID,
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return docs;
        }

        private static IQueryable<Document> ApplySorting(IQueryable<Document> query, string sortExpression, string sortDirection)
        {
            switch (sortExpression)
            {
                case "DocumentID":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.DocumentID) : query.OrderByDescending(u => u.DocumentID);
                    break;
                case "DocumentOriginalName":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.DocumentOriginalName) : query.OrderByDescending(u => u.DocumentOriginalName);
                    break;
                case "DocumentGuidName":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.DocumentGuidName) : query.OrderByDescending(u => u.DocumentGuidName);
                    break;
                case "TimeStamp":
                    query = sortDirection == "ASC" ? query.OrderBy(u => u.TimeStamp) : query.OrderByDescending(u => u.TimeStamp);
                    break;
            }

            return query;
        }

        public List<DocumentTypeModel> DocumentTypeNames(int id)
        {
            List<DocumentTypeModel> docs = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    IQueryable<DocumentType> query = context.DocumentTypes.Where(u => u.DocumentTypeFor == id);

                    docs = new List<DocumentTypeModel>();
                    foreach (DocumentType docType in query)
                    {
                        docs.Add(new DocumentTypeModel
                        {
                            Id = docType.DocumentTypeID,
                            Name = docType.DocumentTypeName
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return docs;
        }

        public SessionClassModel LoginUser(LoginModel login)
        {
            SessionClassModel result = null;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    UserDetail u = context.UserDetails.FirstOrDefault(s => s.Email == login.Email);

                    if (u != null && BCryptConvertion.Verify(u.Password, login.Password))
                    {
                        List<UserRole> role = context.UserRoles.Where(s => s.UserId == u.UserID).ToList();
                        List<RoleModel> roles = new List<RoleModel>();
                        result = new SessionClassModel();
                        foreach (var item in role)
                        {
                            Role r = context.Roles.Find(item.RoleID);
                            roles.Add(new RoleModel
                            {
                                Id = item.RoleID,
                                Name = r.RoleName
                            });
                        }

                        UserInfo user = UserGet(u.UserID);

                        result.Roles = roles;
                        result.UserInfo = user;

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return result;
        }

        public bool DownloadCheck(FileDownloadModel download)
        {
            bool flag=false;
            try
            {
                using (DemoUserManagaementEntities24 context = new DemoUserManagaementEntities24())
                {
                    List<Document> doc= context.Documents.Where(d=>d.ObjectID==download.Id && d.DocumentGuidName==download.Url).ToList();
                    if (doc.Count == 1)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData (ex);
            }
            return flag;
        }
    }
}