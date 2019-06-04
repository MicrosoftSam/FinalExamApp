using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models
{
    public interface INewsRepository
    {
        IQueryable<News> QueryNews { get; }
        void AddNews(News news);
        void EditNews(News news);
        void DeleteNews(int id);
    }
}
