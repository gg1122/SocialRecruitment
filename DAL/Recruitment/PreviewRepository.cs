using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.DAL
{
    /// <summary>
    /// 简历预览
    /// </summary>
    public partial class PreviewRepository
    {
        /// <summary>
        /// 获取简历预览信息
        /// </summary>
        /// <param name="db">数据访问</param>
        /// <param name="ResumeId">简历ID</param>
        public PreviewModel GetPreviewInfo(SysEntities db, string ResumeId)
        {
            PreviewModel model = new PreviewModel();

            model.account = (from c in db.Account
                             join o in db.Resume on c.Id equals o.AccountId
                             where o.Id == ResumeId
                             select c).FirstOrDefault();            
            model.degreeSchool = (from c in db.DegreeSchool                                 
                             where c.ResumeId == ResumeId
                             select c).ToList();
            model.fileUploader = (from c in db.FileUploader
                                  where c.ResumeId == ResumeId
                                  select c).FirstOrDefault();
            model.internshipExperience = (from c in db.InternshipExperience
                                          where c.ResumeId == ResumeId
                                  select c).ToList();
            model.iTAbility = (from c in db.ITAbility
                               where c.ResumeId == ResumeId
                                          select c).ToList();
            model.languageCompetence = (from c in db.LanguageCompetence
                                        where c.ResumeId == ResumeId
                               select c).ToList();
            model.projectExperience = (from c in db.ProjectExperience
                                       where c.ResumeId == ResumeId
                                        select c).ToList();
            model.resume = (from c in db.Resume
                            where c.Id == ResumeId
                                       select c).FirstOrDefault();
            return model;
        }
        /// <summary>
        /// 获取简历预览信息
        /// </summary>
        /// <param name="db">数据访问</param>
        /// <param name="ResumeId">人员ID</param>
        public PreviewModel GetPreviewInfo(SysEntities db, string AccountId)
        {
            PreviewModel model = new PreviewModel();

            model.account = (from c in db.Account
                             join o in db.Resume on c.Id equals o.AccountId
                             where o.Id == ResumeId
                             select c).FirstOrDefault();
            model.degreeSchool = (from c in db.DegreeSchool
                                  where c.ResumeId == ResumeId
                                  select c).ToList();
            model.fileUploader = (from c in db.FileUploader
                                  where c.ResumeId == ResumeId
                                  select c).FirstOrDefault();
            model.internshipExperience = (from c in db.InternshipExperience
                                          where c.ResumeId == ResumeId
                                          select c).ToList();
            model.iTAbility = (from c in db.ITAbility
                               where c.ResumeId == ResumeId
                               select c).ToList();
            model.languageCompetence = (from c in db.LanguageCompetence
                                        where c.ResumeId == ResumeId
                                        select c).ToList();
            model.projectExperience = (from c in db.ProjectExperience
                                       where c.ResumeId == ResumeId
                                       select c).ToList();
            model.resume = (from c in db.Resume
                            where c.Id == ResumeId
                            select c).FirstOrDefault();
            return model;
        }
    }
}
