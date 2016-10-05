using System.Web.Http;

using System.Web;

namespace Models
{
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// 获取当前登陆人的ID
        /// </summary>
        /// <returns></returns>
        public string CurrentPersonId
        {
            get
            {
                var account = AccountModel.GetCurrentAccount();              
                if (account != null && !string.IsNullOrWhiteSpace(account.Id))
                {  return account.Id;
                  
                }
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取当前登陆人的名称
        /// </summary>
        /// <returns></returns>
        public string CurrentPerson
        {
            get
            {
                var account = AccountModel.GetCurrentAccount();
                if (account != null && !string.IsNullOrWhiteSpace(account.Name))
                {
                    return account.Name;

                }
                return string.Empty;                
            }
        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        public Langben.App.Models.Account_Resume CurrentAccount
        {
            get
            {
                Langben.App.Models.Account_Resume currentAccount = null;

                if (HttpContext.Current.Session["account"] != null)
                {
                    currentAccount = HttpContext.Current.Session["account"] as Langben.App.Models.Account_Resume;
                }
                else
                {
                    HttpContext.Current.Session.Clear();
                 
                }

                return currentAccount;
            }
            set
            {
                HttpContext.Current.Session["account"] = value;
            }

        }

        
        public class GetDataParam
        {
            public string sort { get; set; }
            public string order { get; set; }
            public int page { get; set; }
            public int rows { get; set; }
            public string id { get; set; }
            public string search { get; set; }
        }
      
    }
}
