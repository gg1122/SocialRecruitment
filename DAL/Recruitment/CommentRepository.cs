using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
namespace Langben.DAL
{
    /// <summary>
    /// 评论
    /// </summary>
    public partial class CommentRepository
    {


        /// <summary>
        /// 点击“彩”按钮，为彩加一，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        public int Cai(SysEntities db, string id, string myId)
        {

            Comment item = GetById(db, id);

            if (item != null && item.CreatePersonId != myId)
            {
                item.AgreeNumber++;
                return Save(db);
            }

            return 0;
        }

    }
}

