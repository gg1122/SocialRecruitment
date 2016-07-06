using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.DAL
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
       }

}
