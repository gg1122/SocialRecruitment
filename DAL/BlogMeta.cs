using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(BlogMetadata))]//使用BlogMetadata对Blog进行数据验证
    public partial class Blog 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        #endregion

    }
    public partial class BlogMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "主键", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "名称", Order = 2)]
			[Required(ErrorMessage = "不能为空")]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Title { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "内容", Order = 3)]
			[Required(ErrorMessage = "不能为空")]
		
			public object Content { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "评论", Order = 4)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? CommentNumber { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "阅读", Order = 5)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? ReadNumber { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "图片3", Order = 6)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Picture3 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "图片2", Order = 7)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Picture2 { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "图片", Order = 8)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Picture { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 9)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 10)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 11)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 12)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑时间", Order = 13)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑人", Order = 14)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "时间戳", Order = 15)]
			public object Version { get; set; }


    }
}
 

