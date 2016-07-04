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


