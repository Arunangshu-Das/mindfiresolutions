﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
                                                        RegistrationNumber = p.VehicleParkings.OrderByDescending(vp => vp.VehicleParkingID).Where(vp => vp.BookingDateTime != null).Count(vp => vp.ReleaseDateTime==null) != 0 ? p.VehicleParkings.OrderByDescending(Vp => Vp.VehicleParkingID).Select(vp => vp.RegistrationNumber).FirstOrDefault() : null
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
                    //var vacantParkingSpace = context.ParkingSpaces.FirstOrDefault(ps => ps.ParkingAvailability == 1);

                    var vacantParkingSpace = context.ParkingSpaces
        .Where(ps => !context.VehicleParkings.Any(vp => vp.ParkingSpaceID == ps.ParkingSpaceID))
        .Select(ps => new { ps.ParkingSpaceID, ps.ParkingZoneID })
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
            bool flag = true;
            //try
            //{
            //    using (ParkingManagementEntities1 context = new ParkingManagementEntities1())
            //    {
            //        Vehicle vehicle = context.Vehicles.FirstOrDefault(v => v.RegistrationNumber == vehicleRegistrationNumber);
            //        if (vehicle != null)
            //        {
            //            VehicleParking vehiclepark = context.VehicleParkings.FirstOrDefault(v => v.VehicleID == vehicle.VehicleID && v.ReleaseDateTime == null);

            //            if (vehiclepark != null)
            //            {
            //                vehiclepark.ReleaseDateTime = DateTime.Now;
            //                var ParkingSpace = context.ParkingSpaces.FirstOrDefault(ps => ps.ParkingSpaceID == vehiclepark.ParkingSpaceID);
            //                ParkingSpace.ParkingAvailability = 1;
            //                context.SaveChanges();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}

            return flag;
        }
    }
}
