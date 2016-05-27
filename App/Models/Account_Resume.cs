using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Langben.App.Models
{
    public class Account_Resume
    {
        /// <summary>
        /// 账户信息
        /// </summary>
        public Langben.DAL.Account account { get; set; }
        /// <summary>
        /// 简历信息
        /// </summary>
        public Langben.DAL.Resume resume { get; set; }
    }
}