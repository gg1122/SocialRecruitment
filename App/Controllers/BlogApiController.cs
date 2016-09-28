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
    /// 博客
    /// </summary>
    public class BlogApiController : BaseApiController
    {
       
        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public Blog Get(string id)
        {
            Blog item = m_BLL.GetById(id);
            return item;
        }
 
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>        
        /// 
        [System.Web.Http.HttpPost]
        public Common.ClientResult.Result Post([FromBody]Blog entity)
        {           

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            { 
                entity.CreateTime = DateTime.Now;
                entity.CreatePerson = CurrentPerson;
                entity.State = "启用";
                entity.Id = Result.GetNewId();   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                                    
                    LogClassModels.WriteNotice("你成功的发布了博客<a href='/Blog/Details/" + entity.Id + "'>" + entity.Title + "</a>，<a  class='btn btn-default' href='/Publish/Edit/" + entity.Id + "'>修改</a>");//写入消息
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = entity.Id;
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，博客的信息，" + returnValue,"博客"
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

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Put([FromBody]Blog entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验
                string currentPerson = CurrentPerson;
                entity.UpdateTime = DateTime.Now;
                entity.UpdatePerson = currentPerson;
                if (currentPerson!=entity.CreatePerson)
                {
                    result.Code = Common.ClientCode.FindNull;
                    result.Message = Suggestion.UpdateFail + "你无权修改，请联系管理员";
                    return result; //         
                }
                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，博客信息的Id为" + entity.Id,"博客"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，博客信息的Id为" + entity.Id + "," + returnValue, "博客"
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
         

        IBLL.IBlogBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public BlogApiController()
            : this(new BlogBLL()) { }

        public BlogApiController(BlogBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}


