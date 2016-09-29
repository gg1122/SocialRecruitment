using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
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

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Register([FromBody]Langben.App.Models.RegisterModel model)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            if (model != null && ModelState.IsValid)
            {
                DAL.Account entity = new DAL.Account();

                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "绰号不能为空";
                    return result; //提示失败
                }
                else
                {
                    entity.Name = model.Name.Trim();
                }
                if (!Common.Validator.IsMobile(model.PhoneNumber))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "手机号码格式不正确";
                    return result; //提示失败
                }
                else
                {
                    entity.PhoneNumber = model.PhoneNumber.ToString();
                }

                if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6)
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "密码不能为空或长度至少6位";
                    return result; //提示失败
                }
                else
                {
                    entity.Password = EncryptAndDecrypte.EncryptString(model.Password);//加密;
                }
                entity.LogonIP = IP.GetIP();
                entity.CreateTime = DateTime.Now;
                entity.UpdateTime = entity.CreateTime;
                entity.Id = Result.GetNewId();

                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {//事务
                    IBLL.IResumeBLL rBll = new ResumeBLL();
                    Resume ResumeModel = new Resume();
                    ResumeModel.AccountId = entity.Id;
                    ResumeModel.CreateTime = entity.CreateTime;
                    ResumeModel.Id = Result.GetNewId();
                    ResumeModel.Name = "默认";
                    ResumeModel.Remark = "注册账号自动创建";
                    ResumeModel.Sort = 0;
                    ResumeModel.State = StateEnums.QY;
                    ResumeModel.UpdateTime = ResumeModel.CreateTime;
                    ResumeModel.CompletionPercentage = 0;
                    if (rBll.Create(ref validationErrors, ResumeModel))
                    {
                        LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，会员的信息的Id为" + entity.Id, "会员");//写入日志 
                        result.Code = Common.ClientCode.Succeed;
                        result.Message ="注册成功";
                        result.Url = "../Person";//(正式需要修改)注册成功后，跳转到填写简历
                        Langben.App.Models.Account_Resume ar = new Account_Resume();

                        ar.account = entity;
                        ar.resume = ResumeModel;
                        CurrentAccount = ar;
                        return result; //提示创建成功
                    }
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
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败

                }
                
            }
            if (validationErrors != null && validationErrors.Count > 0)
            {
                validationErrors.All(a =>
                {
                    result.Message += a.ErrorMessage;
                    return true;
                });
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
                    result.Message = "现在所在地不能为空";
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
                if (CurrentAccount == null)
                {
                    return null;
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
                    CurrentAccount.account = model;//重新设置Session
                    result.Url = "/DegreeSchool";
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


