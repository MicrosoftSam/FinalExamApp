using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExamApp.Models;

namespace FinalExamApp.Components
{
    public class CategoryNavViewComponent : ViewComponent
    {
        private ICourseRepository _repository;

        public CategoryNavViewComponent(ICourseRepository repo) =>
            _repository = repo;

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Courses
                .Select(c => c.Category)
                .Distinct()
                .OrderBy(c => c));
        }
    }
}
