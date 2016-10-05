using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;


using System.IO;
using System.Data;
using System.Web;
using Langben.DAL;

namespace Models
{
    //[SupportFilter]//此处如果去掉注释，则全部继承BaseController的Controller，都将执行SupportFilter过滤
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取当前登陆人的ID
        /// </summary>
        /// <returns></returns>
        public string CurrentPersonId
        {
            get
            {
                var account = AccountModel.GetCurrentAccount();
                if (account != null && !string.IsNullOrWhiteSpace(account.Id))
                {
                    return account.Id;

                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取当前登陆人的名称
        /// </summary>
        /// <returns></returns>
        public string CurrentPerson
        {
            get
            {
                var account = AccountModel.GetCurrentAccount();
                if (account != null && !string.IsNullOrWhiteSpace(account.Name))
                {
                    return account.Name;

                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public string CurrentResumeId
        {
            get
            {
                var account = AccountModel.GetCurrentAccount();
                if (account != null && !string.IsNullOrWhiteSpace(account.ResumeId))
                {
                    return account.ResumeId;

                }
                return string.Empty;
            }
            
        }

        public BaseController()
        { }

    }
}
