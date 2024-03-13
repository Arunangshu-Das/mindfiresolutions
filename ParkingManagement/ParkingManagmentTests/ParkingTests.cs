using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement.Controllers;
using ParkingManagement.Model;
using System;
using System.Web.Mvc;

namespace ParkingManagmentTests
{
    [TestClass]
    public class ParkingTests
    {
        [TestMethod]
        public void LoginTest()
        {
            LoginModel l = new LoginModel
            {
                Email = "ffff@gmail.com",
                Password = "ffff"
            };
            LoginController controller=new LoginController();
            var result=controller.Login(l);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SignupTest()
        {
            SignupController signupcontroller = new SignupController();
            var result = signupcontroller.Signup(new SignupModel { Email="AS@gmail.com",Name="AS",Password="AS",Type="1"});
            Assert.IsNotNull(result);
        }
    }
}
