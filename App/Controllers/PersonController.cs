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
            if (CurrentAccount != null)
            {
                ViewBag.Id = CurrentAccount.account.Id;
                DAL.Account model = m_BLL.GetById(ViewBag.Id);
                return View(model);
            }
            return View();
        }
        /// <summary>
        /// 编辑保存
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSave([FromBody]DAL.Account entity)
        {
            if (CurrentAccount == null)
            {
                return null;
            }
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
                    result.Url = "../DegreeSchool";
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


