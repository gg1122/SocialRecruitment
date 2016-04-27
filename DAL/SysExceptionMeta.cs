using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(SysExceptionMetadata))]//使用SysExceptionMetadata对SysException进行数据验证
    public partial class SysException 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class SysExceptionMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "类型", Order = 2)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object LeiXing { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "内容", Order = 3)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object Message { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结果", Order = 4)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Result { get; set; }

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
 

