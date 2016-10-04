using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Langben.DAL;
using Langben.IBLL;
using Common;

namespace Langben.BLL
{
    public partial class AccountBLL : IAccountBLL
    {

        /// <summary>
        /// 验证用户名和密码是否正确
        /// </summary>
        /// <param name="phoneNumber">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功后的用户信息</returns>
        public DAL.Account ValidateUser(string phoneNumber, string password)
        {
            if (String.IsNullOrWhiteSpace(phoneNumber) || String.IsNullOrWhiteSpace(password))
                return null;
             password = EncryptAndDecrypte.EncryptString(password);
            //获取用户信息,请确定web.config中的连接字符串正确
            using (SysEntities db = new SysEntities())
            {               
                return  (from p in db.Account
                              where p.PhoneNumber == phoneNumber
                              && p.Password == password
                              && p.State == "启用"
                         select p).FirstOrDefault();               

            }         
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="personName">用户名</param>
        /// <param name="oldPassword">旧密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>修改密码是否成功</returns>
        public bool ChangePassword(string personName, string oldPassword, string newPassword)
        {
            if (!string.IsNullOrWhiteSpace(personName) && !string.IsNullOrWhiteSpace(oldPassword) && !string.IsNullOrWhiteSpace(newPassword))
            {
                try
                {
                    string oldPasswordEncryptString = EncryptAndDecrypte.EncryptString(oldPassword);
                    string newPasswordEncryptString = EncryptAndDecrypte.EncryptString(newPassword);

                    using (SysEntities db = new SysEntities())
                    {


                        return true;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionsHander.WriteExceptions(ex);
                }

            }
            return false;
        }
    }
}

