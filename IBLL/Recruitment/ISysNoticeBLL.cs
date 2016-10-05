using System;
using System.Collections.Generic;
using System.Linq;

using Common;
using Langben.DAL;
using System.ServiceModel;

namespace Langben.IBLL
{
    /// <summary>
    /// 通知中心 接口
    /// </summary>
    public partial interface ISysNoticeBLL
    {
        List<SysNotice> GetByAccountId(string accountId);


    }
}

