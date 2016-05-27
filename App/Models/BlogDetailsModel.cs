using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public class BlogDetailsModel
    {
        /// <summary>
        /// 博客信息
        /// </summary>
        public Langben.DAL.Blog blog{ get; set; }
        /// <summary>
        /// 评论信息集
        /// </summary>
        public List<Langben.DAL.Comment> commentList { get; set; }
       
    }
}