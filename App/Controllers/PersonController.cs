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
    /// 个人信息
    /// </summary>
    public class PersonController : BaseController
    {

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Index()
        {

            DAL.Account model = m_BLL.GetById(CurrentPersonId);
            return View(model);

        }

        IBLL.IAccountBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public PersonController()
            : this(new AccountBLL()) { }

        public PersonController(AccountBLL bll)
        {
            m_BLL = bll;
        }
    }
}


