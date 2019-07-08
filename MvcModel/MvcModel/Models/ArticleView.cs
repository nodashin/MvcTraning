using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MvcModel.Models
{
    public class ArticleView
    {
        [DisplayName("タイトル")]
        public string Title { get; set; }

        [DisplayName("ビュー数")]
        public int ViewCount { get; set; }

        [DisplayName("公開状態")]
        public string Released { get; set; }
    }
}