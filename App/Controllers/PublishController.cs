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
    /// 发布博客
    /// </summary>
    public class PublishController : BaseController
    {
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrWhiteSpace(id)|| string.IsNullOrWhiteSpace(CurrentPerson))
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                Blog item = m_BLL.GetById(id);

                return View(item);
            }

        }
        /// <summary>
        /// 第一次加载
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (string.IsNullOrWhiteSpace(CurrentPerson))
            {
                return RedirectToAction("Index", "Login");
            }
            return View();

        }
        [HttpPost]
        public string CententOfImage(string CKEditorFuncNum)//上传博客内容的图片
        {
            string url = System.Web.HttpContext.Current.Request.Url.Host;
            // CKEditor提交的很重要的一个参数  
            String callback = Request.Form["CKEditorFuncNum"];
            System.Web.HttpPostedFileBase pstFile = Request.Files["upload"];
            string upfile = pstFile.FileName; //取得上传的对象名称
            UploadFiles upFiles = new UploadFiles();
            string msg = upFiles.fileSaveAs(pstFile, upfile);
            string outPut = "<script type=\"text/javascript\">window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum;
            outPut += ",'" +url+ msg + "','')</script>";
            // 返回"图像"选项卡并显示图片  request.getContextPath()为web项目名   


            return outPut;
        }
        [HttpPost]
        public string HDpic()//首页图片上传
        {
            string upfile = Request.Form["name"]; //取得上传的对象名称
            System.Web.HttpPostedFileBase pstFile = Request.Files["file"];
            UploadFiles upFiles = new UploadFiles();
            string msg = upFiles.fileSaveAs(pstFile, upfile);
            return msg;
        }
        IBLL.IBlogBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public PublishController()
            : this(new BlogBLL()) { }

        public PublishController(BlogBLL bll)
        {
            m_BLL = bll;
        }
    }
}


