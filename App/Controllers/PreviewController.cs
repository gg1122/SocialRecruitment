﻿using System;
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
using System.Web.Http;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 简历预览
    /// </summary>
    public class PreviewController : BaseController
    {
        /// <summary>
        /// 预览
        /// </summary>        
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Index()
        {
            Langben.DAL.PreviewModel model = null;
            if (CurrentAccount != null && CurrentAccount.resume != null)
            {
                model = m_BLL.GetPreviewInfo(CurrentAccount.resume.Id);

            }
            return View(model);
        }

        /// <summary>
        /// 预览
        /// </summary>        
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Show(string id)
        {
            Langben.DAL.PreviewModel model = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                model = m_BLL.GetPreviewInfoByAccountId(id);

            }
            else
            {
                RedirectToAction("Blog");
            }
            return View(model);
        }
        IBLL.IPreviewBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public PreviewController()
            : this(new PreviewBLL()) { }

        public PreviewController(PreviewBLL bll)
        {
            m_BLL = bll;
        }
    }
}


