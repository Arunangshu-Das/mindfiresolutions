using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.DAL;
using ParkingManagement.Model;

namespace ParkingManagement.Business
{
    public class Service
    {
        public SessionModel Login(LoginModel model)
        {
            return new DataAccess().Login(model);
        }
        public List<ParkingSpaceShowModel> AllSpace()
        {
            return new DataAccess().AllSpace();
        }
        public bool BookSpace(string vehicleRegistrationNumber)
        {
            return new DataAccess().BookSpace(vehicleRegistrationNumber);
        }
        public bool FreeSpace(string vehicleRegistrationNumber)
        {
            return new DataAccess().FreeSpace(vehicleRegistrationNumber);
        }
        public List<ReportModel> GenerateParkingReport(DateTime startDate, DateTime endDate)
        {
            return new DataAccess().GenerateParkingReport(startDate, endDate);
        }
    }
}
