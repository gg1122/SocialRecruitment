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
    public class AccountController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Id = id;
            return View();

        }

        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        {

            return View();
        }


        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Register(string id)
        {

            return View();
        }

        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter]
        public ActionResult Edit()
        {          
            ViewBag.Id = CurrentAccount.account.Id;            
            DAL.Account model = m_BLL.GetById(ViewBag.Id);            
            return View(model);
        }
        /// <summary>
        /// 编辑保存
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSave([FromBody]DAL.Account entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null)
            {
                if (entity.MyName == null || entity.MyName.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "姓名不能为空";
                    return Json(result); //提示失败
                }
                if (entity.Sex == null || entity.Sex.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "性别不能为空";
                    return Json(result); //提示失败
                }
                if (entity.AnmeldenCity == null || entity.AnmeldenCity.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "户口所在地不能为空";
                    return Json(result); //提示失败
                }
                if (entity.LiveCity == null || entity.LiveCity.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "现在所在地不能为空";
                    return Json(result); //提示失败
                }
                if (entity.PersonalAssessment == null || entity.PersonalAssessment.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "个人评价不能为空";
                    return Json(result); //提示失败
                }
                if (entity.PersonalAssessment == null || entity.PersonalAssessment.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "个人评价不能为空";
                    return Json(result); //提示失败
                }
                DAL.Account model = m_BLL.GetById(CurrentAccount.account.Id);
                model.AnmeldenCity = entity.AnmeldenCity;
                model.AnmeldenProvince = entity.AnmeldenProvince;
                model.Email = entity.Email;
                model.LiveCity = entity.LiveCity;
                model.LiveProvince = entity.LiveProvince;
                model.MyName = entity.MyName;
                model.PersonalAssessment = entity.PersonalAssessment;
                model.Sex = entity.Sex;
                model.UpdatePerson = CurrentPerson;
                model.UpdateTime = DateTime.Now;
                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, model))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，会员的信息的Id为" + model.Id, "会员"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = "提交成功";
                    return Json(result); //提交成功
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，会员的信息，" + returnValue, "会员"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return Json(result); //修改插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return Json(result);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Name">绰号|邮箱|手机号</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Login(string Name, string Pwd)
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Name">绰号|邮箱|手机号</param>
        /// <param name="Pwd">密码</param>
        /// <returns></returns>
        public ActionResult LoginGo(string Name, string Pwd)
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
                result.Message = "绰号|邮箱|手机号不存在";
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
                    result.Url = "../Blog/Index";//(正式需要修改)注册成功后，跳转到填写简历

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

        public AccountController()
            : this(new AccountBLL()) { }

        public AccountController(AccountBLL bll)
        {
            m_BLL = bll;
        }
    }
}


