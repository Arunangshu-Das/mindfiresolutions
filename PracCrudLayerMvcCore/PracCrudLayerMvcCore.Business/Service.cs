using PracCrudLayerMvcCore.Models;
using PracCrudLayerMvcCore.DAL;

namespace PracCrudLayerMvcCore.Business
{
    public class Service : IService
    {
        private IDataAccess _dataAccess;

        public Service(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public bool AddData(StudentModel s)
        {
            return _dataAccess.AddData(s);
        }

        public bool DeleteData(StudentModel s)
        {
            return _dataAccess.DeleteData(s);
        }

        public List<StudentModel> ListData()
        {
            return _dataAccess.ListData();
        }

        public bool UpdateData(StudentModel s)
        {
            return _dataAccess.UpdateData(s);
        }
    }
}
