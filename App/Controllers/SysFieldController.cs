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
    /// 数据字典
    /// </summary>
    public class SysFieldController : BaseController
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
        /// 获取子类集
        /// </summary>
        /// <param name="id">子类MyColums</param>
        /// <param name="parentid">父类MyColums</param>
        /// <param name="value">父类MyTexts</param>
        /// <returns></returns>
        public string GetSysFieldByParent(string id, string parentid, string value)
        {
            //List<SysField> list = (from c in db.SysField
            //                       join o in db.SysField on c.ParentId equals o.Id
            //                       where c.MyColums == id && o.MyColums == parentid && o.MyTexts == value
            //                       select c).ToList();
            List<SysField> list = m_BLL.GetSysFieldByParent(id, parentid, value);
            string strJson = string.Empty;
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            strJson = serialize.Serialize(list);
            return strJson;

        }
        /// <summary>
        /// 根据表名字段名获取集合
        /// </summary>
        /// <param name="table"></param>
        /// <param name="colum"></param>
        /// <returns></returns>
        public string GetSysField(string table, string colum)
        {
            //List<SysField> list = (from c in db.SysField                                  
            //                       where c.MyColums == colum && c.MyTables == table && c.State==StateEnums.QY
            //                       select c).ToList();
            List<SysField> list =  m_BLL.GetSysField(table, colum);
            string strJson = string.Empty;
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            strJson = serialize.Serialize(list);
            return strJson;

        }
        IBLL.ISysFieldBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public SysFieldController()
            : this(new SysFieldBLL()) { }

        public SysFieldController(SysFieldBLL bll)
        {
            m_BLL = bll;
        }

    }
}


