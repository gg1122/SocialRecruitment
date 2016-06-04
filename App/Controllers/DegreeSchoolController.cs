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
    /// 学历学校
    /// </summary>
    public class DegreeSchoolController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
            if(CurrentAccount.resume!=null)
            {
                List<DegreeSchool> list = m_BLL.GetByRefResumeId(CurrentAccount.resume.Id);
                return View(list);
            }
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
            DegreeSchool Model = m_BLL.GetById(id);
            return View(Model);

        }
        /// <summary>
        /// 根据Id获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetById(string id)
        {
            DegreeSchool Model = m_BLL.GetById(id);
            JavaScriptSerializer js = new JavaScriptSerializer();            
            string jsonStr = js.Serialize(Model);
            return jsonStr;
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
        /// 编辑保存
        /// </summary>
        /// <returns></returns>
        public Common.ClientResult.Result CreateSave()
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            try
            {
                if (Request["Model"] != null)

                {
                    string json = Request["Model"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Langben.DAL.DegreeSchool entity = js.Deserialize<Langben.DAL.DegreeSchool>(json);
                    if (entity != null && ModelState.IsValid)
                    {
                        if (string.IsNullOrEmpty(entity.Id) || entity.Id.Trim() == "")
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
                                LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，学历学校的信息的Id为" + entity.Id, "学历学校"
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
                                LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，学历学校的信息，" + returnValue, "学历学校"
                                    );//写入日志                      
                                result.Code = Common.ClientCode.Fail;
                                result.Message = Suggestion.InsertFail + returnValue;
                                return result; //提示插入失败
                            }
                        }
                    }
                }
                else
                {                   
                    result.Code = Common.ClientCode.FindNull;
                    result.Message = Suggestion.InsertFail + "，数据格式有误" ; //提示输入的数据的格式不对 
                    return result;
                }
            }
            catch (Exception ex)
            {

                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.InsertFail + "，"+ex.Message; //提示输入的数据的格式不对 
                return result;
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，数据格式有误"; //提示输入的数据的格式不对 
            return result;
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
        IBLL.IDegreeSchoolBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public DegreeSchoolController()
            : this(new DegreeSchoolBLL()) { }

        public DegreeSchoolController(DegreeSchoolBLL bll)
        {
            m_BLL = bll;
        }

    }
}


