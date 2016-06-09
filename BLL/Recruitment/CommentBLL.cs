using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 评论 
    /// </summary>
    public partial class CommentBLL 
    {
        /// <summary>
        /// 点击“彩”按钮，为彩加一，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        public bool Cai(ref ValidationErrors validationErrors, string id)
        {
            return (repository.Cai(db, id)==1);
        }
   

 
    }
}

