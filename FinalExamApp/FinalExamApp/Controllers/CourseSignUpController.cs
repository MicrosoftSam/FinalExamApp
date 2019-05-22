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
        public int PageSize = 4;

        public CourseSignUpController(ICourseSignUp repo) =>
            _repository = repo;

        public ViewResult Index(int courseSignUpPage = 1)
        {
            return View(new SignUpViewModel
            {
                CourseSignUps = _repository.CourseSignUps
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
    }
}