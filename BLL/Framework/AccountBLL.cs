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
        /// 注册
        /// </summary>
        public Common.Account Register(string name, string phoneNumber, string password, string inviteCode, ref string message)
        {
            if (String.IsNullOrWhiteSpace(inviteCode))
                return null;

            //获取用户信息,请确定web.config中的连接字符串正确
            using (SysEntities db = new SysEntities())
            {

                var data = (from p in db.Invite
                            where p.Code == inviteCode
                             && p.State == StateEnums.QY
                            select p).FirstOrDefault();
                if (data != null)
                {
                    password = EncryptAndDecrypte.EncryptString(password);
                    var dataAccount = (from p in db.Account
                                       where p.PhoneNumber == phoneNumber
                                       || p.Name == name
                                       select p).FirstOrDefault();
                    if (dataAccount == null)
                    {
                        data.State = StateEnums.JY;
                        data.UpdatePerson = name;
                        data.UpdateTime = DateTime.Now;
                        Invite invite = new Invite()
                        {
                            Id = Common.Result.GetNewId(),
                            Code = data.Id.Substring(10, 5),
                            State = StateEnums.QY
                            ,
                            CreateTime = DateTime.Now,
                            CreatePerson = name
                        };
                        db.Invite.Add(invite);
                        Invite invite2 = new Invite()
                        {
                            Id = Common.Result.GetNewId(),
                            Code = data.Id.Substring(14, 5),
                            State = StateEnums.QY
        ,
                            CreateTime = DateTime.Now,
                            CreatePerson = name
                        };
                        db.Invite.Add(invite2);
                        var account = new DAL.Account()
                        {
                            Id = Common.Result.GetNewId(),
                            State = StateEnums.QY,
                            PhoneNumber = phoneNumber,
                            Name = name,
                            Password = password

                            ,
                            CreateTime = DateTime.Now,
                            CreatePerson = phoneNumber
                        };
                        db.Account.Add(account);
                        Resume resume = new Resume()
                        {
                            Id = Common.Result.GetNewId(),
                            AccountId = account.Id,
                            CreateTime = DateTime.Now,
                            CreatePerson = name,
                            Name = "默认",
                            Remark = "注册账号自动创建",
                            Sort = 0,
                            State = StateEnums.QY,
                            CompletionPercentage = 0
                        };
                        db.Resume.Add(resume);

                        SysNotice notice = new SysNotice();
                        notice.Id = Result.GetNewId();
                        notice.CreatePerson = name;
                        notice.CreateTime = DateTime.Now;
                        notice.AccountId = account.Id;
                        notice.Message = "您的邀请码为：" + invite.Code + "，另一个为：" + invite2.Code;
                        db.SysNotice.Add(notice);

                        db.SaveChanges();

                        Common.Account accountCommon = new Common.Account();
                        accountCommon.ResumeId = resume.Id;
                        accountCommon.Name = name;
                        accountCommon.Id = account.Id;
                        return accountCommon;

                    }
                    else
                    {
                        if (phoneNumber == dataAccount.PhoneNumber)
                        {
                            message = "手机号码已经存在";
                        }
                        else if (name == dataAccount.Name)
                        {
                            message = "绰号已经存在";
                        }
                    }
                }
                else
                {
                    message = "邀请码不正确";
                }

                return null;
            }
        }
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
                return (from p in db.Account
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

