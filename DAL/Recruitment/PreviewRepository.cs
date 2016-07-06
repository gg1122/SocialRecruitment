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


            return (from r in db.Resume.Include("DegreeSchool")
                               .Include("LanguageCompetence")
                               .Include("ITAbility")
                               .Include("ProjectExperience")
                               .Include("InternshipExperience")


                    join a in db.Account on r.AccountId equals a.Id
                    where r.Id == ResumeId
                    select new PreviewModel() { account = a, resume = r }).FirstOrDefault();

        }
        /// <summary>
        /// 获取简历预览信息
        /// </summary>
        /// <param name="db">数据访问</param>
        /// <param name="accountId">人员ID</param>
        public PreviewModel GetPreviewInfoByAccountId(SysEntities db, string accountId)
        {
            return (from r in db.Resume.Include("DegreeSchool")
                   .Include("LanguageCompetence")
                   .Include("ITAbility")
                   .Include("ProjectExperience")
                   .Include("InternshipExperience")


                    join a in db.Account on r.AccountId equals a.Id
                    where r.AccountId == accountId
                    select new PreviewModel() { account = a, resume = r }).FirstOrDefault();


        }
    }
}
