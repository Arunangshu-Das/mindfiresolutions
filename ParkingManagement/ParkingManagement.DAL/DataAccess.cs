using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.Model;
using ParkingManagement.Utils;

namespace ParkingManagement.DAL
{
    public class DataAccess
    {
        public SessionModel Login(LoginModel model)
        {
            SessionModel session = null;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    User user = context.Users.FirstOrDefault(u => u.Email == model.Email);
                    if (user != null && user.Password == model.Password)
                    {
                        session = new SessionModel();
                        session.Email = model.Email;
                        session.Name = user.Name;
                        session.Type = user.Type;
                        SessionUtil.SetSession(session);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return session;
        }

        public List<ParkingSpaceShowModel> AllSpace()
        {
            List<ParkingSpaceShowModel> allparkingspace = null;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    var parkingSpacesInfo = context.ParkingSpaces
                                                    .Select(p => new
                                                    {
                                                        ParkingSpaceTitle = p.ParkingSpaceTitle,
                                                        ParkingStatus = p.VehicleParkings.OrderByDescending(vp => vp.VehicleParkingID).Select(vp => vp.ReleaseDateTime).FirstOrDefault(),
                                                        RegistrationNumber = p.VehicleParkings.OrderByDescending(vp => vp.VehicleParkingID).Where(vp => vp.BookingDateTime != null).Count(vp => vp.ReleaseDateTime == null) != 0 ? p.VehicleParkings.OrderByDescending(Vp => Vp.VehicleParkingID).Select(vp => vp.RegistrationNumber).FirstOrDefault() : null
                                                    })
                                                    .ToList();


                    allparkingspace = new List<ParkingSpaceShowModel>();

                    foreach (var info in parkingSpacesInfo)
                    {
                        ParkingSpaceShowModel parkingspace = new ParkingSpaceShowModel();
                        parkingspace.ParkingSpaceTitle = info.ParkingSpaceTitle;
                        parkingspace.Availability = info.ParkingStatus == null && info.RegistrationNumber != null ? "occupied" : "vacant";
                        parkingspace.RegistrationNumber = info.RegistrationNumber;
                        allparkingspace.Add(parkingspace);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return allparkingspace;
        }

        public bool BookSpace(string vehicleRegistrationNumber)
        {
            bool flag = true;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {

                    var vacantParkingSpace = context.ParkingSpaces
                .Where(ps => !context.VehicleParkings.Any(vp =>
                    vp.ParkingSpaceID == ps.ParkingSpaceID &&
                    (vp.ReleaseDateTime == null || vp.BookingDateTime == null)))
                .Select(ps => new
                {
                    ParkingSpaceID = ps.ParkingSpaceID,
                    ParkingZoneID = ps.ParkingZoneID
                })
                .FirstOrDefault();

                    if (vacantParkingSpace != null)
                    {
                        // Create a new VehicleParking record
                        var newVehicleParking = new VehicleParking
                        {
                            ParkingZoneID = vacantParkingSpace.ParkingZoneID,
                            ParkingSpaceID = vacantParkingSpace.ParkingSpaceID,
                            RegistrationNumber = vehicleRegistrationNumber,
                            BookingDateTime = DateTime.Now
                        };

                        // Save changes to the database
                        context.VehicleParkings.Add(newVehicleParking);
                        context.SaveChanges();
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return flag;
        }

        public bool FreeSpace(string vehicleRegistrationNumber)
        {
            bool flag = false;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    VehicleParking vehicleparking = context.VehicleParkings.Where(vp => vp.RegistrationNumber == vehicleRegistrationNumber && vp.ReleaseDateTime == null).OrderByDescending(vp => vp.VehicleParkingID).FirstOrDefault();
                    if (vehicleparking != null)
                    {
                        vehicleparking.ReleaseDateTime = DateTime.Now;
                        context.SaveChanges();
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return flag;
        }

        public List<ReportModel> GenerateParkingReport(DateTime startDate, DateTime endDate)
        {
            List<ReportModel> report = null;
            using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
            {
                report = (from pz in context.ParkingZones
                          from ps in context.ParkingSpaces.Where(x => x.ParkingZoneID == pz.ParkingZoneID).DefaultIfEmpty()
                          from vp in context.VehicleParkings.Where(x => x.ParkingSpaceID == ps.ParkingSpaceID && x.BookingDateTime >= startDate && x.BookingDateTime <= endDate).OrderByDescending(x=>x.VehicleParkingID).Take(1).DefaultIfEmpty()
                          select new ReportModel
                          {
                              ParkingZone = pz.ParkingZoneTitle,
                              ParkingSpace = ps.ParkingSpaceTitle,
                              NumberOfBookings = context.VehicleParkings.Count(x => x.ParkingSpaceID == ps.ParkingSpaceID && x.BookingDateTime >= startDate && x.BookingDateTime <= endDate),
                              NumberOfVehiclesParked = ((vp != null && vp.ReleaseDateTime.HasValue )|| vp==null) ? 0 : 1
                          }).Distinct().ToList();

                return report;
            }
        }
    }
}
