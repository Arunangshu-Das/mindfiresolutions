using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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
            catch (Exception ex)
            {
                Logger.AddData(ex);
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
            catch (Exception ex)
            {
                Logger.AddData(ex);
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
                        var newVehicleParking = new VehicleParking
                        {
                            ParkingZoneID = vacantParkingSpace.ParkingZoneID,
                            ParkingSpaceID = vacantParkingSpace.ParkingSpaceID,
                            RegistrationNumber = vehicleRegistrationNumber,
                            BookingDateTime = DateTime.Now
                        };

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
                Logger.AddData(ex);
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
                Logger.AddData(ex);
            }

            return flag;
        }

        public List<ReportModel> GenerateParkingReport(DateTime startDate, DateTime endDate)
        {
            List<ReportModel> report = null;
            endDate = endDate.AddDays(1);
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    report = (from pz in context.ParkingZones
                              from ps in context.ParkingSpaces.Where(x => x.ParkingZoneID == pz.ParkingZoneID).DefaultIfEmpty()
                              from vp in context.VehicleParkings.Where(x => x.ParkingSpaceID == ps.ParkingSpaceID && x.BookingDateTime >= startDate && x.BookingDateTime <= endDate).OrderByDescending(x => x.VehicleParkingID).Take(1).DefaultIfEmpty()
                              select new ReportModel
                              {
                                  ParkingZone = pz.ParkingZoneTitle,
                                  ParkingSpace = ps.ParkingSpaceTitle,
                                  NumberOfBookings = context.VehicleParkings.Count(x => x.ParkingSpaceID == ps.ParkingSpaceID && x.BookingDateTime >= startDate && x.BookingDateTime <= endDate),
                                  NumberOfVehiclesParked = ((vp != null && vp.ReleaseDateTime.HasValue) || vp == null) ? 0 : 1
                              }).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return report;
        }

        public bool SignUp(Signup userdata)
        {
            bool flag = false;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    User user = new User();
                    user.Name = userdata.Name;
                    user.Email = userdata.Email;
                    user.Password = userdata.Password;
                    user.Type = Convert.ToInt32(userdata.Type);
                    context.Users.Add(user);
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

        public bool AddParkingSpace(ParkingModel model)
        {
            bool flag = false;
            try
            {

                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    // Check if parking zone with the same title already exists
                    ParkingZone existingZone = context.ParkingZones.FirstOrDefault(z => z.ParkingZoneTitle == model.ParkingZoneTitle);

                    if (existingZone == null)
                    {
                        // If parking zone doesn't exist, add a new one
                        ParkingZone parkingzone = new ParkingZone();
                        parkingzone.ParkingZoneTitle = model.ParkingZoneTitle;
                        context.ParkingZones.Add(parkingzone);

                        context.SaveChanges();

                        // Add parking spaces for the specified zone
                        for (int i = 1; i <= model.NumberOfSpaces; i++)
                        {
                            string spaceName = $"{model.ParkingZoneTitle}{i:D2}";

                            // Check if parking space with the same title already exists
                            if (context.ParkingSpaces.Any(s => s.ParkingSpaceTitle == spaceName))
                            {
                                // Increment the counter and update spaceName
                                int counter = 1;
                                do
                                {
                                    counter++;
                                    spaceName = $"{model.ParkingZoneTitle}{counter:D2}";
                                } while (context.ParkingSpaces.Any(s => s.ParkingSpaceTitle == spaceName));
                            }

                            ParkingSpace space = new ParkingSpace { ParkingSpaceTitle = spaceName, ParkingZoneID = parkingzone.ParkingZoneID };
                            context.ParkingSpaces.Add(space);
                        }

                        context.SaveChanges();
                        flag = true;
                    }
                    else
                    {
                        // Append parking spaces to the existing zone
                        var lastSpace = context.ParkingSpaces
                            .Where(s => s.ParkingZoneID == existingZone.ParkingZoneID)
                            .OrderByDescending(s => s.ParkingSpaceTitle)
                            .FirstOrDefault();

                        int startCounter = (lastSpace != null) ? int.Parse(lastSpace.ParkingSpaceTitle.Substring(existingZone.ParkingZoneTitle.Length)) + 1 : 1;

                        for (int i = startCounter; i < startCounter + model.NumberOfSpaces; i++)
                        {
                            string spaceName = $"{model.ParkingZoneTitle}{i:D2}";
                            ParkingSpace space = new ParkingSpace { ParkingSpaceTitle = spaceName, ParkingZoneID = existingZone.ParkingZoneID };
                            context.ParkingSpaces.Add(space);
                        }

                        context.SaveChanges();
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public List<ParkingZoneModel> AllParkingZone()
        {
            List<ParkingZoneModel> parkingzones = null;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    parkingzones = context.ParkingZones.Select(p => new ParkingZoneModel
                    {
                        ParkingZoneID = p.ParkingZoneID,
                        ParkingZoneTitle = p.ParkingZoneTitle,
                    })
                                                             .ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.AddData(ex);
            }

            return parkingzones;
        }

        public bool FindEmail(string email)
        {
            bool flag = false;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    int count = context.Users.Where(u => u.Email == email).Count();
                    if (count == 0)
                    {
                        flag = true;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.AddData(ex);
            }
            return flag;
        }

        public bool DeleteAllTransaction()
        {
            bool flag = false;
            try
            {
                using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
                {
                    context.Database.ExecuteSqlCommand("truncate table vehicleparking");
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
    }
}
