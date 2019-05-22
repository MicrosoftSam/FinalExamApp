using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExamApp.Models;

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
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
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
        public IActionResult EditNews(int id)
        {

            var DbEntry = _repository.QueryNews.Where(n =>
            n.NewsId == id).FirstOrDefault();

            ViewBag.NewsName = DbEntry.NewsName;

            return View(DbEntry);
        }

        [HttpPost]
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
    }
}