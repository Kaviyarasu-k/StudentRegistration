using Microsoft.AspNetCore.Mvc;
using StudentRegistration.DAL;
using StudentRegistration.Models;
using System.Collections.Generic;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repository;

        public StudentController(StudentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertStudent(student);
                return Json(new { success = true, message = "Student registered successfully!" });
            }
            return Json(new { success = false, message = "Invalid data!" });
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            List<Student> students = _repository.GetStudents();
            return Json(students);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateStudent(student);
                return Json(new { success = true, message = "Student updated successfully!" });
            }
            return Json(new { success = false, message = "Invalid data!" });
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentID)
        {
            _repository.DeleteStudent(studentID);
            return Json(new { success = true, message = "Student deleted successfully!" });
        }

    }
}
