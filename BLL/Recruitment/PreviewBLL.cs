using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    /// <summary>
    /// 简历预览
    /// </summary>
    public class PreviewBLL : IBLL.IPreviewBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 会员的数据库访问对象
        /// </summary>
        PreviewRepository repository = new PreviewRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public PreviewBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 获取简历预览信息
        /// </summary>       
        /// <param name="ResumeId">简历ID</param>
        public PreviewModel GetPreviewInfo(string ResumeId)
        {
            try
            {
                PreviewModel model = repository.GetPreviewInfo(db, ResumeId);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 获取简历预览信息
        /// </summary>       
        /// <param name="accountId">用户ID</param>
        public PreviewModel GetPreviewInfoByAccountId(string accountId)
        {
            try
            {
                PreviewModel model = repository.GetPreviewInfoByAccountId(db, accountId);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public void Dispose()
        {

        }
    }
}
