using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoUserManagaement.DAL;
using DemoUserManagaement.Model;

namespace DemoUserManagaement.Business
{
    public class Service
    {
        public bool UserSave(UserInfo user)
        {
            return new DataAccess().UserSave(user);
        }

        public UserInfo UserGet(int id)
        {
            return new DataAccess().UserGet(id);
        }

        public List<StateName> AllStates(int id)
        {
            return new DataAccess().AllStates(id);
        }

        public List<UserInfo> Allusers(string sortExpression, string sortDirection, int startRowIndex, int maximumRows)
        {
            return new DataAccess().Allusers(sortExpression, sortDirection, startRowIndex, maximumRows);
        }

        public List<CountryName> CountryNames()
        {
            return new DataAccess().CountryNames();
        }

        public bool FindEmail(int id, string email)
        {
            return new DataAccess().FindEmail(id, email);
        }

        public int Lenusers()
        {
            return new DataAccess().Lenusers();
        }

        public bool UserUpdate(UserInfo userInfo)
        {
            return new DataAccess().UserUpdate(userInfo);
        }

        public bool NoteSave(NotesInfo noteinfo)
        {
            return new DataAccess().NoteSave(noteinfo);
        }

        public List<NotesInfo> NotesInfos(string sortExpression, string sortDirection, int startRowIndex, int maximumRows, int id)
        {
            return new DataAccess().NotesInfos(sortExpression, sortDirection, startRowIndex, maximumRows, id);
        }

        public int LenNotes(int id)
        {
            return new DataAccess().LenNotes(id);
        }

        public bool DocumentSave(DocumentInfo docinfo)
        {
            return new DataAccess().DocumentSave(docinfo);
        }

        public List<DocumentInfo> DocumentsInfos(string sortExpression, string sortDirection, int startRowIndex, int maximumRows, int id)
        {
            return new DataAccess().DocumentsInfos(sortExpression, sortDirection, startRowIndex, maximumRows, id);
        }

        public int LenDocs(int id)
        {
            return new DataAccess().LenDocs(id);
        }

        public List<DocumentTypeModel> DocumentTypeNames(int id)
        {
            return new DataAccess().DocumentTypeNames(id);
        }
        public SessionClassModel LoginUser(LoginModel login)
        {
            return new DataAccess().LoginUser(login);
        }
        public bool DownloadCheck(FileDownloadModel download)
        {
            return new DataAccess().DownloadCheck(download);
        }
    }
}
