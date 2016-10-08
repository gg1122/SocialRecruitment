using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(AccountMetadata))]//使用AccountMetadata对Account进行数据验证
    public partial class Account 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class AccountMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "绰号", Order = 2)]
			[Required(ErrorMessage = "不能为空")]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "密码", Order = 3)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
			public object Password { get; set; }
        [Required(ErrorMessage = "不能为空")]
        [ScaffoldColumn(true)]
			[Display(Name = "手机号码", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
        [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        public object PhoneNumber { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邀请码", Order = 5)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object InviteCode { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邀请码使用者", Order = 6)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object InviteCodeUser { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邀请码使用时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? InviteCodeDatetime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邀请码2", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object InviteCode2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邀请码使用者2", Order = 9)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object InviteCode2User { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "邀请码2使用时间", Order = 10)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? InviteCode2Datetime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "IP地址", Order = 11)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LogonIP { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "姓名", Order = 12)]
			[StringLength(50, ErrorMessage = "长度不可超过50")]
			public object MyName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "性别", Order = 13)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Sex { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "出生日期", Order = 14)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? Birthday { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "户口所在地省", Order = 15)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object AnmeldenProvince { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "户口所在地市", Order = 16)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object AnmeldenCity { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "现在所在地省", Order = 17)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LiveProvince { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "现在所在地市", Order = 18)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LiveCity { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "个人评价", Order = 19)]
			[StringLength(400, ErrorMessage = "长度不可超过400")]
			public object PersonalAssessment { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "邮箱格式不正确")]
        [ScaffoldColumn(true)]
			[Display(Name = "电子邮件", Order = 20)]
         
        [StringLength(400, ErrorMessage = "长度不可超过400")]
			public object Email { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 21)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 22)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 23)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 24)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑时间", Order = 25)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑人", Order = 26)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "时间戳", Order = 27)]
			public object Version { get; set; }


    }
}
 

