using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Langben.IBLL
{
    [ServiceContract(Namespace = "www.langben.com")]
    public partial interface IPreviewBLL
    {
        /// <summary>
        /// 获取简历预览信息
        /// </summary>
        /// <param name="db">数据访问</param>
        /// <param name="ResumeId">简历ID</param>        
        [OperationContract]
        PreviewModel GetPreviewInfo(string ResumeId);
        /// <summary>
        /// 获取简历预览信息
        /// </summary>
        /// <param name="db">数据访问</param>
        /// <param name="accountId">用户ID</param>        
        [OperationContract]
        PreviewModel GetPreviewInfoByAccountId(string accountId);
    }  
}
