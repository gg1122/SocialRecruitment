using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Models;
namespace Langben.App.Controllers
{
    /// <summary>
    /// 会员
    /// </summary>
    public class AccountController : BaseController
    {
        /// <summary>
        /// 是否登录
        /// </summary>
        /// <returns></returns>
        public string GetIsLogining()
        {
            if (CurrentAccount != null)
            {
                return "Y";
            }
            else
            {
                return "N";
            }
        }
    }
}