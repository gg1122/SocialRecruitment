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
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
            string pageIndex = Request["pageIndex"];
            int pIndex = 1;
            if (!string.IsNullOrEmpty(pageIndex))
                int.TryParse(pageIndex, out pIndex);
            int pageSize = 10;
            int total = 0;
            StringBuilder search = new StringBuilder();
            search.AppendFormat("State{0}&{1}", ArgEnums.DDL_String,StateEnums.QY);   
            List<Blog> list = m_BLL.GetByParam(null, pIndex, pageSize, "desc", "CreateTime", search.ToString(), ref total);           
            var model = new PagedList<Blog>(list, pIndex, pageSize, total);
            return View(model);
        }
         /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]  
        public ActionResult Details(string id,string Op)
        {
             
            var blog = m_BLL.GetById(id);
            
            if (Op == "Read" && blog!=null)//浏览
            {
                try
                {
                    if(blog.ReadNumber==null)
                    {
                        blog.ReadNumber = 0;
                    }
                    blog.ReadNumber++;
                    ValidationErrors err = new ValidationErrors();
                    m_BLL.Edit(ref err, blog);
                }
                catch(Exception ex)
                {

                }

            }
            return View(blog);
            /* 原来的代码，增加blog和comment外键之后
              ViewBag.Id = id;
                        IBLL.ICommentBLL c_BLL = new CommentBLL();
                        Langben.App.Models.BlogDetailsModel model = new BlogDetailsModel();
                        model.blog = m_BLL.GetById(id);
                        StringBuilder search = new StringBuilder();
                        search.AppendFormat("BlogId{0}&{1}^State{0}&{2}", ArgEnums.DDL_String,id, StateEnums.QY);
                        model.commentList = c_BLL.GetByParam("", "desc", "CreateTime", search.ToString());
                        if (Op == "Read" && model.blog!=null)//浏览
                        {
                            try
                            {
                                if(model.blog.ReadNumber==null)
                                {
                                    model.blog.ReadNumber = 0;
                                }
                                model.blog.ReadNumber++;
                                ValidationErrors err = new ValidationErrors();
                                m_BLL.Edit(ref err, model.blog);
                            }
                            catch(Exception ex)
                            {

                            }

                        }
                        */
        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        { 
            
            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View();
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


