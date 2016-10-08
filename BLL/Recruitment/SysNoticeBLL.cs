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
    /// 通知中心 
    /// </summary>
    public partial class SysNoticeBLL :  IBLL.ISysNoticeBLL, IDisposable
    {
        public List<SysNotice> GetByAccountId(string accountId)
        {
            using (SysEntities db = new SysEntities())
            {
                return db.SysNotice.Where(w => w.AccountId == accountId).OrderByDescending(o => o.CreateTime).ToList();
            }
        }

    }
}

