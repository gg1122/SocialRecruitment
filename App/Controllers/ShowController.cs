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
    public class ShowController : BaseController
    {
        /// <summary>
        /// 预览
        /// </summary>        
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Index(string id)
        {
            Langben.DAL.PreviewModel model = null;
            if (string.IsNullOrWhiteSpace(id))
            {
                model = m_BLL.GetPreviewInfo(id);

            }
            return View(model);
        }
        IBLL.IPreviewBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public ShowController()
            : this(new PreviewBLL()) { }

        public ShowController(PreviewBLL bll)
        {
            m_BLL = bll;
        }
    }
}


