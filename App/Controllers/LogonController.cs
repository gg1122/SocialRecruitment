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
    /// 会员
    /// </summary>
    public class LogonController : Controller
    {

        /// <summary>
        /// 第一次加载
        /// </summary>
        /// <returns></returns>
       
        public ActionResult Index()
        {

            return View();
        }
    
    }
}


