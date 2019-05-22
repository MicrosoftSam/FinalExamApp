using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamApp.Models.ViewModels
{
    public class ItemListViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
