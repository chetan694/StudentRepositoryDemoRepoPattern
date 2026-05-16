using Microsoft.AspNetCore.Mvc;
using StudentRepositoryDemo.Models;
using StudentRepositoryDemo.Repository;

namespace StudentRepositoryDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var students = _repo.GetAll();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repo.Add(student);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = _repo.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repo.Update(student);
            _repo.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
            return RedirectToAction("Index");
        }
        
    }
}
