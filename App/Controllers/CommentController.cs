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

namespace Langben.App.Controllers
{
    /// <summary>
    /// 评论
    /// </summary>
    public class CommentController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
        
            return View();
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
        public ActionResult Details(string id)
        {
            ViewBag.Id = id;
            return View();

        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <param name="blogId">博客ID</param>
        /// <param name="Content">评论内容</param>
        /// <returns></returns>
        [SupportFilter]        
        public ActionResult Create(string blogId,string Content)
        {
            Comment model = new Comment();
            model.BlogId = blogId;
            model.AgreeNumber = 0;
            model.Content = Content;
            model.CreatePerson = CurrentPerson;
            model.CreateTime = DateTime.Now;
            if (CurrentAccount != null)
            {
                FileUploaderBLL fBll = new FileUploaderBLL();
                //fBll.GetByRefResumeId
                //UploadFiles fileBll = new SocialSystem.BLL.UploadFiles();
                //SocialSystem.Model.UploadFiles fileModel = fileBll.GetModel(CurrentAccount.Id);
                //if (fileModel != null && fileModel.PictureUrl.Trim() != "")
                //{
                //    model.MyPicture = fileModel.PictureUrl.Trim();
                //}
                //model.MyPicture = GetCurrentAccount().p;
            }
            model.Sort = 0;
            model.State = StateEnums.QY;
            model.UpdatePerson= CurrentPerson;
            model.UpdateTime = model.CreateTime;
            model.Id = Common.Result.GetNewId();
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
     
    }
}


