using System;
using System.Linq;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 会员
    /// </summary>
    public class AccountApiController : BaseApiController
    {
        public Common.ClientResult.Result Logon([FromBody]Langben.App.Models.LogonModel logonModel)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            if (ModelState.IsValid)
            {
                DAL.Account model = m_BLL.ValidateUser(logonModel.PersonName, logonModel.Password);
                if (model != null)
                {//登录成功
                    IBLL.IResumeBLL rBll = new ResumeBLL();
                    var data = rBll.GetByAccountID(model.Id).FirstOrDefault();
                    Common.Account account = new Common.Account();
                    account.Name = model.Name;
                    account.Id = model.Id;
                    account.ResumeId = data.Id;
                    Utils.WriteCookie("account", account, 7);
                    result.Code = Common.ClientCode.Succeed;
                }
                else
                {
                    result.Code = Common.ClientCode.FindNull;
                }
            }
            else
            {
                result.Code = Common.ClientCode.Fail;

            }
            return result;

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Register([FromBody]Langben.App.Models.RegisterModel model)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.InviteCode))
                {
                    result.Message = "邀请码不能为空";
                }
                else if (string.IsNullOrWhiteSpace(model.Name))
                {
                    result.Message = "绰号不能为空";
                }
                else if ((string.IsNullOrWhiteSpace(model.PhoneNumber)) || (model.PhoneNumber.Substring(0, 1) != "1") || (model.PhoneNumber.Length != 11))
                {
                    result.Message = "手机号码格式不正确";
                }
                else if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6)
                {
                    result.Message = "密码长度至少6位";
                }
                else
                {
                    Common.Account account = m_BLL.Register(model.Name.Trim(), model.PhoneNumber.Trim(), model.Password.Trim(), model.InviteCode, ref message);
                    result.Message = message;
                    if (string.IsNullOrWhiteSpace(message))
                    {
                        Utils.WriteCookie("account", account, 7);
                        result.Code = Common.ClientCode.Succeed;
                        return result; //提示创建成功
                    }

                }
            }

            result.Code = Common.ClientCode.FindNull;
            return result;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Edit([FromBody]DAL.Account entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null)
            {
                if (string.IsNullOrWhiteSpace(entity.MyName))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "姓名不能为空";
                    return result; //提示失败
                }
                if (string.IsNullOrWhiteSpace(entity.Sex))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "性别不能为空";
                    return result; //提示失败
                }
                if (string.IsNullOrWhiteSpace(entity.AnmeldenCity))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "户口所在地不能为空";
                    return result; //提示失败
                }
                if (string.IsNullOrWhiteSpace(entity.LiveCity))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "现在居住地不能为空";
                    return result; //提示失败
                }

                if (string.IsNullOrWhiteSpace(entity.PersonalAssessment))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "个人评价不能为空";
                    return result; //提示失败
                }
                if (string.IsNullOrWhiteSpace(entity.Email) || !Validator.IsEmail(entity.Email))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "电子邮箱不能为空或者格式不对";
                    return result; //提示失败
                }
                if (CurrentPersonId != entity.Id)
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "请登录";
                    return result; //提示失败
                }
                DAL.Account model = m_BLL.GetById(CurrentPersonId);
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

                    return result; //提交成功
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
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        IBLL.IAccountBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public AccountApiController()
            : this(new AccountBLL()) { }

        public AccountApiController(AccountBLL bll)
        {
            m_BLL = bll;
        }

    }
}


