using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    /// <summary>
    /// 预览实体
    /// </summary>
    public class PreviewModel
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public Langben.DAL.Account account { get; set; }
        /// <summary>
        /// 简历信息
        /// </summary>
        public Langben.DAL.Resume resume { get; set; }
        /// <summary>
        /// 学校学历
        /// </summary>
        public Langben.DAL.DegreeSchool degreeSchool { get; set; }
        /// <summary>
        /// 上传
        /// </summary>
        public Langben.DAL.FileUploader fileUploader { get; set; }
        /// <summary>
        /// 实习经验
        /// </summary>
        public Langben.DAL.InternshipExperience internshipExperience { get; set; }
        /// <summary>
        /// IT技能
        /// </summary>
        public Langben.DAL.ITAbility iTAbility { get; set; }
        /// <summary>
        /// 语言能力
        /// </summary>
        public Langben.DAL.LanguageCompetence languageCompetence { get; set; }
        /// <summary>
        /// 项目经验
        /// </summary>
        public Langben.DAL.ProjectExperience projectExperience { get; set; }

    }
}