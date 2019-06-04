using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExamApp.Models;
using FinalExamApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalExamApp.Controllers
{
    public class CourseController : Controller
    {
        private ICourseRepository _repository;
        public int PageSize = 4;

        public CourseController(ICourseRepository repo) => 
            _repository = repo;

        public ViewResult Index(string category, int coursePage = 1)
        {                
            return View(new ItemListViewModel
            {
                Courses = _repository.Courses
                .Where(c => c.Category == null || c.Category == category)
                .OrderBy(c => c.Name)
                .Skip((coursePage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = coursePage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        _repository.Courses.Count() :
                        _repository.Courses.Where(x => x.Category
                        == category).Count()
                },
                CurrentCategory = category
            });
        }

        public ViewResult ShowAllCourses(string searchString, int coursePage = 1)
        {
            int courseCount = 0;

            if(searchString != null)
            {
                foreach (var n in _repository.Courses.Where(c =>
                    c.Name.Contains(searchString)))
                {
                    courseCount += 1;
                }
                return View(new ItemListViewModel
                {
                    Courses = _repository.Courses.Where(c =>
                    c.Name.Contains(searchString))
                    .OrderBy(c => c.Name)
                    .Skip((coursePage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = coursePage,
                        ItemsPerPage = PageSize,
                        TotalItems = searchString == null ?
                        _repository.Courses.Count() :
                        courseCount
                    }
                });
            }
            else
            {
                foreach(var n in _repository.Courses)
                {
                    courseCount += 1;
                }

                return View(new ItemListViewModel
                {
                    Courses = _repository.Courses
                    .OrderBy(c => c.Name)
                    .Skip((coursePage - 1) * PageSize)
                    .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = coursePage,
                        ItemsPerPage = PageSize,
                        TotalItems = searchString == null ?
                        _repository.Courses.Count() :
                        courseCount
                    }
                });
            }
                 
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveCourse(newCourse);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            var course = _repository.Courses.Where(c =>
            c.CourseId == id).SingleOrDefault();

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _repository.EditCourse(course);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteCourse(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            return View(
                _repository.Courses.Where(c =>
                c.CourseId == id).FirstOrDefault());
        }
    }
}