using System;
using System.Collections.Generic;
using System.Linq;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 博客 
    /// </summary>
    public partial class BlogBLL : IBLL.IBlogBLL, IDisposable
    {

        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<Blog> GetByPage(int page)
        {
            using (SysEntities db = new DAL.SysEntities())
            {
                var queryData = db.Blog.Where(w => w.State == StateEnums.QY);
                if (page <= 1)
                {
                    queryData = queryData.OrderBy(c => c.CreateTime).Take(15);
                }
                else
                {
                    queryData = queryData.OrderBy(c => c.CreateTime).Skip((page - 1) * 15).Take(15);
                }


                return queryData.ToList();
            }


        }

    }
}

