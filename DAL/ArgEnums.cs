using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.DAL
{
    /// <summary>
    /// 查询参数枚举，查询参数例如：State+ArgEnums.DDL_String&开启^AccountID+ArgEnums.DDL_String&test
    /// </summary>
    public enum ArgEnums
        {
            /// <summary>
            /// 开始时间的标识
            /// </summary>            
            Start_Time = 0,
            /// <summary>
            /// 结束时间的标识
            /// </summary>
            End_Time = 1,
            /// <summary>
            /// 开始数值的标识
            /// </summary>
            Start_Int = 2,
            /// <summary>
            /// 结束数值的标识
            /// </summary>
            End_Int = 3,
            /// <summary>
            /// 精确字符串
            /// </summary>
            DDL_String = 4,
            /// <summary>
            /// 精确数字
            /// </summary>
            DDL_Int = 5,
    
    }
}
