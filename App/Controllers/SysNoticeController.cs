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
    /// 通知中心
    /// </summary>
    public class SysNoticeController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
            var data = m_BLL.GetByAccountId(CurrentPersonId);
            return View(data);
        }
       
        IBLL.ISysNoticeBLL m_BLL;
         

        public SysNoticeController()
            : this(new SysNoticeBLL()) { }

        public SysNoticeController(SysNoticeBLL bll)
        {
            m_BLL = bll;
        }

    }
}


