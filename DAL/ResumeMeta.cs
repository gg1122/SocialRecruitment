using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(ResumeMetadata))]//使用ResumeMetadata对Resume进行数据验证
    public partial class Resume 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class ResumeMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "简历ID", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "会员ID", Order = 2)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object AccountId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "简历名称", Order = 3)]
			[StringLength(50, ErrorMessage = "长度不可超过50")]
			public object Name { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "备注", Order = 4)]
			[StringLength(400, ErrorMessage = "长度不可超过400")]
			public object Remark { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 5)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 7)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑时间", Order = 9)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑人", Order = 10)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "时间戳", Order = 11)]
			public object Version { get; set; }

            [ScaffoldColumn(true)]
            [Display(Name = "完整度", Order = 12)]
            [Range(0, 2147483646, ErrorMessage = "数值超出范围")]
            public int? CompletionPercentage { get; set; }


    }
}
 

