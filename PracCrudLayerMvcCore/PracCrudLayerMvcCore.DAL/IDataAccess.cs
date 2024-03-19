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
        public bool UpdateData(StudentModel s);
        public bool DeleteData(StudentModel s);
        public bool AddData(StudentModel s);
        public List<StudentModel> ListData();
    }
}
