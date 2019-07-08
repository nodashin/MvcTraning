using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcWebAPI.Models;

namespace MvcWebAPI.Controllers
{
    public class ArticlesController : ApiController
    {
        private MvcWebAPIContext db = new MvcWebAPIContext();

        public IEnumerable<Article> GetArticlesByCategory(CategoryEnum id)
        {
            var articles = db.Articles.Where(a => a.Category == id);
            return articles;
        }
    }
}
