using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 博客 接口
    /// </summary>
 
    public partial interface IBlogBLL
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns>结果集</returns>
        [OperationContract]
        List<Blog> GetByPage( int page);
        
    }
}

