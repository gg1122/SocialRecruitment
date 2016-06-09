using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 评论 接口
    /// </summary>
   
    public partial interface ICommentBLL
    {
        /// <summary>
        /// 点击“彩”按钮，为彩加一，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        bool Cai(ref Common.ValidationErrors validationErrors, string id);
        
 
    }
}

