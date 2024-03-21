using Microsoft.AspNetCore.Mvc;
using PracCrudLayerMvcCore.Business;
using PracCrudLayerMvcCore.Models;
using System.Text.Json;

namespace PracCrudLayerMvcCore.Controllers
{
    public class StudentController : Controller
    {
        private IService _service;
        private static bool checkflag = false;

        public StudentController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FetchAllData()
        {
            byte[] serializedData = HttpContext.Session.Get("Alldata");
            List<StudentModel> data = null;

            if (serializedData != null && checkflag == false)
            {
                data = JsonSerializer.Deserialize<List<StudentModel>>(serializedData);
            }
            else
            {
                data = await _service.ListData();
                HttpContext.Session.Set("Alldata", JsonSerializer.SerializeToUtf8Bytes(data));
                checkflag = false;
            }
            return Json(data);
        }

        public async Task<IActionResult> AddData(StudentModel s)
        {
            bool flag = await _service.AddData(s);
            checkflag = true;
            return Json(flag);
        }

        public async Task<IActionResult> UpdateData(StudentModel s)
        {
            bool flag = await _service.UpdateData(s);
            checkflag = true;
            return Json(flag);
        }

        public async Task<IActionResult> DeleteData(int id)
        {
            bool flag = await _service.DeleteData(new StudentModel { StudentId = id });
            checkflag = true;
            return Json(flag);
        }
    }
}
