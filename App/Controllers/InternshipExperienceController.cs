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
using System.Web.Script.Serialization;

namespace Langben.App.Controllers
{
    /// <summary>
    /// 实习经验
    /// </summary>
    public class InternshipExperienceController : BaseController
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
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public string GetList()
        {
            if (CurrentAccount.resume != null)
            {
                List<InternshipExperience> list = m_BLL.GetByRefResumeId(CurrentAccount.resume.Id);
                return JsonObj.ObjToJson(list);

            }
            return null;
        }
        /// <summary>
        /// 创建保存
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateSave()
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            try
            {
                if (Request["Model"] != null)
                {
                    string json = Request["Model"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Langben.DAL.InternshipExperience entity = js.Deserialize<Langben.DAL.InternshipExperience>(json);
                    if (entity != null && ModelState.IsValid)
                    {

                        if (CurrentAccount != null)
                        {
                            entity.ResumeId = CurrentAccount.resume.Id;
                        }
                        entity.Id = Result.GetNewId();
                        entity.CreateTime = DateTime.Now;
                        entity.CreatePerson = CurrentPerson;
                        entity.State = StateEnums.QY;
                        entity.Sort = 0;
                        entity.UpdatePerson = CurrentPerson;
                        entity.UpdateTime = entity.CreateTime;

                        string returnValue = string.Empty;
                        if (m_BLL.Create(ref validationErrors, entity))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，实习经验的信息的Id为" + entity.Id, "实习经验"
                                );//写入日志 
                            result.Code = Common.ClientCode.Succeed;
                            result.Message = Suggestion.InsertSucceed;
                            // return result; //提示创建成功
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
                            LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，实习经验的信息，" + returnValue, "实习经验"
                                );//写入日志                      
                            result.Code = Common.ClientCode.Fail;
                            result.Message = Suggestion.InsertFail + returnValue;
                            // return result; //提示插入失败
                        }
                    }
                    else
                    {
                        result.Code = Common.ClientCode.FindNull;
                        result.Message = Suggestion.InsertFail + "，数据格式有误"; //提示输入的数据的格式不对 
                                                                            //return result;
                    }
                }
                else
                {
                    result.Code = Common.ClientCode.FindNull;
                    result.Message = Suggestion.InsertFail + "，数据格式有误"; //提示输入的数据的格式不对 
                    //return result;
                }
            }
            catch (Exception ex)
            {

                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.InsertFail + "，" + ex.Message; //提示输入的数据的格式不对 
                                                                           //return result;
            }
            return Json(result);
            //return result;
        }

        /// <summary>
        /// 编辑保存
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSave()
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            try
            {
                if (Request["Model"] != null)
                {
                    string json = Request["Model"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Langben.DAL.InternshipExperience entity = js.Deserialize<Langben.DAL.InternshipExperience>(json);
                    if (entity != null && ModelState.IsValid)
                    {   //数据校验

                        entity.UpdateTime = DateTime.Now;
                        entity.UpdatePerson = CurrentPerson;

                        string returnValue = string.Empty;
                        if (m_BLL.Edit(ref validationErrors, entity))
                        {
                            LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，实习经验信息的Id为" + entity.Id, "实习经验"
                                );//写入日志                   
                            result.Code = Common.ClientCode.Succeed;
                            result.Message = Suggestion.UpdateSucceed;
                            //return result; //提示更新成功 
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
                            LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，实习经验信息的Id为" + entity.Id + "," + returnValue, "实习经验");//写入日志   
                            result.Code = Common.ClientCode.Fail;
                            result.Message = Suggestion.UpdateFail + returnValue;
                            //return result; //提示更新失败
                        }
                    }
                    else
                    {
                        result.Code = Common.ClientCode.FindNull;
                        result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
                        //return result; //提示输入的数据的格式不对   
                    }
                }
                else
                {
                    result.Code = Common.ClientCode.FindNull;
                    result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
                    //return result; //提示输入的数据的格式不对   
                }
            }
            catch (Exception ex)
            {
                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.UpdateFail + ex.Message;
                //return result; //提示输入的数据的格式不对  
            }
            return Json(result);
        }
        /// <summary>
        /// 删除保存
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            string returnValue = string.Empty;
            //string[] deleteId = query.GetString().Split(',');
            if (Request["ID"] != null)
            {
                string deleteId = Request["ID"].ToString().Trim();
                if (m_BLL.Delete(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，实习经验信息的Id为" + string.Join(",", deleteId), "消息"
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，实习经验好信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return Json(result);
        }
        /// <summary>
        /// 根据Id获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetById(string id)
        {
            InternshipExperience Model = m_BLL.GetById(id);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonStr = js.Serialize(Model);
            return jsonStr;
        }
        IBLL.IInternshipExperienceBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public InternshipExperienceController()
            : this(new InternshipExperienceBLL()) { }

        public InternshipExperienceController(InternshipExperienceBLL bll)
        {
            m_BLL = bll;
        }

    }
}




