using PracCrudADOMvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracCrudADOMvcCore.Business
{
    public interface IService
    {
        public bool UpdateData(StudentModel s);
        public bool DeleteData(StudentModel s);
        public bool AddData(StudentModel s);
        public List<StudentModel> ListData();
    }
}
