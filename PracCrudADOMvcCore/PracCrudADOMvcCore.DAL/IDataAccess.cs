﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracCrudADOMvcCore.Models;

namespace PracCrudADOMvcCore.DAL
{
    public interface IDataAccess
    {
        public bool UpdateData(StudentModel s);
        public bool DeleteData(StudentModel s);
        public bool AddData(StudentModel s);
        public List<StudentModel> ListData();
    }
}