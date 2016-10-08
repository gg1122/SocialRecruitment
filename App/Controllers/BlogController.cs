using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using Langben.App.Models;
using Webdiyer.WebControls.Mvc;
namespace Langben.App.Controllers
{
    /// <summary>
    /// 博客
    /// </summary>
    public class BlogController : BaseController
    {

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string id)
        { 
            int pIndex = 1;
            if (!string.IsNullOrEmpty(id))
                int.TryParse(id, out pIndex);
            int pageSize = 10;
            int total = 0;
            StringBuilder search = new StringBuilder();
            search.AppendFormat("State{0}&{1}", ArgEnums.DDL_String, StateEnums.QY);
            List<Blog> list = m_BLL.GetByParam(null, pIndex, pageSize, "desc", "CreateTime", search.ToString(), ref total);
            var model = new PagedList<Blog>(list, pIndex, pageSize, total);
            return View(model);
        }
        

        /// <summary>
        /// 详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id) )
            {
                return View();
            }
            ViewBag.CurrentPerson = this.CurrentPerson;
            ViewBag.CurrentPersonId = this.CurrentPersonId;
            var blog = m_BLL.GetById(id);
            if (blog != null)//浏览
            { 
                    if (blog.ReadNumber == null)
                    {
                        blog.ReadNumber = 0;
                    }
                    blog.ReadNumber++;
                    ValidationErrors err = new ValidationErrors();
                    m_BLL.Edit(ref err, blog);
                
            }       
            return View(blog);
          
        }
 
        IBLL.IBlogBLL m_BLL;
        public BlogController()
            : this(new BlogBLL()) { }

        public BlogController(BlogBLL bll)
        {
            m_BLL = bll;
        }

    }
}


