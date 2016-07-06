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
using System.Web;
namespace Langben.App.Controllers
{
    /// <summary>
    /// 上传文件
    /// </summary>
    public class FileUploaderController : BaseController
    {
        [HttpPost]
        public Common.ClientResult.Result HDpic()//头像上传
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            if (CurrentAccount != null && CurrentAccount.resume != null)
            {

                //byte[] FileByte = Request.BinaryRead(Request.TotalBytes);
                string upfile = Request.Form["name"]; //取得上传的对象名称
                HttpPostedFileBase pstFile = Request.Files["file"];
                UploadFiles upFiles = new UploadFiles();
                string newFileName = upFiles.fileSaveAs(pstFile, upfile);

                FileUploader entity = new FileUploader();
                entity.ResumeId = CurrentAccount.resume.Id;
                string currentPerson = this.CurrentPerson;
                entity.CreateTime = DateTime.Now;
                entity.CreatePerson = currentPerson;

                entity.Id = Result.GetNewId();

                entity.ResumeUrl = upfile;//应该增加一个ResumeName字段，存储简历的名称
                entity.PictureUrl = newFileName;
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，上传文件的信息的Id为" + entity.Id, "上传文件"
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，上传文件的信息，" + returnValue, "上传文件"
                        );//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }
            else
            {
                result.Code = Common.ClientCode.FindNull;
                result.Message = Suggestion.InsertFail + "，没有登陆"; //提示输入的数据的格式不对 
                return result;
            }
            
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
            if (CurrentAccount != null && CurrentAccount.resume != null)
            {
                List<FileUploader> list = m_BLL.GetByRefResumeId(CurrentAccount.resume.Id);
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
        IBLL.IFileUploaderBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public FileUploaderController()
            : this(new FileUploaderBLL()) { }

        public FileUploaderController(FileUploaderBLL bll)
        {
            m_BLL = bll;
        }
    }
}


