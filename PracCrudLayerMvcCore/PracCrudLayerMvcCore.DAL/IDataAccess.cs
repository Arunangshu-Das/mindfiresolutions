using PracCrudLayerMvcCore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracCrudLayerMvcCore.Models;

namespace PracCrudLayerMvcCore.DAL
{
    public interface IDataAccess
    {
        public Task<bool> UpdateData(StudentModel s);
        public Task<bool> DeleteData(StudentModel s);
        public Task<bool> AddData(StudentModel s);
        public Task<List<StudentModel>> ListData();
    }
}
