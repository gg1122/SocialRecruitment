using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Langben.DAL;
using Common;

namespace Langben.BLL
{
    /// <summary>
    /// 会员 
    /// </summary>
    public partial class AccountBLL :  IBLL.IAccountBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected SysEntities db;
        /// <summary>
        /// 会员的数据库访问对象
        /// </summary>
        AccountRepository repository = new AccountRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public AccountBLL()
        {
            db = new SysEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public AccountBLL(SysEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<DAL.Account> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {            
            IQueryable<DAL.Account> queryData = repository.GetData(db, order, sort, search);
            total = queryData.Count();
            if (total > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rows);
                }
                else
                {
                    queryData = queryData.Skip((page - 1) * rows).Take(rows);
                }
                 
            }
            return queryData.ToList();
        }
        /// <summary>
        /// 查询的数据 /*在6.0版本中 新增*/
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<DAL.Account> GetByParam(string id, string order, string sort, string search)
        {
            IQueryable<DAL.Account> queryData = repository.GetData(db, order, sort, search);
            
            return queryData.ToList();
        }
        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// <param name="arg">查询条件</param>
        /// <returns></returns>
        public DAL.Account GetByParam(DAL.AccountArg arg)
        {
            DAL.Account result = new DAL.Account();
            if (arg != null)
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(arg.Id) && arg.Id.Trim() != "")
                {                   
                    sb.AppendFormat("Id{0}&{1}^", ArgEnums.DDL_String,arg.Id);
                }
                if (!string.IsNullOrEmpty(arg.Name) && arg.Name.Trim() != "")
                {                   
                    sb.AppendFormat("Name{0}&{1}^", ArgEnums.DDL_String, arg.Name.ToLower());
                }
                if (!string.IsNullOrEmpty(arg.Email) && arg.Email.Trim() != "")
                {                   
                    sb.AppendFormat("Email{0}&{1}^", ArgEnums.DDL_String, arg.Email.ToLower());
                }
                if (!string.IsNullOrEmpty(arg.MyName) && arg.MyName.Trim() != "")
                {                   
                    sb.AppendFormat("MyName{0}&{1}^", ArgEnums.DDL_String, arg.MyName.ToLower());
                }
                if (!string.IsNullOrEmpty(arg.PhoneNumber) && arg.PhoneNumber.Trim() != "")
                {                   
                    sb.AppendFormat("PhoneNumber{0}&{1}^", ArgEnums.DDL_String, arg.PhoneNumber.ToLower());
                }
                if (sb.ToString().Trim() != "")
                {
                    sb = sb.Remove(sb.ToString().Length - 1, 1);
                    List<DAL.Account> list = repository.GetData(db, "desc", "CreateTime", sb.ToString()).ToList();
                    if (list == null || list.Count == 0)
                    {
                        result = null;
                    }
                    else
                    {
                        result = list[0];
                    }

                }
                else
                {
                    result = null;
                }


            }
            else
            {
                result = null;
            }
            return result;
        }
        /// <summary>
        /// 验证数据是否存在
        /// </summary>
        /// <param name="arg">查询条件</param>
        /// <param name="err">返回提示信息</param>
        /// <param name="result">存在返回对象</param>
        /// <returns></returns>
        public bool IsExist(DAL.AccountArg arg, ref string err,ref DAL.Account result)
        {
            //DAL.Account result = new DAL.Account();
            if (arg != null)
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(arg.Id) && arg.Id.Trim() != "")
                {
                    sb.AppendFormat("Id{0}&{1}^", ArgEnums.DDL_String, arg.Id);
                }
                if (!string.IsNullOrEmpty(arg.Name) && arg.Name.Trim() != "")
                {
                    sb.AppendFormat("Name{0}&{1}^", ArgEnums.DDL_String, arg.Name.ToLower());
                }
                if (!string.IsNullOrEmpty(arg.Email) && arg.Email.Trim() != "")
                {
                    sb.AppendFormat("Email{0}&{1}^", ArgEnums.DDL_String, arg.Email.ToLower());
                }
                if (!string.IsNullOrEmpty(arg.MyName) && arg.MyName.Trim() != "")
                {
                    sb.AppendFormat("MyName{0}&{1}^", ArgEnums.DDL_String, arg.MyName.ToLower());
                }
                if (!string.IsNullOrEmpty(arg.PhoneNumber) && arg.PhoneNumber.Trim() != "")
                {
                    sb.AppendFormat("PhoneNumber{0}&{1}^", ArgEnums.DDL_String, arg.PhoneNumber.ToLower());
                }
                if (sb.ToString().Trim() != "")
                {
                    sb = sb.Remove(sb.ToString().Length - 1, 1);                    
                    List<DAL.Account> list = repository.GetData(db, "desc", "CreateTime", sb.ToString(),"or").ToList();
                    if (list == null || list.Count == 0)
                    {
                        result = null;
                    }
                    else
                    {
                        result = list[0];
                    }

                }
                else
                {
                    result = null;
                }


            }
            else
            {
                result = null;
            }
            if (result == null)
            {
                return false;
            }
            else
            {
                if (result.Name == arg.Name)
                {
                    err = "绰号已存在！";
                }
                else if (result.PhoneNumber == arg.PhoneNumber)
                {
                    err = "手机已存在！";
                }
                return true;
            }
        }
        /// <summary>
        /// 创建一个会员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个会员</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, DAL.Account entity)
        {
            try
            {
                AccountArg arg = new AccountArg();
                arg.Name = entity.Name;
                arg.PhoneNumber = entity.PhoneNumber;
                string err = string.Empty;
                DAL.Account model = null;                
                if (!IsExist(arg, ref err,ref model))
                {
                    entity.State = StateEnums.QY;
                    entity.CreateTime = DateTime.Now;
                    entity.UpdateTime = entity.CreateTime;
                    repository.Create(entity);
                    return true;
                }
                else
                {
                    validationErrors.Add(err);
                    return false;
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);
            }
            return false;
        }
        /// <summary>
        ///  创建会员集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">会员集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<DAL.Account> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Create(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Create(db, entitys);
                            if (count == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }                          
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除一个会员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一会员的主键</param>
        /// <returns></returns>  
        public bool Delete(ref ValidationErrors validationErrors, string id)
        {
            try
            {
                return repository.Delete(id) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除会员集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">会员的集合</param>
        /// <returns></returns>    
        public bool DeleteCollection(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                { 
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Delete(db, deleteCollection);
                            if (deleteCollection.Length == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }
                        }
                    }
             
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建会员集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">会员集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<DAL.Account> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int count = entitys.Count();
                    if (count == 1)
                    {
                        return this.Edit(ref validationErrors, entitys.FirstOrDefault());
                    }
                    else if (count > 1)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        { 
                            repository.Edit(db, entitys);
                            if (count == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
         /// <summary>
        /// 编辑一个会员
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个会员</param>
        /// <returns></returns>
        public bool Edit(ref ValidationErrors validationErrors, DAL.Account entity)
        {
            try
            { 
                repository.Edit(db, entity);
                repository.Save(db);
                return true;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
      
        public List<DAL.Account> GetAll()
        {           
            return repository.GetAll(db).ToList();          
        }   
        
        /// <summary>
        /// 根据主键获取一个会员
        /// </summary>
        /// <param name="id">会员的主键</param>
        /// <returns>一个会员</returns>
        public DAL.Account GetById(string id)
        {           
            return repository.GetById(db, id);           
        }


        public void Dispose()
        {
           
        }
    }
}

