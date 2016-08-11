using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.IO;
using System.Data;

using System.Web;
using Common;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using Langben.DAL;

namespace Models
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 获取当前登陆人的ID
        /// </summary>
        /// <returns></returns>
        public string CurrentPersonId
        {
            get
            {
                Langben.App.Models.Account_Resume account = CurrentAccount;
                if (account != null && account.account != null && !string.IsNullOrWhiteSpace(account.account.Id))
                {
                    return account.account.Id;
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
                Langben.App.Models.Account_Resume account = CurrentAccount;
                if (account != null  && account.account!=null && !string.IsNullOrWhiteSpace(account.account.Name))
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

                if (HttpContext.Current.Session["account"] != null)
                {
                    currentAccount = HttpContext.Current.Session["account"] as Langben.App.Models.Account_Resume;
                }
                else
                {
                    HttpContext.Current.Session.Clear();

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
                    //HttpContext.Current.Session["account"] = account;
                    //currentAccount = account;

                    //Response.Redirect("/Blog/Index");
                }

                return currentAccount;
            }
            set
            {
                HttpContext.Current.Session["account"] = value;
            }

        }

        
        public class GetDataParam
        {
            public string sort { get; set; }
            public string order { get; set; }
            public int page { get; set; }
            public int rows { get; set; }
            public string id { get; set; }
            public string search { get; set; }
        }
        public class ExportParam
        {
            public string id { get; set; }
            public string title { get; set; }
            public string field { get; set; }
            public string sortName { get; set; }
            public string sortOrder { get; set; }
            public string search { get; set; }

        }

        public static HttpResponseMessage toJson(Object obj)
        {
            String str;
            if (obj is String || obj is Char)
            {
                str = obj.ToString();
            }
            else
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                str = serializer.Serialize(obj);
            }
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, System.Text.Encoding.GetEncoding("UTF-8"), "application/json") };
          
            return result;
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
