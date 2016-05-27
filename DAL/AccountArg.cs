using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.DAL
{
    /// <summary>
    /// 账户查询参数
    /// </summary>
    [Serializable]
    public partial class AccountArg
    {
        public AccountArg()
        { }
        #region Model
        private string _id;
        private string _name;
        private string _myname;
        private string _phonenumber;
        private string _email;
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string MyName
        {
            set { _myname = value; }
            get { return _myname; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNumber
        {
            set { _phonenumber = value; }
            get { return _phonenumber; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }


        #endregion Model

    }
}
