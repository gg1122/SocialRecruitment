using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Langben.DAL
{
    [MetadataType(typeof(InternshipExperienceMetadata))]//使用InternshipExperienceMetadata对InternshipExperience进行数据验证
    public partial class InternshipExperience 
    {
      
        #region 自定义属性，即由数据实体扩展的实体
        
        [Display(Name = "简历管理Id")]
        public string ResumeIdOld { get; set; }
        
        #endregion

    }
    public partial class InternshipExperienceMetadata
    {
			[ScaffoldColumn(false)]
			[Display(Name = "实习经验编号", Order = 1)]
			public object Id { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "简历管理Id", Order = 2)]
			[StringLength(36, ErrorMessage = "长度不可超过36")]
			public object ResumeId { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "开始日期", Order = 3)]
			[Required(ErrorMessage = "不能为空")]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? BeginDate { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结束日期", Order = 4)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]

			public DateTime? EndDate { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "结束日期是否至今", Order = 5)]
			[StringLength(1, ErrorMessage = "长度不可超过1")]
			public object IsNow { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "工作单位", Order = 6)]
			[Required(ErrorMessage = "不能为空")]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CompanyName { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "公司性质", Order = 7)]
			[Required(ErrorMessage = "不能为空")]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CompanyNature { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "公司规模", Order = 8)]
			[Required(ErrorMessage = "不能为空")]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CompanyScale { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "职务", Order = 9)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object Job { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "工作类别", Order = 10)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object JobType { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "工作职责", Order = 11)]
			[StringLength(4000, ErrorMessage = "长度不可超过4000")]
			public object JobDescription { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "排序", Order = 12)]
			[Range(0,2147483646, ErrorMessage="数值超出范围")]
			public int? Sort { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "状态", Order = 13)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object State { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建时间", Order = 14)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? CreateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "创建人", Order = 15)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object CreatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑时间", Order = 16)]
			[DataType(System.ComponentModel.DataAnnotations.DataType.DateTime,ErrorMessage="时间格式不正确")]
			public DateTime? UpdateTime { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "编辑人", Order = 17)]
			[StringLength(200, ErrorMessage = "长度不可超过200")]
			public object UpdatePerson { get; set; }

			[ScaffoldColumn(true)]
			[Display(Name = "时间戳", Order = 18)]
			public object Version { get; set; }


    }
}
 

