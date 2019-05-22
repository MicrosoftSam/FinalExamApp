using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public class EFNewsRepository : INewsRepository
    {
        private ApplicationDbContext _context;

        public EFNewsRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<News> QueryNews => _context.News;

        public void AddNews(News news)
        {
            _context.Add(news);
            _context.SaveChanges();
        }

        public void EditNews(News news)
        {
            News DbEntry = _context.News.Where(n =>
            n.NewsId == news.NewsId).FirstOrDefault();

            if(DbEntry!= null)
            {
                DbEntry.NewsId = news.NewsId;
                DbEntry.MyNews = news.MyNews;
                DbEntry.NewsName = news.NewsName;
                DbEntry.NewsDate = news.NewsDate;
            }
            _context.SaveChanges();
        }
    }
}
