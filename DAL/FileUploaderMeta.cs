using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(FileUploaderMetadata))]//使用FileUploaderMetadata对FileUploader进行数据验证
    public partial class FileUploader 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "简历管理Id")]
        public string ResumeIdOld { get; set; }
        
        #endregion

    }
    public partial class FileUploaderMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "上传文件编号", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "简历管理Id", Order = 2)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object ResumeId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "上传照片地址", Order = 3)]
			[StringLength(400, ErrorMessage = "长度不可超过400")]
			public object PictureUrl { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "上传简历地址", Order = 4)]
			[StringLength(400, ErrorMessage = "长度不可超过400")]
			public object ResumeUrl { get; set; }

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


    }
}
 

