using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExamApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalExamApp.Controllers
{
    public class HomeController : Controller
    {
        private INewsRepository _repository;

        public HomeController(INewsRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(_repository.QueryNews.AsEnumerable());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNews(News news)
        {
            if (ModelState.IsValid)
            {
                _repository.AddNews(news);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditNews(int id)
        {

            var DbEntry = _repository.QueryNews.Where(n =>
            n.NewsId == id).FirstOrDefault();

            ViewBag.NewsName = DbEntry.NewsName;

            return View(DbEntry);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditNews(News news)
        {
            if (ModelState.IsValid)
            {
                _repository.EditNews(news);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteNews(int id)
        {
            _repository.DeleteNews(id);
            return RedirectToAction("Index");
        }
    }
}