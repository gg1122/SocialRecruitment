using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Common
{
    /// <summary>
    /// 登录的用户信息
    /// </summary>
    [DataContract]
    [Serializable]
    public class Account
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public string Id { get; set; }
        /// <summary>
        /// 绰号
        /// </summary>
        [DataMember]
        public string Name { get; set; }
        /// <summary>
        /// 默认简历主键
        /// </summary>
        [DataMember]
        public string ResumeId { get; set; }
    }
}
