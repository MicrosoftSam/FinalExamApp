using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExamApp.Models;
using FinalExamApp.Models.ViewModels;

namespace FinalExamApp.Controllers
{
    public class CourseSignUpController : Controller
    {
        private ICourseSignUp _repository;
        private ICourseRepository _coursesRepository;
        public int PageSize = 4;

        public CourseSignUpController(ICourseSignUp repo,
            ICourseRepository courseRepo)
        {
            _repository = repo;
            _coursesRepository = courseRepo;
        }

        public ViewResult Index(int id, int courseSignUpPage = 1)
        {
            return View(new SignUpViewModel
            {
                CourseSignUps = _repository.CourseSignUps.Where(
                    c => c.CourseId == id)
                .OrderBy(s => s.LastName)
                .Skip((courseSignUpPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = courseSignUpPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.CourseSignUps.Count()
                }
            });
        }

        [HttpGet]
        public ViewResult SignUp(int id)
        {
            Course course = _coursesRepository.Courses.Where(
                s => s.CourseId == id).FirstOrDefault();

            ViewBag.CourseName = course.Name;

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(CourseSignUp signUp, int id)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveSignUp(signUp, id);
                return RedirectToAction("Index", "Course");
            }
            else
            {
                return View();
            }
        }

       
    }
}