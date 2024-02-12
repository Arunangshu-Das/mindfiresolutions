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
        readonly DataAccess dataAccess = new DataAccess();

        public bool UserSave(UserInfo user)
        {
            return dataAccess.UserSave(user);
        }

        public UserInfo UserGet(int id)
        {
            return dataAccess.UserGet(id);
        }

        public List<StateName> AllStates(int id)
        {
            return dataAccess.AllStates(id);
        }

        public List<UserInfo> Allusers(string sortExpression, string sortDirection, int startRowIndex, int maximumRows)
        {
            return dataAccess.Allusers(sortExpression,sortDirection,startRowIndex,maximumRows);
        }

        public List<CountryName> CountryNames()
        {
            return dataAccess.CountryNames();
        }

        public int Lenusers()
        {
            return dataAccess.Lenusers();
        }

        public bool UserUpdate(UserInfo userInfo)
        {
            return dataAccess.UserUpdate(userInfo);
        }

        public bool NoteSave(NotesInfo noteinfo)
        {
            return dataAccess.NoteSave(noteinfo);
        }
    }
}
