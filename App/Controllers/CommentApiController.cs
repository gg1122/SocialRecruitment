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
    /// 评论
    /// </summary>
    public class CommentApiController : BaseApiController
    {

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post([FromBody]Comment entity)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = this.CurrentPerson;
                if (string.IsNullOrWhiteSpace(currentPerson))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "请登录";
                    return result; //提示插入失败
                }
                entity.CreateTime = DateTime.Now;
                entity.CreatePerson = currentPerson;
                entity.CreatePersonId = this.CurrentPersonId;
                entity.AgreeNumber = 0;

                entity.Id = Result.GetNewId();
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteNotice("你成功的码了一层砖<a href='/Blog/Details/" + entity.BlogId + "'>" + entity.Content + "</a>");//写入消息

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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，评论的信息，" + returnValue, "评论"
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
        /// 彩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Common.ClientResult.Result Put([FromBody]Comment entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            if (entity != null && ModelState.IsValid)
            {   //数据校验
                string currentPersonId = this.CurrentPersonId;
                if (string.IsNullOrWhiteSpace(currentPersonId))
                {
                    result.Code = Common.ClientCode.Fail;
                    result.Message = "请登录";
                    return result; //提示插入失败
                }
                string id = entity.Id;
                string returnValue = string.Empty;
                if (m_BLL.Cai(ref validationErrors, id, currentPersonId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，彩" + id, "评论"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，彩" + id + "," + returnValue, "评论"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }



        IBLL.ICommentBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public CommentApiController()
            : this(new CommentBLL()) { }

        public CommentApiController(CommentBLL bll)
        {
            m_BLL = bll;
        }

    }
}


