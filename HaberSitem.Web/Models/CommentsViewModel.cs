using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitem.Web.Models
{
    public class CommentsViewModel
    {
        public IEnumerable<HaberSitem.Core.Model.News> News { get; set; }
        public IEnumerable<HaberSitem.Core.Model.Comments> Comments { get; set; }
        public IEnumerable<HaberSitem.Core.Model.Category> Category { get; set; }
    }
}
