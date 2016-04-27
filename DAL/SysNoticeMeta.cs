using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(SysNoticeMetadata))]//使用SysNoticeMetadata对SysNotice进行数据验证
    public partial class SysNotice 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class SysNoticeMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "会员编号", Order = 2)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object AccountId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "内容", Order = 3)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Message { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "失效时间", Order = 4)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? LostTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 5)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 6)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 8)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑时间", Order = 10)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑人", Order = 11)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "时间戳", Order = 12)]
			public object Version { get; set; }


    }
}
 

