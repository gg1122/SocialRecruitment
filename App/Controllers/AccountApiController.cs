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
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;
            List<DAL.Account> queryData = m_BLL.GetByParam(null, getParam.page, getParam.rows, getParam.order, getParam.sort, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    Id = s.Id
                    ,
                    Name = s.Name
                    ,
                    Password = s.Password
                    ,
                    PhoneNumber = s.PhoneNumber
                    ,
                    InviteCode = s.InviteCode
                    ,
                    InviteCodeUser = s.InviteCodeUser
                    ,
                    InviteCodeDatetime = s.InviteCodeDatetime
                    ,
                    InviteCode2 = s.InviteCode2
                    ,
                    InviteCode2User = s.InviteCode2User
                    ,
                    InviteCode2Datetime = s.InviteCode2Datetime
                    ,
                    LogonIP = s.LogonIP
                    ,
                    MyName = s.MyName
                    ,
                    Sex = s.Sex
                    ,
                    Birthday = s.Birthday
                    ,
                    AnmeldenProvince = s.AnmeldenProvince
                    ,
                    AnmeldenCity = s.AnmeldenCity
                    ,
                    LiveProvince = s.LiveProvince
                    ,
                    LiveCity = s.LiveCity
                    ,
                    PersonalAssessment = s.PersonalAssessment
                    ,
                    Email = s.Email
                    ,
                    Sort = s.Sort
                    ,
                    State = s.State
                    ,
                    CreateTime = s.CreateTime
                    ,
                    CreatePerson = s.CreatePerson
                    ,
                    UpdateTime = s.UpdateTime
                    ,
                    UpdatePerson = s.UpdatePerson
                    ,
                    Version = s.Version


                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public DAL.Account Get(string id)
        {
            DAL.Account item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]DAL.Account entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;

                entity.Id = Result.GetNewId();
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，会员的信息的Id为" + entity.Id, "会员"
                        );//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    return result; //提示创建成功
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
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Register([FromBody]Langben.App.Models.RegisterModel model)
        {
            DAL.Account entity = null;
            if (model != null && ModelState.IsValid)
            {
                entity = new DAL.Account();
                if (model.Name != null)
                {
                    entity.Name = model.Name.ToUpper();
                }
                if (model.PhoneNumber != null)
                {
                    entity.PhoneNumber = model.PhoneNumber.ToString();
                }
                if (model.Password != null)
                {
                    entity.Password = EncryptAndDecrypte.EncryptString(model.Password);//加密
                }
                entity.CreateTime = DateTime.Now;
                entity.UpdateTime = entity.CreateTime;  
                entity.Id= Result.GetNewId();
            }
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
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
                        result.Message = Suggestion.InsertSucceed;
                        result.Url = "../Blog/Index";//(正式需要修改)注册成功后，跳转到填写简历
                        return result; //提示创建成功
                    }
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

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        // PUT api/<controller>/5
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
                if (entity.MyName == null || entity.MyName.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "姓名不能为空";
                    return result; //提示失败
                }
                if (entity.Sex == null || entity.Sex.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "性别不能为空";
                    return result; //提示失败
                }
                if (entity.AnmeldenCity == null || entity.AnmeldenCity.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "户口所在地不能为空";
                    return result; //提示失败
                }
                if (entity.LiveCity == null || entity.LiveCity.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "现在所在地不能为空";
                    return result; //提示失败
                }
                if (entity.PersonalAssessment == null || entity.PersonalAssessment.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "个人评价不能为空";
                    return result; //提示失败
                }
                if (entity.PersonalAssessment == null || entity.PersonalAssessment.Trim() == "")
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "个人评价不能为空";
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

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Delete(string query)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            string[] deleteId = query.GetString().Split(',');
            if (deleteId != null && deleteId.Length > 0)
            {
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.DeleteSucceed;
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
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


