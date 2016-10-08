using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Langben.App.Models
{

    public class LogonModel
    {
        [Required(ErrorMessage = "请填写手机号")]
        [DisplayName("手机号")]
        public string PersonName { get; set; }

        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [Required(ErrorMessage = "请填写密码")]
        [DataType(DataType.Password)]
        [DisplayName("密码")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "请填写验证码")]
        //[DisplayName("验证码")]
        //public string ValidateCode { get; set; }

        //[DisplayName("记住我?")]
        //public bool RememberMe { get; set; }
    }
   

}

