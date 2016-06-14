using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Common
{
    public class JsonObj
    {
        /// <summary>
        /// 对象转换成json字符床
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <returns></returns>
        public static string ObjToJson(object obj)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(obj, jsSettings);
        }
    }
}
