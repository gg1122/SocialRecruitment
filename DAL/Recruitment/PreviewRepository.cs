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

            model.resume = (from r in db.Resume.Include("DegreeSchool")
                            .Include("LanguageCompetence")
                            .Include("ITAbility")
                            .Include("ProjectExperience")
                            .Include("InternshipExperience")


                            where r.Id == ResumeId
                            select r).FirstOrDefault();
            return model;
        }
        /// <summary>
        /// 获取简历预览信息
        /// </summary>
        /// <param name="db">数据访问</param>
        /// <param name="accountId">人员ID</param>
        public PreviewModel GetPreviewInfoByAccountId(SysEntities db, string accountId)
        {
            PreviewModel model = new PreviewModel();

            model.account = (from c in db.Account
                             where c.Id == accountId
                             select c).FirstOrDefault();

            model.resume = (from r in db.Resume.Include("DegreeSchool")
                            .Include("LanguageCompetence")
                            .Include("ITAbility")
                            .Include("ProjectExperience")
                            .Include("InternshipExperience")

                            where r.AccountId == accountId
                            select r).FirstOrDefault();

            return model;
        }
    }
}
