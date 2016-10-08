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
             
                string upfile = Request.Form["name"]; //取得上传的对象名称
                HttpPostedFileBase pstFile = Request.Files["file"];
                UploadFiles upFiles = new UploadFiles();
                string newFileName = upFiles.fileSaveAs(pstFile, upfile);

                FileUploader entity = new FileUploader();
                entity.ResumeId = CurrentResumeId;
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

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        { 
                List<FileUploader> list = m_BLL.GetByRefResumeId(CurrentResumeId);
                return View(list);
            
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


