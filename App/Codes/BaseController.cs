using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;


using NPOI.HPSF;
using System.IO;
using System.Data;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using Langben.DAL;

namespace  Models
{
    //[SupportFilter]//此处如果去掉注释，则全部继承BaseController的Controller，都将执行SupportFilter过滤
    public class BaseController : Controller
    {
        public string GetCurrentPerson()
        {
            return CurrentPerson;

        }

    /// <summary>
    /// 获取当前登陆人的名称
    /// </summary>
    /// <returns></returns>
    public string CurrentPerson
        {
            get
            {
                Langben.App.Models.Account_Resume account = CurrentAccount;
                if (account != null && account.account != null && !string.IsNullOrWhiteSpace(account.account.Name))
                {
                    return account.account.Name;
                }
                return string.Empty;
            }


        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public Langben.App.Models.Account_Resume CurrentAccount
        {
            get
            {
                Langben.App.Models.Account_Resume currentAccount = null;

                if (Session["account"] != null)
                {
                    currentAccount = Session["account"] as Langben.App.Models.Account_Resume;
                }
                else
                {
                    Session.Clear();


                    //测试
                    //Langben.App.Models.Account_Resume account = new Langben.App.Models.Account_Resume();
                    //Langben.IBLL.IAccountBLL bll = new Langben.BLL.AccountBLL();
                    //AccountArg arg = new AccountArg();
                    //arg.Name = "test";
                    //account.account = bll.GetByParam(arg);
                    //if (account.account != null)
                    //{
                    //    Langben.IBLL.IResumeBLL rBll = new Langben.BLL.ResumeBLL();
                    //    account.resume = rBll.GetFirstByAccountID(account.account.Id);
                    //}
                    //Session["account"] = account;
                    //currentAccount = account;
                   // Response.Redirect("/Blog/Index");

                }

                return currentAccount;
            }
            set
            {
                Session["account"] = value;
            }
            
        }
        
        public BaseController()
        { }
    
   }
}
