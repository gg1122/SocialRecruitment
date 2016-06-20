using Langben.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langben.BLL
{
    /// <summary>
    /// 字典表
    /// </summary>
    public partial class SysFieldBLL
    {
        /// <summary>
        /// 获取子类集
        /// </summary>
        /// <param name="id">子类MyColums</param>
        /// <param name="parentid">父类MyColums</param>
        /// <param name="value">父类MyTexts</param>
        /// <returns></returns>
        public List<SysField> GetSysFieldByParent(string id, string parentid, string value)
        {
            List<SysField> list = (from c in db.SysField
                                   join o in db.SysField on c.ParentId equals o.Id
                                   where c.MyColums == id && o.MyColums == parentid && o.MyTexts == value
                                   select c).ToList();
            return list;

        }
        /// <summary>
        /// 根据表名字段名获取集合
        /// </summary>
        /// <param name="table"></param>
        /// <param name="colum"></param>
        /// <returns></returns>
        public List<SysField> GetSysField(string table, string colum)
        {
            List<SysField> list = (from c in db.SysField
                                   where c.MyColums == colum && c.MyTables == table && c.State == StateEnums.QY
                                   select c).ToList();
            return list;

        }
        /// <summary>
        /// 根据表名获取集合
        /// </summary>
        /// <param name="table"></param>        
        /// <returns></returns>
        public List<SysField> GetSysField(string table)
        {
            List<SysField> list = (from c in db.SysField
                                   where c.MyTables == table && c.State == StateEnums.QY
                                   select c).ToList();
            return list;

        }
    }
}
