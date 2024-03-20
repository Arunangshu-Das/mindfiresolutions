using Microsoft.AspNetCore.Mvc;
using PracCrudADOMvcCore.Business;
using PracCrudADOMvcCore.Models;

namespace PracCrudADOMvcCore.Controllers
{
    public class StudentController : Controller
    {
        private IService _service;

        public StudentController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FetchAllData()
        {
            return Json(_service.ListData());
        }

        public IActionResult AddData(StudentModel s)
        {
            return Json(_service.AddData(s));
        }

        public IActionResult UpdateData(StudentModel s)
        {
            return Json(_service.UpdateData(s));
        }

        public IActionResult DeleteData(int id)
        {
            return Json(_service.DeleteData(new StudentModel { StudentId = id }));
        }
    }
}
