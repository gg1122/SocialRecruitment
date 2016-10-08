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
            model = m_BLL.GetPreviewInfo(CurrentResumeId);
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
            model = m_BLL.GetPreviewInfoByAccountId(id);
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


