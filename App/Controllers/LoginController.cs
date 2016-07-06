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
    public class LoginController : BaseController
    {

        /// <summary>
        /// 第一次加载
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Name">绰号|邮箱|手机号</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public ActionResult Go(string Name, string Pwd)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            AccountArg arg = new AccountArg();
            arg.Name = Name;
            arg.PhoneNumber = Name;
            arg.Email = Name;
            string err = string.Empty;
            DAL.Account model = null;
            m_BLL.IsExist(arg, ref err, ref model);
            if (model == null)
            {
                result.Code = ClientCode.FindNull;
                result.Message = "邮箱|手机号不存在";
            }
            else
            {
                Pwd = EncryptAndDecrypte.EncryptString(Pwd);//加密
                if (model.Password != Pwd)
                {
                    result.Code = ClientCode.Fail;
                    result.Message = "密码错误";
                }
                else if (model.State == StateEnums.JY)
                {
                    result.Code = ClientCode.Fail;
                    result.Message = "账户已禁用，请联系管理员";
                }
                else
                {
                    result.Code = ClientCode.Succeed;
                    result.Message = "登录成功";
                    //result.Url = "../";//(正式需要修改)注册成功后，跳转到填写简历
                    CurrentAccount = new Account_Resume();
                    CurrentAccount.account = model;
                    try
                    {
                        if (model != null)
                        {
                            Langben.IBLL.IResumeBLL rBll = new Langben.BLL.ResumeBLL();
                            CurrentAccount.resume = rBll.GetFirstByAccountID(model.Id);
                        }
                    }
                    catch
                    {

                    }
                }
            }
            return Json(result);

        }
        IBLL.IAccountBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public LoginController()
            : this(new AccountBLL()) { }

        public LoginController(AccountBLL bll)
        {
            m_BLL = bll;
        }
    }
}


